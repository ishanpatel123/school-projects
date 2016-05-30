/**
 * ------------------------------------------------------------
 * File name: pixfile.java
 * Project name: Project 1 
 * ------------------------------------------------------------
 * Creator's name and email: Ishan Patel pateli@goldmail.etsu.edu
 * Course-Section: CSCI 1260-201
 * Creation Date: 1/14/2013
 * Date of Last Modification: 1/14/2013
 * ------------------------------------------------------------
 */

import java.text.DecimalFormat;

/**
 * Class: pixfile
 * Purpose: Models one photographic file
 * @author barrettm
 *
 */
public class pixfile {

	private String name;		// photo name
	private String photographer;	// photographer's name
	private String type;            // file type
	private double fileSize;	// file size

	// Two constants for computations
	private static double SERVERCOST = 0.25;  // cost per MB
	private static double DOWNLOADTIME = 3.0; // mb per second download time

	/**
	 * Default constructor<br>
	 * Sets some sample strings and 0 in the data
	 */
	public pixfile() {
		this.name = "NO NAME";
		this.photographer = "NO PHOTOGRAPHER";
		this.type = "jpeg";
		this.fileSize = 0.0;
	}
	
	public pixfile(pixfile p) {
		this.name = new String(p.name);
		this.photographer = new String(p.photographer);
		this.type = new String(p.type);
		this.fileSize = p.fileSize;
	}
	/**
	 * @param name
	 * @param photographer
	 * @param type
	 * @param fileSize
	 * Overloaded constructor, all parameters<br>
	 */
	public pixfile(String name, String photographer, String type,
			double fileSize) {
		this.name = name;
		this.photographer = photographer;
		this.type = type;
		this.fileSize = fileSize;
	}
	
	/**
	 * Return a string of all pixfile information<br>
	 */
	public String toString( ) {
		String msg = String.format("%-20s %-20s %-10s %10.2f %10.2f %10.2f\n", name,  
						photographer,
						type,
						fileSize,
						computeCost(),
						computeDownloadTime() );
		
	   return msg;
	}
	
	/**
	 * Return a string of all pixfile information formatted for a file<br>
	 */
	public String toStringFile( ) {
		String msg = name + 
					"|" + photographer +
	                "|" + type +
	                "|" + fileSize;
	   return msg;
	}
	/**
	 *  Setters
	 */
	public void setName(String name) {
	   this.name = name;
	}

	public void setphotographer(String photographer) {
	   this.photographer = photographer;
	}

	public void setType(String type) {
	   this.type = type;
	}

	public void fileSize(double fileSize) {
	   this.fileSize = fileSize;
	}

	/**
	 *  Getters
	 */
        public String getName( ) {
	   return name;
	}

        public String getPhotographer( ) {
	   return photographer;
	}

        public String getType( ) {
	   return type;
	}

        public double getFileSize( ) {
	   return fileSize;
	}

	/**
	 * Computes the cost per megabyte<br>
	 */
	private double computeCost( ) {
		return(fileSize*SERVERCOST);
	}
	
	/**
	 * Computes the time to download this file<br>
	 */
	private double computeDownloadTime( ) {
		return(fileSize/DOWNLOADTIME);
	}

} // class pixfile

