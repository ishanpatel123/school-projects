#include <iostream>
#include <map>
#include <string>
#include <process.h>
#include <windows.h>

using namespace std;

// associative array that maps error codes for _spawn and _cwait to descriptive strings
//
map<intptr_t, string> _spawnErrorCodes {
    { E2BIG, "Argument list exceeds 1024 bytes" }, 
    { EINVAL, "Mode argument is invalid"},
    { ENOENT, "File or path is not found" },
    { ENOEXEC, "Specified file is not executable or has invalid executable - file format" },
    { ENOMEM, "Not enough memory is available to execute the new process" },
};
map<intptr_t, string> _cwaitErrorCodes {
    { ECHILD, "No specified process exists, procHandle is invalid, or the call to the GetExitCodeProcess or WaitForSingleObject API failed" },
    { EINVAL, "action is invalid" }
};

// start cmd.exe 
//
int main(int argc, char *argv[], char **env)
{
  // *** *** spawn the process *** ***
  //
  // _spawnl - spawn process, specifying spawn mode, command name, and arguments, with NULL terminator
  //    P_NOWAIT - run asynchronously, enable wait on completion
  //    see https://msdn.microsoft.com/en-us/library/wweek9sc.aspx
  // 
  intptr_t processCode = _spawnl(P_NOWAIT, "c:\\windows\\system32\\cmd.exe", "cmd.exe", NULL);

  if (processCode == -1) {
    // retrieve and show the process's error code; see https://msdn.microsoft.com/en-us/library/windows/desktop/ms679360%28v=vs.85%29.aspx
    cerr << "_spawnl failed: " << _spawnErrorCodes[GetLastError()] << endl;
    // use non-zero value to signal failure to command environment; see https://msdn.microsoft.com/en-us/library/windows/desktop/ms682658(v=vs.85).aspx
    ExitProcess(1);
  }

  // *** *** Process created; ensure child process graceful termination *** ***
  //
  cout << "Process " << processCode << " created" << endl;

  // wait until child process exits;  see https://msdn.microsoft.com/en-us/library/zb9ehy71.aspx
  //
  int exitStatus;
  intptr_t closedProcessCode = _cwait(&exitStatus, processCode, NULL);

  if (closedProcessCode != processCode) {
    // retrieve and show the process's error code; see https://msdn.microsoft.com/en-us/library/windows/desktop/ms679360%28v=vs.85%29.aspx
    cerr << "_cwait failed: " << _cwaitErrorCodes[GetLastError()] << endl;
    // use non-zero value to signal failure to command environment; see https://msdn.microsoft.com/en-us/library/windows/desktop/ms682658(v=vs.85).aspx
    ExitProcess(1);
  }

  cout << "final status for process " << processCode << ": " << exitStatus << endl;

  // CloseHandle:  close handle on system resource;  see https://msdn.microsoft.com/en-us/library/windows/desktop/ms724211%28v=vs.85%29.aspx
  //
  CloseHandle(reinterpret_cast<HANDLE>(processCode));    // close child process handle
  ExitProcess(0);
}