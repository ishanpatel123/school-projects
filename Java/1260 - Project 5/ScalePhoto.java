import java.awt.Graphics;
import java.awt.Image;
import java.awt.image.BufferedImage;

import javax.swing.ImageIcon;

/**
 * ---------------------------------------------------------------------------
 * File name: ScalePhoto.java
 * Project name: Project 5 
 * ---------------------------------------------------------------------------
 * Creator's name and email: Ishan Patel, pateli@goldmail.etsu.edu
 * Course-Section:  CSCI 1260 - 201
 * Creation Date: May 02, 2013
 * Date of Last Modification: May 02, 2013
 * ---------------------------------------------------------------------------
 */

public class ScalePhoto {
	/**
	 * Expects a pixfile filename (with extension) and a desired height
	 * and scales the picture to the desired height, returning an
	 * ImageIcon that can be used to set a picture into a JLabel or
	 * a JButton.  The .jpg or .png file *must* be in the "Pictures"
	 * subdirectory of your project directory.<br>        
	 *
	 * <hr>
	 * Date created: Apr 23, 2013 <br>
	 * Date last modified: Apr 23, 2013 <br>
	 *
	 * <hr>
	 * @param fileName - must be name of a file in the Pictures subfolder in
	 * 						this project
	 * @param desiredHeight - number of pixels representing the height of 
	 * 						the scaled picture
	 * @return ImageIcon that can be used to set the picture in a label
	 * 						or button
	 */
	public ImageIcon getPhotoIcon (String fileName, int desiredHeight)
	{
		ImageIcon icon = new ImageIcon ("Pictures\\" + fileName);

		Image pic = icon.getImage ( );
		double ratio = (double) pic.getWidth (null) / pic.getHeight (null);

		BufferedImage bl = new BufferedImage ((int) (desiredHeight * ratio), desiredHeight, 
		                                      BufferedImage.TYPE_INT_ARGB);
		Graphics gl = bl.getGraphics ( );
		gl.drawImage (pic, 0, 0, (int) (desiredHeight * ratio), desiredHeight, null);
		return new ImageIcon (bl);
	}	


}
