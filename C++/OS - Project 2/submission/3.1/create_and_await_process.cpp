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
   cout << " Ishan Patel " << endl;
   int i;
   cin >> i;
  // *** manage parent process ****
  //
  cout << "child process " << childProcess_pid << " created" << endl;
  
  // wait for child to complete
  //
  int childStatus;
  pid_t completedChildProcess = waitpid(childProcess_pid, &childStatus, 0);   // wait for child
  
  // check wait status
  //
  if (completedChildProcess == -1) {
    // retrieve and show the wait's error code
    cerr << "waitpid failed: " << waitPIDErrorCodes[errno] << endl;
    exit(3);
  }

  // wait failed; recover child status
  //
  if (!WIFEXITED(childStatus)) {  // child terminated abnormally  
      // death by signal
      //
      if (WIFSIGNALED(childStatus)) { 
          cerr << "child process terminated by signal " << WTERMSIG(childStatus);
#ifdef WCOREDUMP
          cerr << ", generating core dump";
#endif      
          cerr << endl;
          exit(4);
      }
  
      // failure by other causes
      //
      cerr << "child process terminated unsuccessfully" << endl;
      exit(4);
  }
  
  // child terminated normally
  //
  cout << "child process final status: " << WEXITSTATUS(childStatus) << endl;
  exit (0);
}
