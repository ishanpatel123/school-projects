using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Project4
{
	public partial class Form1 : Form
	{
		public String fileName = "";
		public String folderName = "";
		public Form1 ( )
		{
			InitializeComponent ( );
		}

		/// <summary>
		/// Handles the Click event of the label2 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void label2_Click (object sender, EventArgs e)
		{}

		/// <summary>
		/// Handles the Click event of the button1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button1_Click (object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog ( );
			openFileDialog1.Title = "Open a BInary file";
			openFileDialog1.Filter = "Binary File|*.bin";
			if (openFileDialog1.ShowDialog ( ) == DialogResult.OK)
			{
				try
				{
					fileName = openFileDialog1.FileName;
				}
				catch (Exception ex)
				{
					MessageBox.Show ("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
			if (!Directory.Exists ("TempFiles123"))
			{
				Directory.CreateDirectory ("TempFiles123");
			}
			folderName = System.Environment.CurrentDirectory + "\\TempFiles123";
		}

		/// <summary>
		/// Handles the Click event of the button2 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void button2_Click (object sender, EventArgs e)
		{
			//If the sort button clicked just create/sort all temp files and display the time
			Stopwatch sw = Stopwatch.StartNew ( );
			CreateBinaryFile access = new CreateBinaryFile ( );
			try
			{
				int heapSize = int.Parse (textBox2.Text );
				int mergeFiles = int.Parse (textBox1.Text);
				access.readSourceFile (fileName, folderName, heapSize, mergeFiles);
				String sortedFileName = System.Environment.CurrentDirectory;
				access.createSortFile (fileName, folderName, sortedFileName, heapSize, mergeFiles);
				Directory.Delete (System.Environment.CurrentDirectory + "\\TempFiles123", true);
				sw.Stop ( );
				label6.Text = "Time Used: " + sw.Elapsed.TotalMilliseconds / 1000.0 + " seconds";
			}
			catch (Exception ex)
			{
				MessageBox.Show ("Error: Enter the heap size and merge files. Original error: " + ex.Message);
			}		
		}

		private void richTextBox1_TextChanged (object sender, EventArgs e)
		{}

		private void label7_Click (object sender, EventArgs e)
		{}

		private void textBox2_TextChanged (object sender, EventArgs e)
		{}

		private void textBox1_TextChanged (object sender, EventArgs e)
		{}

		private void textBox3_TextChanged (object sender, EventArgs e)
		{}

		private void label5_Click (object sender, EventArgs e)
		{}
	}
}
