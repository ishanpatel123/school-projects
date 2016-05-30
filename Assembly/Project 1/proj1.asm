;*************************************************************************************
; Program Name:  proj1.asm
; Programmer:    Ishan Patel
; Class:         CSCI 2160
; Date:          February 21, 2014
; Purpose:
;    		Gets user input till user press enter. Display error message for invalid 
;			characters and too many digits. Calculate largest positive/negetive dword,
;			word and byte.
;*************************************************************************************  
	
	.486
	
	.model flat 
				
	.stack 100h
	ExitProcess PROTO Near32 stdcall, dwExitCode:dword
	ascint32	PROTO Near32 stdcall, lpStringOfNumericChars:dword
	intasc32	PROTO Near32 stdcall, lpStringToHold:dword, dVal:dword
	putstring	PROTO Near32 stdcall, lpStringToPrint:dword
	getstring 	PROTO Near32 stdcall, lpStringToGet:dword, dNumChars:dword
	
	.data
outputValue		sdword 	?								;Holds the correctly entered value entered by user
outputPosByte	sdword 	?								;Holds the largest positive byte
outputPosWord	sdword	?								;Holds the largest positive word
outputPosDword	sdword	?								;Holds the largest positive dword
outputNegByte	sdword	?								;Holds the largest negetive byte
outputNegWord	sdword	?								;Holds thw largest negetive word
outputNegDword	sdword	?								;Holds the largest negetive dword
strName 		byte 	10,13,09, "Name:	Ishan Patel",0	
strClass		byte 	10,13,09, "Class:	CSCI 2160-001",0	
strDate 		byte 	10,13,09, "Date:	2/21/2014  at 9:00 PM",0	
strLab 			byte 	10,13,09, "Lab:	Proj1",0	
strInputValue	byte	10,13, "Enter a value and press ENTER or just press ENTER: ",0
strCalcValue	byte	10,13,"Calculating largest dword,word, then byte",0
strPosDword		byte	10,13, "The largest positive dword is ",0
strNegDword		byte	10,13, "The largest negetive dword is ",0
strPosWord		byte	10,13, "The largest positive word is ",0
strNegWord		byte	10,13, "The largest negetive word is ",0
strPosByte		byte	10,13, "The largest positive byte is ",0
strNegByte		byte	10,13, "The largest negetive byte is ",0
strResult		byte	10,13, "You entered the numeric value: ",0
strInvalidNum	byte 	10,13, "The string you entered had an invalid digit: ",0	
strOverflowFlag byte 	10,13, "The string you entered was too large to convert to a dword: ",0
strOutput		byte	12 dup(?)						;Holds the output number entered by the user
strInput		byte	12 dup(?)						;Holds the input number entered by the user
crlf			byte	10,13,0							;To move to begining of next line

	.code
_start:
	
	INVOKE putstring, addr strName						;display programer name
	INVOKE putstring, addr strClass						;display class and section
	INVOKE putstring, addr strDate						;display data of project
	INVOKE putstring, addr strLab						;display lab name
	INVOKE putString, addr crlf							;Start a new line on the command screen
inputLoop:   											;Define this section of code so that it can be 
														;jumped too in later sections of code.
	INVOKE putstring, offset strInputValue	   			;Prompt the user for input value
	INVOKE  getstring, offset strInput, dword ptr 11	;strInput gets the user's input
	cmp byte ptr [strInput], 00h						;Is user use press enter keybyet?	
	je strDone											;If user press enter key, jump to strDone label	
	INVOKE ascint32, offset strInput 					;Convert the user's input string to numeric form in eax.
	mov outputValue, eax								;outputValue gets user's input value
	jc carry											;Check if carry flag occured, so handle it	
	jo overflow											;Check if overflow flag occured, so hadle it
	INVOKE putstring, offset strResult	 			    ;Display You entered the numeric value
	INVOKE intasc32, offset strOutput, outputValue 		;Convert outputValue to Ascii Characters
	INVOKE putstring, offset strOutput  				;and then Display outputValue
	INVOKE putString, addr crlf							;Start a new line on the command screen
	jmp loopAgain										;Jump to next label loopAgain
carry: 
		INVOKE putstring, offset strInvalidNum			;Display The string you entered had an invalid digit:	
		INVOKE putstring, offset strInput 				;Display the user value stored in strInput	
		jmp LoopAgain									;Jump to next label loopAgain
overFlow: 
		INVOKE putstring, offset strOverflowFlag 		;Display The string you entered was too large to convert to a dword	
		INVOKE putstring, offset strInput  				;Display the user value stored in strInput		
LoopAgain:	
	INVOKE putString, addr crlf							;Start a new line on the command screen
	jmp inputLoop 										;Jump to the inputLoop label. This will allow for further user input	
strDone:
	INVOKE putString, addr crlf							;Start a new line on the command screen
	INVOKE putString, addr strCalcValue					;Display Calculating largest dword,word, then byte
	INVOKE putString, addr crlf							;Start a new line on the command screen
	INVOKE putString, addr crlf							;Start a new line on the command screen
	xor eax, eax										;Clears eax register
strLoop:
	jo posDword											;check if overflow occured, so hadle it
	add eax, 01h										;Add 1 to eax till overflow occured
	jmp strLoop											;Jump to stLoop label to add more 1's
posDword:
	sub eax, 01h										;subtracting one gets a largest posible dword
	mov outputPosDword, eax								;outputPosDword -> 2,147,483,647
	INVOKE putstring, addr strPosDword					;Display The largest positive dword is  
	INVOKE intasc32, offset strOutput, outputPosDword 	;Convert outputPosDword to Ascii Characters
	INVOKE putstring, offset strOutput  				;and then Display 2,147,483,647

	INVOKE putString, addr crlf							;Start a new line on the command screen
	xor eax, eax										;Clear EAX register
strLoop2:
	add eax, 01h										;Add 1 to EAX till overflow occured
	jo NegDword											;check if overflow occured by adding one, hadle it
	jmp strLoop2										;jump to stLoop2 label to add more 1's
NegDword:
	mov outputNegDword, eax								;outputNegDword -> -2,147,483,648
	INVOKE putstring, addr strNegDword					;Display The largest negetive dword is 
	INVOKE intasc32, offset strOutput, outputNegDword 	;Convert outputNegDword to Ascii Characters
	INVOKE putstring, offset strOutput  				;And then Display -2,147,483,648
	INVOKE putString, addr crlf							;Start a new line on the command screen
	INVOKE putString, addr crlf							;Start a new line on the command screen
	xor eax, eax										;Clear EAX register
strLoop3:
	jo posWord											;Check if overflow occured, so hadle it
	add ax, 01h											;Add 1 to ax till overflow occured
	jmp strLoop3										;Jump to stLoop3 label to add more 1's
posWord:
	sub ax, 01h											;Subtracting one gets a largest posible word
	movsx eax, ax										;EAX -> 32,767
	mov outputPosWord, eax								;outputPosWord -> 32,767
	INVOKE putstring, addr strPosWord					;Display The largest positive word is 
	INVOKE intasc32, offset strOutput, outputPosWord 	;Convert outputPosWord to Ascii Characters
	INVOKE putstring, offset strOutput  				;And then Display 32,767
	INVOKE putString, addr crlf							;Start a new line on the command screen
	xor eax, eax										;Clear EAX register
strLoop4:
	add ax, 01h											;Add 1 to AX till overflow occured			
	jo NegWord											;Check if overflow occured, so hadle it
	jmp strLoop4										;Jump to stLoop4 label to add more 1's
NegWord:
	movsx eax, ax										;EAX -> -32,768
	mov outputNegWord, eax								;outputNegWord -> -32,768
	INVOKE putstring, addr strNegWord					;Display The largest negetive word is 
	INVOKE intasc32, offset strOutput, outputNegWord 	;Convert outputNegWord to Ascii Characters
	INVOKE putstring, offset strOutput  				;and then Display 127
	INVOKE putString, addr crlf							;Start a new line on the command screen
	INVOKE putString, addr crlf							;Start a new line on the command screen
	xor eax, eax										;Clear EAX register
strLoop5:
	jo posByte											;Check if overflow occured, so hadle it
	add al, 01h											;Add 1 to al till overflow occured
	jmp strLoop5										;Jump to stLoop5 label to add more 1's
posByte:
	sub al, 01h											;Subtracting one gets a largest posible byte
	movsx eax, al										;EAX -> 127
	mov outputPosByte, eax								;outputPosByte -> 127
	INVOKE putstring, addr strPosByte					;Display The largest positive byte is 
	INVOKE intasc32, offset strOutput, outputPosByte 	;Convert outputPosByte to Ascii Characters
	INVOKE putstring, offset strOutput  				;and then Display 127
	
	INVOKE putString, addr crlf							;Start a new line on the command screen
	xor eax, eax										;Clears EAX register	
strLoop6:
	add al, 01h											;Add 1 to AL till overflow occured
	jo NegByte											;Check if overflow occured, so hadle it
	jmp strLoop6										;Jump to stLoop5 label to add more 1's
NegByte:
	movsx eax, al										;EAX -> -128
	mov outputNegByte, eax								;outputNegByte -> -128
	INVOKE putstring, addr strNegByte					;Display The largest positive byte is 
	INVOKE intasc32, offset strOutput, outputNegByte 	;Convert outputNegByte to Ascii Characters
	INVOKE putstring, offset strOutput  				;and then Display -128
	INVOKE putString, addr crlf							;Start a new line on the command screen

	INVOKE ExitProcess,0								;cell supervisor to end the program
	PUBLIC _start
	END													;End the program