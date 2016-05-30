//Program:	Project2.java
//Name: 	Ishan Patel
//Class: 	1260-201
//Lab:		Project 1
//Date: 	February 22,2013
//Purpose:  Modify Project1 design to maintain and to add an ArrayList
//			of Pixfiles and display the options for user’s choice

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
	
	public pixfile(pixfile p) {
		name = p.name;
		photographer = p.photographer;
		type = p.type;
		fileSize = p.fileSize;
	}
	/**
	 * Return a string of all pixfile information<br>
	 */
	public String toString() {
		DecimalFormat dfmt = new DecimalFormat("#0.00");
		String msg = "Name: \t" + name +
	                "\nPhotographer: \t" + photographer +
	                "\nType: \t" + type +
	                "\nFileSize/MB: \t" + fileSize +
			"\nCost: \t" + dfmt.format(computeCost() ) +
	                "\nApproximate download time (at 3 MB/sec): \t" 
			             + dfmt.format(computeDownloadTime( ));
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

