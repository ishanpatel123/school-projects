//Program:	Project2.java
//Name: 	Ishan Patel
//Class: 	1260-201
//Lab:		Project 1
//Date: 	February 26,2013
//Purpose:  Modify Project1 design to maintain and to add an ArrayList
//			of Pixfiles and display the options for user’s choice
import javax.swing.JOptionPane; //import JOptionPane
import util.Menu;	//import a menu


/**
 * Collect and display picture file data<br>
 *
 * <hr>
 * Date created: Feb 20, 2013<br>
 * Date last modified: Feb 26, 2013<br>
 * <hr>
 * @author Ishan Patel
 */
 
public class pixfileDriver {

	/**
	 * Driver for the card class <br>        
	 *
	 * <hr>
	 * Date created: Feb 20, 2013 <br>
	 * Date last modified: Feb 26, 2013 <br>
	 *
	 * <hr>
	 * @param args
	 */
	

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		PixList mylist;
		mylist = new PixList();		//declare a pixfile object
		String pixfilemsg = "Photo Tracker"; // Header for JOptionPane
		String name;   // pixfile title
		String photog; // pixfile photographer
		String userFirst,
		       userLast; // user name
		String type;   // pixfile type
		double size;   // pixfile size
		int answer;    // for continuing
		
		// Show the splash screen
		JOptionPane.showMessageDialog(null, "--- Welcome to the Patel Photo Tracker program ---", 
		                              pixfilemsg, JOptionPane.INFORMATION_MESSAGE);

		// Input the user's first and last names
		userFirst = JOptionPane.showInputDialog(null, "Enter your first name: ", 
		                              pixfilemsg, JOptionPane.QUESTION_MESSAGE);
		userLast = JOptionPane.showInputDialog(null, "Enter your last name: ", 
		                              pixfilemsg, JOptionPane.QUESTION_MESSAGE);
									  
		Menu menu = new Menu("Main Menu");
		menu.addChoice(" Enter a new Pixfile");
		menu.addChoice("Display all information about one pixfile based on the Pixfile's name");
		menu.addChoice("Display all information about one pixfile based on the Photographer's name");
		menu.addChoice("Display the name of all pixfiles, sorted by Pixfile name");
		menu.addChoice("Display the names and sizes of  the smallest and largest Pixfiles");
		menu.addChoice("Quit the program");
		
		
		pixfile pie = new pixfile();
		int choice = menu.getChoiceDialog( ); //display menu
		while(choice != 6)
		{
			switch(choice)
			{
				
				case 1:
					pixfile song; //create a reference of pixfile
					// Gather all information using JOptionPane

					// Get the photograph name, photographer's name, file type,
					// and file size
					name = JOptionPane.showInputDialog(null, "" + "Enter photograph file name: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE);
					photog = JOptionPane.showInputDialog(null, "" + "Enter photographer's name: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE);
					type = JOptionPane.showInputDialog(null, "Enter file type: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE);
					size = Double.parseDouble(JOptionPane.showInputDialog(null, "Enter file size: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE));
						
					// Create a new pixfile object
					song = new pixfile(name, photog, type, size);	// Display all information
					mylist.add(song);	//add the pixfile to the ArrayList
					break;
					
				case 2:	
					// display info of one Pixfile based on name
					String str = JOptionPane.showInputDialog(null,"Enter the pixfile name?");
					pixfile pa; //display for search method
					pa =  mylist.search(str);
					if( pa != null){
						JOptionPane.showMessageDialog(null, pa.toString());
					} else{
						 JOptionPane.showMessageDialog(null,"String is null, do not attempt to initialize");
					}
					break;
					
				case 3:
					// display info of one Pixfile based on photographer
					str = JOptionPane.showInputDialog(null,"Enter the photographer name?");
					pixfile pv; //display for search method
					pv =  mylist.searchphotographer(str);
					if( pv != null){
						JOptionPane.showMessageDialog(null, pv.toString());
					} else{
						 JOptionPane.showMessageDialog(null,"String is null, do not attempt to initialize");
					}	
					break;
					
				case 4:
					//display names of all pixfiles
					mylist.selectionSort();
					mylist.name();
					break;
					
				case 5:	
					//display names and sizes of largest and smallest pixfiles
					int i =0; // int size
					pixfile ps = mylist.findmax(i);
					JOptionPane.showMessageDialog(null, "\tThe name of highest pixfile:" + ps.getName() + "\n\tThe size of file:" + ps.getFileSize());
					pixfile pd = mylist.findmin(i);
					JOptionPane.showMessageDialog(null, "\tThe name of lowest pixfile:" + pd.getName() + "\n\tThe size of file:" + pd.getFileSize());
					break;
				
				default:
					break;
								
			}	
			choice = menu.getChoiceDialog( );
		}
			JOptionPane.showMessageDialog(null, "Goodbye");
		
	}

}

