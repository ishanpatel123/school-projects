/*
	Project:		Project 1 V 2
	File Name:		AdminForm.cs
	Description:	A form for the administrators to use	
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
	public partial class AdminForm : Form
	{
		public AdminForm ( )
		{
			InitializeComponent ( );
			addUserPanel.Show ( );
		}


		databaseFunctions df = new databaseFunctions ( );

		//Admin Functions
		private void addUserToolStripMenuItem_Click (object sender, EventArgs e)
		{
			addUserPanel.Visible = true;
			removeUserPanel.Visible = false;
			addCoursePanel.Visible = false;
			removeCoursePanel.Visible = false;
		}

		private void removeUserToolStripMenuItem_Click (object sender, EventArgs e)
		{
			addUserPanel.Visible = false;
			removeUserPanel.Visible = true;
			addCoursePanel.Visible = false;
			removeCoursePanel.Visible = false;
		}

		private void addCourseToolStripMenuItem1_Click (object sender, EventArgs e)
		{
			addUserPanel.Visible = false;
			removeUserPanel.Visible = false;
			addCoursePanel.Visible = true;
			removeCoursePanel.Visible = false;
		}

		private void removeCourseToolStripMenuItem1_Click (object sender, EventArgs e)
		{
			addUserPanel.Visible = false;
			removeUserPanel.Visible = false;
			addCoursePanel.Visible = false;
			removeCoursePanel.Visible = true;
		}


		//Add User Functions

		/// <summary>
		/// what happens when the user hits the add user button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void addUserButton_Click (object sender, EventArgs e)
		{
			Match m1 = Regex.Match (addUsernameTextBox.Text, @"^[a-zA-Z]+$");

            if (m1.Success)
            {
                if (addPasswordTextBox.Text.Length > 4 && addPasswordTextBox.Text.Length < 10)
                {
                    if (int.Parse(addUserTypeTextBox.Text) == 1 || int.Parse(addUserTypeTextBox.Text) == 2)
                    {
                        df.addUser(addUsernameTextBox.Text, addPasswordTextBox.Text, Int16.Parse(addUserTypeTextBox.Text));

						addUsernameTextBox.Text = "";
						addPasswordTextBox.Text = "";
						addUserTypeTextBox.Text = "";
					}
                    else
                    {
                        MessageBox.Show("Please enter a 1 or a 2 for the user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
					MessageBox.Show ("The password must be between 5 and 10 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
				MessageBox.Show ("The username must only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

		}

		/// <summary>
		/// what happen when the user hits the remove user button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void removeUserButton_Click (object sender, EventArgs e)
		{
			DialogResult a = MessageBox.Show ("Are you sure you want to remove this user?", "Exit", MessageBoxButtons.YesNo);
			if (a == DialogResult.Yes)
			{
				removeUserComboBox.Items.Clear ( );				//clear all other choose  comboboxes in GDTS application
				df.removeUser (removeUserComboBox.Text);

				List<string> userInfo = new List<string> ( );
				//use to poplulate courses now
				userInfo = df.populateUsers ( );		//display all the courses to course combobox from bank of course
				for (int i = 0; i < userInfo.Count; i++)
				{
					removeUserComboBox.Items.Add (userInfo[i]);
				}
				removeUserComboBox.Text = "Select User...";
			}
		}

		//Add Course Functions


		/// <summary>
		/// what happens when the user hits the add course button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void addCourseButton_Click (object sender, EventArgs e)
		{
            Match m2 = Regex.Match(courseNumberTextBox.Text, @"\d+");

                if (m2.Success && courseNumberTextBox.Text.Length == 4)
                {
                    
                                df.addCourses(courseNumberTextBox.Text, coursePrefixTextBox.Text.ToUpper());

								courseNumberTextBox.Text = "";
								coursePrefixTextBox.Text = "";
                }
                else
                {
					MessageBox.Show ("The course number must only be numers and be 4 numbers long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            removeCourseComboBox.Items.Clear();

			List<string> courseInfo = new List<string> ( );
			courseInfo = df.populateCourses ( );		
			for (int i = 0; i < courseInfo.Count; i++)
			{
				removeCourseComboBox.Items.Add (courseInfo[i]);
			}
		}

		/// <summary>
		/// what happens when the user hits the remove course button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void removeCourseButton_Click (object sender, EventArgs e)
		{
			DialogResult a = MessageBox.Show ("Are you sure you want to remove this course?", "Exit", MessageBoxButtons.YesNo);
			if (a == DialogResult.Yes)
			{
				removeCourseComboBox.Items.Clear ( );
				df.getCourseIdForDeleting (removeCourseComboBox.Text);
				df.removeCourse ( );

				List<string> courseInfo = new List<string> ( );

				courseInfo = df.populateCourses ( );
				for (int i = 0; i < courseInfo.Count; i++)
				{
					removeCourseComboBox.Items.Add (courseInfo[i]);
				}
				removeCourseComboBox.Text = "Select Course...";
			}
		}

		/// <summary>
		/// what happens when the form loads
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AdminForm_Load (object sender, EventArgs e)
		{
			removeCourseComboBox.Items.Clear ( );				
			removeUserComboBox.Items.Clear ( );
			List<string> courseInfo = new List<string> ( );

			courseInfo = df.populateCourses ( );		
			for (int i = 0; i < courseInfo.Count; i++)
			{
				removeCourseComboBox.Items.Add (courseInfo[i]);
			}

			List<string> userInfo = new List<string> ( );

			userInfo = df.populateUsers ( );		
			for (int i = 0; i < userInfo.Count; i++)
			{
				removeUserComboBox.Items.Add (userInfo[i]);
			}
		}

        private void logoutLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
				LoginForm lf1 = new LoginForm ( );
				lf1.Show ( );
				this.Hide ( );
        }

		private void AdminForm_FormClosing (object sender, FormClosingEventArgs e)
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