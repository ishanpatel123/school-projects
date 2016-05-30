;************************************************************************************
;	Program:	traversals.asm
;	Programmer:	Ishan Patel
;	Class:		CSCI 2160
;	Date:		04/21/2014
;	Purpose:  work with binary trees to do inorder (preorder,postorder) traversals
;		and maintain a binary tree for traversing inorder (maintaining increasing
;		order
;
;************************************************************************************
	.486
	.model flat

	ExitProcess	PROTO NEAR32 stdcall, dExitCode:DWORD
	ascint32	PROTO stdcall, lpStringToConvert:dword
	intasc32	PROTO stdcall, lpStringtoHold:dword, dVal:dword
	putstring	PROTO stdcall, lpStringToPrint:dword
	getstring	proto stdcall, lpSTringToHold:dword, dNumChars:dword
	putch		proto stdcall, dVal:dword
	getch		proto stdcall
	getche		proto stdcall
	tabKey 		PROTO stdCall
	newLine 	PROTO stdcall
	printNode 	PROTO stdCall, NodenodeToDisplay:dword
	memoryallocBailey proto stdcall, dSize:dword

	
node	struct
	left dword ?
	dVal dword ?
	right dword ?
node 	ends

	.code
	
COMMENT #
******************************************************************************
* Method Name: tabKey
* Method Purpose: put a tab in the line
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  N/A 
*   @return N/A
*****************************************************************************#
tabKey proc Near32 stdCall					;tabKey method
	local tab[6]:byte						;tab variable => 6 bytes big
	mov [tab], 09h							;pass the 09h to make a tab in line
	INVOKE putstring, addr tab				;put the tab key and invoke it
	ret										;return nothing
tabKey endp									;end of tabKey method

COMMENT #
******************************************************************************
* Method Name: newLine
* Method Purpose:  put a new line to display output corectly
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  N/A 
*   @return N/A
*****************************************************************************#
newLine proc Near32 stdCall					;new line method
	local line[5]:byte						;assign line as byte to become the string
	mov [line], 0Ah							;pass the 10h, 13h and 0h respectively to create a new line
	mov [line+1], 0Dh
	mov [line+2], 0h
	INVOKE putstring, addr line				;display the line in method when it invoked
	ret										;return nothing				
newLine endp								;end of newLine method

COMMENT #
******************************************************************************
* Method Name: addNode
* Method Purpose:  add a node in binary tree using memoryallocBaliey method
*					where it belongs as left or right child. And if the root
*					is empty, add a node as root
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  lpRoot 	- address of the root in binary tree
*	@param 	pred 	- address of the node's predecessor    
*	@param	value	- the value need to insert as child
*	@param	branch	- store 0 or 1 as its left child or right child
*   @return the address of the node contains value
*****************************************************************************#
addNode proc stdcall USES  ebx ecx edi esi, lpRoot:dword,pred:dword, value:dword, branch:dword
	INVOKE memoryallocBailey, size node 	;give us a place in memory to store a 
											;student ADDRESS RETURNED IN EAX!!!!!!
	mov edi, eax							;edi => address of new node	
	assume ebx:ptr node						;ebx => the address of the new node
	assume edi:ptr node						;edi => the address of the new node
	mov eax, lpRoot							;eax => the address of the node root
	mov ecx, value							;ecx => user's entered value to insert
	mov ebx, pred							;ebx => the predecessor of node
	mov esi, branch							;esi => the branch to enter a value	
	.if	edi == 0							;Is no memory left in heap?
		mov ebx, -1							;predecessor  => -1 if tree is empty
		mov eax, -1							;eax => -1 if no memory left
		mov esi,0							;esi => set the branch to 0
	.endif									;end of if loop
	.if	ebx == -1							;Is the root is empty?
		mov [edi].dVal, ecx					;If yes, new node value => user's entered
											;value
		mov [edi].left, -1					;new node's left child => -1(null)
		mov [edi].right, -1					;new node's right child => -1(null)
		mov ebx, edi						;predecessor => the address of new node
		mov [eax], edi						;address of root => new node
		mov eax, edi						;eax => return new node created
	.else									;IS the root NOT empty?
		.if [ebx].dVal > ecx				;Is the user's entered value is smaller  
											;then the value stored in current
											;predecessor ?
			mov [edi].dVal, ecx				;If yes, new node value => user's entered
											;value
			mov [edi].left, -1				;new node's left child => -1(null)
			mov [edi].right, -1				;new node's right child => -1(null)
			mov [ebx].left, edi				;predecessor 's left child => new node
			mov eax, edi					;eax => the address of predecessor 
			mov esi,0						;esi => the breach set to 0 if left child
		.elseif [ebx].dVal < ecx			;Is the user's entered value is bigger  
											;then the value stored in current
											;predecessor ?
			mov [edi].dVal, ecx				;If yes, new node value => user's entered
											;value
			mov [edi].left, -1				;new node's left child => -1(null)
			mov [edi].right, -1				;new node's right child => -1(null)
			mov [ebx].right, edi			;predecessor 's right child => new node
			mov eax, edi					;eax => the address of predecessor 
			mov esi,1						;esi => the breach set to 0 if right 
											;child
		.endif								;End of if loop
	.endif									;End of if loop
	assume edi:nothing						;reset edi to 0
	assume ebx:nothing						;reset ebx to 0
	ret										;return the address of predecessor
addNode endp								;end of the method addNode

COMMENT #
******************************************************************************
* Method Name: findNode
* Method Purpose: gets the user's input value and match with the value in 
*					the tree using this method and display information
*					according to the node is found or NOT 
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  root 		- the root of the tree
*	@param	value		- user's input
*	@param	lpPred		- the address of predecessor
*	@param	lpBranch	- the address of the branch
*   @return N/A
*****************************************************************************#
findNode proc stdcall USES ebx ecx edx edi esi, root:dword, value:dword, lpPred:dword, lpBranch:dword
	local found:dword						;local variable found
	assume ebx:ptr node						;ebx => the address of the new node
	assume ecx:ptr node						;ebx => the address of the new node
	mov ebx, root							;ebx => the address of the node
	mov esi, value							;esi => the user's entered value
	mov edi, lpPred							;edi => the address of the predecessor
	mov edx, lpBranch						;edx => the address of the lpBranch
	mov eax, -1								;set eax to -1 as default
	mov dword ptr [edx], 0					;set the value of lpBranch to 0 if tree 
											;is empty
	mov found, 0							;set found to 0 if the node does not 
											;found
	.if ebx == -1							;Is the root empty?
		mov eax, -1							;If yes, eax => -1 as tree empty
		mov dword ptr[edi], ebx				;address of predecessor => the root
		mov dword ptr[edx], 0				;address of branch => 0
	.else									;Is the root NOT empty?
		.while(found != 1)					;Is the user's entered value found yet?
			.if([ebx].dVal == esi)			;Is the user's entered value is in tree
											;and found?
				mov eax, ebx				;If yes, eax => the address of the node
				mov found, 1				;set found to 1 if the value has been 
											;found
			.elseif [ebx].dVal > esi		;Is the user's entered value is smaller 
											;than the current node's value? 
				mov dword ptr[edi], ebx		;If yes, address of the predecessor => 
											;the address of the current node
				mov dword ptr[edx], 0		;set the value of lpBranch to 0 if its
											; a left child
				mov ecx, ebx				;ecx => the address of current node
				mov ebx, [ebx].left			;address of node => the address of left
											;child of the node
			.elseif [ebx].dVal < esi		;Is the user's entered value is bigger 
											;than the current node's value?
				mov dword ptr[edi], ebx		;If yes, address of predecessor => the 
											;address the current node
				mov dword ptr[edx], 1		;set the value of lpBranch to 1 if its
											; a right child
				mov ecx, ebx				;ecx => the address of current node
				mov ebx, [ebx].right		;address of node => the address of the 
											;right node
			.endif							;end of if loop
			.if ebx == -1					;Is the tree is empty?
				mov eax, -1					;set eax to -1 as default
				.if [ecx].dVal > esi		;Is prodecessor value is smaller than
											;user's input?
					mov dword ptr [edx], 0	;set the value of lpBranch to 0 if tree 
											;is empty
				.else						;Is prodecessor value is bigger than
											;user's input?
					mov dword ptr [edx], 1	;set the value of lpBranch to 0 if tree 
											;is empty
				.endif						;end of if loop
				.break						;terminate the method. return eax as 1, 
											;and set lpBranch to 0
			.endif							;end of if loop
		.endw								;end of while loop
	.endif									;end of if loop
		assume ecx:nothing					;reset ebx to 0
		assume ebx:nothing					;reset ebx to 0
		ret									;returh the address of node
findNode endp								;end of method findNode

COMMENT #
******************************************************************************
* Method Name: inorder
* Method Purpose:traverse the tree in inorder and display the information
*					in left child, root then right child
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  root 			- the root of the tree
*   @return N/A
*****************************************************************************#
inorder proc stdCall USES eax ebx, root:dword
	local flag:dword, checkEmpty:dword	;local variables as flag and checkEmpty
	assume ebx:ptr node						;ebx => the address of the new node
	mov ebx, root							;ebx => the root of the binary tree
	mov flag, 0								;set flag 0 to check if it traverse 
											;the tree yet, 
	mov checkEmpty, 0						;set checkEmpty 0 to keep the track of 
											;the stack
	.while flag == 0						;Is method finsihed inorder traversal in
											;binary tree?
		.if ebx != -1						;Is the address of node NOT null?
			push ebx						;preserve the node in stack
			mov ebx, [ebx].left				;address of node => address of left child
			inc checkEmpty					;increase checkEmpty to keep track of 
											;stack while preserving the node
		.else
			.if checkEmpty != 0				;Is the stack is empty or did it restore
											;every node in tree and dispalyed it?
				pop ebx						;If not, restore the node
				INVOKE printNode, ebx		;display the node information in specific
											;format using printNode method
				mov ebx, [ebx].right		;address of the node => the address of
											;right child
				dec checkEmpty				;decrease checkEmpty to keep track of the
											;stack while restoring the node
			.else
				mov flag, 1					;set flag to 1, if method displayed every 
											;node in binary tree
			.endif							;end the if loop
		.endif								;end the if loop
	.endw									;end the while loop
	assume ebx:nothing						;reset the ebx to 0
	ret										;return nothing
inorder endp								;end of the inorder method

COMMENT #
******************************************************************************
* Method Name: postorder
* Method Purpose:traverse the tree in postorder and display the information
*				in left child, right child, then root,
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  root 			- the root of the tree
*	@param	lpHeader		- the address of lpheader string
*	@param	lpEmptyMessage	- the address of lpEmptyMessage string
*   @return N/A
*****************************************************************************#
postorder proc stdcall uses eax ebx esi, root:dword
	local checkEmpty:dword					;local variable checkEmpty
	assume ebx:ptr node						;ebx => the address of new node
	assume esi:ptr node						;esi => the address of new node
	mov ebx, root							;ebx => the root of the binary tree
	mov checkEmpty, 0						;set checkEmpty to 0 to keep track of 
											;stack	
	mov esi, -1								;set esi to -1 as new node
	inc checkEmpty						;increase checkEmpty to keep track of
											;the stack while preserving the address
											;of the node
	.while([ebx].left != -1)				;Is the left child of the node is null?
		push ebx							;If yes, preserve the address of node in 
											;ebx
		inc checkEmpty						;increase checkEmpty to keep track of
											;the stack while preserving the address
											;of the node
		mov ebx, [ebx].left					;address of node => the address of node's
											;left child
	.endw
	.while( ebx != -1)						;Is the address of the node is null?
		.if checkEmpty == 0					;Is the stack is empty or did it restore
											;every node in tree and dispalyed it?
			.break							;If yes, break and end the method
		.endif								;end of the if loop
		.if (([ebx].right == -1)|| ([ebx].right == esi))
											;Is the right child of the node is null
											;or the right child of node is same as
											;new node in esi?
			INVOKE printNode, ebx			;If yes,display the node information in 
											;specific format using printNode method
			mov esi, ebx					;address of new node in esi => address
											;of the node in ebx
			dec checkEmpty					;decrease checkEmpty to keep track of
											;stack while restoring the address of
											;the node
			.if checkEmpty != 0				;Is the stack is empty or did it restore
											;every node in tree and dispalyed it?
				pop ebx						;restore the address of the node in ebx
			.endif							;end of the if loop
		.else
			push ebx						;preserve the address of node in ebx
			inc checkEmpty					;increase checkEmpty to keep track of
											;the stack while preserving address of 
											;the node
			mov ebx, [ebx].right			;address of node => the address of node's
											;right child
			.while (([ebx].left != -1) && (checkEmpty != 0))
											;Is the address of left child null and
											;checkEmpty is 0 or displayed every node
											;in tree?
				push ebx					;If no, preserve the address of the node
											;in ebx
				inc checkEmpty				;increase checkEmpty to keep track of
											;the stack while preserving address of 
											;the node
				mov ebx, [ebx].left			;address of node => the address of node's
											;left child
			.endw							;end of while loop
		.endif								;end of if loop
	.endw									;end of while loop
	assume esi:nothing						;reset esi to 0
	assume ebx:nothing						;reset ebx to 0
	ret										;return nothing
postorder endp								;end of the postorder method

COMMENT #
******************************************************************************
* Method Name: preorder
* Method Purpose:traverse the tree in preorder and display the information
*				in root, left child then right child
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  root 			- the root of the tree
*	@param	lpHeader		- the address of lpheader string
*	@param	lpEmptyMessage	- the address of lpEmptyMessage string
*   @return N/A
*****************************************************************************#
preorder proc stdCall USES eax ebx, root:dword
	local flag:dword, checkEmpty:dword		;local variables flag and checkEmpty
	assume ebx:ptr node						;ebx => the address of the new node
	mov ebx, root							;ebx => the root of the binary tree
	mov flag, 0								;set flag to 0 to check method displayed
											;every node in tree
	mov checkEmpty, 0						;set checkEmpty to 0 to keep track of 
											;stack
	.while flag == 0						;Is method finsihed preorder traversal in
											;binary tree?
		.while ebx != -1					;Is the address of the node NOT null?
			INVOKE printNode, ebx			;display the node information in specific
											;format using printNode method
			push ebx						;preserve the node stored in ebx
			mov ebx, [ebx].left				;address of the node => the address of 
											;node's left child
			inc checkEMpty					;increase checkEmpty to keep stack of the 
											;stack while preserving the node
		.endw
		.if checkEmpty != 0					;Is the stack is empty or did it restore
											;every node in tree and dispalyed it?
			pop ebx							;restore the node in ebx
			mov ebx, [ebx].right			;address of node => address of the node's
											;right child
			dec checkEMpty					;decrease checkEmpty to keep track of 
											;stack while restoring the node
		.else
			mov flag, 1						;set flag to 1, if method displayed every 
											;node in binary tree
		.endif								;end of if loop
	.endw									;end of while loop
	assume ebx:nothing						;reset the ebx to 0
	ret										;return nothing
preorder endp								;End of the method preorder

COMMENT #
******************************************************************************
* Method Name: printNode
* Method Purpose:  display the address of the node, node's value, node's left
*					child and right child in specific format
*
* Date created: April 21, 2014
* Date last modified: April 21, 2014
* 
* Notes on specifications, special algorithms, and assumptions:
*   notes go here
*
*   @param  NodenodeToDisplay - the address of the node to display
*   @return N/A
*****************************************************************************#
printNode proc stdCall USES eax ebx, NodenodeToDisplay:dword
	local display[12]:byte, found:dword		;local variables display and found
	assume ebx:ptr node						;ebx => the address of the new node
	mov ebx, NodenodeToDisplay				;ebx => the address of node
	INVOKE newLine							;display a new line
	INVOKE intasc32, addr display, ebx		;convert the address of node to numeric 
											;form
	INVOKE putstring, addr display			;display the address of node which stored
											;in eax
	INVOKE tabKey							;put a tab in to the line
	INVOKE intasc32, addr display, [ebx].left
											;convert the left child of node to  
											;numeric form	
	INVOKE putstring, addr display			;display left child which stored in eax
	INVOKE tabKey							;put a tab in to the line
	INVOKE intasc32, addr display, [ebx].dVal
											;convert the value of node to numeric
											; form	
	INVOKE putstring, addr display			;display the value of the node which 
											;stored in eax
	INVOKE tabKey							;put a tab in to the line
	INVOKE intasc32, addr display,[ebx].right
											;convert the right child of node to  
											;numeric form	
	INVOKE putstring, addr display			;display right child which stored in eax
	assume ebx:nothing						;reset ebx to nothing
	ret										;return nothing
printNode endp								;end of the method printNode
END											;END of class traversals
		
