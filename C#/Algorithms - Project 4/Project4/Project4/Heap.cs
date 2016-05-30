// ------------------------------------------------ file name --------------------------------------------------------
//	Programmer’s Name:	Ishan Patel	
//	Course-Section:	CSCI-3230-001
//	Creation Date: 3/28/2014
//	Date of Last Modification:	3/28/2014
//	e-mail address:	pateli@goldmail.etsu.edu
// --------------------------------------------------------------------------------------------------------------------
//	Purpose - gets all input string from user, call heap sort to display all string in sorted order
// --------------------------------------------------------------------------------------------------------------------
//	Input - the number of strings and strings per one line
//	Output - strings in sorted order
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project4
{
	//-------------------------------------------------------------------------------------
	// Class Name: Heap
	// Class Purpose:  adds all strings to heap and sort all strings in ascii order
	// Date created: 3/28/2014
	// Date last modified: 3/28/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------

	class HeapMax
	{
		private int max_size;           //max size of heap, this is included just to explain that size is not maximum size, but is current heap size.
		private int size;               //size of current heap
		private int[] h;             //array of strings that the heap will use
		int index;

		// constructor
		public HeapMax (int maxValue)
		{
			size = 0;
			max_size = maxValue + 1;
			h = new int[max_size];	//creates an array
		}
		//Sorts a given array of items.

		/// <summary>
		/// Heaps the sort.
		/// </summary>
		/// <returns></returns>
		/// 
		public int[] heapSort ( )
		{
			int[] result = new int[max_size];	//creates an new empty array
			for (int i = size; i >= 1; i--)
			{
				result[i] = extract_max ( );	//add strings from heap to empty array
			}
			return result;	//return string array
		}


		/// <summary>
		/// Extract_maxes this instance.
		/// </summary>
		/// <returns></returns>
		public int extract_max ( )
		{
			int max;
			max = h[1];				//holds first item in heap
			h[1] = h[size];			//swap last item in the heap with the first item
			size--;					//reduce size of heap by one
			maxheapify (1, size);	//call maxheapify to fix the heap
			return (max);			//return max
		}

		/// <summary>
		/// Maxheapifies the specified i.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="size">The size.</param>
		/// 
		private void maxheapify (int i, int size)
		{
			int large;
			int temp;
			int l = left (i);		//left child in heap
			int r = right (i);		//right child in heap
			large = ((l <= size) && ((h[l] < h[i]))) ? l : i;
			//Is left child bigger than parent?
			//If yes,large becomes left, else becomes index
			//if ((l <= size) && (String.CompareOrdinal (h[l], h[i]) > 0))
			//{
			//	large = l;
			//}
			//else
			//{
			//	large = i;
			//}
			//is rght child bigger than parent?
			//If yes,large becomes right
			if ((r <= size) && (h[r] < h[large]))
			{
				large = r;
			}
			//If large is not index heap, swap index heap with large heap
			if (large != i)
			{
				temp = h[i];
				h[i] = h[large];
				h[large] = temp;
				maxheapify (large, size);
			}

		}

		/// <summary>
		/// Prints this heap array.
		/// </summary>
		/// 
		public void Print ( )
		{
			for (int i = 0; i <= size; i++)
			{
				Console.Write (h[i]);		//prints every string in heap array
			}
		}

		/// <summary>
		/// Insert a new string item into string array by using ExtraMax
		/// </summary>
		/// <param name="item"></param>
		public void Insert (int item)
		{

			int extra;
			h[++size] = item;
			index = size;
			//If parent index not equal 0, and heap index is bigger than parent heap?
			//swap parent of index with heap of index
			while (Parent (index) > 0 && (h[index] < h[Parent (index)]))
			{
				extra = h[Parent (index)];
				h[Parent (index)] = h[index];
				h[index] = extra;
				index = Parent (index);	//index gets parent index
			}
		}

		/// <summary>
		/// Parents the specified string index.
		/// </summary>
		/// <param name="stringIndex">Index of the string.</param>
		/// <returns></returns>
		/// 
		private int Parent (int stringIndex)
		{
			return stringIndex >> 1;	//parent of stringIndex
		}

		/// <summary>
		/// Lefts the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		/// 
		private int left (int index)
		{
			return 2 * index;		//left child of index
		}

		/// <summary>
		/// Rights the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		private int right (int index)
		{
			return 2 * index + 1;	//right child of index
		}
	}

	//-------------------------------------------------------------------------------------
	// Class Name: Heap
	// Class Purpose:  adds all strings to heap and sort all strings in ascii order
	// Date created: 3/28/2014
	// Date last modified: 3/28/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------

	class HeapMin
	{
		private int min_size;           //max size of heap, this is included just to explain that size is not maximum size, but is current heap size.
		private int size;               //size of current heap
		private int[] h;             //array of strings that the heap will use
		int index;

		// constructor
		public HeapMin (int maxValue)
		{
			size = 0;
			min_size = maxValue + 1;
			h = new int[min_size];	//creates an array
		}
		//Sorts a given array of items.

		/// <summary>
		/// Heaps the sort.
		/// </summary>
		/// <returns></returns>
		/// 
		public int[] heapSort ( )
		{
			int[] result = new int[min_size];	//creates an new empty array
			for (int i = size; i >= 1; i--)
			{
				result[i] = extract_min ( );	//add strings from heap to empty array
			}
			return result;	//return string array
		}


		/// <summary>
		/// Extract_maxes this instance.
		/// </summary>
		/// <returns></returns>
		public int extract_min ( )
		{
			int min;
			min = h[1];				//holds first item in heap
			h[1] = h[size];			//swap last item in the heap with the first item
			size--;					//reduce size of heap by one
			minheapify (1, size);	//call maxheapify to fix the heap
			return (min);			//return max
		}

		/// <summary>
		/// Maxheapifies the specified i.
		/// </summary>
		/// <param name="i">The i.</param>
		/// <param name="size">The size.</param>
		/// 
		private void minheapify (int i, int size)
		{
			int large;
			int temp;
			int l = left (i);		//left child in heap
			int r = right (i);		//right child in heap
			large = ((l <= size) && ((h[l] > h[i]))) ? l : i;
			//Is left child bigger than parent?
			//If yes,large becomes left, else becomes index
			//if ((l <= size) && (String.CompareOrdinal (h[l], h[i]) > 0))
			//{
			//	large = l;
			//}
			//else
			//{
			//	large = i;
			//}
			//is rght child bigger than parent?
			//If yes,large becomes right
			if ((r <= size) && (h[r] > h[large]))
			{
				large = r;
			}
			//If large is not index heap, swap index heap with large heap
			if (large != i)
			{
				temp = h[i];
				h[i] = h[large];
				h[large] = temp;
				minheapify (large, size);
			}

		}

		/// <summary>
		/// Prints this heap array.
		/// </summary>
		/// 
		public void Print ( )
		{
			for (int i = 0; i <= size; i++)
			{
				Console.Write (h[i]);		//prints every string in heap array
			}
		}

		/// <summary>
		/// Insert a new string item into string array by using ExtraMax
		/// </summary>
		/// <param name="item"></param>
		public void Insert (int item)
		{

			int extra;
			h[++size] = item;
			index = size;
			//If parent index not equal 0, and heap index is bigger than parent heap?
			//swap parent of index with heap of index
			while (Parent (index) > 0 && (h[index] > h[Parent (index)]))
			{
				extra = h[Parent (index)];
				h[Parent (index)] = h[index];
				h[index] = extra;
				index = Parent (index);	//index gets parent index
			}
		}

		/// <summary>
		/// Parents the specified string index.
		/// </summary>
		/// <param name="stringIndex">Index of the string.</param>
		/// <returns></returns>
		/// 
		private int Parent (int stringIndex)
		{
			return stringIndex >> 1;	//parent of stringIndex
		}

		/// <summary>
		/// Lefts the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		/// 
		private int left (int index)
		{
			return 2 * index;		//left child of index
		}

		/// <summary>
		/// Rights the specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		private int right (int index)
		{
			return 2 * index + 1;	//right child of index
		}
	}

}