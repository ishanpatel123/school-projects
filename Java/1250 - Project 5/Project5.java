/************************************************************************************
* -----------------------------------------------------------------------------------
* File name: Project5.java
* Project name: CSCI 1250 Project 5
* -----------------------------------------------------------------------------------
* Author Name: Ishan Patel
* Author E-mail: pateli@goldmail.etsu.edu
* Course-Section: CSCI-1250-002
* Creation Date: 11/28/2013
* Date of Last Modification: 11/28/2013
* -----------------------------------------------------------------------------------
*/ 

import javax.swing.JOptionPane;

/************************************************************************************
* Class Name: Project5 <br>
* Class Purpose:simple program in Java that should  use methods, information and 
* calculated information which writtern in advisee class and display it by using JOptionPane
* boxes. it also use methods written in Project 5 to give user choices to get the correct reslut
* based upon requirements.
*
* Date created: 11/28/2013 <br>
* Date last modified: 11/28/2013
* @author Ishan Patel
*/

public class Project5
{
	public static final int LIMIT = 3; //the limit of the number of advisees
	
	/**********************************************************************************
	* Method Name: main <br>
	* Method Purpose: simple program in Java that should  use methods, information and 
	* calculated information which writtern in advisee class and display it by using JOptionPane
	* boxes. <br>
	*
	* <hr>
	* Date created: 11/28/2013 <br>
	* Date last modified: 11/28/2013 <br>
	*
	* <hr>
	* Notes on specifications, special algorithms, and assumptions:
	* if user entered wrong choice, display them error message
	*
	* <hr>
	* @param String[] args - Command Line Arguments
	*/
	  
	public static void main(String[] args) 
	{
		Advisee defaultAdvisee = new Advisee();
		
		Advisee student1;			//reference variable student1
		Advisee student2;			//reference variable student2
		Advisee student3;			//reference variable student3
		String advisorName;			//the advisor's name
		int adviseeCount = 0; 		//the number of advisees
		int choice = 0; 			//the user's main menu selection
		int choice2 = 0; 			//the user's sub-menu selection
		
		//copy the contents of the defaultAdvisee object
		student1 = new Advisee(defaultAdvisee);
		student2 = new Advisee(defaultAdvisee);
		student3 = new Advisee(defaultAdvisee);
		
		//display a welcome screen with your information
		JOptionPane.showMessageDialog(null,"           Welcome to the Advising Manager!\n" 
						+  "--------Created by Kellie Price and Ishan Patel--------");
		
		advisorName = JOptionPane.showInputDialog("What is the advisor's name?");
		student1.setAdvisor(advisorName);
		do{
			choice = displayMenu();
			switch(choice)
			{
				case 1: //add an advisee
				
						if(adviseeCount == 0)
						{
							getAdviseeInfo(student1);
						}
						else if(adviseeCount == 1)
						{
							getAdviseeInfo(student2);
							student2.setAdvisor(advisorName);
							if(student1.getStudentID().equals(student2.getStudentID()))
							{
								JOptionPane.showMessageDialog(null,"Error: That student is already an advisee");
								student2 = new Advisee(defaultAdvisee);
								break;
							}	
						}
						else if(adviseeCount == 2)
						{
							getAdviseeInfo(student3);
							student3.setAdvisor(advisorName);
							if(student2.getStudentID().equals(student3.getStudentID()))
							{
								JOptionPane.showMessageDialog(null,"Error: That student is already an advisee");
								student3 = new Advisee(defaultAdvisee);
								break;
							}
							if(student1.getStudentID().equals(student3.getStudentID()))
							{
								JOptionPane.showMessageDialog(null,"Error: That student is already an advisee");
								student3 = new Advisee(defaultAdvisee);
								break;
							}	
						}
						else if(adviseeCount >= 3)
						{
							JOptionPane.showMessageDialog(null,"You have reached your maximum number of advisees!");
						}
						
						++adviseeCount;
						break;
				
				case 2: //change an advisees info
				
						if(adviseeCount == 0)
						{
							JOptionPane.showMessageDialog(null, "There are no advisees in the system yet");
							break;
						}	
						choice2 = displaySubMenu(student1, student2, student3, adviseeCount);
						if(choice2 == 1 || adviseeCount == 1)
						{
							JOptionPane.showMessageDialog(null, student1.toString());
							getAdviseeInfo(student1);
						}
 
						else if(choice2 == 2 || adviseeCount == 2)
						{
							JOptionPane.showMessageDialog(null, student2.toString());
							getAdviseeInfo(student2);
						}
 
						else if(choice2 == 3 || adviseeCount == 3)
						{
							JOptionPane.showMessageDialog(null, student3.toString());
							getAdviseeInfo(student3);
						}
						else
						{
							JOptionPane.showMessageDialog(null, "The advisee doesn't exist yet!");
						}
 
						break; 
				
				case 3: //display all advisees information
				
						if(adviseeCount == 0)
						{
							JOptionPane.showMessageDialog(null, "There are no advisees in the system yet");
							break;
						}	
						displayAllAdvisees(student1, student2, student3, adviseeCount);
						
						break;
				case 4: //display all advisees that have been cleared to graduate
						
						if(adviseeCount == 0)
						{
							JOptionPane.showMessageDialog(null, "There are no advisees in the system yet");
							break;
						}	
						displayAdviseesClearedToGraduate(student1, student2, student3);
						
						break;
				case 5: //exiting the program, display an EXIT message
						
						JOptionPane.showMessageDialog(null,"Have a nice day!");
		
						break;
			}//end switch
		} while(choice != 5);
		//exit the program
		System.exit(0);
	}//end main(String [ ])
			
	/*************************************************************************************
	 * Method Name: 	displayMenu<br>
	 * Method Purpose: displays a menu of options to the users and returns the users 
	 *					selection <br>
	 * 
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date last modified: 11/28/2013 <br> 
	 * <hr>
	 *	@return int the user's menu selection
	 */
	public static int displayMenu()
	{	
		int selection;
		//build the menu
		String menu = 	  " ~~ Please make a selection from the menu below ~~ \n\n"
						+ "    1. Add a new advisee \n" 
						+ "    2. Update an advisee's information\n\n"
						+ "    3. Display all advisees \n"
						+ "    4. Display advisees who are cleared to graduate \n"
						+ "    5. Exit \n"
						+ "\n\n What is your selection? ";
						
		selection = Integer.parseInt(JOptionPane.showInputDialog(menu));
		
		while(selection <= 0 || selection >= 6)
		{
			JOptionPane.showMessageDialog(null,"Invalid Input");
			selection = Integer.parseInt(JOptionPane.showInputDialog(menu));
		}
		
		return selection; 
	}//end displayMenu()
	
	/*************************************************************************************
     * Method Name: 	displaySubMenu<br>
	 * Method Purpose: displays a submenu of options to the users to present the advisees
	 *                 available for update and returns the users selection <br>
	 * 
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date last modified: 11/28/2013 <br>
	 * <hr>
	 * @param student1 the first Advisee object
	 * @param student2 the second Advisee object
	 * @param student3 the third Advisee object
	 * @param adviseeCount the number of Advisees currently in the system
	 *	@return int the user's submenu selection
	 */
	public static int displaySubMenu(Advisee student1, Advisee student2,
									 Advisee student3, int adviseeCount)
	{	
		int selection;
		String menu ="";
		
		//build the menu
		if (adviseeCount <= 0)
		{	JOptionPane.showMessageDialog(null, "There are no advisees in the system yet");
			selection = 0;
		}
		else
		{
			menu += " ~~ Please select which advisee's information you need to update ~~ "
				 +  "\n\n       1. " + student1.getName();
			if (adviseeCount >= 2)			
			  menu  += "\n       2. " + student2.getName();
			if (adviseeCount >= 3)			
			  menu  += "\n       3. " + student3.getName();
			
			menu +=    "\n\n What is your selection? ";
						
			selection = Integer.parseInt(JOptionPane.showInputDialog(menu));
		}//end else
		
		while(selection <= 0 || selection >= 4)
		{
			JOptionPane.showMessageDialog(null,"Invalid Input");
			selection = Integer.parseInt(JOptionPane.showInputDialog(menu));
		}
		
		return selection;
	}//end displaySubMenu(Advisee, Advisee, Advisee, int)
	
	/*************************************************************************************
     * Method Name: 	getAdviseeInfo<br>
	 * Method Purpose: prompts the user for the information about an advisee and stores
	 *                 the information in an Advisee object<br>
	 * 
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date last modified: 11/28/2013 <br> 
	 * <hr>
	 * @param student an Advisee object to be modified
	 */ 
	public static void getAdviseeInfo(Advisee student)
	{
		int answer; //users answer indicating yes (0) or no (1)
		boolean majorSheet = false;
		boolean intentToGrad = false;
		
		//request the student information from the user
		student.setName(JOptionPane.showInputDialog("What is the student's name?"));
		
		student.setStudentID(JOptionPane.showInputDialog("What is the student's id?"));
		
		student.setConcentration
			(JOptionPane.showInputDialog("What is the student's concentration?"));
		
		student.setNumOfHours
			(Integer.parseInt(JOptionPane.showInputDialog("How many hours has the student "
							 + "completed?")));
		
		answer = JOptionPane.showConfirmDialog
					(null,"Has the student completed a major sheet?", 
					 "Select Yes or No", JOptionPane.YES_NO_OPTION);
		if (answer == 0) //user selected yes
			majorSheet = true;
		student.setMajorSheet(majorSheet);
		
		answer = JOptionPane.showConfirmDialog
					(null,"Has the student filed an intent to graduate?", 
					 "Select Yes or No", JOptionPane.YES_NO_OPTION);
		if (answer == 0) //user selected yes
			intentToGrad = true;
		student.setIntentToGrad(intentToGrad);
			
	}//end getStudentInfo(Advisee)
	
	/*************************************************************************************
     * Method Name: 	displayAllAdvisees<br>
	 * Method Purpose: accepts all advisee objects for display, but only displays the 
	 * 				current number of advisees in the system<br>
	 * 
	 * <hr>
	 * Date created: 11/28/2013 <br>
	 * Date last modified: 11/28/2013 <br>
	 * <hr>
	 * @param student1 the first Advisee object
	 * @param student2 the second Advisee object
	 * @param student3 the third Advisee object
	 * @param adviseeCount the number of Advisees currently in the system
	 */	
	public static void displayAllAdvisees(Advisee student1, Advisee student2, 
										  Advisee student3, int adviseeCount)
	
	{
		if (adviseeCount == 0)  //if there are no advisees in the system
			JOptionPane.showMessageDialog(null,"There are no advisees in the system yet");
		else
		{
			if (adviseeCount >= 1) //if there is at least 1 student, display the 1st one
				JOptionPane.showMessageDialog(null, student1);
			if (adviseeCount >= 2) //if there are at least 2 students, display the 2nd one
				JOptionPane.showMessageDialog(null,student2);
			if (adviseeCount >= 3) //if there are at least 3 students, display the 3rd one
				JOptionPane.showMessageDialog(null,student3);
		}//end else
						
	}//end displayAllAdviseesu(Advisee, Advisee, Advisee, int)
	
	/*************************************************************************************
     * Method Name: displayAdviseesClearedToGraduate<br>
	 * Method Purpose: Displays the advisees who are cleared to graduate<br>
	 * 				  
	 * <hr>
	 * Date created: 11/16/12 <br>
	 * Date last modified: 12/5/12 <br>
	 * <hr>
	 * @param student1 the first Advisee object
	 * @param student2 the second Advisee object
	 * @param student3 the third Advisee object
	 */
	 public static void displayAdviseesClearedToGraduate(Advisee student1, Advisee student2, Advisee student3)
	 {
			//display the advisees that are cleared to graduate
			
			boolean student1Message = student1.metGraduationRequirements();
			boolean student2Message = student2.metGraduationRequirements();
			boolean student3Message = student3.metGraduationRequirements();
			if(student1Message == true)
			{
			JOptionPane.showMessageDialog(null,student1);
			}
 
			if(student2Message == true)
			{
			JOptionPane.showMessageDialog(null,student2);
			}
 
			if(student3Message == true)
			{
			JOptionPane.showMessageDialog(null,student3);
			}
			if(student1Message == false && student2Message == false && student3Message == false)
			{
			JOptionPane.showMessageDialog(null,"There are no advisees ready to graduate");
			}
	}//end displayAdviseesClearedToGraduate(Advisee, Advisee, Advisee)
	
}//end Project5