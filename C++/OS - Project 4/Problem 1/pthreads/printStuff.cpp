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
    for (auto c : _printMe) {
      usleep(40 * microSECS_per_milliSEC);
      cout << c;
      cout.flush();
    }
  }
}
