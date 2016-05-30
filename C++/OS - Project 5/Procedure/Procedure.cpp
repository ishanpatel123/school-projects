// producer-consumer using message passing synchronization - main module
// adapted from https://msdn.microsoft.com/en-us/library/windows/desktop/ms682499(v=vs.85).aspx
//
#include <windows.h> 
#include <iostream>
#include <sstream>
#include <map>

using namespace std;

#include "create_consumer_process.h"
#include "producer_pipe_io.h"
#include "format_error_message.h"

int main(int argc, char *argv[], char **env)
{
	if (argc < 2) {
		cerr << "?? must specify at least one argument - name of file to pass to child process" << endl;
		exit(1);
	}

	cout << endl << "Start of parent execution" << endl;
	int programStatus{ 0 };           // denotes success
	HANDLE hchild_stdout_read{ NULL }, hchild_stdout_write{ NULL };
	HANDLE hchild_stdin_read{ NULL }, hchild_stdin_write{ NULL };
	HANDLE hInputFile{ NULL };
	
	//initialize two new handles for second pair of pipes
	HANDLE hchild_messageout_read{ NULL }, hchild_messageout_write{ NULL };
	HANDLE hchild_messagein_read{ NULL }, hchild_messagein_write{ NULL };

	try {

		// Get a handle to an existing input file for use by the parent.
		// For details, see  https://msdn.microsoft.com/en-us/library/windows/desktop/aa363858%28v=vs.85%29.aspx
		// This example assumes a plain text file and uses string output to verify data flow. 
		//
		hInputFile = CreateFile(
			argv[1],                     // file name
			GENERIC_READ,                // desired access:  read and/or write
			0,                           // sharing mode - 0 means request exclusive access
			NULL,                        // security attributes - typically concerned with child processes inheriting handles
			OPEN_EXISTING,               // action to take based on file's existence or nonexistence
			FILE_ATTRIBUTE_READONLY,     // a far more specific access specification than parameter 2
			NULL);                       // a "template file" for characterizing file creation, if requested

		if (hInputFile == INVALID_HANDLE_VALUE) throw pair<string, string>("main: CreateFile", formatErrorMessage());

		// define security attributes parameters for child-process-inherited handles
		//   1st parameter must be as shown.
		//   2nd parameter - child process inherits parent process security attributes
		//   3rd parameter - child process inherits parent process's handles   
		// 
		SECURITY_ATTRIBUTES securityAttributes{ sizeof(SECURITY_ATTRIBUTES), NULL, TRUE };

		// Create a one-way anonymous pipe for passing data from child to parent
		// Prevent the child process from reading from this pipe.
		//
		if (!CreatePipe(&hchild_stdout_read, &hchild_stdout_write, &securityAttributes, 0))  throw pair<string, string>("main: CreatePipe (STDOUT)", formatErrorMessage());
		if (!SetHandleInformation(hchild_stdout_read, HANDLE_FLAG_INHERIT, 0))        throw pair<string, string>("main: SetHandleInformation (STDOUT)", formatErrorMessage());

		// Create a one-way anonymous pipe for passing data from parent to child.
		// Prevent the child process from writing to this pipe.
		//
		if (!CreatePipe(&hchild_stdin_read, &hchild_stdin_write, &securityAttributes, 0))    throw pair<string, string>("main: CreatePipe (STDIN)", formatErrorMessage());
		if (!SetHandleInformation(hchild_stdin_write, HANDLE_FLAG_INHERIT, 0))        throw pair<string, string>("main: SetHandleInformation (STDIN)", formatErrorMessage());

		// start the child
		//
		CreateChildConsumerProcess(hchild_stdin_read, hchild_stdout_write);


		//creating new pipe to send message from child to parent
		if (!CreatePipe(&hchild_messageout_read, &hchild_messageout_write, &securityAttributes, 0))  throw pair<string, string>("main: CreatePipe (STDOUT)", formatErrorMessage());
		if (!SetHandleInformation(hchild_messageout_read, HANDLE_FLAG_INHERIT, 0))        throw pair<string, string>("main: SetHandleInformation (STDOUT)", formatErrorMessage());

		//convert handle to dword
		DWORD h_to_parent_as_dw{ reinterpret_cast<DWORD>(hchild_messagein_write) };
		//convert dword to const char * to string
		std::stringstream stream;
		stream << h_to_parent_as_dw;
		std::string args = stream.str();
		const char * foo1 = args.c_str();
		char * arg1 = _strdup(foo1);
		//creating one way new pipe to send message from parent to child
		if (!CreatePipe(&hchild_messagein_read, &hchild_messagein_write, &securityAttributes, 0))    throw pair<string, string>("main: CreatePipe (STDIN)", formatErrorMessage());
		if (!SetHandleInformation(hchild_messagein_write, HANDLE_FLAG_INHERIT, 0))        throw pair<string, string>("main: SetHandleInformation (STDIN)", formatErrorMessage());
		//convert handle to dword
		DWORD h_from_parent_as_dw{ reinterpret_cast<DWORD>(hchild_messageout_read) };
		//convert dword to const char * to string
		std::stringstream stream1;
		stream1 << h_from_parent_as_dw;
		std::string args1 = stream1.str();
		const char * foo2 = args1.c_str();
		char * arg2 = _strdup(foo2);

		

		// Write to the pipe that is the standard input for a child process. 
		// Data is written to the pipe's buffers, so it is not necessary to wait
		// until the child process is running before writing data.
		//
		WriteToPipe(hchild_stdin_write, hInputFile);
		cout << endl << "->Contents of " << argv[1] << " written to child STDIN pipe" << endl;

		// Use pipe to read from child process's standard output.
		//
		cout << endl << "->Contents of child process STDOUT:" << endl;
		ReadFromPipe(hchild_stdout_read);
		cout << endl << "->End of parent execution." << endl;
	}
	catch (pair<string, string>& syndrome) {
		cerr << syndrome.first << ":" << syndrome.second << endl;
		programStatus = 1;           // denotes failure
	}

	CloseHandle(hInputFile);
	CloseHandle(hchild_stdin_read);
	CloseHandle(hchild_stdin_write);
	CloseHandle(hchild_stdout_read);
	CloseHandle(hchild_stdout_write);
	int i;
	cin >> i;
	return programStatus;
}


