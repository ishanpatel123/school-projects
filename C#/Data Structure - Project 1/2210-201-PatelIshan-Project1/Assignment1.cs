using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2210_201_PatelIshan_Project1
{
	class Assignment1
	{
		
		static int NEWFILE = 1,
				   DISPLAYFILE = 2,
				   QUIT = 3;
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
			String 	choice1 = "";
			CreditCardInfo newCard;
			CreditcardList clist = new CreditcardList ( );
			Utils.Utility.WelcomeMessage ("Credit Card Program");
			Console.WriteLine ("\n--- Welcome to the Patel Credit Card Infromation Program v.0 ---\n");
			

			choice = displayMenu ( );
			while (choice != QUIT)
			{

				switch (choice)
				{
					case 1:

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

							newCard = new CreditCardInfo (cardHolder, cardNumber, expireDate, holderPhone, holderEmail);
							clist.addPix (newCard);
							Console.Clear ( );

							Console.WriteLine ("\n\nWould you like to continue? Answer 'yes' or 'no'");
							choice1 = Console.ReadLine ( );
							choice1 = choice1.ToUpper ( );
							Console.WriteLine ("\n\n");
						} while (choice1 != "NO"); //ask user if he/she want to add another Credit Card information
						break;

					// Display a credit card information
					case 2:
						Console.WriteLine ("\n\n");
						Console.WriteLine (clist.toString ( ));
						Console.WriteLine ("\n\n");
						break;

					// All done and exit the program
					case 3:
						Utils.Utility.GoodbyeMessage ("");
						break;

					// Should not happen; just in case.
					default: 
						
						Console.WriteLine ("\nYour choice is invalid.\n"
									+ "You must type an integer between 1 and 3.");
						break;
				} //end switch

				// Get the next menu choice
				choice = displayMenu ( );
			}
		}

		// Get the menu choice

		public static int displayMenu ( )
		{
			int choice;

			string hold;

			do 
			{

			Console.WriteLine ("\t1.Enter the credit card information of card holder."
								+ "\n\n\t2.Display the credit card information."
								+ "\n\n\t3.Exit.\n");

			hold = Console.ReadLine( );
			
			choice = Convert.ToInt32 ((hold));  //convert the cohice of user entered and give apropriate choice of menu
				
			} while (choice < NEWFILE || choice > QUIT);

			//TO DO: add the code here to do input validation on selection.  The method should
			//not end until the user has entered a valid selection.
			
			//return the user's selection (the integer returned by the console)
			return choice;
		}
	}
}