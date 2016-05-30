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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DivideAndConqureHull
{
	//-------------------------------------------------------------------------------------
	// Class Name: DivideAndConq.cs
	// Class Purpose: Creates all convex Hull lines between 2 points entered by user and
	//					store as a list using divide and Conqure method
	// Date created: 2/12/2014
	// Date last modified: 2/12/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	
	class DivideAndConq
	{
		public List<List<Point>> hullPoints = new List<List<Point>> ( );	//holds all the edge points to hull
		/// <summary>
		/// use divide and conqure method to draw the hull and store all the line points in hullpints
		/// </summary>
		/// <param name="points"></param>
		public void divideAndConqure (List<Point> points)
		{
			if (points.Count <= 3)
			{
				hullPoints = convHull (points); //if there are less than three points use bruteforce method to solve hull
			}
			else
			{
				List<Point> pointInHull = new List<Point> ( ); //stores all segment for convex hull
				List<Point> pL = new List<Point> ( );
				List<Point> pR = new List<Point> ( );

				//Sort the list by y first then X to get ascending list of points
				points = points.OrderBy (p => p.Y).ToList ( );
				points = points.OrderBy (p => p.X).ToList ( );
				Point p1 = points[0];
				Point pN = points[points.Count - 1];

				//Add the points are on left or they are on right
				for (int i = 0; i < points.Count; i++)
				{
					if ((line(points, p1,pN, i)) < 0)
						pL.Add (points[i]);
					else
						pR.Add (points[i]);
				}
				//Using divide and conqure alorithm calculate the points are on convex hull
				pointInHull.Add (p1);
				pointInHull.AddRange (quickHull (pL, p1, pN));
				pointInHull.Add (pN);
				pointInHull.AddRange (quickHull (pR, pN, p1));

				//Adding the all points are on hull from drawing.
				for (int i = 0; i < pointInHull.Count ( ) - 1; i++)
				{
					List<Point> hull1 = new List<Point> ( );
					hull1.Add (pointInHull[i]);
					hull1.Add (pointInHull[i + 1]);
					hullPoints.Add (hull1);
				}
				List<Point> hull2 = new List<Point> ( );
				hull2.Add (pointInHull[0]);
				hull2.Add (pointInHull[pointInHull.Count ( ) - 1]);
				hullPoints.Add (hull2);
			}
		}

		/// <summary>
		/// return the equation for first and last points of line
		/// return -1 for the points are on left and +1 for points are
		/// on right
		/// </summary>
		/// <param name="p"></param>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <param name="i"></param>
		/// <returns></returns>
		private static double line(List<Point> p, Point p1, Point p2, int i)
		{
			double d = ((p1.X * p2.Y) + (p[i].X * p1.Y) + (p2.X * p[i].Y) - (p[i].X * p2.Y) - (p2.X * p1.Y) - (p1.X * p[i].Y));
			return d;
		}
		private static List<Point> quickHull (List<Point> points, Point start, Point end)
		{
			double d = 0;   //d = Distance between points
			Point pFarthest= new Point ( ); //the farthest point from middle line
			List<Point> pRight = new List<Point> ( );		//points on right side from middle line
			List<Point> pLeft = new List<Point> ( );		//points on left side from left line
			List<Point> hullPoints = new List<Point> ( );	//points are on convex hull in line

			//If there is no points added by user,simply return an
			//empty list
			if (points.Count ( ) == 0)
			{
				return points; 
			}
			else
			{
				for (int i = 0; i < points.Count; i++)
				{
					Point v = new Point (end.X - start.X, end.Y - start.Y); //Left extreme point.
					Point u = new Point (points[i].X - start.X, points[i].Y - start.Y); //Right extreme point.
					double uu = distance (u, u);
					double uv = distance (u, v);
					double vv = distance (v, v); //Dot products.
					double x = Math.Sqrt (uu - (Math.Pow (uv, 2) / vv)); //Distance from dividing line.
					//check if there is any farthest point. If yes
					//add those points to farthest point 
					if (x > d) 
					{
						d = x;
						pFarthest = points[i];
					}
				}

				//Points on the right side of the middle line
				for (int i = 0; i < points.Count; i++)
				{
					if ((line (points, start, pFarthest, i)) < 0)
						pRight.Add (points[i]);
				}

				//Points are on the left side of the middle line
				for (int i = 0; i < points.Count; i++)
				{
					if ((line (points, pFarthest, end, i)) < 0)
						pLeft.Add (points[i]);
				}

				//Points on the convexhull called by recursively
				hullPoints = quickHull (pRight, start, pFarthest);
				hullPoints.Add (pFarthest);
				hullPoints.AddRange (quickHull (pLeft, pFarthest, end));
				return hullPoints;
			}
		}

		/// <summary>
		/// draw a line between the first and list points of sorted list
		/// in term of x coordinates
		/// </summary>
		/// <param name="u"></param>
		/// <param name="v"></param>
		/// <returns></returns>
		public static double distance (Point u, Point v)
		{
			return (u.X * v.X) + (u.Y * v.Y);
		}

		/// <summary>
		/// gets a list to access x and y coordinates from user to
		/// draw a straight lines between two points in a plan using
		/// ax + by + c = 0 equation.
		/// checks all points and see if they fall in edge lines. If
		/// its true, store them into line list.
		/// </summary>
		/// <param name="pointList"></param>
	
		public static List<List<Point>> convHull (List<Point> pointList)
		{
			List<List<Point>> twoPoints = new List<List<Point>> ( );
			for (int i = 0; i < pointList.Count ( ) - 1; i++)
			{
				for (int j = i + 1; j < pointList.Count ( ); j++)
				{
					int pointSize = 0;
					Point p1 = pointList[i];	//p1 = point 1
					Point p2 = pointList[j];	//p2 = point 2
					int A = p2.Y - p1.Y;	//int A = Y2 - Y1
					int B = p1.X - p2.X;	//int B = X2 - X1
					int C = p1.X * p2.Y - p1.Y * p2.X;	//int C = X1 * Y2 - Y1 * X2
					List<int> pointV = new List<int> ( ); // Stores the decision value if point is at left or right side of segment.
					for (int k = 0; k < pointList.Count ( ); k++)
					{
						Point p3 = pointList[k];	//p3 = points 3
						int pointArea = A * p3.X + B * p3.Y - C; //int pointArea = A * X3 + B * Y3 - C

						if (pointSize != 0)
						{
							//Is Point Area is bigger than or smaller than zero, then set edgeline equals false?
							if (pointArea > 0 && pointSize < 0)
							{
								break;
							}
							else if (pointArea < 0 && pointSize > 0)
							{
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
					//IF all points are on same on edge then points are part of line
					if (pointV.Sum ( ) == 0 || pointV.Sum ( ) == pointV.Count ( )) 
					{
						List<Point> P1 = new List<Point> ( );
						P1.Add (pointList[i]);
						P1.Add (pointList[j]);
						// Add the points of the line.
						twoPoints.Add (P1); 
					}
				}
			}
			return twoPoints;		//return a list of list of points
		}
	}
}
