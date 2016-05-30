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

namespace Project4
{
	/// <summary>
	/// structuerr of temp files 
	/// </summary>
	public struct fileName
	{
		public int iNum;
		public string sFileName;

		public fileName (int iNum, string sBinaryFileName)
		{
			this.iNum = iNum;
			this.sFileName = sBinaryFileName;
		}

		public int iNumAcess { get { return iNum; } }
		public string sFileNameAcess { get { return sFileName; } }
	}
}
