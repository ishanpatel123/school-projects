#include <iostream>
   
#include <string>
 
using namespace std;
 
int main(int argc, char* argv[], char **env) {
 
 
	for (int i = 0; i < argc; ++i) {
 
		cout << "command line argument " << i << " is " << argv[i] << endl;
 
	}
 
	cout << endl;
 
	int i = 0;	/* initialize i to count all environmental string*/

	string str = "", strLeft = "",strRight = "";	/*initialize string str, strLeft, and strRight to store substrings*/

 
	for (auto p = env; *p != 0; *++p, ++i) {
 
		str = *p;	/*initialize "str" string to current environment string*/
 
		int lenth = str.size();	/* stores the size of the string*/

		int index = str.find_first_of("=",0); /* finds the length of string from first character to
													the equal sign*/
		
 
		strLeft=str.substr(0,index);	/*stores all characters from the left side of the equals
												sign using substr method and store it in strLeft*/
		strRight=str.substr(index+1, lenth);  /*stores all characters from the equals sign to end*/
		
		
		cout << "environment string " << strLeft << " is " << strRight << endl;	/* Print the two substring string*/
		
		/* Clear both strings*/
		strLeft.clear();
		strRight.clear();
	}
 
	cout << i << endl;
 
	cin >> i;
 
	exit(0);
 
}
