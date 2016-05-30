// ------------------------------------------------------------------------------------
// File name: Program.cs
// Project name: Project3
// ------------------------------------------------------------------------------------
// Author Name: Ishan Patel
// Author E-mail: pateli@goldmail.etsu.edu
// Course-Section: CSCI-3230-001
// Creation Date: 4/17/2014
// Date of Last Modification: 4/17/2014
// ------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace IntClass
{
	//-------------------------------------------------------------------------------------
	// Class Name: UInt.cs
	// Class Purpose: This class is created to calculate factorial for big integer using uint class
	// Date created: 4/17/2014
	// Date last modified: 4/17/2014
	// @author Ishan Patel
	//-------------------------------------------------------------------------------------

		class UInt   // use to model an int class.
		{
			public byte[] x = new byte[50000000];  // maximum number of bytes the UInt can use is 1500
			public int lengthI = 8;  // current size
			int i;

			/// <summary>
			/// Initializes a new instance of the <see cref="UInt"/> class.
			/// </summary>
			/// <param name="y">The y.</param>
			public UInt (uint y)   //constructor accepts an unsigned integer and converts to byte array of size 4            
			{
				/* Place code here ********************************************/
				unsafe
				{
					byte* b;
					b = (byte*)&y;
					x[0] = *(b);
					x[1] = *(++b);
					x[2] = *(++b);
					x[3] = *(++b);
					x[4] = *(++b);
					x[5] = *(++b);
					x[6] = *(++b);
					x[7] = *(++b);
				}
				for (int j = 8 -1; j >= 0; j--)
				{
					if (x[j] == 0)
					{
						lengthI--; //decrease length of array if digit is 0
					}
					else
					{
						break;		//or termiante the program
					}
				}
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="UInt"/> class.
			/// </summary>
			/// <param name="y">The y.</param>
			public UInt ( )   //constructor accepts an byte
			{
				x[0] = 0; lengthI = 1;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="UInt"/> class.
			/// </summary>
			/// <param name="unsignI">The unsign i.</param>
			public UInt (UInt unsignI)
			{
				for (int k = 0; k < unsignI.lengthI; ++k)
				{
					this.x[k] = unsignI.x[k];
				}

				this.lengthI = unsignI.lengthI;
			}


			/// <summary>
			/// Initializes a new instance of the <see cref="UInt"/> class.
			/// </summary>
			/// <param name="y">The y.</param>
			public UInt (byte y)   //constructor accepts an byte
			{
				x[0] = y; lengthI = 1; 
			}

			/// <summary>
			/// Increments this instance.
			/// </summary>
			public void Increment ( )
			{  /* Place code here *************************************/
				//intialize i to zero
				i &= 0;
				//increment byte each time
				x[i]++;

				while (x[i] == 0)
				{
					x[++i]++;

					if (i == lengthI)
					{
						lengthI++;
					}
				}

			}

			/// <summary>
			/// LSs the specified shift.
			/// </summary>
			/// <param name="shift">The shift.</param>
			public void LS ( )  // missing code
			{
				// Left Shift
					// while its not 0 then increase
				byte b;
                for (int i = 0; i < lengthI; i++)
                {
                    b = x[i];
                    if ((x[i] = (byte)(x[i] << 1)) < b)
                    {
                        if (i == (lengthI - 1))
                        {
                            lengthI++;
                            x[i + 1] = 1;
                            break;
                        }
                        x[i + 1] = (byte)((x[i+1] << 1) + 1);
                        break;
                    }
                }


			}

			/// <summary>
			/// Printxes this instance.
			/// </summary>
			public void printx ( )   // bytes are stored in reverse order
			{
				for (int i = lengthI - 1; i >= 0; i--)
					Console.Write ("{0:X2}", x[i]);
			}


			/// <summary>
			/// Prints the hexadecimal file.
			/// </summary>
			public void printHexFile()
			{
				using (System.IO.StreamWriter file = new System.IO.StreamWriter (@"C:\Users\Ishan\Desktop\Algoithms\IntClass\IntClass\HexProj3.txt"))
				{
					for (int i = lengthI - 1; i >= 0; i--)
						file.Write ("{0:X2}", x[i]);
				}
			}
			/// <summary>
			/// Mults the specified u l.
			/// </summary>
			/// <param name="uL">The u l.</param>
			public void mult(ulong uL)
			{
				UInt j = new UInt (this);
				for (int k = 1; k < (int)uL; k++)
				{
					add (j);
				}
			}

			/// <summary>
			/// Adds the specified u il.
			/// </summary>
			/// <param name="uIL">The u il.</param>
			public void add(UInt uIL)
			{
				if (uIL.lengthI > this.lengthI)
				{
					lengthI = uIL.lengthI;			//if the length of input length is max than length of array
													//replace the length of array with input UInt array
				}
				for (int k = 0; k < lengthI; k++)
				{
					if ((x[k] + uIL.x[k]) > 255)	//check if the adding arrays stays smaleer than 2^7
					{
						x[k] += uIL.x[k];			//If yes, add every digits of array with input variable
						i = k + 1;
						x[i]++;						//increase size of array
						while (x[i] == 0)
						{
							x[++i]++;
						}
						if (i == lengthI)
						{
							lengthI++;				//If the increment of array is same as length of array
													//increment the length
						}
					}
					else
					{
						x[k] += uIL.x[k];			//If not, just add every digits of array with input variable
					}
				}
			}

			public void Add (UInt u)
			{
				int small; //minimum value
				int big; //maximum value
				//check to see if the size is biiger than current size
				//if yes, replace minimum with size of array and maximum with current array size
				//If not, do vise versa
				if (lengthI < u.lengthI)
				{
					small = lengthI;
					big = u.lengthI;
				}
				else
				{
					small = u.lengthI;
					big = lengthI;
				}

				bool flag = false; // Initiate the flag to increment the bit
				//add the current value with array value
				for (int Iota = 0; Iota < small; Iota++)
				{
					bool flag2 = x[Iota] > 127u;	//set the flag if the array value is less than 127 bits
					bool flag3 = x[Iota] < u.x[Iota];	//set the flag if array value is smaller than current array
					x[Iota] += u.x[Iota];

					//if flag one got set, then increase the array value by 1
					//and check if cureent value is zero, set the flag3
					if (flag)
					{
						x[Iota] += 1;
						if (x[Iota] == 0u)
							flag3 = true;
					}
					//make a decision to set the flag
					flag = (flag3 || flag2);
				}

				// If there is remainder produce during adding the value, carry to next byte
				if (lengthI == big)
				{
					for (int i = small; i < big; i++)
					{

						if (flag)
						{
							//if flag one got set, then increase the array value by 1
							x[i] += 1;
							if (x[i] != 0u)
							{
								flag = false;
								break;
							}
							flag = true;
						}
					}
				}
				else
				{
					this.lengthI = big;
					for (int i = small; i < big; i++)
					{
						if (flag)
						{
							x[i] = (byte)((u.x[i] + 1u));
							flag = (x[i] == 0u);
						}
						else
							this.x[i] = u.x[i];
					}
				}

				if (flag)
				{
					x[lengthI] = 1;
					lengthI++; // Inrease the size of array
				}
			}
		}

		//-------------------------------------------------------------------------------------
		// Class Name: Program.cs
		// Class Purpose: This class is created to calculate factorial for big integer using uint class
		// Date created: 4/17/2014
		// Date last modified: 4/17/2014
		// @author Ishan Patel
		//-------------------------------------------------------------------------------------

		class Program
		{

			/// <summary>
			/// Defines the entry point of the application.
			/// </summary>
			/// <param name="args">The arguments.</param>
			static void Main (string[] args)
			{
				UInt y = new UInt (1);
				for (int i = 1; i < 1000; i++)
				{
					y.Add (y);
					y.Increment ( );
					
				}
				y.printx ( );
				Console.ReadLine();
				Console.Write ("Enter Number: ");
				ulong n = Convert.ToUInt64 (Console.ReadLine ( ));		//get the user's input
				UInt uL;
				Stopwatch sw = new Stopwatch();		//start the stopwatch
				sw.Start ( );
				uL = Factorial (n);					//call the factorial method to generate hex output of factorials
				sw.Stop ( );	
				Console.WriteLine ("Bytes used to calc factorial : {0}", uL.lengthI);
				Console.WriteLine ("Time used to calc factorial : {0}", sw.Elapsed.TotalMilliseconds / 1000);
				Console.WriteLine ("Press Enter to display {0}! in hex : ", n);
				Console.ReadLine ( );
				uL.printx ( );
				//uL.printHexFile ( );			//print the result in hex
				Console.Write ("\nPress enter to end.");
				Console.ReadLine ( );			//wait till user press enter
			}

			/// <summary>
			/// Factorials the specified n.
			/// </summary>
			/// <param name="n">The n.</param>
			/// <returns></returns>
			public static UInt Factorial (ulong n)
			{
				UInt z = new UInt (1);  //sets z to 1
				for (ulong i = 2; i <= n; i++)
				{
					z.mult (i);
				}
				return z;
			}
		}
	}

