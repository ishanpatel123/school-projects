#include "fork_exec_wait_error_codes.h"

#include <iostream>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>

using namespace std;

// start cmd.exe 
//
int main(int argc, char *argv[], char **env)
{
  struct sigaction sigactionProcess;
  sigactionProcess.sa_handler = SIG_IGN; 
  sigemptyset(&sigactionProcess.sa_mask);
  sigactionProcess.sa_flags = 0;
  if (sigaction(SIGCHLD, &sigactionProcess, 0) == -1)
  {
    perror(0);
    cerr << "reaped failed: " << mapErrorCode[errno] << endl;
    exit(1);
  }
  
  // *** *** fork the child process *** ***
  //
  // fork - fork (i.e., fission) this process, yielding 
  //    P_NOWAIT - run asynchronously, enable wait on completion
  //    see https://msdn.microsoft.com/en-us/library/wweek9sc.aspx
  // 
  pid_t childProcess_pid = fork();

  if (childProcess_pid == -1) {
    cerr << "fork failed: " << forkErrorCodes[errno] << endl;
    exit(1); 
  }
  
  // *** *** manage child process *** ***
  //
  if (childProcess_pid == 0) {
    execle("/bin/ls", "ls", "-l", NULL, env);    // try to become the shell; should go no further if successful
    cerr << "exec failed: " << execErrorCodes[errno] << endl;
    exit(2);    
  } 
  cout << "Ishan Patel" << endl;
  int i;
  cin >> i;
  // *** manage parent process ****
  //
  cout << "child process " << childProcess_pid << " created" << endl;
  
  // child terminated normally
  //
   exit (0);
}
