#ifndef __printStuff_h_
#define __printStuff_h_

#include <chrono>
#include <random>
#include <string>
#include <windows.h>

using namespace std;

//  PrintStuff
//  
//  class that acts as a function object
//  -.  constructor -   define random delay between printings of string
//  -.  setString() -   set string to print (default: '.')
//  -.  setRepCount() - set repetitions to print (default: 10)
//  -.  go() - prints a string for a specified number of times  (default: 10)
//
class PrintStuff {
public:
	typedef unsigned dre_seed_t;

	// constructors
	//
	PrintStuff(dre_seed_t = 0, unsigned min_wait = 10, unsigned max_wait = 1000);

	// setters
	//
	void setString(string&);
	void setRepCount(unsigned);

	// output generation
	//
	void go(void) const;

	// destructor
	//
	~PrintStuff() {};

private:
	mutable default_random_engine _dre;
	uniform_int_distribution<int> _sleep_time;
	string _printMe;
	unsigned _repCount;

	//sychronizing varialbes
	static bool _initialized;
	static bool in_use;
	static CRITICAL_SECTION CriticalSection;
	static CONDITION_VARIABLE CV;
};

#endif
