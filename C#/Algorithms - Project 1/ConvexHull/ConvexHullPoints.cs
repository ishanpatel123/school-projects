// ------------------------------------------------------------------------------------
// File name: ConvexHullPoints.cs
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
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace ConvexHull
{
	//-------------------------------------------------------------------------------------
	// Class Name: Program.cs
	// Class Purpose: This form is created to gets x and y coordinates from user and put 
	//					them into list to draw lines
	// Date created: 2/12/2014
	// Date last modified: 2/12/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	
	public partial class ConvexHullPoints : Form
	{
		List<Point> pointList = new List<Point> ( );
		int x = 0, y = 0, num = 0;

		#region Intialize Componants with Splash Screen
		/// <summary>
		/// Intialize Componant to get x and y coordinates from user
		/// </summary>
		public ConvexHullPoints ( )
		{
			Thread t = new Thread (new ThreadStart (SplashScreen));
			t.Start ( );
			Thread.Sleep (3000);
			InitializeComponent ( );
			t.Abort ( );
		}
		#endregion

		#region ConvexHullPoints Load
		/// <summary>
		/// when help/info button click decrease/increase size of form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ConvexHullPoints_Load (object sender, EventArgs e)
		{
			//change height of form based on butoon text
			if (button1.Text == "Help/Info")
			{
				this.Height -= 45;
			}
			else if (button1.Text == "Hide")
			{
			}
		}
		#endregion

		#region Run Splash Screen
		/// <summary>
		/// Runs splash screen first when program start
		/// </summary>
		public void SplashScreen ( )
		{
			Application.Run (new SplashScreen ( ));
		}
		#endregion

		#region Genrerate Button
		/// <summary>
		/// when Button clicks, it opens drawconvex hull form and
		/// hide current convexHullPoints form
		/// Takes every points from pointlist and check points with
		/// brute force method
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click (object sender, EventArgs e)
		{
			this.Visible = false;
			DrawConvex a = new DrawConvex ( );
			a.Visible = true;
			BrtueForceConvexHull.convHull (pointList);
		}
		#endregion

		#region Help/Info Button
		/// <summary>
		/// when button clicks, change text to Hide and decrease/increase
		/// height of form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void button1_Click (object sender, EventArgs e)
		{
			if (button1.Text == "Help/Info")
			{
				button1.Text = "Hide";		//changes button txt to Hide
				this.HeightTimer.Enabled = true;
			}
			else if (button1.Text == "Hide")
			{
				this.Height -= 45;		//decrease form height
				button1.Text = "Help/Info";		//chage button text to Help/Info
			}
		}
		#endregion

		#region HeightTimer
		/// <summary>
		/// Helps to incease/decrease height of form
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HeightTimer_Tick (object sender, EventArgs e)
		{
			if (this.Height >= 560)
				this.HeightTimer.Enabled = false;
			else
				this.Height += 45; 
		}
		#endregion

		#region Mouse click
		/// <summary>
		/// Gets input x and y coordinates from user by mouse click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ConvexHullPoints_MouseDown (object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics ( );
			if (e.Button == MouseButtons.Left)
			{
				using (Brush b = new SolidBrush (Color.Blue))	
				{
					g.FillEllipse (b, x, y, 10, 10);	//draw all points with blue color
				}
				Point	p = new Point (e.X, e.Y);		//create a point on x and y coordinates from one mouse click
				pointList.Insert (num, p);				//store each point to pointlist to use all points later
			}
		}
		#endregion

		#region Mouse move
		/// <summary>
		/// helps to display x and y coordinates as mouse moves
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void ConvexHullPoints_MouseMove (object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics ( );
			//gets X and Y coordinate and display blue ellipse using mouse click
			x = e.X;	
			y = e.Y;
			label1.Text = "X = " + x.ToString ( );		//display X Coordinate
			label2.Text = "Y = "+ y.ToString ( );		//display Y Coordinate
		}
		#endregion
	}
}
