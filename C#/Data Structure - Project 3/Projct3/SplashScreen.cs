/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Ishan Patel
// Department Name	: Computer and Information Sciences 
// File Name			: SplashScreen.cs
// Purpose				: Create a new loading window before the actual
//							program will start by itself
// Author				: Ishan Patel, E-Mail: pateli@goldmail.etsu.edu
// Create Date			: Sunday, November 2, 2013
//
//-----------------------------------------------------------------------------------
//
// Modified Date		: Sunday, November 3, 2013
// Modified By			: Ishan Patel
//
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projct3
{
	public partial class SplashScreen : Form
	{
		#region Initialize Splash Screen
		
		public SplashScreen ( )
		{
			InitializeComponent ( );
		}

		#endregion
		
		#region Load Splash Screen
		private void Form2_Load (object sender, EventArgs e)
		{

		}
		#endregion

		#region Timer for loading the Splash Screen
		#endregion

		#region Timer for Splash Screen
		private void timer1_Tick (object sender, EventArgs e)
		{
			progressBar1.Increment (1);
			if (progressBar1.Value == 100) timer1.Stop ( );
		}
		#endregion

		#region Progress Bar for Splash Screen
		private void progressBar1_Click (object sender, EventArgs e)
		{

		}
		#endregion
	}
}
