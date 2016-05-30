#include "printStuff.h"

#include <iostream>
#include <unistd.h>
#include <pthread.h>

// constructors
//
PrintStuff::PrintStuff(dre_seed_t seed, unsigned min_wait, unsigned max_wait) :
_dre(seed), _sleep_time(min_wait, max_wait), _printMe("."), _repCount(10) {};

// PrintStuff setters
//
void PrintStuff::setString(string& printMe)   {_printMe = printMe;}
void PrintStuff::setRepCount(unsigned count) {_repCount = count;}

pthread_mutex_t PrintStuff::mutex = PTHREAD_MUTEX_INITIALIZER;
pthread_cond_t PrintStuff::cv = PTHREAD_COND_INITIALIZER;
bool PrintStuff::is_in_use = false;
// PrintStuff::go
//
// print _printMe for _repCount number of times, pausing 
// -.  40 msec between each character in each string
// -.  an init-time determined number of msec between each string printing 
//
void PrintStuff::go (void) {
  const unsigned microSECS_per_milliSEC = 1000;
  for (unsigned i = 0; i < _repCount; ++i) {
    usleep(_sleep_time(_dre) * microSECS_per_milliSEC);
	pthread_mutex_lock(&mutex);	
	while(is_in_use) {
		pthread_cond_wait(&cv,	&mutex);		
	}
	
	is_in_use = true;
    for (auto c : _printMe) {
      usleep(40 * microSECS_per_milliSEC);
      cout << c;
      cout.flush();

    }
	is_in_use = false;

	pthread_mutex_unlock(&mutex);	
	
  }
}
