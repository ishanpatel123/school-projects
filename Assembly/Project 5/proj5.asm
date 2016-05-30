COMMENT #
****************************************************************************** 
*File name:	 	proj5.asm
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
	.stack 100h
	
	ExitProcess 	PROTO stdcall,dwExitCode:dword
	ascint32		PROTO stdcall, lpStringToConvert:dword
	intasc32		proto stdcall, lpStringToHold:dword, dval:dword
	putstring 		PROTO stdcall, lpStringtoPrint:dword
	getstring		PROTO stdcall, lpStringToGet:dword, dlength:dword
	Student_1 		PROTO stdcall, lpNameOfStudent:dword
	Student_2		PROTO stdcall, lpStudentToCopy:dword
	Student_3		PROTO stdcall, lpNameOfStudent:dword, lpStudentToCopy:dword
	Student_setName PROTO stdcall, thus:dword, lpStudentName:dword
	Student_setHrsCompleted		PROTO stdcall, thus:dword, hrs:dword
	Student_setHrsAttempted 	PROTO stdcall, thus:dword, hrs:dword
	Student_setQualityPts 		PROTO stdcall, thus:dword, pts:dword
	Student_setCurrentHrs 		PROTO stdcall, thus:dword, hrs:dword
	Student_getName				PROTO stdcall, thus:dword
	Student_getHrsCompleted 	PROTO stdcall, thus:dword
	Student_getHrsAttempted 	PROTO stdcall, thus:dword
	Student_getQualityPts 		PROTO stdcall, thus:dword
	Student_getCurrentHrs 		PROTO stdcall, thus:dword
	Student_gpa					PROTO stdcall, thus:dword
	Student_letterGrade			PROTO stdcall, thus:dword
	Student_classYear			PROTO stdcall, thus:dword
	Student_equals				PROTO stdcall, thus:dword, other:dword

;structure of student
Student struct
	studentName 	byte 20 dup(?)
	_hrsCompleted 	dword	?
	_hrsAttempted 	dword	?
	_qualityPts 	dword	?
	_currentHrs 	dword 	?
Student ends

	.data
stu1 					dword ?			;holds the value stored in stu1 variable
stu2 					dword ?			;holds the value stored in stu2 variable
stu3 					dword ?			;holds the value stored in stu3 variable
stu4 					dword ?			;holds the value stored in stu4 variable
hrsCompleted 			dword ?			;holds the value stored in hrsCompleted 
										;variable
hrsAttempted 			dword ?			;holds the value stored in hrsAttempted 
										;variable
qualityPts		 		dword ?			;holds the value stored in qualityPts 
										;variable
currentHours			dword ?			;holds the value stored in currentHours 
										;variable
temp 					dword ?			;holds the value stored in temp variable
strStudentName			byte 10,13,"Enter the student's name: ",0
										;Display Enter the student's name:
strHrsCompleted			byte 10,13,"Enter the student's completed hours: ",0
										;Display Enter the student's completed hours:
strHrsAttempted			byte 10,13,"Enter the student's attempted hours: ",0
										;Display Enter the student's attempted hours:
strQualityPoints		byte 10,13,"Enter the student's quality points: ",0
										;Display Enter the student's quality points:
strCurrentHours			byte 10,13,"Enter the student's current hours: ",0
										;Display Enter the student's current hours:
strQualityPointsstu1	byte 10,13,"The quality point for stu1: ",0
										;Display The quality point for stu1: 
strHrsAttemptedstu1		byte 10,13,"The hours attempted for stu1:",0
										;Display The hours attempted for stu1:
strGPAstu2				byte 10,13,"GPA for stu2: ",0
										;Display GPA for stu2:
strLetterGradestu3		byte 10,13,"Letter grade for stu3: ",0
										;Display Letter grade for stu3:
strClassYearstu3		byte 10,13,"Classification for stu3: ",0
										;Display Classification for stu3:
strHrsCompletedStu4		byte 10,13,"The student's completed hours for stu4: ",0
										;Display The student's completed hours for 
										;stu4:
strHrsAttemptedStu4		byte 10,13,"The student's attempted hours for stu4: ",0
										;Display The student's attempted hours for 
										;stu4:
strQualityPointsStu4	byte 10,13,"The student's quality points for stu4: ",0
										;Display The student's quality points for
										;stu4:
strCurrentHoursStu4		byte 10,13,"The student's current hours for stu4: ",0
										;Display The student's current hours for stu4: 
strGetsStudentName 		byte 20 dup (?)
										;holds name of the student
strDisplay				byte 11 dup(?)
										;holds the string which passed in
	.code
_start:
	INVOKE putstring, ADDR strStudentName
										;Display Enter the student's name
	INVOKE getstring, ADDR strGetsStudentName, 19
										;strGetsStudentName holds the name of the 
										;student entered by user
	INVOKE Student_1, ADDR strGetsStudentName
										;Invoke Student_1 to create an instance
	mov stu1, eax						;reference variable stu1 => address of 
										;instance Student_1
	INVOKE putstring, ADDR strHrsCompleted
										;Display Enter the student's completed hours:
	INVOKE getstring, ADDR strDisplay, 11
										;strDisplay => the student's entered 
										;completed hours
	INVOKE ascint32, ADDR strDisplay	;convert completed hours to numeric
	mov hrsCompleted, eax				;hrsCompleted => numeric characters of 
										;completeed hours
	INVOKE Student_setHrsCompleted, stu1, hrsCompleted
										;INVOKE Student_setHrsCompleted and set the 
										;hrsCompleted
	INVOKE putstring, ADDR strHrsAttempted
										;Display Enter the student's attempted hours:
	INVOKE getstring, ADDR strDisplay, 11
										;strDisplay => the student's entered 
										;attempted hours
	INVOKE ascint32, ADDR strDisplay	;convert attempted hours to numeric
	mov hrsAttempted, eax				;hrsAttempted => numeric characters of
										;attempted hours
	INVOKE Student_setHrsAttempted , stu1, hrsAttempted
										;INVOKE Student_setHrsAttempted and set the 
										;hrsAttempted
	INVOKE putstring, ADDR strQualityPoints
										;Display Enter the student's quality points:
	INVOKE getstring, ADDR strDisplay, 11
										;strDisplay => the student's entered quality 
										;points
	INVOKE ascint32, ADDR strDisplay	;convert quality points to numeric
	mov qualityPts, eax					;qualityPts => numeric characters of quality 
										;points
	INVOKE Student_setQualityPts , stu1, qualityPts
										;INVOKE Student_setQualityPts and set the 
										;qualityPts
	INVOKE putstring, ADDR strCurrentHours
										;Display Enter the student's current hours:
	INVOKE getstring, ADDR strDisplay, 11
										;strDisplay => the student's entered current 
										;hours
	INVOKE ascint32, ADDR strDisplay	;convert current hours to numeric
	mov currentHours, eax				;currentHours => numeric characters of 
										;current hours
	INVOKE Student_setCurrentHrs, stu1, currentHours
										;INVOKE Student_setCurrentHrs and set the 
										;currentHours
	INVOKE putstring, ADDR strQualityPointsstu1
										;Display The quality point for stu1: 
	INVOKE Student_getQualityPts , stu1
										;INVOKE Student_getQualityPts and get quality
										;points
	mov qualityPts, eax					;qualityPts holds quality points	
	INVOKE intasc32, ADDR strDisplay, qualityPts
										;convert qualityPts to ascii format
	INVOKE putstring, ADDR strDisplay	;display ascii formated quality points
	INVOKE putstring, ADDR strHrsAttemptedstu1
										;Display The hours attempted for stu1:
	INVOKE Student_getHrsAttempted , stu1
										;INVOKE Student_getHrsAttempted and get 
										;attempted hours
	mov hrsAttempted, eax				;hrsAttempted holds attempted hours by 
										;student
	INVOKE intasc32, ADDR strDisplay, hrsAttempted
										;convert hrsAttempted to ascii format
	INVOKE putstring, ADDR strDisplay	;display ascii formated attempted hours
	
	INVOKE Student_gpa, stu1			;INVOKE Student_gpa and gets gpa of student 
										;using quality points and attempted hours
	INVOKE putstring, ADDR strGPAstu2	;Display GPA for stu2:
	mov temp, eax						;temp hods the gpa of student
	INVOKE intasc32, ADDR strDisplay, temp
										;convert gpa to ascii format
	INVOKE putstring, ADDR strDisplay	;display ascii formated gpa of student
	INVOKE Student_3, ADDR strGetsStudentName, stu1
										;INVOKE Student_2 using stu1 reference 
										;variable and student name
	mov stu3, eax						;reference variable stu3 => address of 
										;instance Student_3
	INVOKE putstring, ADDR strLetterGradestu3
										;Display Letter grade for stu3:
	INVOKE Student_letterGrade, stu3
										;INVOKE Student_letterGrade using reference 
										;variable stu3
	mov temp, eax						;temp holds lettergrade depending on gpa
	INVOKE putstring, ADDR temp			;display letter grade of student	
	INVOKE putstring, ADDR strClassYearstu3
										;Display Classification for stu3:
	INVOKE Student_classYear, stu3
										;INVOKE Student_classYear using reference 
										;variable stu3	
	INVOKE Student_2, stu1				;copy stu1 using copy constructor Student_2
	mov stu4, eax						;reference variable stu4 => address of stu1
	INVOKE putstring, ADDR strHrsCompletedStu4
										;Display The student's completed hours for 
										;stu4:										
	INVOKE Student_getHrsCompleted, stu4
										;INVOKE Student_getHrsCompleted using 
										;reference variable stu4
	mov temp, eax						;temp => competed hours of student
	INVOKE intasc32, ADDR strDisplay, temp
										;converts completed hours to numeric form
	INVOKE putstring, ADDR strDisplay	;display completed hours of student	
	INVOKE putstring, ADDR strHrsAttemptedStu4
										;Display The student's attempted hours for 
										;stu4:
	INVOKE Student_getHrsAttempted, stu4
										;INVOKE Student_getHrsAttempted using 
										;reference variable stu4										
	mov temp, eax						;temp => attempted hours of student
	INVOKE intasc32, ADDR strDisplay, temp
										;converts attempted hours to numeric form
	INVOKE putstring, ADDR strDisplay	;display attempted hours of student	
	INVOKE putstring, ADDR strQualityPointsStu4
										;Display The student's quality points for 
										;stu4:
	INVOKE Student_getQualityPts, stu4
										;INVOKE Student_getQualityPts using reference
										;variable stu4										
	mov temp, eax						;temp => quality points hours of student
	INVOKE intasc32, ADDR strDisplay, temp
										;converts quality points to numeric form
	INVOKE putstring, ADDR strDisplay	;Display quality points of student
	INVOKE putstring, ADDR strCurrentHoursStu4
										;Display The student's current hours for stu4: 
	INVOKE Student_getCurrentHrs, stu4	;INVOKE Student_getCurrentHrs using reference 
										;variable stu4										
	mov currentHours, eax				;temp => current hours of student
	INVOKE intasc32, ADDR strDisplay, currentHours
										;converts current hours to numeric form
	INVOKE putstring, ADDR strDisplay	;Display current hours of student
	
	Invoke ExitProcess,0				;Exit the program
	Public _start						;End of the program
	END									;end of proj4 class
	
	