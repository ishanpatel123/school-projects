// producer-consumer using message passing synchronization - consumer main module
// adapted from https://msdn.microsoft.com/en-us/library/windows/desktop/ms682499(v=vs.85).aspx
// **> assumes multi-byte character set  (Properties > Configuration Properties > General > Character Set)
//
#include "format_error_message.h"
#include "file_io.h"
#include <windows.h>
#include <sstream>

// **> assumes multi-byte character set  (Properties > Configuration Properties > General > Character Set)

using namespace std;

// Read output from the process's pipe for STDIN in one blast and write to the parent process's pipe for STDIN. 
// Read limited to maximum value that can be expressed in a DWORD
//
int main(int argc, char *argv[], char **env)
{
	int programStatus{ 0 };           // denotes success
	CHAR* fileContent{ NULL };
	HANDLE hStdout{ NULL }, hStdin{ NULL };

	try {
		// get handles for communicating with parent process
		hStdout = GetStdHandle(STD_OUTPUT_HANDLE);
		if (hStdout == INVALID_HANDLE_VALUE)  throw pair<string, string>("main (GetStdHandle(STDOUT))", formatErrorMessage());

		hStdin = GetStdHandle(STD_INPUT_HANDLE);
		if (hStdin == INVALID_HANDLE_VALUE)   throw pair<string, string>("main (GetStdHandle(STDIN))", formatErrorMessage());

		HANDLE h_to_parent{ reinterpret_cast<HANDLE>(argv[2]) };
		HANDLE h_from_parent{ reinterpret_cast<HANDLE>(argv[3]) };

		
		// determine size of input to process, allocating buffer for file read
		//
		// NOTE: *** *** this statement represents a potential race condition!! statement must execute after parent process does write *** ***
		DWORD inputSize{ GetFileSize(hStdin, NULL) };
		if (inputSize == INVALID_FILE_SIZE)  throw pair<string, string>("main (GetFileSize)", formatErrorMessage());
		fileContent = new CHAR[inputSize];

		// Read from standard input and stop on error or insufficient data, then
		// Write to standard output and stop on error.
		//
		// *** *** the writeToFile statement below represents a potential race condition!! statement must execute before parent process does read *** ***
		// *** *** to observe the race, delay this next statement for a few seconds with a Sleep()--say, Sleep(6000)--before continuing *** ***
		// *** *** parent should then read nothing *** ***
		//

		readFromFile(hStdin, fileContent, inputSize, "Consumer process main");
		writeToFile(hStdout, fileContent, inputSize, "Consumer process main");
	}
	catch (pair<string, string>& syndrome) {
		// message box required for communication with user because process lacks window
		stringstream message_builder;
		message_builder << syndrome.first << ":" << syndrome.second << endl;
		MessageBox(NULL, static_cast<LPCTSTR>(message_builder.str().c_str()), TEXT("Error"), MB_OK);
		programStatus = 1;           // denotes failure
	}

	// clean up resources
	//
	CloseHandle(hStdout);
	CloseHandle(hStdin);
	delete[] fileContent;

	return programStatus;
}
