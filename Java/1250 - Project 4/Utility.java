/************************************************************************************
* -----------------------------------------------------------------------------------
* File name: Utility.java
* Project name: CSCI 1250 Project 3
* -----------------------------------------------------------------------------------
* Author Name: Ishan Patel
* Author E-mail: pateli@goldmail.etsu.edu
* Course-Section: CSCI-1250-002
* Creation Date: 10/17/2013
* Date of Last Modification: 10/17/2013
* -----------------------------------------------------------------------------------
*/

import java.util.Scanner;	//to allow input from the keyboard

/************************************************************************************
* Class Name: Project3 <br>
* Class Purpose: This program is also has cleaeScreen method, pressEntertoContinue 
* method and myinfo method, so these should give good output format to project3.java 
* class.<hr>
* 
*
* Date created: 10/17/2013 <br>
* Date last modified: 10/17/2013
* @author Ishan Patel
*/
public class Utility
{
	/**  
	 * Method Name: clearScreen <br>
	 * Method Purpose: clear all info from the DOS window <br>
	 *
	 * <hr>
	 * Date created: 10/17/2013 <br>
	 * Date last modified: 10/17/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param  none
	 *   @return nothing
	 */
	public static void clearScreen( )
	{
		System.out.print("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	}//end clearScreen( )

	/**  
	 * Method Name: PressEnterToContinue <br>
	 * Method Purpose: freeze the screen till user press enter key <br>
	 *
	 * <hr>
     * Date created: 10/17/2013 <br>
	 * Date last modified: 10/17/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param  nothing
	 *   @return nothing
	 */	
	public static void PressEnterToContinue( )
	{
		Scanner kb = new Scanner(System.in);
		System.out.print("\n\t\t -- Press Enter to Continue --\n");
		kb.nextLine();
	}//end PressEnterToContinue( )

	/**  
	 * Method Name: myInfo <br>
	 * Method Purpose: To display name of the programmer, date of
	 * 		created, Class section and Project number <br>
	 *
	 * <hr>
	 * Date created: 10/17/2013 <br>
	 * Date last modified: 10/17/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param  sDate - get the date from the user
	 *   @param  sAssign - get the assignment from the user
	 *   @return nothing
	 */		
	public static void myInfo(String sDate, String sAssign)
	{
		System.out.print("\n\n\tName:   Ishan Patel");
		System.out.print("\n\tClass:  CSCI 1250-002");
		System.out.print("\n\tDate:   " + sDate);
		System.out.println("\n\tAssign: "+ sAssign);
	}//end myInfo(String, String)
	
}//end Utility