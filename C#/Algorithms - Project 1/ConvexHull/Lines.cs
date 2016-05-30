// ------------------------------------------------------------------------------------
// File name: Lines.cs
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
	//-------------------------------------------------------------------------------------
	// Class Name: Program.cs
	// Class Purpose: Creates a straight line between two points
	// Date created: 2/12/2014
	// Date last modified: 2/12/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	
	class Lines
	{
		private Point p1;	//point 1
		private Point p2;	//point 2

		/// <summary>
		/// Constructs lines with point 1 and point 2
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		public Lines (Point p1, Point p2)
		{
			this.p1 = p1;
			this.p2 = p2;
		}

		/// <summary>
		/// getpoint1 methods returns point 1
		/// </summary>
		/// <returns></returns>
		public Point getpoint1 ( )
		{
			return p1;
		}

		/// <summary>
		/// getpoint2 method returns point 2
		/// </summary>
		/// <returns></returns>
		public Point getpoint2 ( )
		{
			return p2;
		}
	}
}
