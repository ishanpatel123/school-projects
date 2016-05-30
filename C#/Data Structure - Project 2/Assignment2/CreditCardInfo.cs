using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Assignment2
{
	class CreditCardInfo : IComparable<CreditCardInfo>, IEquatable<CreditCardInfo>
	{

		private string holdersName, creditCardNumber, expirationDate, holdersPhone, emailAddress;
		

		#region Enum type of Credit Card
		public enum CCType { INVALID, VISA, MASTERCARD, AMERICAN_EXPRESS, DISCOVERY, OTHER };
		#endregion

		#region Default constructor
		public CreditCardInfo(string cardNum)
        {
            this.holdersName = "N/A";
            this.creditCardNumber = CleanUpCCNumber(cardNum);
            this.expirationDate = "N/A";
            this.holdersPhone = "N/A";
            this.emailAddress = "N/A";
			this.Not_Expired = false;

        }
		#endregion

		#region Overload constructor
		public CreditCardInfo (string name, string cardNum, string expdate, string phone, string email)
		{
			this.holdersName = name;
			this.creditCardNumber = CleanUpCCNumber (cardNum);
			this.expirationDate = expdate;
			this.holdersPhone = phone;
			this.emailAddress = email;
			this.Not_Expired = false;

			string str;
			str = VaidateCCNumber (this.creditCardNumber);
			str = ValidateExpDate (this.expirationDate);
		}
		#endregion

		#region Return a string of all Credit Card information in detail
		public string Detail ( )
		{
			return "\n\n*****Credit Card Detail*****\n\n"
				+ "Card holder's name: " + holdersName + "\n"
				+ VaidateCCNumber (creditCardNumber) + "\n"
				+ ValidateExpDate (expirationDate) + "\n"
				+ ValidateHoldersPhone (holdersPhone) + "\n"
				+ ValidateEmail (emailAddress);
		}
		#endregion

		#region Return a string of all Credit Card information in text file
		public String toStringFile ( )
		{
			String msg = holdersName +
					"|" + VaidateCCNumber (creditCardNumber) +
					"|" + ValidateExpDate (expirationDate) +
					"|" + ValidateHoldersPhone (holdersPhone) +
					"|" + ValidateEmail (emailAddress);
			return msg;
		}
		#endregion

		#region Getter and setter for Not_Expired, CardType and CreditCardNumber
		public Boolean Not_Expired { get; private set; }

		public CCType CardType { get; private set; }

		public string CreditCardNumber
		{
			get 
			{ 
				return creditCardNumber; 
			}

		}
		#endregion

		#region Remove everything but digit from CCNumber
		public string CleanUpCCNumber (string num)
		{
			string pattern = "\\D";
			Regex rgx = new Regex (pattern);
			return rgx.Replace (num, "");//removing everything but digits

		}
		#endregion
		
		#region	Validate CCNumber of Credit Card and return correct type of Credit Card
		public int CompareTo (CreditCardInfo otherCard)
		{
			//Comparing 2 card numbers as a string and returning an integer as a part of
			//CompareTo implementation.

			return this.VaidateCCNumber (creditCardNumber).CompareTo (otherCard.VaidateCCNumber (creditCardNumber));

		}

		bool IEquatable<CreditCardInfo>.Equals (CreditCardInfo c)
		{

			return this.holdersName == c.holdersName;
		}

		public override bool Equals (object obj)
		{
			if (obj == null)
			{
				return base.Equals (obj);
			}
			if (!(obj is CreditCardInfo))
			{
				throw new ArgumentException ("Parameter is not a CreditCard");
			}
			else return Equals (obj as CreditCardInfo);

		}

		public bool Equals (string s)
		{
			return this.holdersName == s;
		}

		public override int GetHashCode ( )
		{
			return this.holdersName.GetHashCode ( );
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

		#endregion

		#region Validate expire date of Credit card for user and return Match of Expire date
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
						Not_Expired = true;
						return "Expiration date is: " + expdate;
					}
					else
					{
						return "Month is not valid: " + expdate;
					}
				}
				else
				{
					Not_Expired = true;
					return "Your Credit Card has been expired! ( " + expdate + " )";
				}
			}
			else
			{
				return "Provided Credit Card expiration date is not right ( " + expdate + " )";
			}
		}

		#endregion

		#region Validation phone number of Credit Card and return correct match for phone number
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
		#endregion

		#region Validate email address for user and return found email address
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
		#endregion
	
	}
}