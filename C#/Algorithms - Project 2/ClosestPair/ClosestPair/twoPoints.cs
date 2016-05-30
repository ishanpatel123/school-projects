using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
	class twoPoints
	{
		private Point p1;	//point 1
		private Point p2;	//point 2

		/// <summary>
		/// Constructs lines with point 1 and point 2
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		public twoPoints (Point p1, Point p2)
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

		public double LengthSquared ( )
		{
			return (p1.getXCoord ( ) - p2.getXCoord ( )) * (p1.getXCoord ( ) - p2.getXCoord ( ))
				+ (p1.getYCoord ( ) - p2.getYCoord ( )) * (p1.getYCoord ( ) - p2.getYCoord ( ));
		}

		public double Length ( )
		{
			return (double)Math.Sqrt (LengthSquared ( ));
		}
	}
}
