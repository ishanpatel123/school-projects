#ifndef __printStuff_h_
#define __printStuff_h_

#include <chrono>
#include <random>
#include <string>
#include <mutex>
#include <condition_variable>

using namespace std;

//  PrintStuff
//  
//  class that acts as a function object
//  -.  operator() - prints a string for a specified number of times  (default: 10)
//
class PrintStuff {
public:
	typedef unsigned dre_seed_t;
	static mutex printMutex;
	static condition_variable readyCondVar;
	static bool readyFlag;
	
	// constructors
	//
	PrintStuff(dre_seed_t = 0, unsigned min_wait = 10, unsigned max_wait = 1000);

	// output generation
	//
	virtual void operator() (void) const {};
	void operator() (const string&, const unsigned = 10) const;

	// destructor
	//
	~PrintStuff() {};

private:
	mutable default_random_engine _dre;
	uniform_int_distribution<int> _sleep_time;
};

#endif