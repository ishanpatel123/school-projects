COMMENT #
****************************************************************************** 
*File name:	 	proj3.asm
*Project name:	 proj3
******************************************************************************
*Creator’s name & email:	Ishan Patel	pateli@goldmail.etsu.edu
*Course-Section:	 		CSCI 2160-001	
*Creation Date:	 			March 21, 2014
*Date Last Modification:	March 22, 2014	
*****************************************************************************
#
	.486
	.model flat
	.stack 100h
	ExitProcess PROTO Near32 stdcall,dwExitCode:dword  
											;capitalization not necessary
	putstring 	PROTO Near32 stdcall,lpStringToPrint:dword
	getch		PROTO Near32 stdcall 		; get a character from the keyboard w/o 
											;displaying
	getche		PROTO Near32 stdcall 		; get a character from the keyboard and 
											;display it
	putch		PROTO Near32 stdcall,cLetter:byte
	getstring	PROTO Near32 stdcall,lpStringToGet:dword, numchars:dword
	ascint32	PROTO Near32 stdcall,lpStringToConvert:dword
	intasc32	PROTO Near32 stdcall,lpStringToHold:dword,numToConvert:dword
	extern menuB:near32, stringCompareIgnoreCaseB:near32,  oneWordPerLineB:near32
	extern inputArrayB:near32, totalArrayB:near32, displayDwordArrayB:near32
	
	.data
dInputArray				dword 	11 dup(?)	;stores user's input dwords					
dNumEntries				dword	?			;stores a number of dwords enter by user
dTotalOfDwords			dword	?			;stores total of dwords
MenuDisplay  byte 10,13,9,9,"           M E N U                                   "
		byte 10,13,9,9,"1> Get a string, convert to lowercase                     "
		byte 10,13,9,9,"2> get a string and convert to uppercase                  "
		byte 10,13,9,9,"3> Get two strings and compare them                       "
		byte 10,13,9,9,"4> Get a string and display individual words one per line "
		byte 10,13,9,9,"5> Input a max of 10 dwords                               "
		byte 10,13,9,9,"6> Display array of dwords as well as total               "
		byte 10,13,9,9,"7> Exit the program                                       "
		byte 10,13,9,9,"                                                          "
		byte 10,13,9,9,"Enter your selection: ",0
choice					byte 	?			;stores option from the user
crlf					byte 	10,13,0		;Display a new line
strTerminateProg		byte 	10,13,"Have A Good Day!",0
											;Display Have A Good Day!
strLowerCase			byte 	10,13,"String to convert to lowercase: ",0
											;Display String to convert to lowercase:
strPutsLowerCase		byte 	10,13,9,"Lowercase: ",0
											;Display Lowercase:
strGetsLowerCase		byte 	81 dup (?)	;holds lowercase string up to 80 
											;characters entered by useer
strUpperCase			byte 	10,13,"String to convert to uppercase: ",0
											;Display String to convert to uppercase:
strPutsUpperCase		byte 	10,13,9,"Uppercase: ",0
											;Display Uppercase:
strGetsUpperCase		byte 	81 dup (?)	;holds uppercase string up to 80 
											;characters entered by useer
strCompareString1		byte 	10,13,"Enter compare string 1: ",0
											;Display Enter compare string 1: 
strGetsCompareString1	byte 	81 dup (?)	;holds comparestring1 string up to 80 
											;characters entered by useer	
strCompareString2		byte 	10,13,"Enter compare string 2: ",0
											;Display Enter compare string 2: 
strGetsCompareString2	byte 	81 dup (?)	;holds comparestring2 string up to 80 
											;characters entered by useer	
strSameStrings			byte 	10,13,"Strings are the same",0
											;Display Strings are the same
strNotSameStrings		byte 	10,13,"Strings are NOT the same",0
											;Display Strings are NOT the same
strCompareStrings		byte 	?			;holds a byte containg the bothe compare
											;strings are same or NOT
strOneWordPerLine		byte 	10,13,"Enter string to one word per line: ",0
											;Display Enter string to one word per 
											;line: 
strGetsOneWordPerLine	byte 	81 dup (?)	;holds string to display one word per 
											;line up to 80 characters entered by
											;user
strInputArray			byte 	11 dup (?)	;holds to string input dword upto 10 
											;characters
strDisplayDwords		byte	10,13,"The array of dwords is below: ",0
											;Diaplay The array of dwords is below: 
strDisplayNumDwords		byte	11 dup (?)	;holds to display dword into ascii upto
											; 10 characters
strTotalDwords			byte	10,13,"Total: ",0
											;Display TOtal:
strTotalDwordArray	byte	11 dup (?)		;holds upto 10 character to display total
											;of dword array
	.code
_start:
inputLoop:
	push offset MenuDisplay					;address of the string MenuDisplay 
	call menu								;call a method to display menu and get
											;choice from the user
	add esp,4								;restore a stack pointer
	mov choice, al							;choice => user's input between 1 to 7
	INVOKE putstring, addr crlf				;Display a new line
	cmp choice, 31h							;Is user's choice to get string and 
											;convert to lowercase string?
	je lowerCase							;If yes, jump to get string and display 
											;lowercase string
	cmp choice, 32h							;Is user's choice to get string and 
											;convert to uppercase string?
	je upperCase							;If yes, jump to get string and display 
											;uppercase string
	cmp choice, 33h							;Is user's choice to get two strings and 
											;compare them?
	je compareStrings						;If yes, jump to get and compare strings
	cmp choice, 34h							;Is user's choice to get string and 
											;display one word per line?
	je wordPerLine							;If yes, jump to get string and display 
											;one word per line
	cmp choice, 35h							;Is user's choice to get 10 dwords and 
											;store them into array of dwords?
	je inputDwords							;If yes, jump to get and store 10 dwords
											; in array
	cmp choice, 36h							;Is uer's choice is to display all dwords
											;and total of dwords array?
	je displayDwords						;If yes, jump to display all dwords and 
											;total of dwords array
	cmp choice, 37h							;Is user's choice to end the program?
	je exitProgram							;If yes, terminate the program

;Get a string from user and call the method stringToUpperCase convert the string 
;to lowercse and display it
lowerCase:
	INVOKE putstring, addr strLowerCase		;Display String to convert to lower case: 
	INVOKE getstring, offset strGetsLowerCase, dword ptr 80		
											;Gets the user's input for lowercase and 
											;store as strGetsLowerCase	
	push offset strGetsLowerCase			;Address of the string strGetsLowerCase 
											;which user's entered
	call stringToLowerCase					;use a method to convert string to 
											;lowercase
	add esp, 4								;restore a stack pointer
	INVOKE putstring, addr crlf				;Go to new line
	INVOKE putstring, ADDR strPutsLowerCase	;Display Lowercase:
	INVOKE putstring, ADDR strGetsLowerCase	;Display user's input as lowercase
	jmp pressEnterToCont					;Jump to display Press Enter to Continue
											;and get enter key from user

;Get a string from user and call the method stringToUpperCase convert the string 
;to uppercase and display it		
upperCase:
	INVOKE putstring, addr strUpperCase		;Display String to convert to lower case: 
	INVOKE getstring, offset strGetsUpperCase, dword ptr 80			
											;Gets the user's input for uppercase and
											;store as strGetsUpperCase	
	push offset strGetsUpperCase			;Address of the string strGetsUpperCase 
											;which user's entered
	call stringToUpperCase					;use method convert string to uppercase
	add esp, 4								;restore a stack pointer
	INVOKE putstring, addr crlf				;Go to new line
	INVOKE putstring, ADDR strPutsUpperCase	;Display uppercase:
	INVOKE putstring, ADDR strGetsUpperCase	;Display user's input as uppercase
	jmp pressEnterToCont					;Jump to display Press Enter to Continue 
											;and get enter key from user

;Gets two string from user, call the method stringCompareIgnoreCase to compare both
;strings and display both strings are same or not								
compareStrings:
	INVOKE putstring, addr strCompareString1 
											;Display Enter compare string 1: 
	INVOKE getstring, offset strGetsCompareString1, dword ptr 80	
											;Gets user input and store it as 
											;strGetsCompareString1 for string compare
	INVOKE putstring, addr strCompareString2						
											;Display Enter compare string 2: 
	INVOKE getstring, offset strGetsCompareString2, dword ptr 80	
											;Gets the user's input store it as 
											;strGetsCompareString2 for string compare	
	push offset strGetsCompareString2		;Address of the string 
											;strGetsCompareString2 which user's enter
	push offset strGetsCompareString1		;Address of the string 
											;strGetsCompareString1 which user's enter
	call stringCompareIgnoreCase			;use a method to compare two strings are 
											;same or not
	add esp,4								;restore a stack pointer
	mov strCompareStrings, al				;strCompareStrings => byte contain 0 or 1
											;to check strings are same
	cmp strCompareStrings, 1				;Is two strings which user entered same?
	je  sameStrings							;If yse, jump to display Strings are same
	INVOKE putstring, ADDR crlf				;Display a new line
	INVOKE putstring, ADDR strNotSameStrings
											;Display Strings are NOT the same
	jmp PressEnterToCont					;Jump to display Press Enter to Continue 
											;and get enter key from user
sameStrings:								
	INVOKE putstring, ADDR crlf				;Display a new line
	INVOKE putstring, ADDR strSameStrings	;Display Strings are the same
	jmp pressEnterToCont					;Jump to display Press Enter to Continue 
											;and get enter key from user

;Gets a string from user, call method oneWordPerLine and display one word per line. 
;If there is tab, comma, period and space eliminate from word										
wordPerLine:
	INVOKE putstring, ADDR strOneWordPerLine						
											;Display Enter string to one word per 
											;line: 
	INVOKE getstring, offset strGetsOneWordPerLine, dword ptr 80	
											;Gets user input and store it as 
											;strGetsOneWordPerLine
	push offset strGetsOneWordPerLine		;Address of string strGetsOneWordPerLine 
											;which user's entered
	call oneWordPerLine						;use method to display one word per line
	add esp, 4								;restore a stack pointer
	jmp pressEnterToCont					;Jump to display Press Enter to Continue 
											;and get enter key from user

;call a method inputArray to gets 10 dwords and store them to array of dwords										
inputDwords:
	push offset strInputArray				;Address of string strInputArray to get 
											;dwords
	push offset dInputArray					;Address of string dInputArray to store 
											;dwords
	call inputArray							;call methods to get 10 max dwords 
	add esp, 8								;restore a stack pointer
	mov dNumEntries, eax					;strNumsOfDwords => number of dword enter
	jmp pressEnterToCont					;Jump to display Press Enter to Continue 
											;and get enter key from user

;call a method to display all the dwords stored in array of dwords and then display
;total									
displayDwords:													
	INVOKE putstring, addr strDisplayDwords	;Display The array of dwords is below: 
	push offset strDisplayNumDwords			;Address of string which display dword 
											;line by line	
	push offset dInputArray					;Address of string dInputArray has dwords
	call displayDwordArray					;call method to display dwords user enter
	add esp, 8								;restore a stack pointer

	push dNumEntries						;the number of dwords entered by user
	push offset dInputArray					;Address of string dInputArray has dwords
	call totalArray							;call method to display total of dwords
	add esp, 8								;restore a stack pointer
	mov dTotalOfDwords, eax					;dTotalOfDwords => total of dwords
	INVOKE putstring, addr strTotalDwords	;Display Total: 
	INVOKE intasc32, addr strTotalDwordArray, dTotalOfDwords		
											;Convert dTotalOfDwords to Ascii Chars
	INVOKE putstring, addr strTotalDwordArray		
											;and then Display sum of dowrd
	jmp pressEnterToCont					;Jump to display Press Enter to Continue 
											;and get enter key from user

;Freeze the screen, call the method pressEnterToContinue to get enter key from user									
pressEnterToCont:	
	call pressEnterToContinue				;use a method to get Enter key from user
	INVOKE putstring, addr crlf				;Go to new line
	INVOKE putstring, addr crlf				;Go to new line
	jmp inputLoop							;Jump to the inputLoop label.  This will 
											;allow for further user input

;terminate the program											
exitProgram:
	INVOKE putstring, addr crlf				;Go to new line
	INVOKE putstring, addr strTerminateProg	
											;Display Have A Good Day!		
	INVOKE putstring, addr crlf				;Go to new line
	Invoke ExitProcess,0					;Exit the program
	Public _start							;End of the program

COMMENT #
******************************************************************************
* Method Name: displayDwordArray
* Method Purpose: display all the dwords entered by user
*
* Date created: March 21, 2014
* Date last modified: March 22, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the strDisplayNumDwords string 
*	@param1	the address of the dInputArray dword
*   @return a byte containing the number of dwords entered
*****************************************************************************#
displayDwordArray	proc
	push ebp							;preserve base pointer
	mov ebp, esp						;preserve a stack pointer
	push eax							;preserve registers
	push ebx
	push ecx
	push esi
	mov ebx, [ebp+8]					;ebx => the address of the dInputArray dword
	mov esi, [ebp+12]					;esi => the address of strDisplayNumDwords 
										;string
	mov ecx, 10							;ecx => max 10 dwords entered by user
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
stLoop:
	cmp dword ptr [ebx] , 0				;Is there are no dwords?
	je done								;If yes, jump to display zero as total of 
										;dwords
	cmp dword ptr [ebx] , -1			;Is the user entered less than 10 dwords?
	je done								;If yes, jump to display total of dwords
	INVOKE intasc32, addr [esi], [ebx]	;Convert address of dInputArray to Ascii 
										;Characters
	INVOKE putstring, addr [esi]		;and then Display dInputArray
	add ebx, 4							;Increase to display more dwords
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
	loop stLoop							;jump to display more dwords entered by user
done:
	pop esi								;restore registers
	pop ecx
	pop ebx
	pop eax
	mov esp, ebp						;restore the stack pointer
	pop ebp								;restore the base pointer
	ret									;return a choice of hex character
displayDwordArray	endp				;end of menu method

COMMENT #
******************************************************************************
* Method Name: inputArray
* Method Purpose: gets dword from user input and convert and store dwords into 
* into array. Only allow to input max 10 dwords.
*
* Date created: March 21, 2014
* Date last modified: March 22, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the strInputArray string 
*	@param1	the address of the dInputArray dword
*   @return a byte containing the number of dwords entered
*****************************************************************************#
inputArray 	proc
	push ebp							;preserve base pointer
	mov ebp, esp						;preserve a stack pointer
	push ebx							;Preserve registers
	push ecx
	push edi
	push esi
	mov edi, [ebp+8]					;edi => the address of dword dInputArray
	mov ebx, [ebp+12]					;ebx => the address of string strInputArray
	xor ecx, ecx						;clear ecx to return how many dwords entered
	xor esi, esi						;set esi to get only 10 characters from user
	mov esi, 10							;esi => only allow toget ten characters from 
										;user
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
stLoop:
	cmp ecx, 10							;Is user already entered 10 dwords?
	je done								;If yes jum to done
	INVOKE putch, 'E'					;Display 'E'
	INVOKE putch, 'n'					;Display 'n'
	INVOKE putch, 't'					;Display 't'
	INVOKE putch, 'e'					;Display 'e'
	INVOKE putch, 'r'					;Display 'r'
	INVOKE putch, ' '					;Display ' '
	INVOKE putch, 'a'					;Display 'a'
	INVOKE putch, ' '					;Display ' '
	INVOKE putch, 'D'					;Display 'D'
	INVOKE putch, 'w'					;Display 'w'
	INVOKE putch, 'o'					;Display 'o'
	INVOKE putch, 'r'					;Display 'r'
	INVOKE putch, 'd'					;Display 'd'
	INVOKE putch, ':'					;Display ':'
	INVOKE putch, ' '					;Display ' '
	INVOKE getstring, addr [ebx], 10	;get the dword from user and store as address 
										;of string strInputArray
	cmp byte ptr [ebx], 00h				;Check if user hit enter key to display dword
	je addTrailerValue					;Jump to dwordDisplay to display dwords
	INVOKE ascint32, addr  [ebx]		;Convert the user's input from ASCII to 
										;numeric string							 
	mov dword ptr [edi], eax			;The address of dword dInputArray => user's 
										;input dword which is in eax 
	inc ecx								;increase ecx till 10 dwords entered by user
	add edi, 4							;restore the Stack Pointer
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
	jmp stLoop							;jump to get more dowrds from user
addTrailerValue:
	mov dword ptr [edi], -1
done:
	mov eax, ecx						;eax => the number of dwords entered
	pop esi								;preserve registers
	pop edi
	pop ecx
	pop ebx
	mov esp, ebp						;restore the stack pointer
	pop ebp								;restore the base pointer
	ret									;return a choice of hex character
inputArray 	endp						;end of menu method

COMMENT #
******************************************************************************
* Method Name: menu
* Method Purpose: Displays a selection of actions that the user
*  can take to perform string operations, build an array of dwords,
*  total and display them
*
* Date created: March 21, 2014
* Date last modified: March 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the menu string 
*   @return a byte containing the selection number from the menu
*****************************************************************************#
menu	proc
	push ebp							;preserve base pointer
	mov ebp, esp						;preserve a stack pointer
	push ebx							;Preserve registers
	push ecx							
	push esi							
	mov esi, [ebp+8]					;esi => string menuDisplay
	INVOKE putstring, addr [esi]		;display string menuDisplay stored in [esi]
stLoop:
	INVOKE getch						;get character without echo from the keyboard
	mov bl, 31h							;bl => choice 1 which may can user enter
	mov ecx, 7							;ecx => user only can have 1 to 7 choice
correctChoice:
	cmp bl, al							;Is user's enter choice between 1 to 7?
	je done								;If yes, display a choice
	inc bl								;Increase bl to check if user's enter choice 
										;between 2 to 7
	loop correctChoice					;Jump to check which choice user entered
	jmp stLoop							;Jump to get choice between 1 to 7 from user,  
										;other characters are not allowd
done:
	INVOKE putch, al					;display user's choice between 1 to 7
	add esp,4							;restore stack pointer
	pop esi								;restore registers
	pop ecx								
	pop ebx
	mov esp, ebp						;restore the stack pointer
	pop ebp								;restore the base pointer
	ret									;return a choice of hex character
menu 	endp							;end of menu method

COMMENT #
******************************************************************************
* Method Name: oneWordPerLine
* Method Purpose: gets a null terminated string and parses the string and displays 
* one word on a line. Eliminate space, comma, tab, and period from string
*
* Date created: March 21, 2014
* Date last modified: March 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the strOneWordPerLine string 
*   @return N/A
*****************************************************************************#
oneWordPerLine proc
	push ebp							;preserve base pointer
	mov ebp, esp						;preserve a stack pointer
	push eax							;preserve registers
	push ebx							
	push esi
	mov ebx, [ebp+8]					;ebx => address of the strOneWordPerLine 
										;string 
	xor esi, esi						;set esi to zero to index into string 
										;strOneWordPerLine
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
stLoop:
	cmp byte ptr [ebx+esi],0			;Is this end of string strOneWordPerLine?
	je Done								;If yes, return the string strOneWordPerLine
	mov al, byte ptr [ebx+esi]			;al => the character of string
										;strGetsLowerCase
	cmp al, 20h							;Is this character is space key?
	je newLine							;If yes, jump to null terminate the word 
										;and display new line
	cmp al, 09h							;Is this character is tab key?
	je newLine							;If yes, jump to null terminate the word and 
										;display new line
	cmp al, 2Eh							;Is this character is period key?
	je newLine							;If yes, jump to null terminate the word and 
										;display new line
	cmp al, 2Ch							;Is this character is comma key?
	je newLine							;If yes, jump to null terminate the word and 
										;display new line
	INVOKE putch, al					;display the character from string 
										;strOneWordPerLine
	inc esi								;increase esi to get more character from 
										;string strOneWordPerLine
	jmp stLoop							;jump to get more character
newLine:
	INVOKE putch, 0						;null terminate a word string
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
stNextChar:
	inc esi								;increase esi to check next character is 
										;separator						
	mov al, byte ptr [ebx+esi]			;al => the next character of string 
										;strGetsLowerCase
	cmp al, 20h							;Is this character is space key?
	je stNextChar						;If yes, jump to null terminate the word and
										;display new line
	cmp al, 09h							;Is this character is tab key?
	je stNextChar						;If yes, jump to null terminate the word and 
										;display new line
	cmp al, 2Eh							;Is this character is period key?
	je stNextChar						;If yes, jump to null terminate the word and 
										;display new line
	cmp al, 2Ch							;Is this character is comma key?
	je stNextChar						;If yes, jump to null terminate the word and 
										;display new line
	cmp al,0							;Is this end of string strOneWordPerLine?
	je Done								;If yes, return the string strOneWordPerLine
	jmp stLoop							;jump to get more character
Done:
	INVOKE	putch, 0					;null terminate the last word
	pop esi								;restore the registers
	pop ebx
	pop eax
	mov esp, ebp						;restore the stack pointer
	pop ebp								;restore the base pointer
	ret									;return a choice of hex character
oneWordPerLine endp						;end of oneWordPerLine method

COMMENT #
******************************************************************************
* Method Name: pressEnterToContinue
* Method Purpose: Freeze the screen, display Press Enter to continue message, 
* utill user hit enter key
*
* Date created: March 21, 2014
* Date last modified: March 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  N\A 
*   @return N\A
*****************************************************************************#
pressEnterToContinue	proc
	push ebp							;preserve base pointer
	mov ebp, esp						;preserve a stack pointer
	push eax
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
	INVOKE putch, 0Ah					;display a new line
	INVOKE putch, 0Dh					;display a carriage return
	INVOKE putch, 9h					;display a tab key
	INVOKE putch, '*'					;display '*' 
	INVOKE putch, '*'					;display '*' 
	INVOKE putch, '*'					;display '*'
	INVOKE putch, ' '					;display 'P'
	INVOKE putch, 'P'					;display 'P'
	INVOKE putch, 'r'					;display 'r'
	INVOKE putch, 'e'					;display 'e'
	INVOKE putch, 's'					;display 's'
	INVOKE putch, 's'					;display 's'
	INVOKE putch, ' '					;display ' '
	INVOKE putch, 'E'					;display 'E'
	INVOKE putch, 'n'					;display 'n'
	INVOKE putch, 't'					;display 't'
	INVOKE putch, 'e'					;display 'e'
	INVOKE putch, 'r'					;display 'r'
	INVOKE putch, ' '					;display ' '
	INVOKE putch, 'T'					;display 'T'
	INVOKE putch, 'o'					;display 'o'
	INVOKE putch, ' '					;display ' '
	INVOKE putch, 'C'					;display 'C'
	INVOKE putch, 'o'					;display 'o'
	INVOKE putch, 'n'					;display 'n'
	INVOKE putch, 't'					;display 't'
	INVOKE putch, 'i'					;display 'i'
	INVOKE putch, 'n'					;display 'n'
	INVOKE putch, 'u'					;display 'u'
	INVOKE putch, 'e'					;display 'e'
	INVOKE putch, ' '					;display ' '
	INVOKE putch, '*'					;display '*'
	INVOKE putch, '*'					;display '*'
	INVOKE putch, '*'					;display '*'
stLoop:
	INVOKE getch						;get character without echo from the keyboard
	cmp	al,0dh							;did user just hit the ENTER key yet?
	jne stLoop							;if not,freeze screen till user hit enter key 
done:
	pop eax								;restore register
	mov esp, ebp						;restore the stack pointer
	pop ebp								;restore the base pointer
	ret									;return a choice of hex character
pressEnterToContinue 	endp			;end of pressEnterToContinue method

COMMENT #
******************************************************************************
* Method Name: stringCompareIgnoreCase
* Method Purpose: compare both strings and check if both string are same or
* not regardless of capitalization
*
* Date created: March 21, 2014
* Date last modified: March 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of  the strGetsCompareString1 string
*   @param1 the address of  the strGetsCompareString2 string
*   @return the byte containing strings are same or not
*****************************************************************************#
stringCompareIgnoreCase		proc
	push ebp							;preserve base pointer
	mov ebp, esp						;preserve a stack pointer
	push ebx							;preserve registers
	push edx
	push edi
	push esi
	mov esi, [ebp+8]					;esi => address of  strGetsCompareString1
	mov edi, [ebp+12]					;esi => address of  strGetsCompareString2
	xor eax, eax						;set eax to 0 to return byte from method
	mov al, 1							;al => 1 as default to return as same strings
stLoop:
	mov  bl, byte ptr [esi]				;bl => first character of string 
										;strGetsCompareString1
    mov  dl, byte ptr [edi]				;dl => first character of string 
										;strGetsCompareString2
    cmp  bl,0    						;Is this end of string strGetsCompareString1?
    jne  stString1Upper    				;If not, jump to check if it is uppercase or 
										;lowercase
    cmp  dl,0    						;Is this end of string strGetsCompareString2?
    jne  stString1Upper					;If not, jump to check if it is uppercase or 
										;lowercase
    jmp  done							;jump done to return both strings are same or 
										;not      			
stString1Upper:
	cmp bl, 61h							;Is the character of string 
										;strGetsCompareString1 lowercase?
	jl stString2Upper					;If not, check strGetsCompareString2 
										;character is lowercase
	cmp bl, 7Ah							;Is the character of string 
										;strGetsCompareString1 lowercase?
	jg stString2Upper					;If not, check strGetsCompareString2 
										;character is lowercase
	sub bl, 20h							;covert strGetsCompareString1 from lowercase 
										;characte to uppercasse
stString2Upper:
	cmp dl, 61h							;Is the character of string 
										;strGetsCompareString2 lowercase?
	jl stComapreString					;If not, jump to compare both strings
	cmp dl, 7Ah							;Is the character of string 
										;strGetsCompareString2 lowercase?
	jg stComapreString					;If not, jump to compare both strings
										;strGetsCompareString1, strGetsCompareString2
	sub dl, 20h							;covert strGetsCompareString2 from lowercase 
										;characte to uppercasse
stComapreString: 
	inc  esi      						;Increase esi to get and compare more 
										;characters of strGetsCompareString1
    inc  edi							;Increase edi to get and compare more 
										;characters of strGetsCompareString2
    cmp  bl,dl   						;Is string strGetsCompareString1 and string 
										;strGetsCompareString2 are same?
    jne  notSameStrings 				;If not, jump to return as not same strings
	jmp stLoop							;jump to get more characters         		
notSameStrings:
	mov al,0							; al => 0 to return both strings are NOT same
done:	
	pop esi								;restore the registers
	pop edi
	pop edx
	pop ebx
	mov esp, ebp						;restore the stack pointer
	pop ebp								;restore the base pointer
	ret									;return a character for strings same or NOT
stringCompareIgnoreCase		endp		;end of stringCompareIgnoreCase method

COMMENT #
******************************************************************************
* Method Name: stringToLowerCase
* Method Purpose: gets a string from user, convert to lowercase and display
* a string
*
* Date created: March 21, 2014
* Date last modified: March 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of  the Lowercase string
*   @return N\A
*****************************************************************************#
stringToLowerCase	proc
	push ebp								;preserve base pointer
	mov ebp, esp							;preserve a stack pointer
	push eax								;Preserve registers
	push ebx
	push edi
	mov ebx, [ebp+8]						;ebx => the address of string
											;strGetsLowerCase
	xor edi, edi							;set edi to zero to index into string 
											;strGetsLowerCase
stLoop:
	cmp byte ptr [ebx+edi], 0				;Is this end of string strGetsLowerCase?
	je done									;If yes, return string strGetsLowerCase
	mov al, byte ptr [ebx+edi]				;al => the character of  strGetsLowerCase
	cmp al, 41h 							;Is the character of  strGetsLowerCase 
											;lowercase?
    jl addToString 							;If yes, add character back to address of 
											;string strGetsLowerCase
    cmp al, 5Ah								;Is the character of string 
											;strGetsLowerCase lowercase?
    jg addToString							;If yes, add character back to address of 
											;;string strGetsLowerCase
	add al, 20h								;If this is Uppercase, then convert to 
											;lowercase
	mov byte ptr [ebx+edi],al				;string strGetsLowerCase => character
	inc edi									;inc edi to store more charaters in 
											;output string strGetsLowerCase
	jmp stLoop								;jump to get more characters
addToString:
	mov byte ptr [ebx+edi], al				;string strGetsLowerCase => character
	inc edi									;inc edi to store more charaters in  
											;string strGetsLowerCase
	jmp stLoop								;jump to get more characters

done:
	mov byte ptr [ebx+edi], 0				;Null-terminate the string 
											;strGetsLowerCase
	pop edi									;restore registers
	pop ebx
	pop eax	
	mov esp, ebp							;restore the stack pointer
	pop ebp									;restore the base pointer
	ret										;return nothing
stringToLowerCase 	endp					;end of stringToLowerCase method

COMMENT #
******************************************************************************
* Method Name: stringToUpperCase
* Method Purpose: gets a string from user, convert to uppercase and display
* a string
*
* Date created: March 21, 2014
* Date last modified: March 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of  the Uppercase string
*   @return N\A
*****************************************************************************#
stringToUpperCase	proc
	push ebp								;preserve base pointer
	mov ebp, esp							;preserve a stack pointer
	push eax								;Preserve registers
	push ebx
	push edi
	mov ebx, [ebp+8]						;ebx => the address of string 
											;strGetsUpperCase
	xor edi, edi							;set edi to zero to index into string 
											;strGetsUpperCase
stLoop:
	cmp byte ptr [ebx+edi], 0				;Is this end of string strGetsUpperCase?
	je done									;If yes, return string strGetsUpperCase
	mov al, byte ptr [ebx+edi]				;al => the character of strGetsUpperCase
	cmp al, 61h 							;Is the character of string 
											;strGetsUpperCase lowercase?
    jl addToString 							;If not, add character back to address of
											;string strGetsUpperCase
    cmp al, 7Ah								;Is the character of string 
											;strGetsUpperCase Lowercase?
    jg addToString							;If yes, add character back to address of 
											;string strGetsUpperCase
	sub al, 20h								;If this is Uppercase, then convert to 
											;lowercase
	mov byte ptr [ebx+edi],al				;string strGetsUpperCase => character
	inc edi									;inc edi to store more charaters in 
											;output string strGetsUpperCase
	jmp stLoop								;jump to get more characters
addToString:
	mov byte ptr [ebx+edi], al				;string strGetsUpperCase => character
	inc edi									;inc edi to store more charaters in 
											;output string strGetsUpperCase
	jmp stLoop								;jump to get more characters
done:
	mov byte ptr [ebx+edi], 0				;Null-terminate string strGetsUpperCase
	pop edi									;restore registers
	pop ebx
	pop eax	
	mov esp, ebp							;restore the stack pointer
	pop ebp									;restore the base pointer
	ret										;return nothing
stringToUpperCase 	endp					;end of stringToUpperCase method

COMMENT #
******************************************************************************
* Method Name: totalArray
* Method Purpose: gets all the dwords, calculate total of all dwords and
* return the total
*
* Date created: March 21, 2014
* Date last modified: March 22, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  The address of string dInputArray which has dwords
*  	@param1	The number of dwords entered by user 
*	@return total of dwords
*****************************************************************************#
totalArray	proc
	push ebp								;preserve base pointer
	mov ebp, esp							;preserve a stack pointer
	push ebx								;preserve the register
	push ecx
	mov ebx, [ebp+8]						;ebx => Address of string dInputArray 
											;which has dwords
	mov ecx, [ebp+12]						;edi => the number of dwords entered
	xor eax, eax							;clear eax to hold total of dwords
	cmp ecx, 0								;Is there are no dwords?
	je done									;jump to return total of dwords
stLoop:
	add eax, [ebx]							;eax => the sum of dwords
	add ebx, 4								;Increase ebx to add more dwords
	loop stLoop								;jump to add more dwords
done:
	pop ecx									;restore registers
	pop ebx
	mov esp, ebp							;restore the stack pointer
	pop ebp									;restore the base pointer
	ret										;return total of dwords
totalArray 	endp							;end of stringToUpperCase method
	END										;end of proj3 class
	 