#include "printStuff.h"

#include <iostream>
#include <thread>

mutex PrintStuff::printMutex{};
condition_variable PrintStuff::readyCondVar{};
bool PrintStuff::readyFlag{false};

// constructors
//
PrintStuff::PrintStuff(dre_seed_t seed, unsigned min_wait, unsigned max_wait) :
_dre(seed), _sleep_time(min_wait, max_wait) {};

// PrintStuff::go
//
// print printMe for repeat_count number of times, pausing 
// -.  40 msec between each character in each string
// -.  an init-time determined number of msec between each string printing 
//
void PrintStuff::operator() (const string& printMe, const unsigned repeat_count) const {
	for (unsigned i = 0; i < repeat_count; ++i) {
		this_thread::sleep_for(chrono::milliseconds(_sleep_time(_dre)));
		
		unique_lock<mutex> ul(printMutex);
		
		while(readyFlag) {
			readyCondVar.wait(ul, []{return !readyFlag; });
		}
		readyFlag = true;
		
		for (auto c : printMe) {
			this_thread::sleep_for(chrono::milliseconds(40));
			cout << c;
			cout.flush();
		}
		readyFlag = false;
	}
}
