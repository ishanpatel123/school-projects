
import javax.swing.JOptionPane;
import javax.swing.SwingUtilities;

/**
 * ---------------------------------------------------------------------------
 * File name: pixFileDriver.java
 * Project name: Project 5 
 * ---------------------------------------------------------------------------
 * Creator's name and email: Ishan Patel, pateli@goldmail.etsu.edu
 * Course-Section:  CSCI 1260 - 201
 * Creation Date: May 02, 2013
 * Date of Last Modification: May 02, 2013
 * ---------------------------------------------------------------------------
 */
public class pixfileDriver
{
	
	public static void main(String args[]) {
		String pixfilemsg = "Photo Tracker"; // Header for JOptionPane
	
		// Show the splash screen
		JOptionPane.showMessageDialog(null, "--- Welcome to the Patel Photo Tracker program v.2 ---", 
		                              pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
	
		// Input the user's first and last names
		String userFirst = JOptionPane.showInputDialog(null, "Enter your first name: ", 
		                              pixfilemsg, JOptionPane.QUESTION_MESSAGE);
		String userLast = JOptionPane.showInputDialog(null, "Enter your last name: ", 
		                              pixfilemsg, JOptionPane.QUESTION_MESSAGE);
	
		 SwingUtilities.invokeLater 
		   (
		 		 new Runnable()
		 		 {
			 		    @Override
			 		    public void run()
			 		    {
	
			 		    	
			 		    	menuWindow m = new menuWindow();
			 		    }
			 	 }
		 	);
		}
}