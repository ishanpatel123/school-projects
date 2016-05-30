/////////////////////////////////////////////////////////////////////////////////////
//
// Company Name		: Ishan Patel
// Department Name	: Computer and Information Sciences 
// File Name			: AboutBox.cs
// Purpose				: Display a window which contains the information of
//							about this program under help menu.
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
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projct3
{
	partial class AboutBox1 : Form
	{
		#region Default Constructor
		public AboutBox1 ( )
		{
			InitializeComponent ( );
			this.Text = String.Format ("About {0}", AssemblyTitle);
			this.labelProductName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format ("Version {0}", AssemblyVersion);
			this.labelCopyright.Text = AssemblyCopyright;
			this.labelCompanyName.Text = AssemblyCompany;
			this.textBoxDescription.Text = AssemblyDescription;
		}
		#endregion

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes (typeof (AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension (Assembly.GetExecutingAssembly ( ).CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly ( ).GetName ( ).Version.ToString ( );
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes (typeof (AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes (typeof (AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes (typeof (AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes (typeof (AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		#region Copyright Label
		private void labelCopyright_Click (object sender, EventArgs e)
		{

		}
		#endregion

		#region OK Button
		private void okButton_Click (object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close ( );
		}
		#endregion

		#region Laod AboutBox
		private void AboutBox1_Load (object sender, EventArgs e)
		{

		}
		#endregion
	}
}
