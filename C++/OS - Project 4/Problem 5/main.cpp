// adapted from code from Josuittis, the C++ Standard Library: Second Edition,
// pp. 955-956
//
#include "printStuff.h"
#include <iostream>
#include <vector>
#include <exception>
#include <windows.h>
#include <tchar.h>
#include <strsafe.h>
#include <algorithm>

using namespace std;

// namespace random_delay_params
//
// values for introducing variability into the string print routine
// -.  tse() - returns ticks since epoch - for seeding random delays
// -.  min_to_wait, max_to_wait - bound the delay between printing a string and repeating the print (time: msec)
//
namespace random_delay_params {
	unsigned long long tse(void) { return chrono::system_clock::now().time_since_epoch().count(); };
	const unsigned min_to_wait = 10, max_to_wait = 1000;
}

// doit()
//
// -> main uses doit() (see below) to run the computations done by the program's threads
// -> the Win32 API passes one argument to doit() when it invokes doit():  a PrintStuff* object that's been cast to void *
// -> doit must 
//    -.  uncast this parameter to its "real" type, PrintStuff*, then
//    -.  invoke its go() method
//
DWORD WINAPI doit(void *pPrintStuffInstance_as_void) {
	PrintStuff* pPrintStuffInstance = static_cast<PrintStuff*>(pPrintStuffInstance_as_void);
	pPrintStuffInstance->go();
	return NULL;
}

// template class for eliminating repetitive code in untemplated version of main
// all code for templates-- i.e., not just prototypes-- must be included in modules that use them
//
template<char C>
class PrintChar : public PrintStuff {
public:
	PrintChar(void) : PrintStuff(delay_seed()), _print_me(_make_print_string()) { _make_print_string(); };
	PrintChar(unsigned mx) : PrintStuff(delay_seed(), mx), _print_me(_make_print_string()) { _make_print_string(); };
	PrintChar(unsigned mn, unsigned mx) : PrintStuff(delay_seed(), mn, mx), _print_me(_make_print_string()) { _make_print_string(); };
	~PrintChar(void) {};

private:
	dre_seed_t delay_seed(void) { return static_cast<dre_seed_t>(random_delay_params::tse() + C); };
	string _print_me;
	string  _make_print_string(void) {
		string temp;
		for (unsigned i = 0; i < 5; ++i) temp.push_back(C);
		setString(temp);
		return temp;
	}
};

int main() {
	using namespace random_delay_params;

	// set up the first thread
	// -.  specify a character to print ('.')
	// -.  use character's ASCII value, current time to create seed for randomizing delay between char printings
	// -.  create the string to print as a sequence of this character
	// -.  inititialize the parameters for the '.'-printing call to doit
	//
	// set up three threads - use char to print, current time to create random seed for print routine
	//
	PrintChar<'.'> pstuff_dot(random_delay_params::min_to_wait, random_delay_params::max_to_wait);
	PrintChar<'+'> pstuff_plus(random_delay_params::min_to_wait, random_delay_params::max_to_wait);

	vector<PrintStuff*> _pThreads{ &pstuff_dot, &pstuff_plus };

	const unsigned thread_count = (unsigned) _pThreads.size();
	cout << "starting " << thread_count << " threads asynchronously" << endl;

	// Win32 thread creation
	// -.  CreateThread invokes doit on the specified struct, returning a handle on the thread and a thread ID
	// -.  the initial two parameters, NULL and 0, specify default security attributes and default stack size
	// -.  the next-to-last parameter directs the thread to run immediately
	//
	// CreateThread documented at https://msdn.microsoft.com/en-us/library/windows/desktop/ms682453%28v=vs.85%29.aspx
	//
	vector<DWORD>  thread_IDs;
	vector<HANDLE> threadHandles;
	int index = 0;
	for (auto pThread : _pThreads) {
		thread_IDs.insert(thread_IDs.end(), NULL);
		threadHandles.push_back(CreateThread(NULL, 0, doit, static_cast<void *>(pThread), 0, &thread_IDs[index]));
		++index;
	}

	// if any of the threads has failed....
	if (any_of(threadHandles.begin(), threadHandles.end(), [](HANDLE& ha){return  ha == NULL; })){
		for (auto pTC : threadHandles) CloseHandle(&pTC);

		cout << endl << "done: some thread failed" << endl;
		ExitProcess(1);
	}

	WaitForMultipleObjects(thread_count, threadHandles.data(), true, INFINITE);
	cout << endl << "done: all threads succeeded" << endl;
	int i;
	cin >> i;
	ExitProcess(0);
}
