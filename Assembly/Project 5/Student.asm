COMMENT #
****************************************************************************** 
*File name:	 	Student.asm
*Project name:	 proj5
******************************************************************************
*Creator’s name & email:	Ishan Patel	pateli@goldmail.etsu.edu
*Course-Section:	 		CSCI 2160-001	
*Creation Date:	 			April 15, 2014
*Date Last Modification:	April 15, 2014	
*****************************************************************************
#

	.486
	.model flat
	
	intasc32 			PROTO stdcall lpStringToHoldAnswer:dword, dVal:dword
	putstring 			PROTO stdcall, lpStringToPrint:dword
	getstring 			PROTO stdcall, lpStringToHoldCharacters:dword, dlength:dword
	ascint32 			PROTO stdcall, lpStringToConvert:dword 
	memoryallocBailey	PROTO stdcall, numBytes:dword
 
Student struct
	studentName byte 20 dup(?)
	hrsCompleted 	dword	?
	hrsAttempted 	dword	?
	qualityPts 		dword	?
	currentHrs 		dword 	?
Student ends

	.code
COMMENT #
******************************************************************************
* Method Name: Student_1
* Method Purpose: default constructor which sets name of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the lpStudentName string 
*   @return address of Student_1 constructor
*****************************************************************************#
Student_1 proc stdcall USES ebx ecx edi esi, lpStudentName:dword
	INVOKE memoryallocBailey, size Student 	;give us a place in memory to store a 
											;Student ADDRESS RETURNED IN EAX!!!!!!
	mov edi, eax							;edx => address of new Student	
	assume edi:ptr Student					;edi => address of new Student
	mov ebx, lpStudentName					;ebx => the address of lpStudentName
											;string
	mov ecx, size lpStudentName				;ecx => the size of string lpStudentName
	mov esi,0								;clear esi to index into lpStudentName							
stLoop:
	mov al, byte ptr[ebx]					;al => the character of string 
											;lpStudentName
	mov [edi].studentName[esi], al			;Student's name => the character of 
											;lpStudentName
	inc esi									;increase esi to store more characters
	inc ebx									;increase ebx to get more characters
	loop stLoop								;loop to store more characters
	mov ebx, 0								;ebx => 0
	mov [edi].hrsCompleted, ebx				;Student's hrsCompleted => 0
	mov ebx, 0								;ebx => 0
	mov [edi].hrsAttempted, ebx				;Student's hrsAttempted => 0
	mov ebx, 0								;ebx => 0
	mov [edi].qualityPts, ebx				;Student's qualityPts => 0
	mov ebx, 0								;ebx => 0
	mov [edi].currentHrs, ebx				;Student's currentHrs => 0
	assume edi:nothing						;reset edi to 0
	ret										;return the address of Student_1
Student_1 endp								;end of the method Student_1

COMMENT #
******************************************************************************
* Method Name: Student_2
* Method Purpose: copy constructor
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the lpStudentToCopy  
*   @return address of Student_2 constructor
*****************************************************************************#
Student_2 proc stdcall USES ebx edx edi esi, lpStudentToCopy:dword
	INVOKE memoryallocBailey, size Student 	;give us a place in memory to store a 
											;Student ADDRESS RETURNED IN EAX!!!!!!
	mov edi, eax							;edx => address of new Student	
	assume edi:ptr Student					;edi => address of new Student
	assume esi:ptr Student					;edi => address of new Student
	mov esi, lpStudentToCopy				;esi => address of copied Student
	mov ecx, size Student.studentName		;ecx => the size of studentName field
	mov ebx,0								;clear ebx to index into stundetName
stLoop:
	mov dl, [esi].studentName[ebx]			;dl => the character of studentName
	mov [edi].studentName[ebx], dl			;Student's name => the character of 
											;string studentName
	inc ebx									;increase ebx  to get more characters
	loop stLoop								;loop to store more characters
	mov edx, [esi].hrsCompleted				;edx => copied Student's hrsCompleted
	mov [edi].hrsCompleted, edx				;Student's hrsCompleted => copied
											;Student's hrsCompleted
	mov edx, [esi].hrsAttempted				;edx => copied Student's hrsAttempted
	mov [edi].hrsAttempted, edx				;Student's hrsAttempted => copied
											;Student's hrsAttempted
	mov edx, [esi].qualityPts				;edx => copied Student's qualityPts
	mov [edi].qualityPts, edx				;Student's qualityPts => copied
											;Student's qualityPts
	mov edx, [esi].currentHrs				;edx => copied Student's currentHrs
	mov [edi].currentHrs, edx				;Student's currentHrs => copied
											;Student's currentHrs
	assume esi:nothing						;reset esi to 0
	assume edi: nothing						;reset edi to 0
	ret
Student_2 endp								;end of Student_2 method

COMMENT #
******************************************************************************
* Method Name: Student_3
* Method Purpose: copy constructor which also sets name of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the lpStudentToCopy  
*   @param1  the address of the lpStudentName  
*   @return address of Student_3 constructor
*****************************************************************************#

Student_3 proc stdcall USES ebx edx edi esi, lpStudentName:dword, lpStudentToCopy:dword
	INVOKE memoryallocBailey, size Student 	;give us a place in memory to store a 
											;Student ADDRESS RETURNED IN EAX!!!!!!
	mov edi, eax							;edx => address of new Student	
	assume edi:ptr Student					;edi => address of new Student
	assume esi:ptr Student					;edi => address of new Student
	mov ebx, lpStudentName					;ebx => the address of lpStudentName
											;string
	mov ecx, size lpStudentName				;ecx => the size of string lpStudentName
	mov esi,0								;clear esi to index into lpStudentName							
stLoop:
	mov al, byte ptr[ebx]					;al => the character of string 
											;lpStudentName
	mov [edi].studentName[esi], al			;Student's name => the character of 
											;lpStudentName
	inc esi									;increase esi to store more characters
	inc ebx									;increase ebx to get more characters
	loop stLoop								;loop to store more characters
	mov esi, lpStudentToCopy				;esi => address of lpStudentToCopy
	mov edx, [esi].hrsCompleted				;edx => copied Student's hrsCompleted
	mov [edi].hrsCompleted, edx				;Student's hrsCompleted => copied
											;Student's hrsCompleted
	mov edx, [esi].hrsAttempted				;edx => copied Student's hrsAttempted
	mov [edi].hrsAttempted, edx				;Student's hrsAttempted => copied
											;Student's hrsAttempted
	mov edx, [esi].qualityPts				;edx => copied Student's qualityPts
	mov [edi].qualityPts, edx				;Student's qualityPts => copied
											;Student's qualityPts
	mov edx, [esi].currentHrs				;edx => copied Student's currentHrs
	mov [edi].currentHrs, edx				;Student's currentHrs => copied
											;Student's currentHrs
	assume esi:nothing						;reset esi to 0
	assume edi: nothing						;reset edi to 0
	ret
Student_3 endp								;end of Student_3 method

COMMENT #
******************************************************************************
* Method Name: Student_setName
* Method Purpose: sets the name of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the address of the thus  
*   @param1  the address of the lpStudentName  
*   @return N/A
*****************************************************************************#	
Student_setName proc stdcall USES ebx ecx edi esi, thus:dword, lpStudentName:dword
	assume edi:ptr Student					;edi => address of new Student
	mov edi, thus							;edi will contain the address of Student
	mov ebx, lpStudentName					;ebx => the address of lpStudentName
											;string
	mov ecx, size lpStudentName				;ecx => the size of string lpStudentName
	mov esi,0								;clear esi to index into lpStudentName							
stLoop:
	mov al, byte ptr[ebx]					;al => the character of string 
											;lpStudentName
	mov [edi].studentName[esi], al			;Student's name => the character of 
											;lpStudentName
	inc esi									;increase esi to store more characters
	inc ebx									;increase ebx to get more characters
	loop stLoop								;loop to store more characters
	assume edi:nothing						;reset edi to 0
	ret
Student_setName endp						;End of method Student_setName

COMMENT #
******************************************************************************
* Method Name: Student_setHrsCompleted
* Method Purpose: sets the hours completed of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @param1  the dword hrs  
*   @return N/A
*****************************************************************************#	
Student_setHrsCompleted proc stdcall USES edi esi, thus:dword, hrs:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => address of the student
	.IF sdword ptr hrs > 0					;Is the user's entered hrs greter than 
											;zero?
		mov esi, hrs						;esi => user's entered hrs
		mov [edi].hrsCompleted, esi			;Student's hrsCompleted => user's entered
											;hrs
	.ENDIF
	assume edi:nothing						;reset edi to 0
	ret										
Student_setHrsCompleted endp				;end of method Student_setHrsCompleted

COMMENT #
******************************************************************************
* Method Name: Student_setHrsAttempted
* Method Purpose: sets the hours attempted of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @param1  the dword hrs  
*   @return N/A
*****************************************************************************#	
Student_setHrsAttempted proc stdcall USES edi esi, thus:dword, hrs:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => address of the student
	.IF sdword ptr hrs > 0					;Is the user's entered hrs greter than 
											;zero?
		mov esi, hrs						;esi => user's entered hrs
		mov [edi].hrsAttempted, esi			;Student's hrs => user's entered hrs
	.ENDIF
	assume edi:nothing						;reset edi to 0
	ret
Student_setHrsAttempted endp				;end of method Student_setHrsAttempted

COMMENT #
******************************************************************************
* Method Name: Student_setQualityPts
* Method Purpose: sets the quality points of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @param1  the dword pts  
*   @return N/A
*****************************************************************************#	
Student_setQualityPts proc stdcall USES edi esi, thus:dword, pts:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => address of the student
	.IF sdword ptr pts > 0					;Is the user's entered pts greter than 
											;zero?
		mov esi, pts						;esi => user's entered pts
		mov [edi].qualityPts, esi			;Student's pts => user's entered pts
	.ENDIF
	assume edi:nothing						;reset edi to 0
	ret	
Student_setQualityPts endp					;end of method Student_setQualityPts

COMMENT #
******************************************************************************
* Method Name: Student_setCurrentHrs
* Method Purpose: sets the quality points of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @param1  the dword hrs  
*   @return N/A
*****************************************************************************#	
Student_setCurrentHrs proc stdcall USES edi esi, thus:dword, hrs:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => address of hrs passed in
	.IF sdword ptr hrs > 0					;Is the user's entered hrs greter than 
											;zero?
		mov esi, hrs						;esi => user's entered pts
		mov [edi].currentHrs, esi			;Student's prss => user's entered hrs
	.ENDIF
	assume edi:nothing						;reset edi to 0
	ret
Student_setCurrentHrs endp					;end of method Student_setQualityPts

COMMENT #
******************************************************************************
* Method Name: Student_getName
* Method Purpose: gets the quality points of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return address of the name
*****************************************************************************#	
Student_getName proc stdcall USES ebx edi, thus:dword
	local sName[21]:byte
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => address of name passed in
	mov esi,0								;clear esi to index into studentName
	mov al,[edi].studentName[esi]			;al => the character of studentName
	.while(al != 0)							;Is the character is null?
		mov al, byte ptr [edi].studentName[esi]	
											;al => the character of studentName
		mov byte ptr sName[esi], al			;sName => the character of studentName
		inc esi								;increase to get more character
	.endw
	INVOKE putstring, ADDR sName			;Display localy stored string which 
											;contain name
	lea eax, [sName]						;eax => the address of local string sName
	assume edi:nothing						;reset edi to 0
	ret										;return the address of string sName
Student_getName endp						;end of the method Student_getName

COMMENT #
******************************************************************************
* Method Name: Student_getHrsCompleted
* Method Purpose: gets the hours completed of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return address of the hours completed
*****************************************************************************#
Student_getHrsCompleted proc stdcall USES edi, thus:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => the address of hrsCompleted of 
											;student
	mov eax, [edi].hrsCompleted				;eax => student's hrsCompleted
	assume edi:nothing						;reset edi to 0
	ret										;return the hrsCompleted dword
Student_getHrsCompleted endp				;end of the method Student_getHrsCompleted

COMMENT #
******************************************************************************
* Method Name: Student_getHrsAttempted
* Method Purpose: gets the hours attempted of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return address of the hours attempted
*****************************************************************************#
Student_getHrsAttempted proc stdcall USES edi, thus:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => the address of hrsAttempted of 
											;student
	mov eax, [edi].hrsAttempted				;eax => student's hrsAttempted
	assume edi:nothing						;reset edi to 0
	ret										;return the hrsAttempted dword
Student_getHrsAttempted endp				;end of the method Student_getHrsAttempted

COMMENT #
******************************************************************************
* Method Name: Student_getQualityPts
* Method Purpose: gets the quality points of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return address of the quality points
*****************************************************************************#
Student_getQualityPts proc stdcall USES edi, thus:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => the address of qualityPts of 
											;student
	mov eax, [edi].qualityPts				;eax => student's qualityPts
	assume edi:nothing						;reset edi to 0
	ret										;return the qualityPts dword
Student_getQualityPts endp					;end of the method Student_getQualityPts

COMMENT #
******************************************************************************
* Method Name: Student_getCurrentHrs
* Method Purpose: gets the current hours of student
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return address of the current hours
*****************************************************************************#
Student_getCurrentHrs proc stdcall USES edi, thus:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi, thus							;edi => the address of currentHrs of 
											;student
	mov eax, [edi].currentHrs				;eax => student's currentHrs
	assume edi:nothing						;reset edi to 0
	ret										;return the currentHrs dword
Student_getCurrentHrs endp					;end of the method Student_getCurrentHrs

COMMENT #
******************************************************************************
* Method Name: Student_gpa
* Method Purpose: to calculate gpa of student in whole number(rounded)
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return the gpa of student
*****************************************************************************#
Student_gpa proc stdcall USES ebx edx edi esi, thus:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi,thus       						;edi => the address of the Student
	.if sdword ptr [edi].qualityPts >= 0	;Is quality points is bigger than 0?
		mov eax, [edi].qualityPts			;eax => quality points of student
		cdq									;edx:eax => number of quality points
		mov ebx, [edi].hrsAttempted			;ebx => hours attempted by user
		idiv ebx							;edx => remainder, eax=> gpa of student
		mov esi, eax						;esi => gpa of the student
		mov eax, edx						;eax => remainder of gpa
		mov ebx, 2							;ebx => 2
		imul ebx							;edx:eax => the remainder of gpa
		.if(eax >= 8)						;Is gpa is bigger than .5?
			inc esi							;If yes, increase gpa
		.endif
		mov eax, esi						;eax => the gpa of the student
	.endif	
	assume edi:nothing						;reset edi to 0
	ret										;return gpa of the student
Student_gpa endp							;End of the method Student_gpa

COMMENT #
******************************************************************************
* Method Name: Student_letterGrade
* Method Purpose: To display letter grade of student based on gpa
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return the letter grade of student
*****************************************************************************#
Student_letterGrade proc stdcall USES ebx edi esi, thus:dword
	assume edi:ptr Student					;edi => the address of the Student
	mov edi,thus       						;edi => the address of the Student
	.if dword ptr [edi].qualityPts >= 0	;Is quality points is bigger than 0?
		mov eax, [edi].qualityPts			;eax => quality points of student
		cdq									;edx:eax => number of quality points
		mov ebx, [edi].hrsAttempted			;ebx => hours attempted by user
		idiv ebx							;edx => remainder, eax=> gpa of student
		mov esi, eax						;esi => gpa of the student
		mov eax, edx						;eax => remainder of gpa
		mov ebx, 2							;ebx => 2
		imul ebx							;edx:eax => the remainder of gpa
		.if(eax >= 8)						;Is gpa is bigger than .5?
			inc esi							;If yes, increase gpa
		.endif
	.endif
	.if esi > 3								;Is gpa is bigger than 3?
		mov eax, 41h						;If yes return 'A' in eax
	.elseif esi > 2							;Is gpa is bigger than 2?
		mov eax, 42h						;If yes return 'B' in eax
	.elseif esi > 1							;Is gpa is bigger than 1?
		mov eax, 43h						;If yes return 'C'in eax
	.elseif esi == 1						;Is gpa is equals to 1?
		mov esi, 44h						;If yes return 'D' in eax
	.elseif esi < 1							;Is gpa is smaller than 1?
		mov eax, 46h						;If yes return 'F' in eax
	.endif
	assume edi:nothing						;reset edi to 0
	ret										;return the letter grade
Student_letterGrade endp					;end of method Student_letterGrade

COMMENT #
******************************************************************************
* Method Name: Student_classYear
* Method Purpose: display class year of student based on how may hours completed
*
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus  
*   @return the string contains class year
*****************************************************************************#
Student_classYear proc stdcall USES ebx edx edi esi, thus:dword
	local class[4]:byte							;class => the string of class year
	assume edi:ptr Student						;edi => the address of Student
	mov edi, thus 								;edi => address of Student referenced 
	mov edx, [edi].hrsCompleted					;edx => completed hours of student
	.if edx >= 0h && edx <= 1ch					;Is completed hours between 0 and 30?
		mov bl, 66h								;bl => the character 'f'
		mov [class], bl							;pass the character 'f' to the 
												;address of class string
		mov bl, 72h								;bl => the character 'r'
		mov [class+1], bl						;pass the character 'r' to the 
												;address of class string
		mov bl, 0								;bl => null character
		mov[class+2], 0							;pass the null character to the 
												;address of class string
	.elseif edx >= 1Dh && edx <= 3Bh			;Is completed hours between 30 and 60?
		mov bl, 73h								;bl => the character 's'
		mov [class], bl							;pass the character 's' to the 
												;address of class string
		mov bl, 6Fh								;bl => the character '0'
		mov [class+1], bl						;pass the character '0' to the 
												;address of class string
		mov bl, 0								;bl => null character
		mov[class+2], 0							;pass the null character to the 
												;address of class string
	.elseif edx >= 3Ch && edx <= 59h			;Is completed hoursbetween 60 and 90?
		mov bl, 6Ah								;bl => the character 'j'
		mov [class], bl							;pass the character 'j' to the 
												;address of class string
		mov bl, 72h								;bl => the character 'r'
		mov [class+1], bl						;pass the character 'r' to the 
												;address of class string
		mov bl, 0								;bl => null character
		mov[class+2], 0							;pass the null character to the 
												;address of class string
	.else										;Is completed hoursmore than 90?
		mov bl, 73h								;bl => the character 's'
		mov [class], bl							;pass the character 's' to the 
												;address of class string
		mov bl, 72h								;bl => the character 'r'
		mov [class+1], bl						;pass the character 'r' to the 
												;address of class string
		mov bl, 0								;bl => null character
		mov[class+2], 0							;pass the null character to the 
												;address of class string
	.endif
		INVOKE putstring, ADDR class			;Display the class string to user
		lea eax, [class]						;eax => the address of class string
		assume edi:nothing						;reset edi to 0
		ret										;return address of class string
Student_classYear endp							;End of the method Student_classYear

COMMENT #
******************************************************************************
* Method Name: Student_equals
* Method Purpose: equals method to check all fields are same in both reference 
*					variables
* Date created: April 15, 2014
* Date last modified: April 15, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  the dword thus 
*	@param1 the dword other 
*   @return the byte for all fields are same or not
*****************************************************************************#
Student_equals proc stdcall USES ebx edx edi esi, thus:dword, other:dword
	assume ebx:ptr Student						;ebx =>the address of the student
	assume esi:ptr Student						;esi =>the address of the student
	mov ebx, thus								;ebx=> the address of referenec 
												;variable paased in
	mov esi, other								;esi => other student
	mov edi, 0									;clear edi to set index into 
												;studentName string
	mov eax, 1									;eax holds one as default
	.while(byte ptr [ebx].studentName != 0 && byte ptr [esi].studentName != 0)
												;Check if both string are same?
		mov dl, byte ptr [ebx].studentName[edi]	;dl => the character of student
		mov cl, byte ptr [esi].studentName[edi]	;cl => the character of other student
		.if dl != cl							;Is both claracters are NOT same?
			mov eax, 0							;If yes, set eax is equal 0 and break
			.break
		.endif
		inc edi									;increase edi to check more character
	.endw										;end of while loop
	mov edx, [ebx].hrsCompleted					;edx => hrsCompleted of the student
	.if edx != [esi].hrsCompleted				;Is hrsCompleted of the other
												;student and student are NOT same?
		mov eax, 0								;If yes, eax => 0 and break
	.endif
	mov edx, [ebx].hrsAttempted					;edx => hrsAttempted of the student
	.if edx != [esi].hrsAttempted				;Is hrsAttempted of the other
												;student and student are NOT same?
		mov eax, 0								;If yes, eax => 0 and break
	.endif
	mov edx, [ebx].qualityPts					;edx => qualityPts of the student
	.if edx != [esi].qualityPts					;Is qualityPts of the other
												;student and student are NOT same?
		mov eax, 0								;If yes, eax => 0 and break
	.endif
	mov edx, [ebx].currentHrs					;edx => currentHrs of the student
	.if edx != [esi].currentHrs					;Is currentHrs of the other
												;student and student are NOT same?
		mov eax, 0								;If yes, eax => 0 and break
	.endif
	assume esi:nothing							;reset esi to 0
	assume ebx:nothing							;reset edi to 0
	ret											;return byte containing 0 or 1 based
												;on both fields are same or not
Student_equals endp								;END of Student_equals method
	END
	