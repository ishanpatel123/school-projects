/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Ishan Patel
// Department Name	: Computer and Information Sciences 
// File Name			: InfixToPostfix.cs
// Purpose				: A simple program which input the text file and generate
//							the infix to postfix solution and display in the textbox.
//							It also contain the AboutBox which show information of 
//							this program.
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Utils;
namespace Projct3
{
	public partial class MainWindow : Form
	{
		#region Infix to Postfix Driver
		
		public MainWindow ( )
		{
			Thread t = new Thread (new ThreadStart (SplashScreen));
			t.Start ( );
			Thread.Sleep (3000);
			InitializeComponent ( );
			t.Abort ( );

		}
		#endregion

		#region Run SplashScreen
		public void SplashScreen ( )
		{
			Application.Run (new SplashScreen ( ));

		}
		#endregion

		#region Label for Infix Expression
		private void label1_Click (object sender, EventArgs e)
		{

		}
		#endregion

		#region Exit Button
		private void exitToolStripMenuItem_Click (object sender, EventArgs e)
		{
			DialogResult dlg = MessageBox.Show ("Do you want to exit this program?",
				"Exit", MessageBoxButtons.YesNo);
			if (dlg == DialogResult.Yes)
			{
				Application.Exit ( );
			}
			else if (dlg == DialogResult.No)
			{
			}
		}
		#endregion

		#region AboutBox
		private void aboutInfixToPostFixToolStripMenuItem_Click (object sender, EventArgs e)
		{
			AboutBox1 b = new AboutBox1 ( );
			b.ShowDialog ( );
		}
		#endregion

		#region Help Menu
		private void helpToolStripMenuItem_Click (object sender, EventArgs e)
		{

		}
		#endregion

		#region Open Dialog
		private void inputInfixDataFileToolStripMenuItem_Click (object sender, EventArgs e)
		{

			// Create an instance of the open file dialog box.
			OpenFileDialog openFileDialog1 = new OpenFileDialog ( );

			// Set filter options and filter index.
			openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog1.ShowDialog ( ) == DialogResult.OK)
			{
				if (File.Exists (openFileDialog1.FileName) == true)
				{
					String[] info = File.ReadAllLines (openFileDialog1.FileName);
					for (int i = 0; i < info.Length; i++)
					{
						listBox1.Items.Add (info[i]);
					}
				}
			}

		}
		#endregion

		#region List Box
		private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
		{
			textBox1.Text = listBox1.SelectedItem.ToString ( );
		}
		#endregion

		#region Text Box
		private void textBox1_TextChanged (object sender, EventArgs e)
		{

		}
		#endregion

		#region Exit Button
		private void button3_Click (object sender, EventArgs e)
		{
			DialogResult dlg = MessageBox.Show ("Do you want to exit this program?",
				"Exit", MessageBoxButtons.YesNo);
			if (dlg == DialogResult.Yes)
			{
				Application.Exit ( );
			}
			else if (dlg == DialogResult.No)
			{
			}
		}
		#endregion

		#region Clear Button
		private void button2_Click (object sender, EventArgs e)
		{
			textBox2.Clear ( );
			textBox1.Clear ( );
		}
		#endregion

		#region Text Box
		private void textBox2_TextChanged (object sender, EventArgs e)
		{

		}
		#endregion

		#region Generate Button
		private void button1_Click (object sender, EventArgs e)
		{
				string infixBuffer = textBox1.Text;
				string postfixBuffer = "";
				Stack o = new Stack ( );

				o.InfixToPostfixConvert (ref infixBuffer, out postfixBuffer);
				textBox2.Text = postfixBuffer;
		}
		#endregion

		#region Load Infix to Postfix
		private void Form1_Load (object sender, EventArgs e)
		{

		}
		#endregion
	}
}

