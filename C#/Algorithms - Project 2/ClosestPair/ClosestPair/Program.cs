// ------------------------------------------------------------------------------------
// File name: Program.cs
// Project name: ClosestPair
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
using System.Drawing;
 
namespace ClosestPair
{
	//-------------------------------------------------------------------------------------
	// Class Name: Program.cs
	// Class Purpose:  Accepts a x and y of points from user, call a divide and conqure method 
	//				   and return tw points are closest in list
	// Date created: 2/12/2014
	// Date last modified: 2/12/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------
	class Program
	{
		/// <summary>
		/// this method used to gets x and y coordinates of the points and then 
		/// call the method divideAndConqure to gets two closest points and then
		/// finds a distance in main
		/// </summary>
		/// <param name="args"></param>
		static void Main (string[] args)
		{

			String s = Console.ReadLine ( );
			int count = int.Parse (s);	//get the count of nums from user
			List<PointF> points = new List<PointF> (count);
			int num = 0;
			//store x and y points into arrays
			int[] x = new int[count];
			int[] y = new int[count];
			//split the user's input and store to specified arrays
			for (int i = 0; i < count; i++)
			{
				String instring = Console.ReadLine ( );
				String[] values = instring.Split (' ');
				Int32.TryParse (values[0], out x[i]);
				Int32.TryParse (values[1], out y[i]);
				PointF p = new PointF (x[i], y[i]);
				points.Insert (num, p);
			}

			//call the method DivideAndConqure by passing points which return two
			//points and store those points as twoPoint
			var twoPoint = Line.DivideAndConqure (points);
			//finds a distance between two closest points in List of points
			double A = (twoPoint.P1.X - twoPoint.P2.X) * (twoPoint.P1.X - twoPoint.P2.X);
			double B = (twoPoint.P1.Y - twoPoint.P2.Y) * (twoPoint.P1.Y - twoPoint.P2.Y);
			double d = Math.Sqrt (A + B);
			Console.WriteLine (d);
			Console.ReadLine ( );
		}
	}

	class Line
	{
		/// <summary>
		/// Line constructor hold stwo points 
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		public Line (PointF p1, PointF p2)
		{
			P1 = p1;
			P2 = p2;
		}

		public PointF P1;		//gets point 1
		public PointF P2;		//gets point 2

		/// <summary>
		/// calculate and return the distance between two points 
		/// </summary>
		/// <returns></returns>
		public double Length ( )
		{
			return (double)Math.Sqrt (LengthSquared ( ));
		}

		/// <summary>
		/// calculate and return the length between the two points 
		/// </summary>
		/// <returns></returns>
		public double LengthSquared ( )
		{
			return (P1.X - P2.X) * (P1.X - P2.X)
				+ (P1.Y - P2.Y) * (P1.Y - P2.Y);
		}

		/// <summary>
		/// gets points of list and return the method DivideAndConqureOne
		/// with sorted x
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		public static Line DivideAndConqure (List<PointF> points)
		{
			return DivideAndConqureOne (points.OrderBy (p => p.X).ToList ( ));
		}

		/// <summary>
		/// ges a list and return brute force is there are no more than 3 points,
		/// else use divide and conqure method to  return two smallest point in list
		/// </summary>
		/// <param name="pointsByX"></param>
		/// <returns></returns>
		private static Line DivideAndConqureOne (List<PointF> pointsByX)
		{
			int count = pointsByX.Count;		//holds number of points in list
			//if there are smallest than 3 points, use bruteforce to find it
			if (count <= 3)
				return bruteForce (pointsByX);
			// left lists sorted by X, as order retained from full list
			var leftX = pointsByX.Take (count / 2).ToList ( );
			var lResult = DivideAndConqureOne (leftX);
			//finds all the value on  Y, and store them as rResult
			var rightX = pointsByX.Skip (count / 2).ToList ( );
			var rResult = DivideAndConqureOne (rightX);
			//reuslt will holds the smallest of lResult and rResult
			var result = rResult.Length ( ) < lResult.Length ( ) ? rResult : lResult;
			// There may be a shorter distance that crosses the divider
			// Thus, extract all the points within result.Length either side
			var midXPoint = leftX.Last ( ).X;
			var Width = result.Length ( );
			//makes a line running through a middle point
			var inBandByX = pointsByX.Where (p => Math.Abs (midXPoint - p.X) <= Width);
			// Sort by Y, so we can efficiently check for closer pairs
			var inBandByY = inBandByX.OrderBy (p => p.Y).ToArray ( );
			// Pick all points one by one and try the next points till the difference
			// between y coordinates is smaller than line.
			int iLast = inBandByY.Length - 1;
			//if the result lenght is bigger than pUpper - pLower, break the loop
			for (int i = 0; i < iLast; i++)
			{
				var pLower = inBandByY[i];
				for (int j = i + 1; j <= iLast; j++)
				{
					var pUpper = inBandByY[j];
					// Comparing two points which each  Y values
					// Thus,difference between pUpper - pLower is greater than best result
					if ((pUpper.Y - pLower.Y) >= result.Length ( ))
						break;
					Line line = new Line (pLower, pUpper);
					if (line.Length ( ) < result.Length ( ))
						result = line;		
				}
			}
			return result;
		}

		/// <summary>
		/// gets points entered by user and finds a shortest distance between two points.
		/// If distance is smaller  than maximum distance, make max to smallest distance,
		/// and return those two points has smallest distance
		/// </summary>
		/// <param name="points"></param>
		/// <returns></returns>
		private static Line bruteForce (List<PointF> points)
		{
			double max = 1000000;
			Line s = new Line (points[0], points[1]);
			for (int i = 0; i < points.Count - 1; i++)
			{
				for (int j = 1; j < points.Count; j++)
				{
					PointF p1 = points[i];	//gets point 1 from Line class
					PointF p2 = points[j];	//gets point 2 from line class
					//distance between the points and store it as dist
					//double dist = Math.Sqrt (Math.Pow ((x[j] - x[i]), 2) + Math.Pow ((y[j] - y[i]), 2));
					double dist = Math.Sqrt (Math.Pow ((p2.X - p1.X), 2) + Math.Pow ((p2.Y - p1.X), 2));
					//distance(x,y,i,j);
					//Is distance is smallest then max distance and not equals zero?
					if (dist < max && dist != 0.0)
					{
						max = dist;
						s = new Line (p1, p2); //s => two points has smallest distance
					}
				}
			}
			return s; //return two points
		}
	}
}