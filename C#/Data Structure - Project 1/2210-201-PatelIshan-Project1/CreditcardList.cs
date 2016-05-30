using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2210_201_PatelIshan_Project1
{
	class CreditcardList
	{
		private CreditCardInfo[] list; // For a collection of credit cards
		private int numCard;     // Number of credit card holders actually stored
		private int maxCard;     // Maximum number of credit card holder possible

		private enum CCType { INVALID, VISA, MASTERCARD, AMERICAN_EXPRESS, DISCOVERY, OTHER };

		 // Default constructor
		public CreditcardList ( )
	   {
		   maxCard = 10;
		   list = new CreditCardInfo[maxCard];
		   numCard = 0;
	   }

		public CreditcardList (int n)
	   {
		   // Error check the requested size
		   if (n <= 0 || n > 100)
		   {
			   maxCard = 5;
		   }
		   else
		   {
			   maxCard = n;
		   }
		   list = new CreditCardInfo[maxCard];
		   numCard = 0;
	   }

		// Insert a new Credit Card into the list
		//   but only if there's room
		public virtual void addPix (CreditCardInfo p)
		{
			if (numCard < maxCard)
			{
				list[numCard] = new CreditCardInfo (p);
				numCard++;
			}
		}

		// Getter for number of Credit Cards stored
		public virtual int NumPix
		{
			get
			{
				return numCard;
			}
		}

		public virtual CreditCardInfo get (int i)
		{
			if (i < numCard)
			{
				return list[i];
			}
			else
			{
				return null;
			}
		}

		// Stringify the whole array
		public String toString ( )
		{
			String s = "";
			for (int i = 0; i < numCard; i++)
			{
				s += list[i].Detail ( );
			}
			return s;
		}

		


		public string VaidateCCNumber (string num)
		{
			CCType newCCard;
			int[] numbers = new int[num.Length];
			int sum = 0;//accumulator


			//fill out the array of integers with digits from cc number.
			for (int i = 0; i < num.Length; i++)
			{
				numbers[i] = int.Parse (num.Substring (i, 1));
			}

			//Luhn's Algorithm.
			bool count = false;
			for (int i = num.Length - 1; i >= 0; i--)
			{
				if (count)
				{
					if (numbers[i] * 2 > 9)
					{

						sum += numbers[i] * 2 - 9;

					}
					else
					{
						sum += numbers[i] * 2;
					}

				}
				else
				{
					sum += numbers[i];
				}

				count = !count;

			}

			//if the card number valid, find the type
			if (sum % 10 == 0)
			{
				Regex rgx = new Regex ("3[4,7]");//amex pattern
				//match the string of 2 first digits to amex pattern
				Match matchAmmex = rgx.Match (num.Substring (0, 2));//testing (could
				//use a substring method)

				rgx = new Regex ("5[1-5]");//MasterCard  pattern
				//match the string of 2 first digits to MasterCard pattern
				Match matchMasterCard = rgx.Match (num.Substring (0, 2));

				rgx = new Regex ("6[0,4,5][1,4]1?");//DiscoveryCard  pattern
				//match the string of 4 first digets to DiscoveryCard pattern
				Match matchDiscoveryCard = rgx.Match (num.Substring (0, 4));


				//card type identifier for VISA
				if (numbers[0] == 4)
				{
					newCCard = CCType.VISA;
				}
				else if (matchAmmex.Success)
				{
					newCCard = CCType.AMERICAN_EXPRESS;
				}
				else if (matchMasterCard.Success)
				{
					newCCard = CCType.MASTERCARD;
				}
				else if (matchDiscoveryCard.Success)
				{
					newCCard = CCType.DISCOVERY;
				}
				else
				{
					newCCard = CCType.OTHER;
				}
			}
			else
			{
				newCCard = CCType.INVALID;
			}

			return "The card type: " + newCCard;
		}

		//Find the validate expire date of Credit card for user and return Match 
		//found correct or incorrect or invalid

		public string ValidateExpDate (string expdate)
		{
			Regex rgx = new Regex (@"\b[1-12]?/(\d\d|19\d\d|200\d|201\d)\b");//Expiration date pattern

			Match match = rgx.Match (expdate);
			if (match.Success)
			{
				string[] monthAndYear = expdate.Split ('/');//splitting the string

				DateTime CurDate = DateTime.Today;
				int CurMonth = CurDate.Month;
				int CurYear = CurDate.Year;

				//if year entered as 00 add 20 in the front to make it 0000 format
				if (monthAndYear[1].Length == 2)
				{
					monthAndYear[1] = "20" + monthAndYear[1];
				}

				//validation of expire date
				if (CurYear <= Convert.ToInt32 (monthAndYear[1]) &&
					CurMonth < Convert.ToInt32 (monthAndYear[1]))
				{
					if (Convert.ToInt32 (monthAndYear[0]) <= 12 &&
						Convert.ToInt32 (monthAndYear[0]) >= 1)
					{
						return "Expiration date is: " + expdate;
					}
					else
					{
						return "Month is not valid: " + expdate;
					}
				}
				else
				{
					return "Your Credit Card has been expired! ( " + expdate + " )";
				}
			}
			else
			{
				return "Provided Credit Card expiration date is not right ( " + expdate + " )";
			}
		}

		//Find the validate phone number of Credit card holder for user and return Match 
		//found correct or invalid

		public string ValidateHoldersPhone (string phoneNumber)
		{

			Regex pattern = new Regex (@"\(?\d{3}\)?\s*-?\s*\d{3}\s*-?\s*\d{4}");//phone pattern
			Match match = pattern.Match (phoneNumber);
			if (match.Success)
			{
				string[] trimedPhone;
				string trimedOutput = "";

				trimedPhone = phoneNumber.Split (new char[] { '-', ' ', '(', ')' });

				foreach (string item in trimedPhone)
				{
					trimedOutput = trimedOutput + item;

				}
				return "Phone number: " + trimedOutput;
			}
			else
			{
				return "Provided holder's phone number is invalid ( " + phoneNumber + " )";
			}

		}

		//Find the validate email address for user and return Match 
		//found correct or invalid

		public string ValidateEmail (string email)
		{

			Regex pattern = new Regex (@"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)
										|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})");//email pattern

			Match match = pattern.Match (email);

			//Check for if the valiadte email entered by user is correct
			
			if (match.Success)
			{
				return "E-Mail address: " + email;
			}
			else
			{
				return "Provided holder's E-Mail address is invalid ( " + email + " )";
			}


		}

   
	}	//end class CreditcardList
}	//end nameSpance _2210_201_PatelIshan_Project1
