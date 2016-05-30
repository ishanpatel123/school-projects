#include "producer_pipe_io.h"
#include "file_io.h"
#include "format_error_message.h"

#include <iostream>
#include <sstream>
using namespace std;

// **> assumes multi-byte character set  (Properties > Configuration Properties > General > Character Set)

// Read a file's content in one blast and write its entire contents to the pipe for the child's STDIN.
// Write limited to maximum value that can be expressed in a DWORD
//
void WriteToPipe(HANDLE stdin_write, HANDLE hInputFile)
{
	CHAR* fileContent{ NULL };
	try {
		// determine size of input file, assuming file is not more than DWORD_MAX bytes
		// see https://msdn.microsoft.com/en-us/library/windows/desktop/aa364955%28v=vs.85%29.aspx
		//
		DWORD fileSize{ GetFileSize(hInputFile, NULL) };
		if (fileSize == INVALID_FILE_SIZE) throw pair<string, string>("WriteToPipe: GetFileSize", formatErrorMessage());

		// *** *** the writeToFile statement represents a potential race condition!! write must execute before child process does read *** ***
		// *** *** to observe the race, delay this next statement for a few seconds with a Sleep()--say, Sleep(6000)--or a breakpoint and pause before continuing *** ***
		// *** *** program should then stall at read file below *** ***
		//
		fileContent = new CHAR[fileSize];
		readFromFile(hInputFile, fileContent, fileSize, "WriteToPipe");
		writeToFile(stdin_write, fileContent, fileSize, "WriteToPipe");
		delete[] fileContent;
	}
	catch (pair<string, string>& syndrome) {
		delete[] fileContent;
		throw syndrome;
	}
}


// Read output from the child process's pipe for STDOUT in one blast and write to the parent process's pipe for STDOUT. 
// Read limited to maximum value that can be expressed in a DWORD
//
void ReadFromPipe(HANDLE stdout_read)
{
	CHAR* fileContent{ NULL };
	try {
		// get handle for displaying results of read
		//
		HANDLE hStdout{ GetStdHandle(STD_OUTPUT_HANDLE) };
		if (hStdout == INVALID_HANDLE_VALUE) throw pair<string, string>("WriteToPipe: GetStdHandle(STDOUT)", formatErrorMessage());

		// determine size of input to process, allocating buffer for file read
		// *** *** the GetFileSize() statement below represents a potential race condition!! this get must execute after child process does write *** ***
		//
		DWORD inputSize{ GetFileSize(stdout_read, NULL) };
		if (inputSize == INVALID_FILE_SIZE)  throw pair<string, string>("WriteToPipe: GetFileSize", formatErrorMessage());
		fileContent = new CHAR[inputSize];

		readFromFile(stdout_read, fileContent, inputSize, "ReadFromPipe");
		writeToFile(hStdout, fileContent, inputSize, "ReadFromPipe");
		delete[] fileContent;
	}
	catch (pair<string, string>& syndrome) {
		delete[] fileContent;
		throw syndrome;
	}

}


