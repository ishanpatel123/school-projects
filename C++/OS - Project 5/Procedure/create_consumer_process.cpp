#include "create_consumer_process.h"
#include "format_error_message.h"

#include <sstream>
#include <iostream>

using namespace std;

// **> assumes multi-byte character set  (Properties > Configuration Properties > General > Character Set)

// Create a child process that uses the previously created pipes for STDIN and STDOUT.
//
void CreateChildConsumerProcess(HANDLE stdin_read, HANDLE stdout_write)
{
	LPCTSTR applicationName = NULL;                     // module name; NULL => take module name from command line to execute
	LPTSTR  commandLine = "C:\\Users\\Ishan\\Desktop\\Classes\\Spring2015\\OS\\HW\\HW4\\Project4\\Debug\\consumer.exe";
	// command line to execute.  **** change this to location of your consumer executable ***
	LPSECURITY_ATTRIBUTES processSecurityAttrs = NULL;  // security descriptor for child process; NULL => child doesn't inherit handle for parent process
	LPSECURITY_ATTRIBUTES threadSecurityAttrs = NULL;   // security descriptor for child process main thread; NULL => child doesn't inherit handle for parent process's main thread
	BOOL inheritHandles = TRUE;                         // false => child doesn't inherit parent process handles
	DWORD creationFlags = 0;                            // process creation flags: control a process's creation modes and priority
	LPVOID  environmentBlock = NULL;                    // pointer to environment block; NULL => use parent process's environment block
	LPCTSTR currentDirectory = NULL;                    // pointer to initial current directory; NULL => use parent process's current directory
	STARTUPINFO siStartInfo{};                          // Specifies the window station, desktop, standard handles, and appearance of a process's main window at creation time." (MSDN)
	siStartInfo.cb = sizeof(siStartInfo);           // structure size, in bytes (fixed)
	siStartInfo.hStdError = stdout_write;           // stdin, stdout, stderr for child.
	siStartInfo.hStdOutput = stdout_write;
	siStartInfo.hStdInput = stdin_read;
	siStartInfo.dwFlags |= STARTF_USESTDHANDLES;    // direct child process to use these handles
	PROCESS_INFORMATION piProcInfo{};                   // "[Returns] information about a newly created process and its primary thread."  (MSDN)

	// Create the child process. 
	// 
	BOOL success = CreateProcess(
		applicationName,
		commandLine,
		processSecurityAttrs,
		threadSecurityAttrs,
		inheritHandles,
		creationFlags,
		environmentBlock,
		currentDirectory,
		&siStartInfo,
		&piProcInfo);

	if (!success) throw pair<string, string>("CreateProcess", formatErrorMessage());

	CloseHandle(piProcInfo.hProcess);
	CloseHandle(piProcInfo.hThread);
}


