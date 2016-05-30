// ------------------------------------------------------------------------------------
// File name: Program.cs
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
	// Class Purpose: Creates all convex Hull lines between 2 points entered by user and
	//					store as a list
	// Date created: 2/12/2014
	// Date last modified: 2/12/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	
	class BrtueForceConvexHull
	{
		public static List<Lines> line = new List<Lines> ( );			//stores all lines from brute force method
		public static List<Point> points = new List<Point> ( );			//stores all points from brute force method

		#region Brute Force Method
		/// <summary>
		/// gets a list to access x and y coordinates from user to
		/// draw a straight lines between two points in a plan using
		/// ax + by + c = 0 equation.
		/// checks all points and see if they fall in edge lines. If
		/// its true, store them into line list.
		/// </summary>
		/// <param name="pointList"></param>
	
		public static void convHull(List<Point> pointList)
		{
			int num = 0;		//set count = 0
			for (int i = 0; i < pointList.Count ( ) - 1; i++)
			{
				for (int j = i + 1; j < pointList.Count ( ); j++)
				{
					bool edgeLine = true;
					int pointSize = 0;
					Point p1 = pointList[i];	//p1 = point 1
					Point p2 = pointList[j];	//p2 = point 2
					int A = p2.getYCoord ( ) - p1.getYCoord ( );	//int A = Y2 - Y1
					int B = p1.getXCoord ( ) - p2.getXCoord ( );	//int B = X2 - X1
					int C = p1.getXCoord ( ) * p2.getYCoord ( ) - p1.getYCoord ( ) * p2.getXCoord ( );	//int C = X1 * Y2 - Y1 * X2
					for (int k = 0; k < pointList.Count ( ); k++)
					{
						Point p3 = pointList[k];	//p3 = points 3
						int pointArea = A * p3.getXCoord ( ) + B * p3.getYCoord ( ) - C; //int pointArea = A * X3 + B * Y3 - C

						if (pointSize != 0)
						{
							//Is Point Area is bigger than or smaller than zero, then set edgeline equals false?
							if (pointArea > 0 && pointSize < 0)
							{
								edgeLine = false;
								break;
							}
							else if (pointArea < 0 && pointSize > 0)
							{
								edgeLine = false;
								break;
							}
							else { }
						}
						else
						{
							//Is pointArea is bigger than 0, than set pointSize to 1
							//or smaller than zero, than setpointSize to -1
							if (pointArea > 0)
							{
								pointSize = 1;
							}
							else if (pointArea < 0)
							{
								pointSize = -1;
							}
							else { }
						}
					}
					//Is this edgeline, than add those two points to lines class
					if (edgeLine)
					{
						line.Insert (num, new Lines (p1, p2));
						num++;
					}
				}
				//copy pointlist into points to display points into drawConvex form
				points = new List<Point> (pointList);
			}
		}
		#endregion
	}
}
