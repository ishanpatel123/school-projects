// adapted from code from Josuittis, the C++ Standard Library: Second Edition,
// pp. 955-956
//
#include "printStuff.h"
#include <iostream>
#include <exception>
#include <string>
#include <future>
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

// template class for eliminating repetitive code in untemplated version of main
// all code for templates-- i.e., not just prototypes-- must be included in modules that use them
//
template<char C>
class PrintChar : public PrintStuff {
public:
	PrintChar(void) : PrintStuff(delay_seed()), _print_me(_make_print_string()) {};
	PrintChar(unsigned mx) : PrintStuff(delay_seed(), mx), _print_me(_make_print_string()) {};
	PrintChar(unsigned mn, unsigned mx) : PrintStuff(delay_seed(), mn, mx), _print_me(_make_print_string()) {};

	void operator()(void)  { PrintStuff::operator()(const_cast<const string&>(_print_me)); };

	~PrintChar(void) {};

private:
	dre_seed_t delay_seed(void) { return static_cast<dre_seed_t>(random_delay_params::tse() + C); };
	string _print_me;
	string  _make_print_string(void) {
		string temp;
		for (unsigned i = 0; i < 5; ++i) temp.push_back(C);
		return temp;
	}
};


int main() {
	using namespace random_delay_params;

	// set up three threads - use char to print, current time to create random seed for print routine
	//
	PrintChar<'.'> pstuff_dot(random_delay_params::min_to_wait, random_delay_params::max_to_wait);
	PrintChar<'+'> pstuff_plus(random_delay_params::min_to_wait, random_delay_params::max_to_wait);
	PrintChar<'%'> pstuff_pct(random_delay_params::min_to_wait, random_delay_params::max_to_wait);

	// place in vector in order to simplify thread-starting and future-generating logic
	//
	vector<PrintStuff*> pThreadCodes{ &pstuff_dot, &pstuff_plus, &pstuff_pct };

	cout << "starting " << pThreadCodes.size() << " threads asynchronously" << endl;

	// start each thread, capturing futures returned by async in vector for further processing
	//
	vector<future<void>> threadFutures;
	for (auto pTC : pThreadCodes) threadFutures.push_back(async([=](){ (*pTC)(); }));

	// if at least one of the background threads is running...
	// -.  any_of() - true iff executing the third parameter on any of the arguments between the first and second is true
	//
	if (any_of(threadFutures.begin(), threadFutures.end(), [](future<void>& f){ return f.wait_for(chrono::seconds(0)) != future_status::deferred; }))
	{
		// poll while all threads are running
		// -.  all_of() - true iff executing the third parameter on each of the arguments between the first and second is true
		//
		while (all_of(threadFutures.begin(),
			threadFutures.end(),
			[](future<void>& f){ return f.wait_for(chrono::seconds(0)) != future_status::ready; })
			)
		{
			this_thread::yield();   // hint to reschedule to the next thread
		}
	}

	// wait for all futures to finish
	//
	for (auto& f : threadFutures) {
		try {
			f.get();
		}
		catch (const exception& e) {
			cout << endl << "EXCEPTION: " << e.what() << endl;
		}
	}
}
