;************************************************************************************
;	Program:	proj6.asm
;	Programmer:	
;	Class:		CSCI 2160
;	Date:		
;	Purpose:  work with binary trees to do inorder (preorder,postorder) traversals
;		and maintain a binary tree for traversing inorder (maintaining increasing
;		order
;
;************************************************************************************
	.486
	.model flat
	.stack 100h
	ExitProcess	PROTO NEAR32 stdcall, dExitCode:DWORD
	ascint32	PROTO stdcall, lpStringToConvert:dword
	intasc32	PROTO stdcall, lpStringtoHold:dword, dVal:dword
	putstring	PROTO stdcall, lpStringToPrint:dword
	getstring	proto stdcall, lpSTringToHold:dword, dNumChars:dword
	putch		proto stdcall, dVal:dword
	getch		proto stdcall
	getche		proto stdcall
	menu		proto stdcall, lpMenu:dword,lpError:dword
	printNode	proto stdcall, nodeToPrint:dword
	findNode	proto stdcall, root:dword,value:dword,lpPred:dword,lpBranch:dword
	inorder 	proto stdcall, myRoot:dword
	preorder	proto stdcall, myRoot:dword
	postorder	proto stdcall, myRoot:dword
	addNode 	proto stdcall, lpRoot:dword ,dpred:dword,dvalue:dword,dbranch:dword
	memoryallocBailey proto stdcall, dSize:dword

newline	macro			;move to new line
	INVOKE putch,10
	INVOKE putch,13
	endm
	
node	struct
	left dword ?
	dVal dword ?
	right dword ?
node 	ends

NULL	EQU	-1
	.data
;************************************************************************************
;DO NOT INSERT ANY OF YOUR DATA IDENTIFIERS BEFORE root. Add after my comment below
;************************************************************************************
root	dword btree
btree	node <B,40,P>
B		node <A,30,D>
A		node <NULL,10,NULL>
D		node <NULL,35,NULL>
P		node <K,70,S>
K		node <J,60,M>
J		node <NULL, 50,NULL>
M		node <NULL,65,NULL>
S		node<NULL,80,V>
V		node <NULL,100,NULL>
pred	dword	?
strMenu	byte  	10,13,10,13,9,"			M E N U",10,13
		byte	10,13,9,"1> Find Node with specific value. INVOKE printNode"
		byte	10,13,9,"2> Add a Node (have key value ready to enter)"
 		byte	10,13,9,"3> Inorder Traversal"
 		byte	10,13,9,"4> Preorder Traversal (10 point bonus)"
 		byte	10,13,9,"5> PostOrder Traversal (25 pt bonus)"
 		byte	10,13,9,"6> Initialize the root to -1. Creates an empty tree"
 		byte	10,13,9,"7> *** Exit ***"
		byte	10,13,9,"8> Display the original tree as it is stored in memory"
 		byte	10,13,10,13,9,"Type number of selection and press ENTER: ",0
strInvalid		byte	10,13,10,13,9,"Invalid choice! Re-enter choice: ",0
strInorder		byte	10,13,10,13,"Inorder Traversal",0
strPreorder		byte	10,13,10,13,"Preorder Traversal",0
strPostOrder	byte	10,13,10,13,"Postorder Traversal",0
strEmptyTree	byte	10,13,"      *** EMPTY TREE *** ",0
strPressEnter	byte 	10,13,10,13,9,"Press ENTER to Continue",0
strNotDone		byte	10,13,10,13,9,"****NOT completed yet!****",10,13,0
strFinished		byte	10,13,10,13,"  All Done!!",10,13,0
strNodeHeader	byte	10,13,10,13,"Node Addrress left        value      right",0
cMenu			byte	?					;menu option
branch	dword	?
option1	equ		1
option2	equ		2
option3	equ		3
option4	equ		4
option5	equ		5
option6	equ		6
optionExit	equ	7					;option to exit
option8		equ 8
strNum1	byte 13 dup(?)
strEnterValue	byte	10,13,"What is the value? ",0
strAlreadyThere	byte	10,13,"The value you want to insert is already in the tree!",0
strCouldNotFind	byte	10,13,"The value you are looking for is NOT in the tree!",0
strValFound		byte	10,13,"The address of the found cell is ",0
strPredBranch	byte 	10,13,"  Pred and branch =  ",0
dAddress		dword	?
dValue			dword	?
;************************************************************************************
;  ADD any of your own identifiers below the line of *'s below.
;************************************************************************************

	.code
_start:
	mov	eax,0
;************************************************************************************
; You are to complete the code for each "do" block
;************************************************************************************
	INVOKE menu,ADDR strMenu,ADDR strInvalid
	mov cMenu,al								;menu option in cMenu
	.WHILE cMenu != optionExit  				;while user is not exiting
		.IF cMenu == option1						;find a node with a value
				INVOKE putstring, ADDR strNotDone
				INVOKE putstring, ADDR strPressEnter	;press ENTER to continue
				INVOKE getch
				newline
		;******************************************************************************
		;COMMENT %         ;when you get this section working, uncomment it
		;*****************************************************
			.IF root ==-1							;tree is empty
				INVOKE putstring, ADDR strEmptyTree
			.ELSE
				newline			
				INVOKE putstring, ADDR strEnterValue	;prompt user for value
				INVOKE getstring, ADDR strNum1,12		;get value from user
				INVOKE ascint32, ADDR strNum1			;convert to an int
				mov dValue,eax							;dValue = value to find
				INVOKE findNode,root,dValue,ADDR pred, ADDR branch ;find it
				.IF eax ==-1							;value not in the tree
					INVOKE putstring, ADDR strCouldNotFind ; display error mst
					newline								;display what its pred
					INVOKE putstring, ADDR strPredBranch; and whether it would be
					INVOKE intasc32, ADDR strNum1,pred	; right/left child of pred
					INVOKE putstring, ADDR strNum1		; whose address is this
					INVOKE putch, 9
					INVOKE intasc32,ADDR strNum1,branch ;0=left child of parent
					INVOKE putstring,ADDR strNum1		;1=right child of parent
				.ELSE
					INVOKE putstring, ADDR strNodeHeader
					INVOKE printNode,eax				;found it, so display all
					newline								;the information possible
					INVOKE intasc32, ADDR strNum1,eax	;about that node
					INVOKE putstring, ADDR strValFound	;message that it was found
					INVOKE putstring, ADDR strNum1		;the addr of node that has it
					INVOKE putstring, ADDR strPredBranch;whether it is left/right child
					INVOKE intasc32, ADDR strNum1,pred	;of its parent
					INVOKE putstring, ADDR strNum1		;and the address of its parent
					INVOKE putch, 9
					INVOKE intasc32,ADDR strNum1,branch
					INVOKE putstring,ADDR strNum1
				.ENDIF
				INVOKE putstring, ADDR strPressEnter	;press ENTER to continue
				INVOKE getch
			.ENDIF
			
		;****************************************************************************
		;	%			;END OF COMMENTED section
		;****************************************************************************
		.ELSEIF cMenu == option2					;add a value to the tree
			;do addNode	
			INVOKE putstring, ADDR strNotDone		
			INVOKE putstring, ADDR strPressEnter
			INVOKE getch
			newline
		;****************************************************************************
		;COMMENT %         ;when you get this section working, uncomment it
		;****************************************************************************
			INVOKE putstring,ADDR strEnterValue		;prompt user for value		
			INVOKE getstring,ADDR strNum1,12		;get its ASCII value and
			INVOKE ascint32,ADDR strNum1			;  convert it to a number
			mov dValue,eax							;dValue = value to insert
			INVOKE findNode,root,dValue,ADDR pred, ADDR branch; is it already
			mov dAddress,eax						;in the tree?
			.IF dAddress !=-1						;if it is then can't insert
				INVOKE putstring, ADDR strAlreadyThere	; it, so display all there
				INVOKE putstring, ADDR strNodeHeader
				INVOKE printNode,eax				; is to know about the node
				newline								; that contains it
				INVOKE intasc32, ADDR strNum1,eax	;display the node's address
				INVOKE putstring, ADDR strValFound	; and the fact that it was found
				INVOKE putstring, ADDR strNum1
				INVOKE putstring, ADDR strPredBranch; whether it is left/right
				INVOKE intasc32, ADDR strNum1,pred	;child of predecessor
				INVOKE putstring, ADDR strNum1		;and address of its predecessor
				INVOKE putch, 9
				INVOKE intasc32,ADDR strNum1,branch
				INVOKE putstring,ADDR strNum1
			.ELSE									;value not in the tree so
				INVOKE addNode, ADDR root, pred,dValue,branch ;can add it
				mov dAddress,eax					;dAddress = address of new node
				INVOKE putstring, ADDR strNodeHeader
				INVOKE printNode,dAddress			;display all there is to know
													;about the added node
			.ENDIF
			INVOKE putstring,ADDR strPressEnter
			newline
		;****************************************************************************
		;	%			;END OF COMMENTED section
		;****************************************************************************
				
			.ELSEIF cMenu == option3
				;do inorder traversal
				INVOKE putstring, ADDR strNotDone		
				INVOKE putstring, ADDR strPressEnter
				INVOKE getch
				newline
		;****************************************************************************
		;COMMENT %         ;when you get this section working, uncomment it
		;****************************************************************************
				.IF root ==-1							;tree is empty
					INVOKE putstring, ADDR strEmptyTree
				.ELSE
					INVOKE putstring, ADDR strInorder
					INVOKE inorder, root
					INVOKE putstring, ADDR strPressEnter	;press ENTER to continue
					INVOKE getch
					newline
				.endif
		;****************************************************************************
		;	%			;END OF COMMENTED section
		;****************************************************************************
	
			.ELSEIF cMenu == option4
				;do preorder traversal
				INVOKE putstring, ADDR strNotDone		
				INVOKE putstring, ADDR strPressEnter
				INVOKE getch
				newline
		;****************************************************************************
		;COMMENT %         ;when you get this section working, uncomment it
		;****************************************************************************
				.IF root ==-1							;tree is empty
					INVOKE putstring, ADDR strEmptyTree
				.ELSE
					INVOKE putstring, ADDR strPreorder
					INVOKE preorder, root
				.ENDIF
				INVOKE putstring, ADDR strPressEnter
				INVOKE getch
				newline
		;****************************************************************************
		;	%			;END OF COMMENTED section
		;****************************************************************************

			.ELSEIF cMenu == option5
				;do postorder traversal
				INVOKE putstring, ADDR strNotDone
				INVOKE putstring, ADDR strPressEnter
				INVOKE getch
				newline
		;****************************************************************************
		;COMMENT %         ;when you get this section working, uncomment it
		;****************************************************************************
				.IF root ==-1							;tree is empty
					INVOKE putstring, ADDR strEmptyTree
				.ELSE
					INVOKE putstring, ADDR strPostorder
					INVOKE postorder, root
				.ENDIF
				
		;****************************************************************************
		;	%			;END OF COMMENTED section
		;****************************************************************************
			.ELSEIF cMenu == option6
				;do Empty the tree
				mov	root,-1							;empty the tree
			.ELSEIF cMenu == option8
				;Display the first 10 nodes of the original tree
				mov ebx, offset bTree
				.IF ebx == root			;still the original tree
					mov ecx,10
					lea	ebx, bTree
				stLoop:
					INVOKE printNode, ebx
					add	ebx, sizeof node
					newline
					loop stLoop
				.ENDIF	
			.ENDIF	
		INVOKE menu,ADDR strMenu, ADDR strInvalid
		mov cMenu,al				;menu option in cOption
	.ENDW
		
done:	
		INVOKE putstring, ADDR strFinished
		INVOKE ExitProcess,0
		PUBLIC _start
		
menu	proc stdcall uses ebx, lpMenu:dword,lpErrorMsg:dword
	local strChoice[12]:byte
	mov ebx,lpMenu						;ebx -> menu
	INVOKE putstring, ebx				;display menu
	INVOKE getstring,ADDR strChoice,11	;get the character string rep of the number
	INVOKE ascint32, ADDR strChoice		;allows for 2-dit or more menu options
	.WHILE eax <1 || eax> 9			;make user re-enter if outside menu range
		INVOKE putstring, lpErrorMsg
		INVOKE getstring,ADDR strChoice,11;get the character string rep of the number
		INVOKE ascint32, ADDR strChoice
	.ENDW
	RET
menu endp
	END
	