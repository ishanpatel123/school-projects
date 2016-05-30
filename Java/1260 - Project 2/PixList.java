//Program:	Project2.java
//Name: 	Ishan Patel
//Class: 	1260-201
//Lab:		Project 1
//Date: 	February 26,2013
//Purpose:  Modify Project1 design to maintain and to add an PixList
//			of Pixfiles and display the options for user’s choice


import javax.swing.JOptionPane; //import JOptionPane

	/**
	 * Enter type purpose here<br>
	 *
	 * <hr>
	 * Date created: Feb 19, 2013<br>
	 * Date last modified: Feb 26, 2013<br>
	 * <hr>
	 * @author Ishan Patel
	 */
public class PixList{
		private pixfile[] list;
		private	int size;
	
	// a defalut constructor
	public PixList() {
		list = new pixfile[10];
		size = 0;	//the size of pixfile
	} //end of default constructor 
		
	/**
	 * Add a each size of pixfile in tol list<br>
	 */
		
	public void add(pixfile p) {
		list[size] = p;
		size++;	
	} //end of add
	
	
	/**
	 * Return a string of all list information<br>
	 */
	public String toString() {
		String str = ""; //display's message
		
		for(int i = 0; i < size; i++) {
			str = list[i].toString();
		}
		return str; //return a String
	} //end of toString
	
	
	
	/**
	 * Find a Pixfile based on file name <br>        
	 *
	 * <hr>
	 * Date created: Feb 20, 2013 <br>
	 * Date last modified: Feb 26, 2013 <br>
	 *
	 * <hr>
	 * @param search
	 * @return null
	 */
	 
	public pixfile search(String pa)
	{
		for(int i = 0; i < size; i++){ 
			if(pa.equals(list[i].getName())){
				return list[i];
				 }
			}
		return null; //return a null
	} //end of search
	
	/**
	 * Find a Pixfile based on photographer name <br>        
	 *
	 * <hr>
	 * Date created: Feb 20, 2013 <br>
	 * Date last modified: Feb 26, 2013 <br>
	 *
	 * <hr>
	 * @param searchphotographer
	 * @return null
	 */
	 
	public pixfile searchphotographer(String pv)
	{
		for(int i = 0; i < size; i++)
		{ 
			if(pv.equals(list[i].getPhotographer())) {
				return list[i];
				 }
				 
			}
		return null; //return a null
	} //end of searchphotographer
	
	/**
	 * Display the names of all Pixfiles <br>        
	 *
	 * <hr>
	 * Date created: Feb 21, 2013 <br>
	 * Date last modified: Feb 26, 2013 <br>
	 *
	 * <hr>
	 * @return
	 */
	 
	public void selectionSort()
	{
		int out, in, min;

	   for(out=0; out<size-1; out++)  // outer loop
		 {
			min = out;           // minimum
			for(in=out+1; in<size; in++) // inner loop
				if((list[in].getName()).compareTo(list[min].getName()) < 0)	{
				min = in;        // we have a new min
			swap(out, min);        // swap them
		 } // end for(out)
	   } // end selectionSort()
	}

	/**
	 * swap the names of all Pixfiles <br>        
	 *
	 * <hr>
	 * Date created: Feb 21, 2013 <br>
	 * Date last modified: Feb 26, 2013 <br>
	 *
	 * <hr>
	 * @return
	 */
	private void swap(int one, int two)
	{
	   pixfile temp = list[one];
	   list[one] = list[two];
	   list[two] = temp;
	}
	
	/*
	* display the name based pixfile names
	*/
	
	public void name(){
		
		for(int i = 0; i < size; i++) {
			JOptionPane.showMessageDialog(null, "The sorted file is: " + (list[i].getName()) + " ");
		}
	
	}
	
	/**
	 * Find the largest Pixfile <br>        
	 *
	 * <hr>
	 * Date created: Feb 21, 2013 <br>
	 * Date last modified: Feb 25, 2013 <br>
	 *
	 * <hr>
	 * @return
	 */
	
	public pixfile findmax(int number) {
				//ine size
				int i ;

		for(i = 1; i < size; i++) {
				if((list[i].getName()).compareTo(list[number].getName()) > 0)	{
				number = i;
			} 

		}
		return list[number];
	}
	
	/**
	 * Find the largest Pixfile <br>        
	 *
	 * <hr>
	 * Date created: Feb 21, 2013 <br>
	 * Date last modified: Feb 25, 2013 <br>
	 *
	 * <hr>
	 * @return
	 */
	
	
	public pixfile findmin(int number) {
		//ine size
		int i ;
		for(i = 1; i < size; i++) {
				if((list[i].getName()).compareTo(list[number].getName()) < 0)	{
				number = i;
			} 

		}
		return list[number];
	}
}	
	  
