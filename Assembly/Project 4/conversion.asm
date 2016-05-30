COMMENT #
****************************************************************************** 
*File name:	 	conversion.asm
*Project name:	 proj4
******************************************************************************
*Creator’s name & email:	Ishan Patel	pateli@goldmail.etsu.edu
*Course-Section:	 		CSCI 2160-001	
*Creation Date:	 			March 4, 2014
*Date Last Modification:	March 5, 2014	
*****************************************************************************
#
	
	.486
	.model flat
	
	.code
COMMENT #
******************************************************************************
* Method Name: asciiToInteger
* Method Purpose: Convert ascii characters input to the numeric value
*
* Date created: March 4, 2014
* Date last modified: March 5, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the lpStringWithNumericChars string 
*   @return the value stored in eax
*****************************************************************************#
asciiToInteger proc stdCall USES ebx  ecx edx esi, lpStringWithNumericChars:dword
	local minusSignFlag:dword				;minusSignFlag is set the flag if it is 
											;negetive number
	mov ebx, lpStringWithNumericChars		;ebx => the address of the string 
											;lpStringWithNumericChars which entered
											;by user
	mov esi, 10								;esi => 10 to divide the number stored at
											;the address of the string 
											;lpStringWithNumericChars
	mov minusSignFlag, 0					;minusSignFlag => 0 till negetive number
											;entered by user
	.IF(byte ptr [ebx] != 0)				;Is this end of lpStringWithNumericChars?
		.while(byte ptr[ebx] == " ")		;Is the character of string 
											;lpStringWithNumericChars space?						
			inc ebx							;If yes, increase ebx to get more 
											;character from lpStringWithNumericChars
		.ENDW								;End of while loop
		.IF(byte ptr[ebx] != 0)				;Is this end of lpStringWithNumericChars?
			xor eax, eax					;Clear eax to return the value entered by
											;user if it it correctly entered
			.IF(byte ptr[ebx] == "-")		;Is this character a negetive sign?
				mov minusSignFlag, 1		;If yes, minusSignFlag to 1, which says
											;user entered negetive number
				inc ebx						;increase ebx to get more character from
											;lpStringWithNumericChars
			.ENDIF							;End of if loop
			.WHILE (byte ptr[ebx] != 0)		;Is this end of lpStringWithNumericChars?
				.IF(byte ptr[ebx] > 29h && byte ptr[ebx] < 40h)
											;Is this character is between 0 and 9?
					imul esi				;If yes, multiple character with 10 
											;stored in esi
					.IF(OVERFLOW?)			;Is overflow occured by multiplying 10
											;with character?
						mov eax, 0			;If yes, clear eax and return nothing
						clc					;Clear the carry flag
						.Break				;terminate the method. return eax as 0, 
											;and overflow flag
					.ENDIF					;End of if loop
					mov ecx, 0				;clear ecx to move character from
											;string lpStringWithNumericChars at cl
					mov cl, byte ptr [ebx]	;cl => the character from the string 
											;lpStringWithNumericChars				
					sub cl, 30h				;Subract cl to make numeric character
					.IF (minusSignFlag == 0);Is this minusSignFlag 0?
						add eax, ecx		;Add numeric character to eax
					.ELSE
						sub eax, ecx		;Subract numeric character to eax
					.ENDIF					;End of if loop
				.ELSE						;is the character NOT between 0 to 9?
					mov eax, 0				;Clear eax and return nothing in eax
					stc						;Set carry flag for invalid characters
					.break					;Terminate the method. return eax as 0, 
											;and carry flag
				.ENDIF						;End of if loop
				.IF(OVERFLOW?)				;Is overflow occured by multiplying 10
											;with character?
					mov eax, 0				;If yes, clear eax and return nothing
					clc						;Clear the carry flag
					.Break					;terminate the method. return eax as 0, 
											;and overflow flag
				.ENDIF						;End of if loop
				.IF(!OVERFLOW?)				;Is the overflow flag NOT set yet?
					inc ebx					;increase ebx to get more character from
											;lpStringWithNumericChars
				.ENDIF						;End of if loop
			.ENDW							;End of while loop
		.ENDIF								;End of if loop
	.ENDIF									;End of if loop
	ret										;return the value stored in eax
asciiToInteger endp							;End of the method asciiToInteger 

COMMENT #
******************************************************************************
* Method Name: integerToAscii
* Method Purpose: Convert the numeric value to ascii characters
*
* Date created: March 4, 2014
* Date last modified: March 4, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the lpStringToHoldChars string 
*	@param1	dVal dword
*   @return Nothing
*****************************************************************************#
integerToAscii proc stdCall USES eax ecx edx esi, lpStringToHoldChars:dword, dVal:dword
	mov eax, dVal							;eax => the dowrd which user entered
	mov esi, lpStringToHoldChars			;edx => the string to convert dowrd to ascii
											;characters
	mov ecx, 10								;ecx => only allow to convert 10 dword 
											;charcters to aascii charaters
	mov edx,	0							;edx => null terminate the string to display 
											;on command line
	push dx									;preserve null character in dx
	.IF(sdword ptr eax == 0)				;Is the dowrd is equal to 0?
		add dl, 30h							;add dl with 30 to dispay '0' ascii character
		push dx								;preserve 30h which is in dx
	.ELSEIF(sdword ptr eax < 0)				;Is dowrd is smaller than 0?
		cdq									;edx:eax => the dword entered by user
		mov ecx, 0FFFFFFF6h					;ecx => -10
		idiv ecx							;edx => remainder of dword entered
		neg edx								;make remainder positive what is in edx
		add dl, 30h							;add dl with '0' to dispay make a ascii character
		push dx								;preserve what is in dx
		mov ecx, 10							;make ecx positive again to check if it's 
											;digit later
	.ENDIF
	.IF(sdword ptr eax != 0)				;Is dVal is not equal to 0?
		.WHILE(sdword ptr eax != 0)			;Is dVal is not equal to 0?
			cdq								;edx:eax => dword
			idiv ecx						;edx => remainder of dword, eax: quotient of dword
			add dl, 30h						;add dl with '0' to dispay make a ascii character
			push dx							;preserve what is in dx
		.ENDW
		mov eax, dVal						;eax => dVal
		.IF(sdword ptr eax < 0)				;Is dVal is not smaller to 0?
				mov dl, 2Dh					;dl => negetive sign '-' character
				push dx						;preserve what is in dx
		.ENDIF
	.ENDIF
	pop ax									;restore what is in ax
	mov byte ptr[esi], al					;lpStringToHoldChars => the ascii character of dowrd
	.WHILE(sbyte ptr al != 0)				;Is al not equals to null character?
		inc esi								;increase esi to grab next character
		pop ax								;preserve what is in ax
		mov byte ptr[esi], al				;lpStringToHoldChars => the ascii character of dowrd
	.ENDW
	ret										;return nothing
integerToAscii endp							;end of the method integerToAscii
	END										;END of conversion class