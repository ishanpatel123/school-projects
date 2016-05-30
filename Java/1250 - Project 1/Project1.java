/**************************************************************************************
* ------------------------------------------------------------------------------------
* File name: Project1.java
* Project name: CSCI 1250 Project 1
* ------------------------------------------------------------------------------------
* Author Name: Ishan Patel
* Author E-mail: pateli@goldmail.etsu.edu
* Course-Section: CSCI-1250-002
* Creation Date: 11/14/2013
* Date of Last Modification: 11/14/2013
* ------------------------------------------------------------------------------------
*/

import java.util.Scanner;	//to allow input from the keyboard

/**************************************************************************************
* Class Name: Project1 <br>
* Class Purpose:To display user will take steps over minute, hour, day, and  a year 
*	It also convert and display steps in feets and miles over 20 year <br>
* <hr>
* Date created: 11/14/2013 <br>
* Date last modified: 11/14/2013
* @author Ishan Patel
*/

public class Project1
{
	/**********************************************************************************
	* Method Name: main <br>
	* Method Purpose: To display a simple program in Java that will interact with the
	* user through some dialog. It will ask the user for their name and the
	* number of steps are taken by user in 10 second time interval. The program will
	* then display to the user the approximate number of minutes,hours, days and years he/she should
	* be take steps as well as the minimum daily average. It also convert steps are taken in over 20 
	* years, feet in 20 years and miles in 20 years.
	* <br>
	*
	* <hr>
	* Date created: 11/14/2013 <br>
	* Date last modified: 11/14/2013 <br>
	*
	* <hr>
	* Notes on specifications, special algorithms, and assumptions:
	* The suggested number of steps are taken in 10 seconds time interval.
	*
	* <hr>
	* @param String[] args - Command Line Arguments
	*/
	
	public static void main(String[] args)
	{
		//***************************VARIABLE DECLARATIONS*****************************
		//-------------------------------input by user---------------------------------
		String strName = "";						//holds the user's input name
		float fStepsinInterval = 0f;				//holds the steps are taken in 10 seconds interval entered by user

		//--------------------------------calculated-----------------------------------
		float fStepsperMinute = 0f;					//holds the value of steps are taken in minute
		float fStepsperHour = 0f;					//holds the value of steps are taken in hour
		float fStepsperDay = 0f;					//holds the value of steps are taken in day
		float fStepsperYear = 0f;					//holds the value of steps are taken in year
		double dStepsperTwentyYears = 0;			//holds the values of steps are taken in twenty years
		double dFeetperSteps =0;					//holds the value of number of feet per step
		double dFeetperMiles =0;					//holds the value of feet in miles
		
		//------------------------------other variables--------------------------------
		Scanner kb = new Scanner(System.in);		//used to  get input from keyboard
		String strYourName = "Ishan";
		
		//---------------------------------constants-----------------------------------
		final int iSecondsInterval = 10;			//# of seconds in interval to take steps
		final int iSecondsperMinute = 60;			//# of seconds per minute
		final int iMinutesperHour = 60;				//# of minutes per hour
		final int iHoursperDay = 18;				//# of hours per day
		final int iDaysinYear = 365;				//# of days in year
		final int iTotalYears = 20;					//# of years that steps are taken
		final int iTotalFeetsperMile = 5280;		//# of the total feet in one mile
		final float fTotalFeetperStep = 2.5f;		//# of the total feet per steps are taken

		//*************************INPUT - PROCESSING - OUTPUT*************************
		//-----------------------------------------------------------------------------
		// introduce myself and prompt for the user's name
		//-----------------------------------------------------------------------------
		System.out.println("\n************************************************************************");
		System.out.print("\nHello, my name is " + strYourName +"! What is your name? ");
		strName = kb.nextLine();
		
		//-----------------------------------------------------------------------------
		// ask user for steps are taken in 10 second interval(whole numbers)
		//-----------------------------------------------------------------------------
		System.out.print("\nHello, " + strName + ". How many steps do you take in a 10 second interval? ");
		fStepsinInterval = kb.nextFloat();
		
		System.out.println("\n************************************************************************");
		System.out.print("\n If you take " + fStepsinInterval + " steps in a 10 second time interval." +
		"\n You could potentially achieve...\n\n");
		
		//-----------------------------------------------------------------------------
		// calculate:
		// the total steps the user is taking as:
		//the number of steps the user should take in one minute as:
		// the number Steps are in 10 second interval * 60 second per minute / 10 second time interval
		//the number of steps the user should take in one hour as:
		// the total steps are in minute * minutes in one hour
		//the number of steps the user should take in one day as:
		// the total steps are in hour * hours in one day
		//the number of steps the user should take in one year as:
		// the total steps are in day * days in one year
		//the number of steps the user should take in twenty year as:
		// the total steps in year * twenty years
		//the number of feet the user should take in twenty years as:
		// the total steps in twenty * feet per step
		//the number of miles the user should take in twenty years as:
		// the total feet / the a mile per feet
		//-----------------------------------------------------------------------------
		fStepsperMinute = (fStepsinInterval * iSecondsperMinute) / iSecondsInterval;
		fStepsperHour = fStepsperMinute * iMinutesperHour;
		fStepsperDay =  fStepsperHour * iHoursperDay;
		fStepsperYear = fStepsperDay * iDaysinYear;
		dStepsperTwentyYears = fStepsperYear * iTotalYears;
		dFeetperSteps = dStepsperTwentyYears * fTotalFeetperStep;
		dFeetperMiles = dFeetperSteps / iTotalFeetsperMile;
		
		//-----------------------------------------------------------------------------
		// display the calculated information to the user in a readable format
		//-----------------------------------------------------------------------------
		System.out.println("       Number of steps per minute: " + fStepsperMinute);
		System.out.println("\t Number of steps per hour: " + fStepsperHour);
		System.out.println("\t  Number of steps per day: " + fStepsperDay);
		System.out.println("\t Number of steps per year: " + fStepsperYear);
		
		System.out.println("\n Over a period of 20 years." +
				"\n you could potentially have traveled...\n");
	
		System.out.println("\t\t  Number of Steps: " + dStepsperTwentyYears);
		System.out.println("\t\t   Number of feet: " + dFeetperSteps);
		System.out.println("\t\t  Number of miles: " + dFeetperMiles);
		
		System.out.println("\n************************************************************************");

	}//end main
}//end Project1