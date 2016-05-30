/**
 * ---------------------------------------------------------------------------
 * File name: pixfileDriver.java
 * Project name: pixfile2
 * ---------------------------------------------------------------------------
 * Creator's name and email: Marty Barrett, barrettm@etsu.edu
 * Course:  CSCI 1260
 * Creation Date: Feb 19, 2013
 * Date of Last Modification: March 5, 2013
 * ---------------------------------------------------------------------------
 */

/**
 * Driver for Project 2<br>
 *
 * <hr>
 * Date created: Feb 19, 2013<br>
 * Date last modified: Mar 6, 2013<br>
 * <hr>
 * @author Marty Barrett
 */
import javax.swing.JOptionPane;
import util.Menu;
import javax.swing.JFileChooser;
import java.io.File;
import java.util.Scanner;
import java.io.*;
import javax.swing.*;
public class pixfileDriver
{
	final static int NEWFILE 	= 1,
					SEARCHNAME 	= 2,
					SEARCHPHOTOG = 3,
					SHOWALL 	= 4,
					MINMAX 	= 5,
					DELETE = 6,
					CHECK = 7,
					QUIT = 8;
	private Menu menu = new Menu("Photo Tracker");
	
	// Driver main program
	public static void main(String args[]) {
		
		// Some local variables
		int choice;		// User menu choice
		String pixfilemsg = "Photo Tracker"; // Header for JOptionPane
		String key;		// Key to search on
		pixfile p;		// One pixfile found
		Scanner infile = null;
		JFileChooser chooser = null;
		Double siz = 0.0;
		// Data structures used
		
		
		pixList plist = new pixList();				// List of pixfiles
		pixfileDriver pfd = new pixfileDriver();	// Need to create the other functions, so ...
		// Show the splash screen
				JOptionPane.showMessageDialog(null, "--- Welcome to the Barrett Photo Tracker program v.2 ---", 
		                              pixfilemsg, JOptionPane.INFORMATION_MESSAGE);

		// Input the user's first and last names
		String userFirst = JOptionPane.showInputDialog(null, "Enter your first name: ", 
		                              pixfilemsg, JOptionPane.QUESTION_MESSAGE);
		String userLast = JOptionPane.showInputDialog(null, "Enter your last name: ", 
		                              pixfilemsg, JOptionPane.QUESTION_MESSAGE);
		// open the jfilechooser to save a file					
		
		openDialog();
				String file = "C:/Users/Ishan/Documents/Project 3/new.txt";
		try {
			infile = new Scanner(file);
		}
		catch(Exception e) {
			System.out.println("Error, could not open file " + e.getMessage());
		}				
					
		// Display the menu, get the user choice, continue until quit
		choice = pfd.getChoice();
		while (choice != QUIT) {
			
			// Switch between user choices
			switch (choice) {
				
				// Enter a new pixfile
				case NEWFILE:
					   // Gather all information using JOptionPane
					   // Get the photograph name, photographer's name, file type,
					   // and file size
							
						   String name = JOptionPane.showInputDialog(null, "" + "Enter pixfile name: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE);
						   String photog = JOptionPane.showInputDialog(null, "" + "Enter photographer's name: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE);
						   String type = JOptionPane.showInputDialog(null, "Enter file type: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE);

						   double size = Double.parseDouble(JOptionPane.showInputDialog(null, "Enter file size: ", 
															  pixfilemsg, JOptionPane.QUESTION_MESSAGE));

						// Create a new pixfile object
						p = new pixfile(name, photog, type, size);
						// Add the new pixfile to the list
						plist.addPix (p);
												
						break;
				
				// Search the list by pixfile name
				case SEARCHNAME:
						// Get the search key
						key = JOptionPane.showInputDialog(null, "Search for what pixfile?", 
									pixfilemsg, JOptionPane.QUESTION_MESSAGE);
						// Search the list
						p = plist.searchByName (key);
						
						// Was the key found?
						if ( p == null ) {
							// No - show an error message
							JOptionPane.showMessageDialog(null, "Pixfile " + key + " not found.",
								pixfilemsg, JOptionPane.ERROR_MESSAGE);
						} else {
							// Yes - show the pixfile data
							JOptionPane.showMessageDialog (null, "Found: " + p.toString ( ), 
								pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
						}
						
					break;
				
				// Search by photographer name
				case SEARCHPHOTOG:
					// Get the search key
					try{
							BufferedReader br = new BufferedReader(new FileReader("C:/Users/Ishan/Documents/Project 3/new.txt"));
							key = JOptionPane.showInputDialog(null, "Search for what photographer?", 
							pixfilemsg, JOptionPane.QUESTION_MESSAGE);
							String msg = "";
							p = plist.searchByPhotographer (key);

							while((key = br.readLine()) != null){
								msg += key + "\n";
							}
							br.close();
							if ( p == null ) {
							// No - display an error message
								JOptionPane.showMessageDialog(null, key + " not found.",
									pixfilemsg, JOptionPane.ERROR_MESSAGE);
							} else {
								// Yes - show the pixfile data
								JOptionPane.showMessageDialog (null, "Found: " + key.toString(), 
									pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
							}
							JOptionPane.showMessageDialog(null, msg);
						} catch(Exception e)
						{
							JOptionPane.showMessageDialog(null, "Dude" + e.getMessage());
						}
				
					// Was the key found?
					
					
					
					break;
					
				// Sort and display the list
				case SHOWALL:
					// Display one stringified list
					JOptionPane.showMessageDialog (null, "Pixfile List\n\n" + plist.getSorted ( ),
							pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
					break;
					
				// Show the largest and smallest by file size
				case MINMAX:
					// Get the largest and smallest.
					JOptionPane.showMessageDialog (null, "Largest Pixfile:\n" + 
							plist.findMax ( ).toString ( ) +
						    "***************\n" +
							"\n\nSmallest Pixfile:\n" + plist.findMin ( ).toString ( ),
							pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
					break;
				
				// All done
				case DELETE:
					// Delete a pixfile from list
					String s1 = JOptionPane.showInputDialog(null, "Enter a pixfile name to delete?", 
						pixfilemsg, JOptionPane.QUESTION_MESSAGE);
					
					
					int i = plist.deleteDisk(s1);

					if(s1 == null){
						JOptionPane.showMessageDialog(null, s1 + " not found.",
							pixfilemsg, JOptionPane.ERROR_MESSAGE);
					}							
					int  value = JOptionPane.showConfirmDialog (null, 
												"Are you sure?", "Please Confirm", JOptionPane.YES_NO_OPTION);
					if (value == JOptionPane.YES_OPTION && s1 != null)
					{
						JOptionPane.showMessageDialog(null, "The pixfile " + s1 + " is deleted");
					} else if(value == JOptionPane.NO_OPTION)
					{
						JOptionPane.showMessageDialog(null, "THe pixfile " + s1 + " is NOT deleted");
					}
					
					
					break;
					
				case CHECK:
					/** while (infile.hasNext() ) {
						String str = infile.next( );
						String[] fields = str.split("\\|");
						try {
						siz = Double.parseDouble(fields[3]);	
						} catch(Exception e)
						{
						JOptionPane.showMessageDialog(null, "Double need to parse double");

						}
						plist.addPix(new pixfile(fields[0], fields[1], fields[2], siz));
						JOptionPane.showMessageDialog(null, str);
						infile.close(); **/
						try{
							BufferedReader br = new BufferedReader(new FileReader("C:/Users/Ishan/Documents/Project 3/new.txt"));
							String s = "";
							String msg = "";
							while((s = br.readLine()) != null){
								msg += s + "\n";
							}
							br.close();
							JOptionPane.showMessageDialog(null, msg);
						} catch(Exception e)
						{
							JOptionPane.showMessageDialog(null, "Dude" + e.getMessage());
						}
					
				// Display the data file
					
					break;
					
				case QUIT:
					String s = JOptionPane.showInputDialog("Enter the name of file to save");
					File f = new File(s);	
						if(f.exists()){
						int result = JOptionPane.showConfirmDialog(null,"The file exists, overwrite?","Existing file",JOptionPane.YES_NO_OPTION);
						if (result == JOptionPane.YES_OPTION )
								{
									JOptionPane.showMessageDialog(null, "The file  is saved");
								} else if(result == JOptionPane.NO_OPTION)
								{
									JOptionPane.showMessageDialog(null, "The file is NOT saved");
								}
						}
					JOptionPane.showMessageDialog(null, "--- Thanks for using the Barrett Photo Tracker program v.2 ---",
						pixfilemsg, JOptionPane.INFORMATION_MESSAGE);
					break;
					
				// Should not happen; just in case.
				default:
					break;
				
			}
			// Get the next menu choice
			choice = pfd.getChoice();
		

		}
	}
	
	// Packages up the menu creation
	public pixfileDriver() {

		menu.addChoice ("Enter a New Pixfile");
		menu.addChoice("Search for Pixfile by Photo (File) Name");
		menu.addChoice("Search for Pixfile by Photographer's Name");
		menu.addChoice("Display Pixfile Names");
		menu.addChoice ("Show smallest and largest files");
		menu.addChoice("Delete a pixfile");
		menu.addChoice("Check the data file");
		menu.addChoice ("Quit");
	}
	
	// Get the menu choice
	public int getChoice() {
		int choice; // user choice
		do {
			choice = menu.getChoiceDialog ( );
		} while ( choice < NEWFILE || choice > QUIT );
		return choice;
	}
	
	
	public static void openDialog(){
	
			JFileChooser chooser = new JFileChooser("C:/Users/Ishan/Documents/Project 3");
			int x = chooser.showOpenDialog(null);
			try {
				if(x == JFileChooser.APPROVE_OPTION){
					String file = chooser.getSelectedFile().getPath();
					Scanner kb = new Scanner(file);
				}
				else{
					JOptionPane.showMessageDialog(null, "This file can't found");

				}
			} catch (Exception e){
					JOptionPane.showMessageDialog(null, "This file can't found");
				}
		
	}

	private static PrintWriter File(String fileName){

			try{
				// Creates a File object that allows you to work with files on the hardrive

				File listOfNames = new File(fileName);

				// FileWriter is used to write streams of characters to a file
				// BufferedWriter gathers a bunch of characters and then writes
				// them all at one time (Speeds up the Program)
				// PrintWriter is used to write characters to the console, file

				PrintWriter infoToWrite = new PrintWriter(
				new BufferedWriter(
						new FileWriter(listOfNames)));
				return infoToWrite;
			}
			// You have to catch this when you call FileWriter
			catch(IOException e){
				System.out.println("An I/O Error Occurred");
				// Closes the program
				System.exit(0);
			}
			return null;
		}
	
}
		


