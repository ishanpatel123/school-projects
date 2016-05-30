using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPair
{
	class Point
	{
		private int x_Coord;	//x coordinate
		private int y_Coord;	//y coordinate

		/// <summary>
		/// construct defalut values of x and y coordinates to zero
		/// </summary>
		public Point ( )
		{
			this.x_Coord = 0;
			this.y_Coord = 0;
		}

		/// <summary>
		/// constructs points of x and y coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Point (int x, int y)
		{
			this.x_Coord = x;
			this.y_Coord = y;
		}

		/// <summary>
		/// getXCoord methods returns x coordinates
		/// </summary>
		/// <returns></returns>
		public int getXCoord ( )
		{
			return x_Coord;
		}

		/// <summary>
		/// getYCoord method returns y coordinates
		/// </summary>
		/// <returns></returns>
		public int getYCoord ( )
		{
			return y_Coord;
		}
	}
}
