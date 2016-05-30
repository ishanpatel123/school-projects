#include <iostream>
 
#include <cstdlib>
 
#include <string.h>
 
using namespace std;
 
int main(int argc, char* argv[], char **env) {
  
	for (int i = 0; i < argc; ++i) {
 
		cout << "command line argument " << i << " is " << argv[i] << endl;
 
	}
 
	cout << endl;
	
	char *ptr; /*stores what 'strtok_s' returns */
	
	int i = 0;

	for (char** p = env; *p != 0; *++p, ++i) {
 
		char* tempT;	/* initialize temp to store right side of environment */
 
		ptr = strtok_r(*p, "=", &tempT); /* Split the string into tokens where it found equal sign
											store left side to ptr, and right side stays in tempT variable*/
		
		 cout << "environment string " << ptr << " is " <<  tempT << endl; /* Display environment string*/
 
	}
 
	cout << i << endl;
 
	cin >> i;
 
	exit(0);

 
}

