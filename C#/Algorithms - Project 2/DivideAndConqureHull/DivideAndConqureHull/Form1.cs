// ------------------------------------------------------------------------------------
// File name: Program.cs
// Project name: ConvexHull
// ------------------------------------------------------------------------------------
// Author Name: Ishan Patel
// Author E-mail: pateli@goldmail.etsu.edu
// Course-Section: CSCI-3230-001
// Creation Date: 3/24/2014
// Date of Last Modification: 3/24/2014
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

namespace DivideAndConqureHull
{
	//-------------------------------------------------------------------------------------
	// Class Name: Program.cs
	// Class Purpose: This form is created to gets x and y coordinates from user and put 
	//					them into list to draw lines
	// Date created: 3/24/2014
	// Date last modified: 3/24/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	
	public partial class Form1 : Form
	{
		public List<Point> points = new List<Point> ( );
		//public List<List<Point>> hullPoints = new List<List<Point>> ( );
        DivideAndConq d = new DivideAndConq ( );
		
		public Form1 ( )
		{
			InitializeComponent ( );
		}

		/// <summary>
		/// use a clear button to delete every points
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click (object sender, EventArgs e)
		{
			this.Invalidate ( );
			points.Clear ( );
			d.hullPoints.Clear ( );
		}

		/// <summary>
		/// if convex hull button clicked,use divide and conqure method to store
		/// all the points
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click (object sender, EventArgs e)
		{
			this.Invalidate ( ); // Clear canvas
			d.divideAndConqure (points);
		}
		

		private void button1_MouseDown (object sender, MouseEventArgs e)
		{	}

		private void button1_Paint (object sender, PaintEventArgs e)
		{	}

		/// <summary>
		/// Draw the convex hull based on points entered by user
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Paint (object sender, PaintEventArgs e)
		{
			Graphics g = CreateGraphics ( );
			Pen a = new Pen (Color.Gold, 2);

			foreach (var point in points)
			{
				using (Brush b = new SolidBrush (Color.Blue))
				{
					g.FillEllipse (b, point.X, point.Y, 7,7);
				}
			}

			foreach (var A in d.hullPoints)
			{
				var i = A.ElementAt (0);
				var j = A.ElementAt (1);
				g.DrawLine (a, i.X, i.Y, j.X, j.Y); // Draw convex hull.
			}
			d.hullPoints.Clear ( ); // Clear convex hull points.
		}

		/// <summary>
		/// Gets input x and y coordinates from user by mouse click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		
		private void Form1_MouseDown (object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics ( );
			if (e.Button == MouseButtons.Left)
			{
				using (Brush b = new SolidBrush (Color.Blue))
				{
					g.FillEllipse (b, e.X, e.Y, 7, 7);	//draw all points with blue color
				}
				Point PT = new Point (e.X, e.Y);
				points.Add (PT); // Add point from user to the list of points named PTS.
			}
		}

		private void label2_Click (object sender, EventArgs e)
		{	}

		/// <summary>
		/// helps to display x and y coordinates as mouse moves
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void Form1_MouseMove (object sender, MouseEventArgs e)
		{
			Graphics g = CreateGraphics ( );
			//gets X and Y coordinate and display blue ellipse using mouse click
			label3.Text = "X = " + e.X.ToString ( );		//display X Coordinate
			label2.Text = "Y = " + e.Y.ToString ( );
		}

		
	}
}
