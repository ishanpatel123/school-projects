import java.text.DecimalFormat;		//Allows decimal formatting
/**
	 * Class Name: Intro to Computer Science II<br>
	 * Class Purpose: This class design to Store photographs in files and calculating
	 * cost per pixfiles storage
	 * <hr>
	 * Date created: 2/03/2013<br>
	 * Date last modified: 2/03/2013
	 * @author Ishan Patel
	 * Author's E-mail: pateli@goldmail.etsu.edu
	 */
public class photo {

	private String username;		// holds the User name
	private String filename;		// holds the File name
	private String photographer;	// holds the Photographer name
	private String typefile;		// holds the Type of file
	private double size;			// holds the Size of file
	
	/**
	 * Method Name: photo <br>
	 * Method Purpose: it create a default constructor for photo class <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param N/A
	 *   @return N/A
	 */	
	
	public photo() {}//end photo
	
	/**
	 * Method Name: photo <br>
	 * Method Purpose: it create a constructor for photo class <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param N/A
	 *   @return N/A
	 */	

	public photo(String username, String filename,  String photographer, String typefile, double size)
		{
			setusername(username);
			setfilename(filename);
			setphotographer(photographer);
			settypefile(typefile);
			setsize(size);		
		} //end photo(String, String, String, String, double)

	/**
	 * Method Name: setusername <br>
	 * Method Purpose: it set the user name for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param username to set user name
	 *   @return N/A
	 */	
	  
	public void setusername(String username)
		{		
			this.username = username;
		} //end setusername(String)
		
	/**
	 * Method Name: setfilename <br>
	 * Method Purpose: it set the file name for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param filename to set file name
	 *   @return N/A
	 */	
	 	 
	public void setfilename(String filename)
		{	
			this.filename = filename;
		} // end setfilename(String)
	
	/**
	 * Method Name: setusername <br>
	 * Method Purpose: it set the user name for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param username to set username
	 *   @return N/A
	 */	
	 	 
	public void setphotographer(String photographer)
		{
			this.photographer = photographer;
		} //end setphotographer(String)
	
	/**
	 * Method Name: settypefile <br>
	 * Method Purpose: it set the types of file for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param settypefile to set type of file
	 *   @return N/A
	 */	
	 
	public void settypefile(String typefile)
		{
			this.typefile = typefile;
		} //end settypefile(String)
	
	/**
	 * Method Name: setsize <br>
	 * Method Purpose: it set the size for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param setsize to set size of file
	 *   @return N/A
	 */	
	 
	public void setsize(double size)
		{
			if(size >0)
				this.size = size;	
		} //end setsize(double)
	
	/**
	 * Method Name: getusername <br>
	 * Method Purpose: it get the user name for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param getuseername to get the user name
	 *   @return username
	 */	
	 
	public String getusername()
		{
			return username;
		} //end getusername
	
	/**
	 * Method Name: getfilename <br>
	 * Method Purpose: it get the name of file for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param getfilename to get the file name
	 *   @return getfilename
	 */	
	 
	public String getfilename()
		{
			return filename;
		} //end getfilename	
	
	/**
	 * Method Name: getphotographer <br>
	 * Method Purpose: it get the name of photographer  for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param getphotographer to get the photographer name
	 *   @return getphotographer
	 */	
	 
	public String getphotographer()
		{
			return photographer;
		} //end getphotographer
	
	/**
	 * Method Name: gettypefile <br>
	 * Method Purpose: it get the type of file for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param gettypefile to get the type of file
	 *   @return typefile
	 */	
	 
	public String gettypefile()
		{
			return typefile;
		} //end gettypefile
	
	/**
	 * Method Name: getsize <br>
	 * Method Purpose: it get size for photo class  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param getsize to get the size
	 *   @return size
	 */	
	 
	public double getsize()
		{	
			return size;
		} //end getsize
	
	/**
	 * Method Name: calcsize <br>
	 * Method Purpose: it calculate the cost of size of file  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param dcost calculate the cost of size
	 *   @return dcost
	 */	
	 
	public double calcsize()
		{
			double dcost = (getsize() * 0.25);
			return dcost;
		} //end calcsize
	
	/**
	 * Method Name: dtime <br>
	 * Method Purpose: it calculate approximate time for download  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param dtime calculate time
	 *   @return dtime
	 */	
	 
	public double dtime()
		{
			double dtime = (getsize() /3.0);
			return dtime;
		} //end dtime
		
	
	/**
	 * Method Name: toString <br>
	 * Method Purpose: output, to dispaly appropiate label for photoclass  <br>
	 *
	 * <hr>
	 * Date created: 2/03/2013 <br>
	 * Date last modified: 2/03/2013 <br>
	 *
	 * <hr>
	 *
	 * <hr>
	 *   @param output of photo class
	 *   @return N/A
	 */	
	 
	public String toString()
		{
			DecimalFormat df = new DecimalFormat("#0.00");
			String strinfo;
			strinfo =  "\n\n\t\tUser Name: " + getusername();
			strinfo+=  "\n\t\tTitle: Photo Tacker"; 
			strinfo +="\n\n\tType: "+ gettypefile();
			strinfo+= "\n\tPhotographer: " + getphotographer();
			strinfo+= "\nSize of the pixfile: " + df.format(getsize());
			strinfo+= "\nCost for file storage: " + df.format(calcsize());
			strinfo+= "\nApproximate download time: " + df.format(dtime());

			return strinfo;
	
		}//end toString	
	
}