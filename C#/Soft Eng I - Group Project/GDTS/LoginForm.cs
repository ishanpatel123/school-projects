/*
	Project:		Project 1 V 2
	File Name:		LoginForm.cs
	Description:	A form for users to log in	
	Course:			CSCI 3250 - 001 Software Engineer I
	Author:			Team Blue (Marc Giuffrida (giuffrida@goldmail.etsu.edu), Michael Espy (espymr@goldmail.etsu.edu)
						Charles Fleming (FLEMINGCE@goldmail.etsu.edu), Philip Snider (sniderp@goldmail.etsu.edu)
							Ishan Patel (pateli@goldmail.etsu.edu))
	Created:			Friday, September 15, 2014

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDTS
{
	public partial class LoginForm : Form
	{
		//create a versionof the database functions class
		databaseFunctions df = new databaseFunctions ( );

		public static string username;

		public LoginForm ( )
		{
			InitializeComponent ( );
			loginTextBox.Select ( );

		}

		/// <summary>
		/// what happens when the user hits the login button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void loginButton_Click (object sender, EventArgs e)
		{
			
			//if the user doesn't give an approved login information
			if (df.loginCheck(loginTextBox.Text, passwordTextBox.Text) == false)
			{
				loginTextBox.Text = "";
				passwordTextBox.Text = "";
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			else
			{
				//check to see if the user had previously logged in or not
				if (df.checkLoginCounter (loginTextBox.Text) > 0)
				{
					//get the type of instructor from database
					int type = df.getType(loginTextBox.Text);
					
					//switch case to choose which page to load depending on the type of instructor
					switch (type)
					{
						case 0:
							AdminForm nextForm = new AdminForm ( );
							nextForm.Show ( );
							this.Hide ( );
							break;

						case 1:
							TeacherForm nextForm1 = new TeacherForm ( );
							nextForm1.Show ( );
							this.Hide ( );
							break;

						case 2:
							CoordinatorForm nextForm2 = new CoordinatorForm ( );
							nextForm2.Show ( );
							this.Hide ( );
							break;

					}
					
				}
				else
				{
					username = loginTextBox.Text;
					NewInstructor nextForm3 = new NewInstructor ( );
					nextForm3.Show ( );
					this.Hide ( );

				}
			}

		}

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
			MessageBox.Show ("--- Thanks for using Team Blue GDTS program v.3 ---");
			Application.ExitThread ( );
        }

		private void loginTextBox_TextChanged (object sender, EventArgs e)
		{

		}
	}
}
