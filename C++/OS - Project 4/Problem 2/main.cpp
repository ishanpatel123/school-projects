// adapted from code from Josuittis, the C++ Standard Library: Second Edition,
// pp. 955-956
//
#include "printStuff.h"
#include <iostream>
#include <exception>
#include <string>
#include <future>

using namespace std;

// namespace random_delay_params
//
// values for introducing variability into the string print routine
// -.  tse() - returns ticks since epoch - for seeding random delays
// -.  min_to_wait, max_to_wait - bound the delay between printing a string and repeating the print (time: msec)
//
namespace random_delay_params {
  unsigned long long tse(void) { return chrono::system_clock::now().time_since_epoch().count(); };
  const unsigned min_to_wait = 10;
  const unsigned max_to_wait = 1000;
}


int main() {
  using namespace random_delay_params;

  // set up the first thread
  // -.  specify a character to print ('.')
  // -.  use character's ASCII value, current time to create seed for randomizing delay between char printings
  // -.  create the string to print as a sequence of this character
  //
  char char_dot{ '.' };
  PrintStuff pstuff_dot(static_cast<PrintStuff::dre_seed_t>(tse() + char_dot), min_to_wait, max_to_wait);
  string dot_thread_output;
  for (unsigned i = 0; i < 5; ++i) dot_thread_output.push_back(char_dot);

  // set up the second thread -- similar to the first
  char char_plus{ '+' };
  PrintStuff pstuff_plus(static_cast<PrintStuff::dre_seed_t>(tse() + char_plus), min_to_wait, max_to_wait);
  string plus_thread_output;
  for (unsigned i = 0; i < 5; ++i) plus_thread_output.push_back(char_plus);

  cout << "starting 2 threads asynchronously" << endl;

  // C++11 standard library thread creation
  // -.  async 
  //     -.  takes one argument - a function to execute
  //     -.  returns one value - a future - i.e., an object that represents the result from a nonblocking computation
  // -.  [...](...){....} is the C++11 syntax for a **lambda**: a nameless function
  //     -.  the [...] component specifies how to access nonlocal variables; [&] denotes "access by reference"
  //     -.  the (...) component specifies the parameters to the lambda;  here, none are needed
  //     -.  the {...} component specifies the function's body
  //
  // std::async is documented at http://www.cplusplus.com/reference/future/async/?kw=async
  // std::future is documented at http://www.cplusplus.com/reference/future/future/
  //
  auto dot_thread = async(launch:: async,[&](){ pstuff_dot.go(const_cast<const string&>(dot_thread_output)); });
  auto plus_thread = async(launch:: async,[&](){ pstuff_plus.go(const_cast<const string&>(plus_thread_output)); });

  // if at least one of the futures were successfully activated...
  //
  if (dot_thread.wait_for(chrono::seconds(0)) != future_status::deferred ||
    plus_thread.wait_for(chrono::seconds(0)) != future_status::deferred) {
    // poll until at least one activity finishes
    //
    while (dot_thread.wait_for(chrono::seconds(0)) != future_status::ready &&
      plus_thread.wait_for(chrono::seconds(0)) != future_status::ready) {
      this_thread::yield();   // hint to reschedule to the next thread
    }
  }

  // wait for all futures to finish
  //
  try {
    dot_thread.get();
    plus_thread.get();
  }
  catch (const exception& e) {
    cout << endl << "EXCEPTION: " << e.what() << endl;
  }
  cout << endl << "done" << endl;
}
