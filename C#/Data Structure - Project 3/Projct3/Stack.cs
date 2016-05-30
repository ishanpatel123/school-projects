/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Ishan Patel
// Department Name	: Computer and Information Sciences 
// File Name			: Stack.cs
// Purpose				: To convert infix to postfix and give nice outlook to String 
// Author				: Ishan Patel, E-Mail: pateli@goldmail.etsu.edu
// Create Date			: Sunday, November 2, 2013
//
//-----------------------------------------------------------------------------------
//
// Modified Date		: Sunday, November 3, 2013
// Modified By			: Ishan Patel
//
/////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Projct3
{
	class Stack
	{
		#region Convert Infix to Postfix
		/// <summary>
		/// InfixToPostFix method convert the Infix to Postfix
		/// and give it nice outlook to String
		/// </summary>
		/// <param name="infixBuffer"></param>
		/// <param name="postfixBuffer"></param>
		/// <returns></returns>
		public bool InfixToPostfixConvert (ref string infixBuffer, out string postfixBuffer)
		{
			int priority = 0;	 
			postfixBuffer = " ";
			Stack<Char> s1 = new Stack<char> ( ); //Create the stack for character
			Stack<string> operandStack = new Stack<string> ( );
			char[] ReservedChars = { '(', ')' };

			int count = 0, countOne =0;
			foreach (char c in infixBuffer) //check if there are open or close parenthesis there
			{
				 count = infixBuffer.Count (f => f == '(');
				 countOne = infixBuffer.Count (f => f == ')');
			}
			
			if (count != countOne) //display the error if there are not close parenthesis
			{
				postfixBuffer += " * * * E R R O R * * *     Unpaired  open  parenthesis ";
			}
			else
			{
				try
				{
					ValidateInfixExpression (ref infixBuffer);

					for (int i = 0; i < infixBuffer.Length; i++)
					{
						char ch = infixBuffer[i];
						foreach (char c in ReservedChars)
						{
							infixBuffer = infixBuffer.Replace (c.ToString ( ), "");
						}

						if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
						{
							// check the precedence
							if (s1.Count <= 0)
								s1.Push (ch);
							else
							{

								if (s1.Peek ( ) == '*' || s1.Peek ( ) == '/')
									priority = 1;
								else
									priority = 0;
								
								if (priority == 1)
								{
									if (ch == '+' || ch == '-')
									{
										postfixBuffer += s1.Pop ( ) + "  ";
										i--;
									}
									else
									{ // Same
										postfixBuffer += s1.Pop ( ) + "  ";
										i--;
									}
								}
								else
								{
									if (ch == '+' || ch == '-')
									{
										postfixBuffer += s1.Pop ( ) + "  ";
										s1.Push (ch);
									}
									else
										s1.Push (ch);
								}
							}
						}
						else
						{
							postfixBuffer += ch + " ";
						}
					}

					int len = s1.Count;
					for (int j = 0; j < len; j++)
						postfixBuffer += s1.Pop ( ) + "  ";

				}
				catch (Exception ex)
				{
					MessageBox.Show ("Invalid Expression", ex.Message);
				}
			}
			return true;
		}

		#endregion

		#region Check for Valid Expression
		
		public void ValidateInfixExpression (ref string expression)
		{
			expression = expression.Replace ("  ", string.Empty);
			// Rule 1: '(' and ')' pair
			// Rule 2: Every two operands must have one operator in between
		}
		#endregion
	}
}
