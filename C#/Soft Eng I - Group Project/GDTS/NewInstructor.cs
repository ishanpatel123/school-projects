/*
	Project:		Project 1 V 2
	File Name:		NewInstructorForm.cs
	Description:	A form for new instructors to enter information about themselves.	
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
using System.Text.RegularExpressions;

namespace GDTS
{
	public partial class NewInstructor : Form
	{
		//create a versionof the database functions class
		databaseFunctions df = new databaseFunctions ( );

		public NewInstructor ( )
		{
			InitializeComponent ( );
		}

		/// <summary>
		/// updates the users database to update there informatio, then redirect the user to his or her correct page
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void submitNewTeacherInfoButton_Click (object sender, EventArgs e)
		{
            Match m1 = Regex.Match(firstNameBox.Text, @"^[a-zA-Z]+$");
            Match m2 = Regex.Match(lastNameBox.Text, @"^[a-zA-Z]+$");

            if(m1.Success)
            {
                if(m2.Success)
                {
                    df.updateUser(LoginForm.username, firstNameBox.Text, lastNameBox.Text, classroomRankBox.Text, graduateRankBox.Text);
                }
                else
                {
					MessageBox.Show ("The last must only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
				MessageBox.Show ("The first name must only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

			int type = df.getType (LoginForm.username);
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

		private void NewInstructor_FormClosing (object sender, FormClosingEventArgs e)
		{
			DialogResult a = MessageBox.Show ("Do you want to go Log out and close the app?", "Exit", MessageBoxButtons.YesNo);
			if (a == DialogResult.Yes)
			{
				Application.ExitThread ( );
			}
			else if (a == DialogResult.No)
			{
				e.Cancel = true;
			}
		}
	}
}
