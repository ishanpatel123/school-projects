/************************************************************************************
 * ---------------------------------------------------------------------------
 * File name: Project2.java
 * Project name: CSCI 1250 Project 2
 * ---------------------------------------------------------------------------
 * Author’s name: Ishan Patel	
 * Author’s email: pateli@goldmail.etsu.edu
 * Course-Section: CSCI-1250-002
 *	Creation Date:	8:16 PM 09/28/2013		
 * Last modified: 10:51 PM 10/05/2013
 * ---------------------------------------------------------------------------
 */
	

import java.text.DecimalFormat;		//to allow input from the keyboard
import java.util.Scanner;			//format the decimal numbers for output
 
/**
* Class Name: Project2 <br>
* Class Purpose: The main  method of class. It display calculate the amount of tip 
* based upon the user’s selection in DOS command window. <br>
*
* <hr>
* Date created: 09/28/2013 <br>
* Last modified: Ishan Patel, 10/05/2013, pateli@goldmail.etsu.edu
* @author Author’s Ishan Patel
*/

public class Project2
{
	/**
	 * Method Name: main <br>
	 * Method Purpose: To display a simple program in Java that should calculate the 
	 * 	amount of tip based upon the user’s selection. It should give the user a menu
	 * 	of options including the option to enter a tip percentage other than those  
	 * 	listed in the menu. It also use cleaeScreen method, pressEntertoContinue 
	 * 	method and myinfo method, so these  should give a good output format to 
	 *	this java class. <br>
	 *
	 * <hr>
	 * Date created: 09/28/2013 <br>
	 * Last modified: 10/05/2013 <br>
	 *
	 * <hr>
	 * Notes on specifications, special algorithms, and assumptions:
	 * The suggested number of tip percentages are provided in menu selection
	 * 	to calculate the total tip percentage entered by user.
	 *	Tip_Selection_1 = 0.10f;
	 *	Tip_Selection_2 = 0.15f;	
	 *	Tip_Selection_3 = 0.20f;
	 *
	 * <hr>
	 *   @param String[] args - Command Line Arguments
	 *   @return void
	*/
	
	public static void main(String[] args)
	{	
		//***************************VARIABLE DECLARATIONS***************************
		
		//-------------------------------input by user-------------------------------
		float fAmountOfPurchase;		//The amount of purchase the user buy
		int   fTipSelection = 0;		//# of percentage tip user can choose from
										//menu selection
		float fTipUserPreferred = 0;	//# of the tip which will enter by user
										//in menu selection no.4
										
		//--------------------------------calculated---------------------------------
		float fTipAmountPurchase;		//total $ of tip which will given by user
		float fTipUserConversion;		//# of the tip which will enter by user
										//in menu selection no.4 convert back to
										//percentage value
		float fTipPercentage = 0.00f;	//holds the tip selection value from menu 
										//selection entered by user
		//------------------------------other variables------------------------------
		Scanner kb = new Scanner(System.in);				
		DecimalFormat df = new DecimalFormat("$ ###.00");	//formatting numbers upto
															//two decimal places and 
															//dollar sign in Java
		DecimalFormat df1 = new DecimalFormat("##.00");		//formatting numbers upto
															//two decimal places in 
															//Java
		DecimalFormat df2 = new DecimalFormat("$ ##.00");	//formatting numbers upto
															//two decimal places and 
															//dollar sign in Java
		String strYourName = "Ishan Patel";					//holds my name

		//---------------------------------constants---------------------------------
		final float Tip_Selection_1 = 0.10f;	//# of percentage tip in user can 
												//choose from menu selection no. 1
		final float Tip_Selection_2 = 0.15f;	//# of percentage tip in user can 
												//choose from menu selection no. 2
		final float Tip_Selection_3 = 0.20f;	//# of percentage tip in user can 
												//choose from menu selection no. 3
		final float Convert_To_Decimal_Value = 100f;	//convert the user input to 
														//decimalto calculate tip 
														//selection
														
		//*************************INPUT - PROCESSING - OUTPUT***********************
		
		//---------------------------------------------------------------------------
		// Clear many lines from the DOS window
		//---------------------------------------------------------------------------		
		clearScreen( );
		
		//---------------------------------------------------------------------------
		// Short introduction myself 
		//---------------------------------------------------------------------------
		myInfo( );			//To display my short information

		//---------------------------------------------------------------------------
		// Freeze the screen till user press enter key
		//---------------------------------------------------------------------------		
		pressEnterToContinue(kb);	
		
		//---------------------------------------------------------------------------
		// Clear many lines from the DOS window
		//---------------------------------------------------------------------------		
		clearScreen( );
		
		//---------------------------------------------------------------------------
		// Welcome message to tip calculator 
		//---------------------------------------------------------------------------
		System.out.print(" ****** WELCOME TO THE TIP CALCULATOR ********"
			+ "\n\t  created by " + strYourName + "\n\n");
		
		//---------------------------------------------------------------------------
		// Freeze the screen till user press enter key
		//---------------------------------------------------------------------------	
		pressEnterToContinue(kb);	
		
		//---------------------------------------------------------------------------
		// Clear many lines again and ask user to input the amount of purchase
		//---------------------------------------------------------------------------		
		clearScreen( );
		System.out.print("Enter the amount of purchase: ");
		fAmountOfPurchase = kb.nextFloat( );
		
		//---------------------------------------------------------------------------
		// Display menu selection for user to input the tip selection
		//---------------------------------------------------------------------------
		System.out.print("\n\nPlease make a selection from the menu below" 
			+ "\n\n\n\t  Tip Calculator Menu"
			+ "\n\t-------------------------"
			+ "\n\t1. 10% tip"
			+ "\n\t2. 15% tip"
			+ "\n\t3. 20% tip"
			+ "\n\t4. Enter a tip percentage");
		System.out.print("\n\n\n\tEnter your selection: ");
		fTipSelection = kb.nextInt(); //get the user input for menu selection		
		
		//---------------------------------------------------------------------------
		// Using Switch statement, select tip selection from menu selection, which 
		// entered by user
		//---------------------------------------------------------------------------	
		switch(fTipSelection)
		{
			case 1:
				fTipPercentage = Tip_Selection_1;
				break;
			case 2:
				fTipPercentage = Tip_Selection_2;
				break;
			case 3:
				fTipPercentage = Tip_Selection_3;
				break;
			case 4:
				System.out.print("\nPlease enter the preferred tip percentage: ");
				fTipUserPreferred = kb.nextFloat();
				fTipUserConversion = (fTipUserPreferred / Convert_To_Decimal_Value);
				fTipPercentage = fTipUserConversion;
				break;
			default:
				System.out.print("\nSorry, that was an invalid selection.");
				break;
		}
		
		//---------------------------------------------------------------------------
		// Calculate: The total tip of amount of purchase
		// Amount of purchase * tip percentage
		//---------------------------------------------------------------------------
		fTipAmountPurchase = fAmountOfPurchase * fTipPercentage;
		
		//---------------------------------------------------------------------------
		// Display the calculated information to the user in a readable format
		//---------------------------------------------------------------------------
		System.out.println("\n\nA " + df1.format(fTipAmountPurchase) +"% tip for a " 
		+ df.format(fAmountOfPurchase) + " purchase would be " 
		+ df2.format(fTipAmountPurchase) + "\n");
	}//end main

	/********************************************************************************
	 * Method Name: clearScreen <br>
	 * Method Purpose: clear all info from the DOS window. <br>
	 *
	 * <hr>
	 * Date created: 09/28/2013 <br>
	 * Date last modified: 09/28/2013 <br>
	 *
	 * <hr>
	 * Notes on specifications, special algorithms, and assumptions: N/A
	 * 
	 *
	 * <hr>
	 * @param N/A
	 *   @return N/A
	 */
	public static void clearScreen()
	{
		System.out.print("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	}//end clearScreen()
	
	/********************************************************************************
	 * Method Name: pressEnterToContinue <br>
	 * Method Purpose: Press Enter key to continue. <br>
	 *
	 * <hr>
	 * Date created: 09/28/2013 <br>
	 * Date last modified: 09/28/2013 <br>
	 *
	 * <hr>
	 * Notes on specifications, special algorithms, and assumptions: N/A
	 * 
	 *
	 * <hr>
	 * @param Scanner fred - get input from keyboard to go in next line
	 * @return N/A
	 */
	public static void pressEnterToContinue(Scanner fred)
	{
		System.out.print("\n\t\t -- Press Enter to Continue --");
		fred.nextLine();
	}//end freezeScreen(Scanner)
	
	/********************************************************************************
	 * Method Name: myInfo <br>
	 * Method Purpose:  To display name of the programmer, date of
	 * 		created, Class section and Project number <br>
	 *
	 * <hr>
	 * Date created: 09/28/2013 <br>
	 * Date last modified: 09/28/2013 <br>
	 *
	 * <hr>
	 * Notes on specifications, special algorithms, and assumptions: N/A
	 * 
	 *
	 * <hr>
	 * @param  N/A
	 * @return N/A
	 */
	public static void myInfo( )
	{
		System.out.println("\n\tAuthor:\t\tIshan Patel" + 
		"\n\tClass:\t\t1250-002" + 
		"\n\tDate:\t\tOctober 6,2013" +
		"\n\tLab:\t\tProject 2\n");
	}//end myInfo
	
}//end class Project2