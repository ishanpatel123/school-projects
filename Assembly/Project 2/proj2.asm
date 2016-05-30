;*************************************************************************************
; Program Name:  proj2.asm
; Programmer:    Ishan Patel
; Class:         CSCI 2160
; Date:          March 5, 2014
; Purpose:
;    		Gets user input limited to 10 charcters per dowrd. User can only enter 10
;			dwords at maximum number. THis program adds up all the dwords,which display 
;			dwords and sum of those dwords as output when user hit enter key as input.
;*************************************************************************************  
	
	.486
	.model flat
	.stack 100h
	ExitProcess PROTO Near32 stdcall, dwExitCode:dword  
	putstring   PROTO Near32 stdcall, lpStringToDisplay:dword
	intasc32	PROTO Near32 stdcall, lpStringToHold:dword, dVal:dword
	ascint32	PROTO Near32 stdcall, lpStringOfNumericChars:dword
	extern getcharecho:near32, getchar:near32
	extern putchar:near32

	.data
inputNumber1		dword 	11 dup(?)						;stores user's input					
outputDwordSum1		dword 	11 dup(?)						;stores output of dword's sum
strPrompt			byte	10,13, "Enter a numeric string up to 10 characters: ",0
strInvalidNum		byte 	10,13, "The string you entered had an invalid digit: ",0	
strOverflowFlag 	byte	10,13, "The string you entered was too large to convert to a dword: ",0
strDisplayDwords	byte	10,13, "Display All the Dwords: ",0
strDisplaySumDwords	byte	10,13, "Display Sum of Dwords : ",0
strGetsMaxDwords	byte	10,13, "Can't get more than 10 dwords!",0
pressEnterToCont	byte	10,13, "	*** Press Enter To Continue ***",0
crlf 				byte	10,13,0							;advance to a newline
strTab				byte	9,0								;display a tab into line
strInput  			byte	11 dup(?)  						;will hold an input string up to 10 characters
strOutput  			byte	11 dup(?)  						;will hold an input string up to 10 characters
	

	.code
_start:
	xor esi, esi											;set esi to zero to index into dword
	xor ecx, ecx											;set ecx to zero to count max 10 dwords
inputLoop:
	cmp ecx, 10												;did user already typed correct 10 dwords?
	je strMaxDwords											;if yes, display all dwords and sum of dwords
	invoke putstring,ADDR strPrompt							;Display Enter a numeric string up to 10 characters:
	mov	ebx,0												;ebx indexes into the string
	mov edi,10												;edi indexes to get max ten character per dword
stLoop:
	call getchar											;get a character without echo from the keyboard
	cmp	al,0dh												;did user just hit the ENTERkey?
	jne HitBackspaceYet										;if not, check if user hitbackspace key
	jmp  stringDone											;jump to null terminate the string
HitBackspaceYet:	
	cmp al, 08h												;did user hit the backspace key?
	jne insertcharacter 									;no, so put the character into memory
	cmp ebx,0												;at the beginning of the line
	je	stloop												;go get another character
	push	eax												;preserve what is in eax
	mov	al, 08												;prime the al register with character to display backspace
	push	eax												;preserve what is in eax
	call putchar											;display the character backspace
	add	esp,4												;restore the stack pointer
	push	eax												;preserve what is in eax
	mov	al, ' '												;prime the al register with character to display space
	push	eax												;preserve what is in eax
	call putchar											;display the character space
	add	esp,4												;restore the stack pointer
	push	eax												;preserve what is in eax
	mov	al, 08												;prime the al register with character to display backspace
	push	eax												;preserve what is in eax
	call putchar											;display the character backspace
	add	esp,4												;restore the stack pointer	
	dec ebx													;decrease index od string after hit backspace key
	jmp stLoop												;go get another character
insertcharacter:
	cmp ebx, edi											;Is user entered 10 or more characters yet?
	jge stLoop												;If yes, jump to check for is it backspace or enter key
	push eax												;preserve what is in eax
	call putchar											;display the charaters
	add  esp,4												;Restore the Stack Pointer
	mov	strInput[ebx],al									;Store the input character into the strInput
	inc ebx													;inc ebx to store more charaters in strInput
	jmp	stLoop												;Jump to get more characters
	
stringDone:
	mov	strInput[ebx],0										;Null-terminate the string
	cmp byte ptr [strInput], 00h							;Check if user use enter key to display dwords
	je dwordDisplay											;Jump to dwordDisplay to display dwords
	INVOKE ascint32, offset strInput 						;Convert the user's input from ASCII to numeric string							 
	jc carry												;Check if carry flag occured, so handles it
	jo overflow												;Check if overflow flag occured, so hadle it
	mov inputNumber1[esi], eax								;inputNumber1 => user's input which is in eax 
	inc ecx													;increase ecx till 10 dwords entered by user
	add esi, 4												;restore the Stack Pointer
	INVOKE putstring, ADDR crlf								;Go to newline
	jmp inputLoop											;Jump to the inputLoop label. This will allow for further user input	
					
carry: 
	INVOKE putstring, offset strInvalidNum					;Display The string you entered had an invalid digit:	
	INVOKE putstring, ADDR strInput							;Display user's typed input
	INVOKE putstring, ADDR crlf								;Go to new line
	jmp inputLoop 											;Jump to the inputLoop label. This will allow for further user input	

overFlow: 
	INVOKE putstring, offset strOverflowFlag 				;Display The string you entered was too large to convert to a dword	
	INVOKE putstring, ADDR strInput							;Display user's typed input
	INVOKE putstring, ADDR crlf								;Go to new line
	jmp inputLoop 											;Jump to the inputLoop label. This will allow for further user input	

strMaxDwords:
	INVOKE putstring, ADDR strGetsMaxDwords					;Can't get more than 10 dwords!
	INVOKE putstring, ADDR crlf								;go to newline
	INVOke putstring, ADDR pressEnterToCont					;Display *** Press Enter to Continue ***
	INVOKE putstring, ADDR crlf								;go to newline

PressEnterToContinue:	
	call getchar											;get a character from keyboard
	cmp al, 0Dh												;Is user pressed enter key yet?
	jne PressEnterToContinue								;If not, jump to get enter key from user
	jmp dwordDisplay										;If yes, jump to display dwords and sum of dwords
dwordDisplay:
	xor esi, esi											;set esi to zero which indexes into dwords
	xor ebx, ebx											;set EBX to zero to get a dword
	xor edx, edx											;set edx to zero
	xor edi, edi											;set edi to zero
	INVOKE putstring, ADDR crlf								;go to newline	
	cmp ecx,0
	je strDone
	INVOKE putstring, ADDR strDisplayDwords					;Display Display All the Dwords: 

strDisplay:
	mov ebx, inputNumber1[esi]								;ebx => input dword
	cmp edi, ecx											;Is it end of dwords?
	je strDone												;If yes, display sum of dowrds
	INVOKE intasc32, offset strOutput, inputNumber1[esi]	;Convert inputNumber1 to Ascii Characters
	INVOKE putstring, offset strOutput  					;and then Display inputNumber1
	add esi, 4												;restore the stack pointer
	add edx, ebx											;edx += inputNumber1
	inc edi
	INVOKE putstring, ADDR crlf								;go to newline	
	INVOKE putstring, ADDR strTab							;display tab key in line
	INVOKE putstring, ADDR strTab							;display tab key in line
	INVOKE putstring, ADDR strTab							;display tab key in line
	jmp strDisplay											;jump to strDisplay to get/display more dwrods

strDone:
	INVOKE putstring, ADDR strDisplaySumDwords				;display Display Sum of Dwords :
	mov outputDwordSum1, edx								;outputDwordSum1 => sum of Dwords
	INVOKE intasc32, offset strOutput, outputDwordSum1		;Convert outputDwordSum1 to Ascii Characters
	INVOKE putstring, offset strOutput  					;and then Display outputDwordSum1
	INVOKE putstring, ADDR crlf								;go to newline	

	Invoke ExitProcess,0									;Exit the program
	Public _start
	END														;End of the program