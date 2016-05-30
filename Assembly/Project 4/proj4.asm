COMMENT #
****************************************************************************** 
*File name:	 	proj4.asm
*Project name:	 proj4
******************************************************************************
*Creator’s name & email:	Ishan Patel	pateli@goldmail.etsu.edu
*Course-Section:	 		CSCI 2160-001	
*Creation Date:	 			March 4, 2014
*Date Last Modification:	March 4, 2014	
*****************************************************************************
#
	.486
	.model flat
	.stack 100h
	ExitProcess 	PROTO Near32 stdcall,dwExitCode:dword  
									;capitalization not necessary
	putstring 		PROTO Near32 stdcall,lpStringToPrint:dword
	getch			PROTO Near32 stdcall 	
									;get a character from the keyboard w/o 
									;displaying
	getche			PROTO Near32 stdcall 	
									;get a character from the keyboard and display
									;it
	putch			PROTO Near32 stdcall,cLetter:byte
	getstring		PROTO Near32 stdcall,lpStringToGet:dword, numchars:dword
	ascint32		PROTO Near32 stdcall,lpStringToConvert:dword
	intasc32		PROTO Near32 stdcall,lpStringToHold:dword,numToConvert:dword
	integerToAscii 	PROTO Near32 stdCall, lpStringToHoldChars:dword, dVal:dword
	asciiToInteger 	PROTO Near32 stdCall, lpStringWithNumericChars:dword
	
	.data
output			dword 	?			;Hold the correctly entered value entered by user
strPrompt		byte	10,13, "Enter a string (Press Enter to quit): ",0
									;Display Enter a string (Press Enter to quit):
strResult		byte	10,13, "You entered string: ",0
									;Display You entered the numeric value: 
strInvalidNum	byte 	10,13, "INVALID STRING ",0
									;Display INVALID STRING 
strOverflow 	byte 	10,13, "OVERFLOW",0	
									;Display OVERFLOW
crlf			byte 	10,13,0		;Display a new line
strInput		byte	20 dup(?)	;Holds the input number entered by user
strOutput		byte	12 dup(?)	;Holds the output number entered by user

	.code
_start:

	INVOKE putstring,ADDR strPrompt	;Display Enter a string (Press Enter to quit): 
	INVOKE  getstring, ADDR strInput, dword ptr 19	
									;strInput gets the user's input
	.WHILE(byte ptr [strInput] != 00h)
									;IS user press the enter key yet? If yes, then 
									;terminate the program
									
		INVOKE asciiToInteger, ADDR strInput	
									;Convert the user's input string to numeric form 
									;in eax.
		.IF(CARRY?)					;Check if carry flag occured, so handle it	
			INVOKE putstring, offset strInvalidNum			
									;Display The string you entered had an invalid 
									;digit:	
		.ELSEIF(OVERFLOW?)			;Check if carry flag occured, so handle it	
			INVOKE putstring, offset strOverflow 		
									;Display The string you entered was too large to 
									;convert to a dword	
		.ELSE
			add eax, 05h			;Add 5 to value stored in eax	
			mov output, eax			;outputValue gets user's input value
			INVOKE putstring, ADDR strResult
									;Display You entered the numeric value
			
			INVOKE integerToAscii, ADDR strOutput, output
									;Convert outputValue to Ascii Characters
			INVOKE putstring, ADDR strOutput  				
									;and then Display outputValue
		.ENDIF
		INVOKE putstring,ADDR strPrompt	
									;Display Enter a numeric string up to 10 
									;characters:
		INVOKE  getstring, ADDR strInput, dword ptr 11		
									;strInput gets the user's input
	.ENDW
	Invoke ExitProcess,0			;Exit the program
	Public _start					;End of the program
	END								;end of proj4 class
	