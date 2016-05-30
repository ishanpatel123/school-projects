/************************************************************************************
* -----------------------------------------------------------------------------------
* File name: Project4.java
* Project name: CSCI 1250 Project 4
* -----------------------------------------------------------------------------------
* Author Name: Ishan Patel
* Author E-mail: pateli@goldmail.etsu.edu
* Course-Section: CSCI-1250-002
* Creation Date: 11/02/2013
* Date of Last Modification: 11/02/2013
* -----------------------------------------------------------------------------------
*/ 

/************************************************************************************
* Class Name: Project4 <br>
* Class Purpose:simple program in Java that should  use methods, information and 
* calculated information which writtern in BookOrder and display it by creating the 
* object. This class also use methods writtern in utility class to make it in nice 
* format.
*
* Date created: 11/02/2013 <br>
* Date last modified: 11/02/2013
* @author Ishan Patel
*/

public class Proj4
{
	/**********************************************************************************
	* Method Name: main <br>
	* Method Purpose: To display a simple program in Java that should use information 
	* and calculated information which writtern in BookOrder and display it by  
	* creating the object. This class also use methods writtern in utility class to
	*  make it in nice format. <br>
	*
	* <hr>
	* Date created: 11/02/2013 <br>
	* Date last modified: 11/02/2013 <br>
	*
	* <hr>
	* Notes on specifications, special algorithms, and assumptions:
	* Set number of books of copyB by  -5
	* copyA and copyB are original copy of BookOrder instance
	*
	* <hr>
	* @param String[] args - Command Line Arguments
	*/
	public static void main(String[] args)
	{
		//***************************VARIABLE DECLARATIONS***************************
		//-------------------------------Other Variable-------------------------------
		String strDate = "11-06-2013";			//The date of project
		String strAssignment = "Project 4";		//the assignment name
		String author; 							//holds the author of book		
		String title;							//holds the title of book
		int quantity; 							//holds the quantity of books in order	
		double costPerBook; 					//holds the cost of the books in order	
		String orderDate;						//holds the order date of the books
		double weight;							//holds the weight of ordered book
		char type;								//holds the type of shipping type
		String invoice;							//holds the information of invoice	
		//*************************- OUTPUT PROCESSING -***********************
		//---------------------------------------------------------------------------
		// Clear many lines from the DOS window
		//---------------------------------------------------------------------------	
		Utility.clearScreen();
		//---------------------------------------------------------------------------
		// Display to Introduce myself 
		//---------------------------------------------------------------------------
		Utility.myInfo(strDate, strAssignment);
		//---------------------------------------------------------------------------
		// Freeze the screen till user press enter key
		//---------------------------------------------------------------------------	
		Utility.PressEnterToContinue( );
		//---------------------------------------------------------------------------
		// Clear many lines from DOS window
		//---------------------------------------------------------------------------		
		Utility.clearScreen( );
		//---------------------------------------------------------------------------
		// Create a new object and display information of BookOrder class which has 
		// instance named bookOrder
		//---------------------------------------------------------------------------				
		BookOrder bookOrder  = new BookOrder("Tolstoy","War and Peace",10,5.50,"11/06/2012"
			,6.0,'N');
		//---------------------------------------------------------------------------
		// Create a new object of BookOrder class and instance called copyA. It copy 
		// original BookOrder
		//---------------------------------------------------------------------------				
		BookOrder copyA =new BookOrder(bookOrder);
		//---------------------------------------------------------------------------
		// Create a new object of BookOrder class and instance called copyB. It copy 
		// original BookOrder
		//---------------------------------------------------------------------------				
		BookOrder copyB = new BookOrder(bookOrder);
		copyB.setQuantity(-5);	//set quantity of books to -5		
		//---------------------------------------------------------------------------
		// Display information of BookOrder class
		//---------------------------------------------------------------------------		
		invoice = bookOrder.toString();
			invoice = bookOrder.invoice();

		System.out.println("\n\n"+ invoice);
	}
	
	public static String f()
	{
		return "Ishan Patel";
	}
}	