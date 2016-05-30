
/**
 * ---------------------------------------------------------------------------
 * File name: pixList.java
 * Project name: pixfile2
 * ---------------------------------------------------------------------------
 * Creator's name and email: Ishan Patel pateli@goldmail.etsu.edu
 * Course:  CSCI 1260
 * Creation Date: Feb 19, 2013
 * Date of Last Modification: Mar 6, 2013
 * ---------------------------------------------------------------------------
 */



/**
 * Stores a collection of pixfiles<br>
 *
 * <hr>
 * Date created: Feb 19, 2013<br>
 * Date last modified: Mar 6, 2013<br>
 * <hr>
 * @author Marty Barrett
 */

public class pixList
{
   private pixfile[] list; // For a collection of pixfiles
   private int numPix;     // Number of pixfiles actually stored
   private int maxPix;     // Maximum number of pixfiles possible
   
   // Default constructor
   public pixList() {
	   maxPix = 10;
	   list = new pixfile[maxPix];
	   numPix = 0;
   }
   
   // Overloaded constructor
   //   Only allow up to 100 pixfiles
   public pixList(int n) {
	   // Error check the requested size
	   if ( n <= 0 || n > 100 ) {
		   maxPix = 5;
	   } else {
		   maxPix = n;
	   }
	   list = new pixfile[maxPix];
	   numPix = 0;
   }
   
   // Insert a new pixfile into the list
   //   but only if there's room
   public void addPix(pixfile p) {
	   if (numPix < maxPix) {
		   list[numPix] = new pixfile(p);
		   numPix++;
	   }
   }
      
   // Getter for number of pixfiles stored
   public int getNumPix() {
	   return numPix;
   }
   
   public pixfile get(int i) {
	   if ( i < numPix ) return list[i];
	   else return null;
   }
   
   // Search for a pixfile by file name
   public pixfile searchByName(String str) {
	   pixfile p = null;
	   int i = 0;
	   boolean found = false;
	   
	   // Continue searching until either
	   //   end of array is reached, not found
	   //   found it
	   while ( i < numPix && !found ) {
		   if ( list[i].getName( ).equals(str) ) {
			   found = true;
			   p = list[i];
		   }
		   else {
			   i++;
		   }
	   }
	   return p;
   }
   
   // Search for a pixfile by photographer name
   public pixfile searchByPhotographer(String str) {
	   pixfile p = null;
	   int i = 0;
	   boolean found = false;
	   
	   // Continue searching until either
	   //   end of array is reached, not found
	   //   found it
	   while ( i < numPix && !found ) {
		   if ( list[i].getPhotographer ( ).equals(str) ) {
			   found = true;
			   p = list[i];
		   }
		   else {
			   i++;
		   }
	   }
	   return p;
   }
   
   // Stringify the whole array
   public String toString() {
	   String s = "";
	   for (int i=0; i<numPix; i++) {
		   s += list[i].toString ( );
	   }
	   return s;
   }
   
   // Find the largest name
   //     Only used by sort( )
   private int findMaxName(int n) {
	   int max = 0;
	   
	   // Assume list[max] is largest unless list[i] is bigger
	   for (int i=1; i<n; i++) {
		   if (list[i].getName ( ).compareTo (list[max].getName ( )) > 0) {
			   max = i;
		   }
	   }
	   return max;
   }
   
   // Selection sort
   // Find the largest thing, move it to
   //    the end of the current part of the array,
   //    repeat until current part is one element
   public void sort() {
	   int big;
	   
	   // Traditional selection sort
	   // Use the whole array, then one less, then one less ..
	   for (int i=numPix; i>1; i--) {
		   
		   // Find the largest name between 0 and i
		   big = findMaxName(i);
		   
		   // Swap the largest from position i
		   //   into position big
		   pixfile p = list[big];
		   list[big] = list[i-1];
		   list[i-1]   = p;
	   }
   }
   
   // Sort and stringify
   public String getSorted() {
	   sort();
	   return toString();
   }
   
   // Find the smallest by file size
   public pixfile findMin() {
	   int where = 0;
	   
	   // Assume list[where] is smallest,
	   //    change where to i if i'th is smaller
	   for (int i = 1; i< numPix; i++) {
		   if ( list[i].getFileSize ( ) < list[where].getFileSize ( ) ) {
			   where = i;
		   }
	   }
	   return list[where];
   }
   
   // Find the largest by file size
   public pixfile findMax() {
	   int where = 0;
	   
	   // Assume list[where] is largest,
	   //    change where to i if i'th is larger
	   for (int i = 1; i< numPix; i++) {
		   if ( list[i].getFileSize ( ) > list[where].getFileSize ( ) ) {
			   where = i;
		   }
	   }
	   return list[where];
   }
   
   public boolean remove(String key) {
	   boolean found = false;
	   int i = 0;
	   
	   // Continue searching until either
	   //   end of array is reached, not found
	   //   found it
	   while ( i < numPix && !found ) {
		   if ( list[i].getName( ).equals(key) ) {
			   found = true;
		   }
		   else {
			   i++;
		   }
	   }
	   
	   // If found, copy the last pixfile into position i
	   //    and decrement the count, unless there's only
	   //    one pixfile in the list - just decrement (to zero)
	   if ( found ) {
		   if (numPix >= 1) {
			   list[i] = list[numPix];
		   }
		   numPix--;
	   }

	   // Return whether you found it or not
	   return found;
   }
   
   public String[] getTitles(){
	   String[] s = new String[numPix];
	   for (int i=0; i<numPix; i++) {
		   s[i] = list[i].getName();
	   }
	return s;
	   
   } 
   
  
}
