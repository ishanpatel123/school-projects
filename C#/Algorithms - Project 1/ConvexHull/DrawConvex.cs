// ------------------------------------------------------------------------------------
// File name: DrawConvex.cs
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
	// Class Name: Program.cs
	// Class Purpose: This form is created to draw convex hull from x and y coordinates
	//					from user
	// Date created: 2/12/2014
	// Date last modified: 2/12/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	
	public partial class DrawConvex : Form
	{
		List<Point> solList = new List<Point> ( );
		int num = 0;

		#region Initialize DrawCoonvex Form

		/// <summary>
		/// initialize form to draw convex hull
		/// </summary>
		public DrawConvex ( )
		{
			InitializeComponent ( );
		}
		#endregion

		#region Close Button

		/// <summary>
		/// close button to display thanks message and
		/// close application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void button1_Click (object sender, EventArgs e)
		{
			//Display Thanks message
			MessageBox.Show ("--- Thanks for using the Patel Convex Hull program V.0 ---", "Convex Hull");
			//Exit Application
			Application.Exit ( );	
		}
		#endregion

		#region Apps Close

		/// <summary>
		/// close convex hull application
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawConvex_FormClosing (object sender, FormClosingEventArgs e)
		{
			Application.Exit ( );
		}
		#endregion

		#region Draw Convex Hull

		/// <summary>
		/// get lines from brute force class and
		/// draw lines of convex hull using paint class
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DrawConvex_Paint (object sender, PaintEventArgs e)
		{
			foreach (Lines lp in BrtueForceConvexHull.line)
			{
				//gets point 1 from line list
				Point p1 = lp.getpoint1 ( );
				//gets point 2 from line list
				Point p2 = lp.getpoint2 ( );		
				Graphics g = CreateGraphics ( );
				//Draw a line with a gold color
				Pen a = new Pen (Color.Gold, 2);
				//draw a edge line between two points using their X and Y Coordinates
				g.DrawLine (a, p1.getXCoord ( ), p1.getYCoord ( ), p2.getXCoord ( ), p2.getYCoord ( ));
			}

			foreach (Point p in BrtueForceConvexHull.points)
			{
				//using blue color draw circle on each points are in points list
				Graphics g = CreateGraphics ( );
				Pen a = new Pen (Color.Gold, 2);
				using (Brush b = new SolidBrush (Color.Blue))
				{
					g.FillEllipse (b, p.getXCoord ( ), p.getYCoord ( ), 10, 10);
				}
			}
		}
		#endregion
	}
}
