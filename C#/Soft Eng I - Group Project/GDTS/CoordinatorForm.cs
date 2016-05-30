/*
	Project:		Project 1 V 2
	File Name:		CoordinatorForm.cs
	Description:	A form for coordinators to give tests, remove tests, and add and remove students.	
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
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace GDTS
{
	public partial class CoordinatorForm : Form
	{
        databaseFunctions df = new databaseFunctions();
        int iForTesting = 0;
        int jForTesting = 0;
        int selectedRadioButton;

		public CoordinatorForm ( )
		{
			InitializeComponent ( );
			administerTestPanel.Show ( );
			logoutLink.Location = new Point (440, 7);
			
		}

		/// <summary>
		/// what happens when the form loads
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CoordinatorForm_Load (object sender, EventArgs e)
		{
			chooseCourseComboBox.Items.Clear ( );
			chooseStudentComboBox.Items.Clear ( );
			removeStudentComboBox.Items.Clear ( );


			List<string> studentInfo = new List<string> ( );

			studentInfo = df.populateStudents ( );		
			for (int i = 0; i < studentInfo.Count; i++)
			{
				chooseStudentComboBox.Items.Add (studentInfo[i]);
				removeStudentComboBox.Items.Add (studentInfo[i]);
			}
		}


		//Coordinator Functions
		private void administerTestToolStripMenuItem_Click (object sender, EventArgs e)
		{
			this.Width = 513;
			this.Height = 389;
			administerTestPanel.Visible = true;
			addStudentPanel.Visible = false;
			removeStudentPanel.Visible = false;
			logoutLink.Location = new Point (440, 7);
		}

		private void addToolStripMenuItem_Click (object sender, EventArgs e)
		{
			this.Width = 275;
			this.Height = 245;
			administerTestPanel.Visible = false;
			addStudentPanel.Visible = true;
			removeStudentPanel.Visible = false;
			logoutLink.Location = new Point (199, 7);

		}

		private void removeToolStripMenuItem_Click (object sender, EventArgs e)
		{
			this.Width = 275;
			this.Height = 245;
			administerTestPanel.Visible = false;
			addStudentPanel.Visible = false;
			removeStudentPanel.Visible = true;
			logoutLink.Location = new Point (199, 7);
		}

		//Administer Test Functions
		private void chooseCourseComboBox_SelectedIndexChanged (object sender, EventArgs e)
		{
            DialogResult a = MessageBox.Show("Are you sure you want to begin a test?", "Test", MessageBoxButtons.YesNo);
			
            if (a == DialogResult.Yes)
            {
                df.createTest();
                label1.Show();
                label2.Show();
                label4.Show();
                label3.Show();
                label21.Show();
                administerTestQuestion.Show();
                administerTestCorrectAnswer.Show();
                radioButton1.Show();
                radioButton2.Show();
                radioButton3.Show();
                radioButton4.Show();
                radioButton5.Show();
                administerTestNextButton.Show();

                df.getCourseIdForTesting(chooseCourseComboBox.Text);
                df.getGoalForQuestion();
                df.generateListOfQuestions();
                outputtingQuestion();

                chooseStudentComboBox.Visible = true;
            }
            else
            {
                hideInfoBoxes();
            }
		}

		private void chooseStudentComboBox_SelectedIndexChanged (object sender, EventArgs e)
		{
			df.figureStudentIdForTesting (chooseStudentComboBox.Text);
            List<string> courseInfo = new List<string>();
            courseInfo = df.populateCoursesForTesting();
            for (int i = 0; i < courseInfo.Count; i++)
            {
                chooseCourseComboBox.Items.Add(courseInfo[i]);
            }
            chooseCourseComboBox.Visible = true;			
		}

		private void administerTestQuestion_Click (object sender, EventArgs e)
		{

		}

		private void administerTestCorrectAnswer_Click (object sender, EventArgs e)
		{

		}

        private void administerTestNextButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false && radioButton5.Checked == false)
            {
                MessageBox.Show("Please select answer for question!");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    selectedRadioButton = 1;
                }
                else if (radioButton2.Checked == true)
                {
                    selectedRadioButton = 2;
                }
                else if (radioButton3.Checked == true)
                {
                    selectedRadioButton = 3;
                }
                else if (radioButton4.Checked == true)
                {
                    selectedRadioButton = 4;
                }
                else if (radioButton5.Checked == true)
                {
                    selectedRadioButton = 5;
                }
                questionTrackerStore();

                if (df.counter < 3)
                {
                    outputtingQuestion();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Do you want to ask another question?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    int number = 0;// = df.questionsToGive[df.randomListOfGoals.Count ( ) - 1].Count;
                    for (int i = 0; i < df.questionsToGive.Count; i++)
                    {
                        int num = df.questionsToGive[i].Count;
                        number += num;
                    }



                    if (result == DialogResult.Yes)
                    {
                        if (number == df.counter)
                        {
                            MessageBox.Show("There are no more questions to ask.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            df.questionsToGive = new List<List<int>>();
                            df.randomListOfGoals = new List<int>();

                            hideInfoBoxes();
                        }

                        outputtingQuestion();
                    }
                    else
                    {
                        hideInfoBoxes();

                        df.questionsToGive = new List<List<int>>();

                    }
                }

            }
        }

		//Add student functions

		private void addStudentButton_Click (object sender, EventArgs e)
		{
            
            Match m1 = Regex.Match(addStudentIDTextBox.Text, @"\d+");
            Match m2 = Regex.Match(addFirstNameTextBox.Text, @"^[a-zA-Z]+$");
            Match m3 = Regex.Match(addLastNameTextBox.Text, @"^[a-zA-Z]+$");


            if (m1.Success && addStudentIDTextBox.Text.Length == 8)
            {
                if (m2.Success)
                {
                    if (m3.Success)
                    {
                        df.addStudents("E" + addStudentIDTextBox.Text, addFirstNameTextBox.Text, addLastNameTextBox.Text, concentrationComboBox.Text);

						addStudentIDTextBox.Text = "";
						addFirstNameTextBox.Text = "";
						addLastNameTextBox.Text = "";
					}
                    else
                    {
						MessageBox.Show ("The last name must only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
					MessageBox.Show ("The first name must only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
				MessageBox.Show ("The ID must be numbers only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			chooseCourseComboBox.Items.Clear ( );
			chooseStudentComboBox.Items.Clear ( );
			removeStudentComboBox.Items.Clear ( );

			List<string> courseInfo = new List<string> ( );
			courseInfo = df.populateCourses ( );		
			for (int i = 0; i < courseInfo.Count; i++)
			{
				chooseCourseComboBox.Items.Add (courseInfo[i]);
			}

			List<string> studentInfo = new List<string> ( );
			
			studentInfo = df.populateStudents ( );		
			for (int i = 0; i < studentInfo.Count; i++)
			{
				chooseStudentComboBox.Items.Add (studentInfo[i]);
				removeStudentComboBox.Items.Add (studentInfo[i]);
			}
		}

		//Remove student functions
		private void removeStudentButton_Click (object sender, EventArgs e)
		{
			DialogResult a = MessageBox.Show ("Are you sure you want to remove this student?", "Exit", MessageBoxButtons.YesNo);
			if (a == DialogResult.Yes)
			{
				df.getStudentIdForDeleting (removeStudentComboBox.Text);
				df.removeStudent ( );

				removeStudentComboBox.Items.Clear ( );

				List<string> studentInfo = new List<string> ( );
				//use to poplulate courses now
				studentInfo = df.populateStudents ( );		//display all the courses to course combobox from bank of course
				for (int i = 0; i < studentInfo.Count; i++)
				{
					removeStudentComboBox.Items.Add (studentInfo[i]);
				}
				removeStudentComboBox.Text = "Select a student...";
			}

		}

		private void removeStudentComboBox_SelectedIndexChanged (object sender, EventArgs e)
		{
			
		}



		/// <summary>
		/// display a question to user from question combobox
		/// </summary>
        public void outputtingQuestion()
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");

            df.counter++;


            try
            {
                //reading data from database via SqlDataReader object
                SqlDataReader dReader1;
                // Instantiate command with a query and  sql connection
                SqlCommand cmd1 = new SqlCommand();
                //Set the Connection property with command
                cmd1.Connection = cn;
                //Set a commandtype property with  command text
                cmd1.CommandType = CommandType.Text;
                //set a command text with sql connection to select question id
                cmd1.CommandText = "Select * from Question where Question_ID = " + df.questionsToGive[iForTesting][jForTesting];
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader1 = cmd1.ExecuteReader();
                //Ensure that sql data reader can read 
                while (dReader1.Read())
                {
                    //gets and display question and its correct answer  from question table
                    string questionHolder = dReader1["Question"].ToString();
                    administerTestQuestion.Text = questionHolder;
                    string answerHolder = dReader1["Correct_Answer"].ToString();
                    administerTestCorrectAnswer.Text = answerHolder;
                }
                //close the reader
                dReader1.Close();
            }
            catch (Exception)
            {
                //display if there are any errors are occured 
            }
            finally
            {
                //If not, close a connection
                cn.Close();
            }
            try
            {
                if (iForTesting < df.questionsToGive.Count() - 1)
                {
                    iForTesting++;

                    if (jForTesting == df.questionsToGive[iForTesting].Count())
                    {
                        df.questionsToGive.RemoveAt(iForTesting);
                    }
                }
                else
                {
                    iForTesting = 0;
                    jForTesting++;
                }
            }
            catch (Exception)
            {
                //reset the administrate test tabe
                MessageBox.Show("There are no more questions to ask.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                df.questionsToGive = new List<List<int>>();
                df.randomListOfGoals = new List<int>();
                hideInfoBoxes();
            }
        }

        public void questionTrackerStore()
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
            try
            {
                //open a sql connection
                cn.Open();
                // Instantiate command with a query and  sql connection
                SqlCommand exeSql = new SqlCommand("", cn);
                //set a command text with sql connection to database
                exeSql.CommandText = "insert into QuestionTracker ( Grade, Question_Id, Test_Id, Course_Id, Goal_Id, Student_ID) values (" + selectedRadioButton + ",  " + df.questionsToGive[iForTesting][jForTesting] + ", " + df.testId + ", " + df.courseIdToGiveQuestion + ", " + df.randomListOfGoals[iForTesting] + ", '" + df.studentIdForTest + "')";
                //call a ExecuteNonQuery to send command via connection
                exeSql.ExecuteNonQuery();
            }
            catch(Exception)
            {
                
            }
            //display a message that student is added to database	
            //MessageBox.Show ("Student successfully added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //close a connection with databse
            finally
            {
                cn.Close();
            }


        }



		public void hideInfoBoxes ( )
		{
			administerTestCorrectAnswer.Text = "";
			administerTestQuestion.Text = "";
			chooseCourseComboBox.Text = "";
			chooseStudentComboBox.Text = "";
			df.counter = 0;
			chooseCourseComboBox.Hide ( );
			label1.Hide ( );
			label2.Hide ( );
			label4.Hide ( );
			label3.Hide ( );
			label21.Hide ( );
			administerTestQuestion.Hide ( );
			administerTestCorrectAnswer.Hide ( );
			radioButton1.Hide ( );
			radioButton2.Hide ( );
			radioButton3.Hide ( );
			radioButton4.Hide ( );
			radioButton5.Hide ( );
			administerTestNextButton.Hide ( );
			//only display to select a new course and student from combox list
			chooseCourseComboBox.Text = "Choose course...";
			chooseStudentComboBox.Text = "Choose student...";
		}

        private void logoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			LoginForm lf1 = new LoginForm ( );
			lf1.Show ( );
			this.Hide ( );
        }

		private void CoordinatorForm_FormClosing (object sender, FormClosingEventArgs e)
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

		private void logoutLink_LinkClicked_1 (object sender, LinkLabelLinkClickedEventArgs e)
		{
			LoginForm lf1 = new LoginForm ( );
			lf1.Show ( );
			this.Hide ( );
		}

	}
}
