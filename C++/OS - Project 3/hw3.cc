// Include the C++ i/o library   
#include <iostream>
// Include the C-string library
#include <string.h>
// Standard library
#include <stdlib.h>
// Include the fstream mlibrary 
#include <fstream>
// allow use of POSIX OS API
#include <unistd.h>
// allow use of time function
#include <time.h>
// allow to convert string to int
#include <sstream>
// check for error
#include <stdexcept>
#include <boost/algorithm/string/split.hpp>
#include <boost/algorithm/string/classification.hpp>
#include <vector>
// used for wait function
#include <sys/wait.h>

// Shortcut for the std namespace
using namespace std;

// String length, plus one for \0
#define STRLEN 32

// create chars for getopt() function
char strSetupFile[STRLEN-1] = "", strCMDFile[STRLEN-1] = "";
// create the stream out object
//fstream logFile;
// create the object to read a file for the setupfile
ifstream setupFile;  
// create the object to read a file for the cmdfilename
ifstream cmdFile;

// create a global struct for all messages between pipes
struct message
{
	int from;	  // who sent this message: 0 == parent, 1 == first robot
	char payload[32]; // the rest of the message
}m;

// initialize 7 pipes with write and write ability
int pipeList[7][2];

// display any arguments entered by user
void displayArguments()
{
	// Show the arguments
	if ( strlen(strSetupFile) > 0 ) 
	{
		cout << "strSetupFile = " << strSetupFile << endl;
	}
	else
	{
		// display error, tell user that s should contain a name
		cout << "Error: s flag requires an argument" << endl;
		exit(0);  
	}
	if ( strlen(strCMDFile) > 0 ) 
	{
		cout << "strCMDFile = " << strCMDFile << endl;
	}
}


int processSetupFile( string words, int& R, int& X, int& Y)
{
	using namespace boost::algorithm;	

	// check to see if setupfile is not present 
	if ( !setupFile)
	{
		// print error to log file
		string temp = "Error: log file not found"; 
		// copy string to the message payload
		strcpy(m.payload, temp.c_str());
		write(pipeList[6][1], (char*)&m, sizeof(message));
		// display error to user
		cout << "Error, " << strSetupFile << " does not exist" << endl;
		// print the ending time
		exit(0);
	}
	else
	{
		// read from setupfilename and write it out to log file
		while (!setupFile.eof())	// while filename is not at the end of file
		{
			getline(setupFile, words);	 // reads the whole line and stores it in a string, words

			// instantiate an array of tokens	
			vector<std::string> tokens;
			// split the string into space delimited strings
			split(tokens, words, is_any_of(" ")); // here it is

			// make sure it is not out of range
			try
			{
				// check if the current line is robots	
				if (words[0] == 'R')
				{
					R  = atoi(tokens[1].c_str());
					strcpy(m.payload, words.c_str());
					write(pipeList[6][1], (char*)&m, sizeof(message));
					
				}
				// check if the current line is the x coordinate
				else if (words[0] == 'X') 
				{
					X = atoi(tokens[1].c_str());
					strcpy(m.payload, words.c_str());
					write(pipeList[6][1], (char*)&m, sizeof(message));
				}
				// check if the current line is the y coordinate
				else if (words [0] == 'Y') 
				{
					Y = atoi(tokens[1].c_str());
					strcpy(m.payload, words.c_str());
					write(pipeList[6][1], (char*)&m, sizeof(message));
				}
			}
			catch (const std::out_of_range& oor) 
			{
			}

		} // while

		// check if any of the parameters are out of range
		if ((R >= 1 && R <= 5) && (X >= 1 && X <= 20) && (Y >= 1 && Y <= 20))
		{
		}
		else
		{
			// print an error message to the user
			cout << "Error: there was a parameter out of range." << endl;
			// initialize error string
			string temp = "Error: Parameter out of range.\n" ;
			// copy string to the message payload
			strcpy(m.payload, temp.c_str());
			// write it to the pipe
			write(pipeList[6][1], (char*)&m, sizeof(message));
			// exit the program
			exit(0);
		}
	}
	// return the number of robots processed 
	return R;
}


// close any files opened in the program
void closeFiles()
{
	// close the read file setupFile
	setupFile.close();
	// close the cmdfilename stream
	cmdFile.close();	
}

int checkCommand (bool commandFlagPresent) 
{
	// if the argument for -c was provided
	if ( strlen(strCMDFile) > 0 ) 
	{
		commandFlagPresent = true;
		// if -c is provided and cmd file is not found
		if (! cmdFile)
		{
			// print error message to log file
			//logFile << "Command file " << strCMDFile << " does not exist" << endl;
			// display error to user
			cout << "Error, " << strCMDFile<< " does not exist" << endl;
			// print the ending time
			// exit
			return -1; 
		}
	}

	else
	{
		// if no argument for -c was provided set the boolean to false
		commandFlagPresent = false;
	}

	return commandFlagPresent;		
}

void runRobot(int i, int R, int X, int Y)
{
	int x = 0;
	int y = 0;
	
	// read message sent to all robots
	read(pipeList[i][0], (char*)&m, sizeof(message));
	// keep reading messages until Q is read from pipe
	while (m.payload[0] != 'Q')
	{
		if (m.payload[4] == 'N')
		{
			if (Y - 1 > y)
			{
				// move the robot up
				y++;
			}
		}	
		else if (m.payload[4] == 'S')
		{
			if (y  > 0)
			{
				// move the robot down
				y --;
			}
		}
		else if (m.payload[4] == 'E')
		{
			if (X - 1 >  x)
			{
				// move the robot right
				x++;
			}
		}
		else if (m.payload[4] == 'W')
		{
			if (x > 0)
			{
				// move the robot left
				x--;
			}
		}

		// send message from robot 
		m.from = i;
		// set payload equal to which robot received instruction and X and Y
		sprintf(m.payload, "P %d %d %d", i , x, y );
		// write current position back to parent
		write(pipeList[5][1], (char*)&m, sizeof(message));
		// keep reading messages until Q is read from pipe
		read(pipeList[i][0], (char*)&m, sizeof(message));
	}
		
	// exit child
	exit(0);
}

int logger (char* strLogFile)
{
	// initialize f stream object
	fstream logFile;
	// check to see if log file failed to open
	if ( !logFile) 
	{
		// logFile.open( ) failed
		cout << "Error, " << logFile << " does not exist" <<  endl;
		return -1;       
	} 
	if ( strlen(strLogFile) > 0 ) 
	{
		logFile.open (strLogFile, std::fstream::in | std::fstream::out| std::fstream::app);
		cout << "strLogFile = " << strLogFile << endl;
		if ( access ( strLogFile, F_OK) == -1 )
		{
			cout << "Error, " << strLogFile << " does not exist " << endl; 
		}
	}
	else 
	{
		logFile.open ("log.txt", std::fstream::in | std::fstream::out | std::fstream::app );
	}

	// create timer
	time_t timer;
	//pass variable timer to time function
	time(&timer); 

	// print the begin time to the log file
	logFile << "Begin: " << ctime(&timer);
	// initialize message m to hold the payload and 
	message m;
	// read from the pipe position 7 
	read(pipeList[6][0], (char*)&m, sizeof(message));
	
	// while the first letter in payload does not contain q, keep reading each line
	while (strcmp(m.payload, "Q") != 0 )
	{
		// print message from payload to log file
		logFile << m.payload << endl;
		// read from the pipe position 0
		read(pipeList[6][0], (char*)&m, sizeof(message));
	}	

	// print message from payload to log file
	logFile << m.payload << endl;
	
	//write timestamp
	logFile << "End: " << ctime(&timer);
	// close file
	logFile.close();
	// exit child
	exit(0);
}

// process forking
void processSetup (string words, int R, int X, int Y, bool cFlag, bool logBool, char* strLogFile)
{

	// open the logger pipe
	if (pipe (pipeList[6]) == -1)
	{
		// exit program
		exit(0);
	}
	// create new child process for log
	pid_t pidValue = fork();
	if (pidValue == -1)
	{
		// display error if process not found
		cout << "Error: process does not exist" << endl;
		// exit program
		exit(0);	
	}
	else if (pidValue == 0) // child function
	{
		// log the procses through pipelist[0]
		logger(strLogFile);
	}
	else // parent function
	{
		if (pipe (pipeList[5]) == -1)
		{
			exit(0);
		}
		// get # of robots and return, write out x and y coordinates
		int numOfRobots = processSetupFile( words, R, X, Y);

		for (int i = 0; i < numOfRobots; i++)
		{
			// make pipe available to child
			if (pipe (pipeList[i]) == -1)
			{
				cout << "Error, pipe not available for robot" << i +1 << endl;
			}
			// fork off each robot
			pid_t forkRobots = fork();
			if (forkRobots == -1)
			{
				cout << "Error: process does not exist" << endl;	
			}
			else if (forkRobots == 0) // child function
			{
				// run the robot
				runRobot(i, R, X, Y);
				exit(0);
			}
			else	// parent function
			{
			}
		}
		m.from = 0;

		int i;
		// determine how to process commands depending on whether the user entered a c flag or not 
		if (cFlag == true)
		{
			do
			{ 
				// reads the whole line from a file and stores it in a string, words
				getline(cmdFile, words); 
				// copy words to payload
				strcpy(m.payload, words.c_str());
				// grab the character in payload[2] and convert it to an int 
				i = m.payload[2];
				char s[5];
				s[0] = m.payload[2];
				// put in a new line at s[1]
				s[1] = '\0';
				i = atoi(s);
				// write to the robot that received message
				if (words != "Q")
				{
					write(pipeList[i][1], (char*)&m, sizeof(message));
					read(pipeList[5][0], (char*)&m, sizeof(message));
					cout << "Parent received " << m.payload << endl;
				}
				// write to the logger pipe 
				write(pipeList[6][1], (char*)&m, sizeof(message));
			} while ( words != "Q");
		}
		else // user did not specify c flag... read command froms console
		{
			do
			{
				// get input from user to enter commands
				getline (cin, words);
				// copy words to payload 
				strcpy(m.payload, words.c_str());
				// grab the character in payload[2] and convert it to an int 
				i = m.payload[2];
				char s[5];
				s[0] = m.payload[2];
				// put in a new line at s[1]
				s[1] = '\0';
				i = atoi(s);
				// write to the robot that received message
				if (words != "Q")
				{
					write(pipeList[i][1], (char*)&m, sizeof(message));
					read(pipeList[5][0], (char*)&m, sizeof(message));
					cout << "Parent received " << m.payload << endl;
				}
				// write to the logger pipe 
				write(pipeList[6][1], (char*)&m, sizeof(message));
			} while (words != "Q"); 
		}
	
	
	// indicates message is from parent
	m.from = 0;
	// copy Q into the payload to warn robots to quit
	strcpy(m.payload, "Q");	
	for (int i = 0; i < numOfRobots; i++)
	{
		// send Q to each robot so that it knows to quit
		write(pipeList[i][1], (char*)&m, sizeof(message));
	}
	// send Q to the logger so that it knows to quit
	write(pipeList[6][1], (char*)&m, sizeof(message));
	// send Q to the write back pipe
	write(pipeList[5][1], (char*)&m, sizeof(message));

	// wait until each robot dies
	for (int i = 0; i < numOfRobots; i++)
	{
		wait(pipeList[i]);
	}
	// wait until the logger dies
	wait(pipeList[6]);	
	}	
}

//
// main( )
//
//	Shows the use of argc and argv
//	  and retrieving argv from getopt( )
//
int main ( int argc, char** argv ) 
{	
	// create string to loop through read setupfile and send to log file
	string words = "";
	// to be used for reading commands from cmdfilename
	string input = "";
	// initialize number of robots, X-coordinate, Y-coordinate to coordinates 0,0 
	int R , X , Y ;			
	// boolean to test whether command flag was present or not
	bool commandFlagPresent = false;
	// initialize bool to check how log file was declared
	bool logBool = false;
	// For return value of getopt( )
	char c;
	char strLogFile[STRLEN-1] = "";

	// check if user enters no arguments
	if ( argc == 1 ) 
	{
		// display error, tell user to enter arguments
		cout << "Error: Please enter arguments -s (required) -c -l" << endl;
		exit(0);     
	} // if
	else
	{
		// Use getopt( ) to loop through -s, -c, -l flags
		while ( (c = getopt(argc, argv, "s:c:l:")) != -1 ) 
		{
			switch (c) 
			{
				case 's': strncpy(strSetupFile, optarg, STRLEN-1);
					  // open a file using the parameters entered by user for setupfilename
					  setupFile.open (strSetupFile);		
					  break;
				case 'c': strncpy(strCMDFile, optarg, STRLEN-1);
					  // open a file using the parameters entered by user for cmdfilename
					  cmdFile.open (strCMDFile);
					  break;
				case 'l': strncpy(strLogFile, optarg, STRLEN-1);			  
					  // create a file using the parameters entered by user
					  break;
			}; // switch
		} // while
		// Use getopt( ) to loop through -s, -c, -l flags
		displayArguments();
		// check commandFlag
		bool cFlag = checkCommand(commandFlagPresent);
		// begin forking
		processSetup (words, R, X, Y, cFlag, logBool, strLogFile);

	}

	// close all files open
	closeFiles();

	// requires an integer return value
	return 0;

} // main ( )
