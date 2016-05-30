/**
 * ---------------------------------------------------------------------------
 * File name: FileManager.java
 * Project name: pixfile3
 * ---------------------------------------------------------------------------
 * Creator's name and email: Ishan Patel pateli@goldmail.etsu.edu
 * Course:  CSCI 1260
 * Creation Date: Mar 22, 2013
 * Date of Last Modification: Mar 22, 2013
 * ---------------------------------------------------------------------------
 */

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;

/**
 * Enter type purpose here<br>
 *
 * <hr>
 * Date created: Mar 22, 2013<br>
 * Date last modified: Mar 22, 2013<br>
 * <hr>
 * @author Marty Barrett
 */

public class FileManager
{
	public FileManager()
	{
		
	}
	
	/**
	 * Retrieve data from a text file to populate 
	 * and return an pixList object <br>        
	 *
	 * <hr>
	 * Date created: Oct 27, 2010 <br>
	 * Date last modified: Oct 27, 2010 <br>
	 *
	 * <hr>
	 * @param fileName
	 * @return
	 */
	public pixList getFile ()
	{
		pixList list = new pixList();
		Scanner fileIn = null;
		String record;
		
		try
		{
			JFileChooser dlg = new JFileChooser( ".");
			if(dlg.showOpenDialog (null) == JFileChooser.APPROVE_OPTION)
				fileIn = new Scanner(dlg.getSelectedFile ( ));
			else
				throw new IOException ("No text file selected - cannot get the file");
			
			
			while (fileIn.hasNext ( ))
			{
				record = fileIn.nextLine ( );
				String [ ] field = record.split("\\|");
				if (field.length != 4)
					throw new IOException("Invalid record in file - does not contain the proper number of fields");
				pixfile p = new pixfile (field[0], field[1], field[2], Double.parseDouble (field[3]));
				list.addPix (p);
			}
		}
		catch (Exception ex)
		{
			JOptionPane.showMessageDialog (null, "Input of text file failed: " + ex.getMessage ( ) + "\n" 
				+ ex.getStackTrace ( ), "File Input Error", JOptionPane.ERROR_MESSAGE);
			return null;
		}
		finally
		{
			if (fileIn != null)
				fileIn.close ( );
		}
		
		return list;
	}
	
	/**
	 * Save the list in a text file <br>        
	 *
	 * <hr>
	 * Date created: Oct 27, 2010 <br>
	 * Date last modified: Oct 27, 2010 <br>
	 *
	 * <hr>
	 * @param fileName
	 * @param list
	 */
	public  void saveFile (pixList list)
	{
		PrintWriter pw = null;
		boolean saved = false;
		try
		{
			while (!saved)
			{
				JFileChooser dlg = new JFileChooser (System.getProperty ("user.dir"));
				if (dlg.showSaveDialog (null) == JFileChooser.APPROVE_OPTION)
				{
					if ( (dlg.getSelectedFile ( )).exists ( ))
					{
						if (JOptionPane.showConfirmDialog (null,
							"This file already exists - do you want to overwrite it?",
							"Erase File?", JOptionPane.YES_NO_OPTION, JOptionPane.QUESTION_MESSAGE) == JOptionPane.NO_OPTION)
						{
							JOptionPane.showMessageDialog (null, "File not saved");
							continue;  // go to next iteration of the while loop
						}
					}
					
					pw = new PrintWriter (dlg.getSelectedFile ( ));
					for (int n = 0; n < list.getNumPix ( ); n++ )
					{
						pixfile p = list.get (n);
						pw.println (p.toStringFile());
					}
					saved = true;
					JOptionPane.showMessageDialog (null, "File saved successfully", "Successful",
						JOptionPane.INFORMATION_MESSAGE);
				}
			}
			
		}
		catch (Exception ex)
		{
			JOptionPane.showMessageDialog (null, "Save text file failed: " + ex.getMessage ( ) + "\n" 
				+ ex.getStackTrace ( ), "File Save Error", JOptionPane.ERROR_MESSAGE);
			return;
		}
		finally
		{
			if (pw != null)
				pw.close ( );
		}
		
	}

}
