// ------------------------------------------------ file name --------------------------------------------------------
//	Programmer’s Name:	Ishan Patel	
//	Course-Section:	CSCI-3230-001
//	Creation Date: 5/5/2014
//	Date of Last Modification:	5/5/2014
//	e-mail address:	pateli@goldmail.etsu.edu
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project4
{
	class CreateBinaryFile
	{
		//-------------------------------------------------------------------------------------
		// Class Name: CreateBInaryFIle
		//	Creation Date: 5/5/2014
		//	Date of Last Modification:	5/5/2014
		//	e-mail address:	pateli@goldmail.etsu.edu
		// @author Ishan Patel
		//-------------------------------------------------------------------------------------

		public string sortedText = "";
		/// <summary>
		/// Reads the source file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="FolderPath">The folder path.</param>
		/// <param name="heapSize">Size of the heap.</param>
		/// <param name="mergeFiles">The merge files.</param>
		
		public void readSourceFile (String fileName, String FolderPath, int heapSize, int mergeFiles)
		{
			//read the source file
			using (BinaryReader b = new BinaryReader (File.Open (fileName, FileMode.Open)))
			{
				long position = 0;
				int i = 1;
				long lengthOfCurFile= (int)b.BaseStream.Length;
				//gets the lenghth of file
				int length = (int)lengthOfCurFile / 4;
				//create new temparary file for storage
				BinaryWriter c = new BinaryWriter (File.Create (FolderPath + "\\Temp" + i + ".bin"));
				//create list to hold the storage before adding to temp file
				List<int> tempList = new List<int> ( );
				
				//Is this end of the file?
				while (position < lengthOfCurFile)
				{
					//If not create new list which has all sorted values to write to file
					if (tempList.Count ( ) == heapSize)
					{
						tempList.Sort ( );
						for (int j = 0; j < heapSize; j++)
							//write to new temp file just created
							c.Write (tempList[j]);
						c.Close ( );
						i++;
						//create a new temp file to repeat
						c = new BinaryWriter (File.Create (FolderPath + "\\Temp" + i + ".bin"));
						tempList = new List<int> ( );
					}
					tempList.Add (b.ReadInt32 ( ));
					//move to next position of file
					position += sizeof (int);
				}

				//Is this end of source file and then create new file with how many elements left in source file
				if (tempList.Count ( ) > 0)
				{
					tempList.Sort ( );
					for (int j = 0; j < tempList.Count ( ); j++)
						c.Write (tempList[j]);
					c.Close ( );
				}
				//close the source file
				b.Close ( );
			}
		}


		/// <summary>
		/// Creates the sort file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="FolderPath">The folder path.</param>
		/// <param name="sortedFile">The sorted file.</param>
		/// <param name="heapSize">Size of the heap.</param>
		/// <param name="mergeFiles">The merge files.</param>
	
		public void createSortFile (String fileName, String FolderPath, String sortedFile, int heapSize, int mergeFiles)
		{
			//get the total size of file
			int totalHeapSize = mergeFiles * heapSize;
			int iLength = 0;
			//read the source file again to get the length
			using (BinaryReader b = new BinaryReader (File.Open (fileName, FileMode.Open)))
			{
				iLength = (int)b.BaseStream.Length;
			
				b.Close();
			}
			//divide the length to get how mnay ints in file
			int size = iLength/4;
			//Tells how many files to traverse
			int filesToTraverse = size/(heapSize);
			int k = heapSize * mergeFiles;
			HeapMin min = new HeapMin (k);
			//create a array to hold all ints from heap
			int[] numbers = new int[10000000];
			String filename = "";
			bool endofFiles = false;
			int nums = 0, pos = 0;
			int track = 0;
			int i = 1;
			int jk = 0;
			int trackFiles = mergeFiles + track;
			//create a array of struct to store all ints before to put them in heap
			fileName[] fName = new fileName[totalHeapSize];
				//go to each files and create a new temp file
				for (; i <= trackFiles; )
				{
					int ka = i;
					int kb = trackFiles;
						//reads a file how many user want to merge at time
						for (; ka <= kb; ka++)
						{
							filename = FolderPath + "\\Temp" + ka + ".bin";
							//read from the file and put it to struct of ints and repeat till its an end of file
							using (BinaryReader b = new BinaryReader (File.Open (filename, FileMode.Open)))
							{
								while (pos < (int)b.BaseStream.Length)
								{
									fName[nums] = new fileName ( ) { iNum = b.ReadInt32 ( ) };
									nums++;
									pos += sizeof (int);
									b.BaseStream.Seek (pos, SeekOrigin.Begin);			
								}					
								b.Close ( );
							}
								//reset the position
								pos = 0;	
						}						
						jk++;
						//gets the ints from merge files and put it to heap
						for (int j = 0; j < k; j++)
						{
							min.Insert (fName[j].iNum);
						}
						//create a new temp file to store all ints from the heap
						BinaryWriter c = new BinaryWriter (File.Create (FolderPath + "\\Temp" + kb + ".bin"));
						String s = FolderPath + "\\Temp" + kb + ".bin";
						numbers = min.heapSort ( );
						//numbers holds ints from heap and then write to temp file
						for (int h = 1; h < numbers.Length; h++)
						{
							c.Write (numbers[h]);
						}
						c.Close ( );
						//If this is end of all files, just terminate the program
						if (endofFiles == true)
						{
							break;
						}
						i += (mergeFiles -1);
						track += (mergeFiles - 1);
						trackFiles = mergeFiles + track;
						if (trackFiles > (size/heapSize))
						{
						
							int tr = trackFiles - (size / heapSize);
							trackFiles = trackFiles - tr;
							double remainder = (double)size / heapSize;
							//decimal f= decimal.Round (remainder);
							bool isInt = remainder == (int)remainder;
							//String s= "";
							//bool isDouble = Double.TryParse(s, out remainder)
							if (isInt == false)
							{
								trackFiles++;
							}
						
							endofFiles = true;
						}

						int ak = i;
						int ab = trackFiles;
						k = 0;
						//read next three file to continue the process
						for (; ak <= ab; ak++)
						{
							filename = FolderPath + "\\Temp" + ak + ".bin";

							using (BinaryReader b = new BinaryReader (File.Open (filename, FileMode.Open)))
							{
								int x = (int)b.BaseStream.Length/4;
								k += x;
								b.Close ( );
							}
						}				
						fName = new fileName[k];
						min = new HeapMin (k);
						pos = 0;
						jk = 0;
						nums = 0;		
				}
				//if the sorted file exist in the degug folder, delete the previous one and create sorted file
			if (File.Exists (sortedFile + "\\" + size + "sorted.bin"))
			{
				File.Delete (sortedFile + "\\" + size + "sorted.bin");
			}
			File.Copy (FolderPath + "\\Temp" + trackFiles + ".bin", sortedFile +"\\"+size + "sorted.bin" );
			sortedText = (sortedFile + "\\" + size + "sorted.bin").ToString();
		}	
	}
}