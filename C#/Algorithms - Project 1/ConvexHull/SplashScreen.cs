// ------------------------------------------------------------------------------------
// File name: Points.cs
// Project name: ConvexHull
// ------------------------------------------------------------------------------------
// Author Name: Ishan Patel
// Author E-mail: pateli@goldmail.etsu.edu
// Course-Section: CSCI-3230-001
// Creation Date: 2/12/2014
// Date of Last Modification: 2/12/2014
// ------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvexHull
{
	//-------------------------------------------------------------------------------------
	// Class Name: SpashScreen.cs
	// Class Purpose: SPlashScreen to start the program
	// Date created: 2/12/2014
	// Date last modified: 2/12/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	
	public partial class SplashScreen : Form
	{
		public SplashScreen ( )
		{
			InitializeComponent ( );
		}
		/// <summary>
		/// Timer tick method to stop time when progress bar
		/// value set to 100
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer1_Tick (object sender, EventArgs e)
		{
			progressBar1.Increment (1);
			if (progressBar1.Value == 100) timer1.Stop ( );
		}

		private void pictureBox1_Click (object sender, EventArgs e)
		{

		}
	}
}
