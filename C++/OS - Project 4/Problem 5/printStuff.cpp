#include "printStuff.h"

#include <iostream>
#include <windows.h>

bool PrintStuff::_initialized{ false };
CRITICAL_SECTION PrintStuff::CriticalSection;
CONDITION_VARIABLE PrintStuff::CV;
bool PrintStuff::in_use{ false };

// constructors
//
PrintStuff::PrintStuff(dre_seed_t seed, unsigned min_wait, unsigned max_wait) :
_dre(seed), _sleep_time(min_wait, max_wait), _printMe("."), _repCount(10) 
{
	if (_initialized == false)
	{
		InitializeCriticalSection(&CriticalSection);
		InitializeConditionVariable(&CV);
		_initialized = true;
	}
};

// PrintStuff setters
//
void PrintStuff::setString(string& printMe)   { _printMe = printMe; }
void PrintStuff::setRepCount(unsigned count) { _repCount = count; }

// PrintStuff::go
//
// print _printMe for _repCount number of times, pausing 
// -.  40 msec between each character in each string
// -.  an init-time determined number of msec between each string printing 
//
void PrintStuff::go(void) const {
	for (unsigned i = 0; i < _repCount; ++i) {
		Sleep(_sleep_time(_dre));

		EnterCriticalSection(&CriticalSection);

		while (in_use) {
			SleepConditionVariableCS(&CV, &CriticalSection, INFINITE);
		}
		in_use = true;

		for (auto c : _printMe) {
			Sleep(40);
			cout << c;
			cout.flush();
		}
		in_use = false;
		LeaveCriticalSection(&CriticalSection);
	}
}
