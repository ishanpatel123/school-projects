//Program:	Proj3.java
//Name: 	Ishan Patel
//Class: 	1250-201
//Lab:		Project3
//Date: 	October 30,2012
//Purpose: 	Using writing method to display the GPA based on the average of three 
//			grades entered by user 

import java.text.DecimalFormat;
import java.util.Scanner;

/*
 * Class Name: Proj3 <br>
 * Class Purpose: contains the methods to calculate the GPA based on average 
 *	grade <br>
 *
 * <hr>
 * Date created: 10/30/2012 <br>
 * Date last modified: 10/30/2012 <br>
 * @author Ishan Patel
 */
 
public class Proj3
{
	public static void main(String[] args)
	{
		Scanner kb = new Scanner(System.in);
		DecimalFormat df = new DecimalFormat("#.##");
		String strDate;						//user input the date
		String strAssignment;				//user input the assignment
		String Name;						//holds the user name
		String input;						//user input Yes to rerun the program
		int i1; 							//holds the first grade enterd by user
		int i2;								//holds the second grade enterd by user
		int i3;								//holds the third grade enterd by user
		double dAvg;						//holds the average of three grade input
		double dGPA;						//holds the GPA based on character letter
		char cLetter;						//holds the character based on average
		char repeat;						//holds the character rerun the program	
		
		System.out.print("\nEnter the date: ");
		strDate = kb.nextLine();
		System.out.print("\nEnter the assignment: ");
		strAssignment = kb.nextLine();
		Utility.myInfo(strAssignment, strDate);
		Utility.freezeScreen(kb);
		
		System.out.print("\n\nWhat is your name? ");
		Name = kb.nextLine();
		createWelcomeMessage(Name);
	

		do
		{
		System.out.print("\n\nThe three test scores are ");
			i1 = kb.nextInt();
			i2 = kb.nextInt();
			i3 = kb.nextInt();
		dAvg = calcAverage(i1, i2, i3);
		Utility.freezeScreen(kb);

		cLetter = getLetterGrade(dAvg);
		System.out.print("\nThe letter grade is " + cLetter + "\n");
		Utility.freezeScreen(kb);

		dGPA = calcGPA(cLetter);
		System.out.print("\nThe GPA is " + df.format(dGPA) + "\n");
		Utility.freezeScreen(kb);

		Utility.clearScreen();


			System.out.print("\n\nEnter Y for yes or N for no: ");
			input = kb.next(); 
			repeat = input.charAt(0);  

		} while (repeat == 'Y' || repeat == 'y');
		
		createEndingMessage(Name);
	}
		
/**
 * Method Name: createWelcomeMessage <br>
 * Method Purpose: to display the welcome message of user <br>
 *
 * <hr>
 * Date created: 10/30/2012 <br>
 * Date last modified: 10/30/2012 <br>
 *
 * <hr>
 *
 * <hr>
 *   @param first String User name to run program
 *   @return nothing
 */		
	
	private static void createWelcomeMessage(String userName)
	{
		System.out.print ("\n\n\tHello there, " + userName);
		System.out.print("\n\tThis program is created to calculate GPA");
	}//end createWelcomeMessage(String)

/**
 * Method Name: calcAverage <br>
 * Method Purpose: To calculate and to display the average of user
 *     <br>
 *
 * <hr>
 * Date created: 10/30/2012 <br>
 * Date last modified: 10/30/2012 <br>
 *
 * <hr>
 *
 * <hr>
 *   @param  dAvg double take three score and divide by 3.0
 *   @return dAvg
 */	
	
	public static double calcAverage(int i1, int i2, int i3)
		{
			double dAvg;
			dAvg = (i1 + i2 + i3)/3.0;
			System.out.print("\nthe average " + dAvg + "\n");
			
			return dAvg;
		}//end calcAverage(int, int, int)
		
/**
 * Method Name: getLetterGrade <br>
 * Method Purpose: To display letter grade of average grade
 *     <br>
 *
 * <hr>
 * Date created: 10/30/2012 <br>
 * Date last modified: 10/30/2012 <br>
 *
 * <hr>
 *
 * <hr>
 *   @param  cLetter the letter grade of average
 *   @return cLetter
 */		
	public static char getLetterGrade(double dAvg)
		{
			char cLetter;
			if(dAvg >=90)
				{
					cLetter = 'A';
				}
			else if(dAvg >=80)
				{
					cLetter = 'B';
				}
			else if(dAvg >=70)
				{
					cLetter = 'C';
				}
			else if(dAvg >=60)
				{
					cLetter = 'D';
				}
			else
				{
					cLetter ='F';
				}

			return cLetter;
		}//end getLetterGrade(double)
	
/**
 * Method Name: calcGPA <br>
 * Method Purpose: To display GPA of letter grade based on average
 *     <br>
 *
 * <hr>
 * Date created: 10/30/2012 <br>
 * Date last modified: 10/30/2012 <br>
 *
 * <hr>
 *
 * <hr>
 *   @param  dGPA to display the value of GPA
 *   @return dGPA
 */		
	
	public static double calcGPA(char cLetter)
		{
			double dGPA;
		
			switch (cLetter) 
			{
				case 'A': dGPA = 4.0; 
					break;
				case 'B': dGPA = 3.0; 
					break;
				case 'C': dGPA = 2.0; 
					break;
				case 'D': dGPA = 1.0; 
					break;
				default: dGPA = 0.0;
				System.out.print("No Credit\n");
			}
			return dGPA;
		} 
	
/**
 * Method Name: createEndingMessage <br>
 * Method Purpose: To display ending message,name, etc.
 *     <br>
 *
 * <hr>
 * Date created: 10/30/2012 <br>
 * Date last modified: 10/30/2012 <br>
 *
 * <hr>
 *
 * <hr>
 *   @param  
 *   @return nothing
 */		
		private static void createEndingMessage(String first)
	{
		System.out.print ("\n\n\tThank you for using this program, " + first + 
			"!!\n");
	}//end createEndingMessage(String)
	
}	 
