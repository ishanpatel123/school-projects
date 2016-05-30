using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2210_201_PatelIshan_Project1
{
	class CreditCardInfo
	{
		
		private string holdersName, creditCardNumber, expirationDate, holdersPhone, emailAddress;
		CreditcardList cl = new CreditcardList ( );

		public CreditCardInfo(string name, string cardNum, string expdate, string phone, string email)
		{
			this.holdersName = name;
			this.creditCardNumber = CleanUpCCNumber(cardNum);
			this.expirationDate = expdate;
			this.holdersPhone = phone;
			this.emailAddress = email;


		}

		public CreditCardInfo(CreditCardInfo p)
		{
			this.holdersName = p.holdersName;
			this.creditCardNumber = p.creditCardNumber;
			this.expirationDate = p.expirationDate;
			this.holdersPhone = p.holdersPhone;
			this.emailAddress = p.emailAddress;
		}
		public string Detail ( )
		{
			return "\n\n*****Credit Card Detail*****\n\n"
				+ "Card holder's name: " + holdersName + "\n"
				+ cl.VaidateCCNumber(creditCardNumber) + "\n"
				+ cl.ValidateExpDate(expirationDate) + "\n"
				+ cl.ValidateHoldersPhone(holdersPhone) + "\n"
				+ cl.ValidateEmail(emailAddress);
		}

		public string CleanUpCCNumber (string num)
		{
			string pattern = "\\D";
			Regex rgx = new Regex (pattern);
			return rgx.Replace (num, "");//removing everything but digits

		}
	}//end of the class


}//end of the nameSpace
	
