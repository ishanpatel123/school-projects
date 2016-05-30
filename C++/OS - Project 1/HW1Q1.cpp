#include <iostream>
 
#include <cstdlib>
 
#include <string.h>
 
using namespace std;
 
int main(int argc, char* argv[], char **env) {
  
	for (auto i = 0; i < argc; ++i) {
 
		cout << "command line argument " << i << " is " << argv[i] << endl;
 
	}
 
	cout << endl;
	
	char *ptr; /*stores what 'strtok_s' returns */
	string str = "";
	int i = 0;

	for (auto p = env; *p != 0; *++p, ++i) {
 
		char* tempT;	/* initialize temp to store right side of environment*/
 
		ptr = strtok_s(*p, "=", &tempT); /* Split the string into tokens where it found equal sign
											store left side to ptr, and right side stays in tempT variable*/
		
		 cout << "environment string " << ptr << " is " <<  tempT << endl; /* Display environment string*/
 
	}
 
	cout << i << endl; /*Display counts of environment strings*/
 
	cin >> i;
 
	exit(0);

 
}
