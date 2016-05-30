/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Ishan Patel
// Department Name	: Computer and Information Sciences 
// File Name		: Program.cs
// Purpose			: use to add and retrive credit card information and put/get 
//						credit card information from text file and display it.
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
using System.Windows.Forms;
using System.IO;

namespace Assignment2
{
	class Assignment1
	{
		
		static int	SaveFile = 0,
					EMPTYLIST = 1,
					TEXTFILE = 2,
					NEWFILE = 3,
					REMOVEFILE = 4,
					DISPLAYNTHLIST = 5,
					DISPLAYCARDNUM = 6,
					DISPLAYPERSON =7,
					DISPLAYNONEXPIRED = 8,
					SORTCARD = 9,
					DISPLAYALLFILE = 10,
					QUIT = 11;

		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		[STAThread]
		static void Main (string[] args)
		{
			//the user's main menu selection

			int choice; // User menu choice
			String cardHolder,
					cardNumber,
					expireDate,
					holderPhone,
					holderEmail;
			String choice1 = " ";//if user want add another credit card information
			CreditcardList clist = null;

			Utils.Utility.WelcomeMessage ("Credit Card Program");
			Console.WriteLine ("\n--- Welcome to the Patel Credit Card Infromation Program v.1 ---\n");

			choice = displayMenu ( );
			while (choice != QUIT)
			{

				switch (choice)
				{
					#region 0.	Save a CreditcardList to text file
					case 0: 
						Console.Clear();
						if (clist == null && clist.Count == 0)
						{
							Console.WriteLine("\n*NO DATA*\n");
							Console.WriteLine("Press Enter to continue...");
							Console.ReadLine();
							break;
                        
						}
						else
						{
							clist.SaveToFile(); //Save a CreditCardList to text file
							break;
						}
                    
                #endregion

					#region 1.	Create a new empty CreditCardList.
					case 1:
						if (clist != null)
						{

							Console.Clear ( );
							Console.WriteLine ("-----------------------Notice--------------------");
							Console.WriteLine ("------------ALL UNSAVED DATA WILL BE LOST------------");
							Console.WriteLine ("Do you want to Continue? yes/no");
							if (Console.ReadLine ( ).ToLower ( ) == "yes")
							{
								clist = new CreditcardList ( );
								Console.WriteLine ("Press Enter to continue...");
								Console.ReadLine ( );
							}
						}
						else
						{
							Console.Clear ( );
							clist = new CreditcardList ( );
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
						}

						break;
					#endregion

					#region 2.	Open a  text file and populate a CreditCardList.
					
					case 2:
						
						Console.Clear();
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Title = "Choose the text file.";
                    dlg.Filter = "text file |*.txt";

                    if (clist != null)
                    {

						Console.WriteLine ("-----------------------Notice--------------------");
						Console.WriteLine ("------------ALL UNSAVED DATA WILL BE LOST------------");
						Console.WriteLine ("Continue? yes/no");

                        if (Console.ReadLine().ToLower() == "yes")
                        {
                            if (dlg.ShowDialog() == DialogResult.Cancel)
                            { break; }

                            clist = new CreditcardList(dlg.FileName);
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        
                    }
                    else
                    {
                        if (dlg.ShowDialog() == DialogResult.Cancel)
                        { break; }
                        clist = new CreditcardList(dlg.FileName);
                        Console.WriteLine("\n*DONE*\n");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                    
                    
						break;
					#endregion

					#region 3.	Add a CreditCard to the current CreditCardList.
					case 3:
						
						if (clist == null)
						{
							clist = new CreditcardList ( );
						}

						Console.Clear ( );
						do
						{
							// Gather all information using console application
							// Get the Credit Card holder name, Credit Card number, expiration date,
							// holder's phone number and holder's email address
							Console.Clear ( );
							Console.WriteLine ("Please enter the Credit Card holder's name.");
							cardHolder = Console.ReadLine ( );

							Console.WriteLine ("\nPlease enter Credit Card number.");
							cardNumber = Console.ReadLine ( );

							Console.WriteLine ("\nPlease enter expiration date.");
							expireDate = Console.ReadLine ( );

							Console.WriteLine ("\nPlease enter holder's phone number.");
							holderPhone = Console.ReadLine ( );

							Console.WriteLine ("\nPlease enter holder's e-mail address.");
							holderEmail = Console.ReadLine ( );

							// Create a new CreditCardInfo object

							clist += new CreditCardInfo (cardHolder, cardNumber, expireDate, holderPhone, holderEmail);
							Console.Clear ( );

							Console.WriteLine ("\n\nWould you like to continue? Answer 'yes' or 'no'");
							choice1 = Console.ReadLine ( );
							choice1 = choice1.ToUpper ( );
							Console.WriteLine ("\n\n");
						} while (choice1 != "NO"); //ask user if he/she want to add another Credit Card information
						
						break;
					#endregion

					#region 4.	Remove a CreditCard from the current CreditCardList.

					case 4://here
						//remove a Creditcardlist based on its position from text file
						Console.Clear ( );
						if (clist == null || clist.Count == 0)
						{
							Console.WriteLine ("\n*NO DATA*\n");
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
							break;
						}					

						for (int i = 0; i < clist.Count; i++)
						{
							Console.WriteLine ("\n\nPosition: {0}  \t {1}", i, clist[i].Detail ( ));
						}

						Console.WriteLine ("\n\nPlease enter the corresponding position of the Credit Card you want to remove.");

						try
						{
							clist -= clist[int.Parse (Console.ReadLine ( ))]; //put -1 position back to other CreditCardInfo after delete
						}
						catch (Exception ex)
						{

							MessageBox.Show (ex.GetType ( ) + "\n" + ex.Message + "\n",
								"Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						}

						Console.WriteLine ("\n*DONE*\n");
						Console.WriteLine ("Press Enter to continue...");
						Console.ReadLine ( );

						break;
					#endregion

					#region 5.	Retrieve and display a CreditCard from position n in the list.

					case 5:
						// It got CreditCard Information from the text file and display it 
						// on DOS window on nth position
						Console.Clear ( );
						if (clist == null || clist.Count == 0)
						{
							Console.WriteLine ("\n*NO DATA*\n");
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
							break;
						}

						try
						{
							Console.WriteLine ("Please enter the position in the list(0 - " + (clist.Count - 1) + ")");
							string str = Console.ReadLine ( );

							Console.Clear ( );
							Console.WriteLine (clist[int.Parse (str)].Detail ( ));
						}
						catch (Exception ex)
						{

							MessageBox.Show (ex.GetType ( ) + "\n" + ex.Message + "\n",
								"Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						}


						Console.WriteLine ("\nPress Enter to continue...");
						Console.ReadLine ( );


						break;
					#endregion

					#region 6.	Retrieve and display a CreditCard by its card number.

					case 6:
						// It got CreditCard Information from the text file by its Credit card number
						//and display it on DOS window
						Console.Clear ( );
						if (clist == null || clist.Count == 0)
						{
							Console.WriteLine ("\n*NO Information in Text File*\n");
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
							break;
						}
						
						Console.WriteLine ("Please enter the Card Number for a Credit Card to display.");
						string tempCardNumber = Console.ReadLine ( );
						try
						{
							Console.WriteLine (clist[tempCardNumber].Detail ( ));
						}
						catch (Exception ex)
						{

							MessageBox.Show (ex.Message, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
							break;
						}


						Console.WriteLine ("Press Enter to continue...");
						Console.ReadLine ( );


						break;
					#endregion

					#region  7.	Retrieve and display all CreditCards belonging to a specified person.
					case 7:
						// It got CreditCard Information from the text file
						//and display it on DOS window on nth position belong to holder's name
						Console.Clear ( );
						if (clist == null || clist.Count == 0)
						{
							Console.WriteLine ("\n*NO DATA*\n");
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
							break;
						}
						

						Console.WriteLine ("Please enter Card Holder's name.");
						string tempHoldersName = Console.ReadLine ( );

						bool found = false;
						for (int i = 0; i < clist.Count; i++)
						{
							if (clist[i].Equals (tempHoldersName))
							{
								found = true;
								Console.WriteLine (clist[i].Detail ( ));
							}
						}
						if (!found)
						{
							Console.WriteLine ("\n*Not found!*\n");
						}


						Console.WriteLine ("\n*DONE*\n");
						Console.WriteLine ("Press Enter to continue...");
						Console.ReadLine ( );
						break;
					#endregion

					#region 8.	Retrieve and display all non-expired valid credit cards.
					case 8:
						// It got CreditCard Information from the text file by all non-expired creditcard
						//and display it on DOS window on nth position
						 Console.Clear();
                    if (clist == null)
                    {
                        Console.WriteLine("\n*NO DATApp*\n");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break; 
                    }
                    else if (clist.Count == 0)
                    {
                        Console.WriteLine("\n*NO DATA*\n");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                    }
					
                    for (int i = 0; i < clist.Count; i++)
                    {
						if (!(clist[i].CardType.Equals(clist[i].Not_Expired)))
						{
                            Console.WriteLine(clist[i].Detail());
                        }
                    }
                    Console.WriteLine("\n*DONE*\n");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();

                    break;
					#endregion

					#region 9.	Sort the CreditCards in the CreditCardList by card number.
					case 9:
						//sort the list ans display on DOS window
						Console.Clear ( );
						if (clist == null || clist.Count == 0)
						{
							Console.WriteLine ("\n*NO DATA*\n");
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
							break;
						}
						
						clist.Sort ( );

						Console.WriteLine ("\n*DONE*\n");
						Console.WriteLine ("Press Enter to continue...");
						Console.ReadLine ( );
						break;
					#endregion

					#region 10.	Display all CreditCards in the CreditCardList.
					case 10:
						//Display all CreditCards in the CreditCardList from the text file
						Console.Clear ( );
						if (clist == null || clist.Count == 0)
						{
							Console.WriteLine ("\n*NO DATA*\n");
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
							break;
						}
												else
						{
							clist.PrintDetail ( );
							Console.WriteLine ("\n*DONE*\n");
							Console.WriteLine ("Press Enter to continue...");
							Console.ReadLine ( );
						}
						break;
					#endregion

					#region 11.	Exit the program.
					case 11:
						Utils.Utility.GoodbyeMessage ( );							
						break;
					#endregion

					default:
							Console.WriteLine ("\nPlease! Choose the choice between 1 to 11.\n");
							break;
				} //end switch

				// Get the next menu choice
				choice = displayMenu ( );
			}
		}

		#region display menu selecetion
		// Get the menu choice
		public static int displayMenu ( )
		{
			int choice;

			string hold;

			do 
			{

			Console.WriteLine ("\t0. Save a CreditCardList"
				+ "\n\t1.	Create a new empty CreditCardList"
				+ "\n\t2.	Open a  text file and populate a CreditCardList"
				+ "\n\t3.	Add a CreditCard to the current CreditCardList"
				+ "\n\t4.	Remove a CreditCard from the current CreditCardList"
				+ "\n\t5.	Retrieve and display a CreditCard from position n in the list"
				+ "\n\t6.	Retrieve and display a CreditCard by its card number"
				+ "\n\t7.	Retrieve and display all CreditCards belonging to a specified" +"\n\t\tperson"
				+ "\n\t8.	Retrieve and display all non-expired valid credit cards"
				+ "\n\t9.	Sort the CreditCards in the CreditCardList by card number"
				+ "\n\t10.	Display all CreditCards in the CreditCardList"
				+ "\n\t11.	Exit the program ");

			hold = Console.ReadLine( );
			
			choice = Convert.ToInt32 ((hold));  //convert the cohice of user entered and give apropriate choice of menu

			} while (choice < SaveFile || choice > QUIT);

			//TO DO: add the code here to do input validation on selection.  The method should
			//not end until the user has entered a valid selection.
			
			//return the user's selection (the integer returned by the console)
			return choice;
		}
		#endregion

	}
}