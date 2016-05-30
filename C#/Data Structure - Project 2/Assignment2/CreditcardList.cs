/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Ishan Patel
// Department Name	: Computer and Information Sciences 
// File Name		: CreditcardList.cs
// Purpose			: To take an action on a collection of CreditCards,
//					 and store them indexer CreditCard List
// Author				: Ishan Patel, E-Mail: pateli@goldmail.etsu.edu
// Create Date			: Monday, September 30, 2013
//
//-----------------------------------------------------------------------------------
//
// Modified Date		: Monday, September 30, 2013
// Modified By			: Ishan Patel
//
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace Assignment2
{
	class CreditcardList 
	{
		private List<CreditCardInfo> list = new List<CreditCardInfo> (); // For a collection of credit cards

		#region Default constructor
		/// <summary>
		/// Default constructor for Creditcardlist class
		/// </summary>
		public CreditcardList ( )
		{
			list = new List<CreditCardInfo> ();
			SaveNeeded = false;
		}
		#endregion

		#region Copy constructor
		/// <summary>
		/// Copy constructor for CreditcardList
		/// </summary>
		/// <param name="obj"></param>
		public CreditcardList(CreditcardList obj)
		{
			//new instance 
			CreditcardList Temp = new CreditcardList();
			
			//coping data
			foreach (CreditCardInfo cc in obj.list)
			{
				Temp.list.Add(cc);
			}
			//pointing to new temporary data
            this.list = Temp.list;
		
		}
		#endregion

		#region Count property
		/// <summary>
		/// Count allows to determine how many CreditCards
		/// are currently in the list.
		/// </summary>
		public int Count
		{
			get { return list.Count; }
		}
		#endregion

		#region SaveNeeded property
		/// <summary>
		/// SaveNeeded property made the chage to true or stay false, and
		/// has getter and setter for it.
		/// </summary>
		public bool SaveNeeded 
		{ 
			get; 
			private set; 
		}
		#endregion

		#region Stringify the whole CreditCard List
		/// <summary>
		/// Display all credit card information files at once in list
		/// </summary>
		public void PrintDetail ( )
		{
			foreach (CreditCardInfo c in list)
			{
				Console.WriteLine (c.Detail ( ));
			}

		}
		#endregion

		#region Testing data in text file  by pipe character
		
		/// <summary>
		/// Testing an input string to have "|" character
		/// as a pipe separating 5 values(1 or more any characters)
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public bool TestString (string str)
		{
			Regex rgx = new Regex (@"^.+\|.+\|.+\|\d+\|.+/\d{2,4}$");
			Match match = rgx.Match (str);
			if (match.Success) return true;
			else return false;

		}
		#endregion

		#region Sort the entire List
		/// <summary>
		/// Sort the creditcardlist and set it to true.
		/// </summary>
		public void Sort ( )
		{
			list.Sort ( );
			 SaveNeeded = true;

		}
		#endregion

		#region OVERLOADING OPERATOR +
		//OVERLOADING +
		public static CreditcardList operator + (CreditcardList List, CreditCardInfo Card)
		{

			CreditcardList tempList = new CreditcardList (List);
			tempList.list.Add (Card);
			tempList.SaveNeeded = true;
			return tempList;

		}
		#endregion

		#region OVERLOADING OPERATOR -
		//OVERLOADING -
		public static CreditcardList operator - (CreditcardList List, CreditCardInfo Card)
		{
			CreditcardList tempList = new CreditcardList (List);
			tempList.list.Remove (Card);
			tempList.SaveNeeded = true;
			return tempList;
		}
		#endregion

		#region Overloading INDEXER[integer]
		/// <summary>Overloading INDEXER[integer] which check for
		/// the CreditCardInfo is between count and 0.And throw exception
		/// if there is an error.
		/// 
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public CreditCardInfo this[int i]
		{

			get
			{

				if (i >= list.Count || i < 0)
				{
					throw new ArgumentOutOfRangeException ( );
				}

				return list[i];
			}

			private set
			{
				if (i >= list.Count || i < 0)
				{
					throw new ArgumentOutOfRangeException ( );
				}
				list[i] = value;
				SaveNeeded = true;
			}



		}
		#endregion

		#region Overloading INDEXER[string]
		/// <summary>
		/// Overloading INDEXER[string] and save the data to list
		/// </summary>
		/// <param name="cardNumber"></param>
		/// <returns></returns>
		public CreditCardInfo this[string cardNumber]
		{

			get
			{
				CreditCardInfo c = new CreditCardInfo(cardNumber);
				list.Sort ( );
				//ppl might want to save data after the sort
				SaveNeeded = true;
				int i = list.BinarySearch (c);

				if (i == -1)
				{
					throw new Exception ("Not found");
				}

				return list[i];

			}
		}
		#endregion

		#region Retrieve data from a text file to populate
		/// <summary>
		/// Retrieve data from a text file to populate 
		/// and return an pixList object
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns> list
		public CreditcardList(string filePath)
		{
			StreamReader srd = null;


			try
			{
				srd = new StreamReader(filePath);

				CreditCardInfo tempCard = null;
				string[] str = null;
                string line = null;
                int skeptLineCount = 0;
				while (srd.Peek() != -1)
				{
                    //read and test line
                    line = srd.ReadLine();
                    if (TestString(line))
                    {
                        str = line.Split('|');
						tempCard = new CreditCardInfo (str[0], str[3], str[4], str[1], str[2]);
                        this.list.Add(tempCard);
                    }
                    else if (!TestString(line))
                    {
                        skeptLineCount += 1;
                    }
                    

				}

                if (skeptLineCount > 0)
	            {
		            throw new FileLoadException(skeptLineCount + " Line[s] did not match the pattern!");
	            }
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message, ex.StackTrace +"\n" + ex.GetType());
			}
			finally
			{
				if (srd != null)
					{
						srd.Close();
					}
			}

            SaveNeeded = false;
		}
		
		#endregion

		#region Save the list in a text file
		/// <summary>
		/// Save the list in a text file by using savefile dialog
		/// </summary>
		public void SaveToFile ( )
		{
			StreamWriter stw = null;
			List<CreditCardInfo> CardList = null;

			try
			{
				SaveFileDialog dlg = new SaveFileDialog ( );
				dlg.Filter = "text files|*.txt";
				dlg.Title = "Save credit card data";
				if (dlg.ShowDialog ( ) == DialogResult.Cancel)
				{
					return;
				}

				stw = new StreamWriter (new FileStream (dlg.FileName, FileMode.Create, FileAccess.Write));

				foreach (CreditCardInfo c in CardList)
				{
					stw.WriteLine (c.toStringFile ( ));
				}
				SaveNeeded = false;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				if (stw != null)
				{
					stw.Close ( );
				}

			}

		}
		#endregion

	}
}