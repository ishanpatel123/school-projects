// producer - consumer using message passing synchronization - create consumer process module
// adapted from https ://msdn.microsoft.com/en-us/library/windows/desktop/ms682499(v=vs.85).aspx
//
#ifndef __CREATE_CONSUMER_PROCESS_H__
#define __CREATE_CONSUMER_PROCESS_H__

#include <windows.h> 

void CreateChildConsumerProcess(HANDLE, HANDLE);

#endif