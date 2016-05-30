// adapted from code from Josuittis, the C++ Standard Library: Second Edition,
// pp. 955-956
//
#include "printStuff.h"
#include <iostream>
#include <exception>
#include <pthread.h>

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

// doit()
//
// -> main uses doit() (see below) to run the computations done by the program's threads
// -> the Win32 API passes one argument to doit() when it invokes doit():  a PrintStuff* object that's been cast to void *
// -> doit must 
//    -.  uncast this parameter to its "real" type, PrintStuff*, then
//    -.  invoke its go() method
//
void * doit( void *pPrintStuffInstance_as_void ) {
  PrintStuff* pPrintStuffInstance = static_cast<PrintStuff*>(pPrintStuffInstance_as_void);
  pPrintStuffInstance->go();
  return NULL;
}

template<char C>
	class PrintChar : public PrintStuff
	{
		public:
			PrintChar(void) : PrintStuff(delay_seed()){_make_print_string();}
			PrintChar(unsigned max) : PrintStuff(delay_seed(), max){_make_print_string();}
			PrintChar(unsigned min, unsigned max) : PrintStuff(delay_seed(), min, max){_make_print_string();}
			~PrintChar(void) {};
		private:
			dre_seed_t delay_seed(void){return static_cast<dre_seed_t>(random_delay_params::tse() + C);}
			void _make_print_string(void)
			{
				string temp;
				for (unsigned i = 0; i < 5; ++i) temp.push_back(C);
				PrintStuff::setString(temp);
			}
	};


int main() {
  using namespace random_delay_params;

  // spread of print event wait times, in milliseconds
  //
  PrintChar<'.'> pstuff_dot(random_delay_params::min_to_wait, random_delay_params::max_to_wait);
  PrintChar<'+'> pstuff_plus(random_delay_params::min_to_wait, random_delay_params::max_to_wait);
  
  const unsigned thread_count = 2;
	cout << "starting " << thread_count << " threads asynchronously" << endl;

  // start threads;  wait for all threads to finish
  //
  pthread_t psdot;
  pthread_t psplus;
  vector<PrintStuff *> pThreadChars {&pstuff_dot, &pstuff_plus};
  vector<pthread_t *> pThreadCharsT {&psdot, &psplus};
  try {
    for(unsigned i = 0; i < pThreadChars.size(); ++i)
	{
		pthread_create(pThreadCharsT[i],  NULL, doit, static_cast<void *>(pThreadChars[i]));
	}
	for(auto p : pThreadCharsT)
	{
    	pthread_join(*p,  NULL);
	}
  }
  catch (const exception& e) {
    cout << endl << "EXCEPTION: " << e.what() << endl;
  }
  cout << endl << "done" << endl;
}
