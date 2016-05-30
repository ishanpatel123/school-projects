/*
	Project:		Project 1 V 2
	File Name:		TeacherForm.cs
	Description:	A form for teachers to add and remove questions and add and remove students.	
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
	public partial class TeacherForm : Form
	{
		//create a versionof the database functions class
        databaseFunctions df = new databaseFunctions();
        int courseNumber;
        int goalHolder;
        string questionToRemove;
        int questionHolder;
		int checkSameCourse;
		public TeacherForm ( )
		{
			InitializeComponent ( );
			addQuestionPanel.Show ( );
			logoutLink.Location = new Point (440, 7);

		}

		/// <summary>
		/// what happens when the form loads
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TeacherForm_Load (object sender, EventArgs e)
		{
			removeStudentComboBox.Items.Clear ( );
			chooseCourseComboBoxAddQuestion.Items.Clear ( );
			List<string> courseInfo = new List<string> ( );
			//use to poplulate courses now
			courseInfo = df.populateCourses ( );		//display all the courses to course combobox from bank of course
			for (int i = 0; i < courseInfo.Count; i++)
			{
				chooseCourseComboBoxAddQuestion.Items.Add (courseInfo[i]);
			}

			List<string> studentInfo = new List<string> ( );
			//use to poplulate courses now
			studentInfo = df.populateStudents ( );		//display all the courses to course combobox from bank of course
			for (int i = 0; i < studentInfo.Count; i++)
			{
				removeStudentComboBox.Items.Add (studentInfo[i]);
			}

			
		}
		//Teacher Functions


        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 513;
            this.Height = 389;
            addQuestionPanel.Visible = true;
            addStudentPanel.Visible = false;
            removeStudentPanel.Visible = false;
			matrixStudentPanel.Visible = false;
			logoutLink.Location = new Point (440, 7);

        }

		private void addToolStripMenuItem1_Click (object sender, EventArgs e)
		{
			this.Width = 275;
			this.Height = 245;
			addQuestionPanel.Visible = false;
			addStudentPanel.Visible = true;
			removeStudentPanel.Visible = false;
			matrixStudentPanel.Visible = false;
			logoutLink.Location = new Point (199, 7);

		}

		private void removeToolStripMenuItem1_Click (object sender, EventArgs e)
		{
			this.Width = 275;
			this.Height = 245;
			addQuestionPanel.Visible = false;
			addStudentPanel.Visible = false;
			removeStudentPanel.Visible = true;
			matrixStudentPanel.Visible = false;
			logoutLink.Location = new Point (199, 7);

		}

		//metrix Functions

		private void studentToolStripMenuItem1_Click (object sender, EventArgs e)
		{
			this.Width = 513;
			this.Height = 389;
			addQuestionPanel.Visible = false;
			addStudentPanel.Visible = false;
			removeStudentPanel.Visible = false;
			matrixStudentPanel.Visible = true;
			logoutLink.Location = new Point (440, 7);

		}

		//Add question
		private void chooseCourseComboBoxAddQuestion_SelectedIndexChanged (object sender, EventArgs e)
		{
			chooseObjectiveComboBox.Visible = true;
            getCourseNumber();
			if (chooseCourseComboBoxAddQuestion.SelectedIndex != checkSameCourse)
			{
				chooseObjectiveComboBox.Items.Clear ( );
			}
			else
			{
				checkSameCourse = chooseCourseComboBoxAddQuestion.SelectedIndex;
			}
            getGoalForQuestion();
		}

        private void chooseObjectiveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
			
			checkedListBox1.Visible = true;
            addQuestionToBankButton.Visible = true;
            removeQuestionButton.Visible = true;
            getGoalId();
            displayAllQuestions();
        }

		private void addQuestionToBankButton_Click (object sender, EventArgs e)
		{
			AddQuestion aq = new AddQuestion ( );
            aq.Show();
            this.Hide();
			//df.addQuestions (addQuestionTextBox.Text, addCorrectAnswerTextBox.Text);
		}
        private void removeQuestionButton_Click(object sender, EventArgs e)
        {
            questionToRemove = checkedListBox1.SelectedItem.ToString();
            getQuestionIdForDeletion();
            removeQuestion();
            checkedListBox1.Items.Clear();
            displayAllQuestions();
        }

		//Add student


		/// <summary>
		/// calls the add student method to add a new student to the database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

						//clear all below textboxes 
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
                MessageBox.Show("The ID must only contain numbers and be 8 numbers long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			removeStudentComboBox.Items.Clear ( );

			List<string> studentInfo = new List<string> ( );
			//use to poplulate courses now
			studentInfo = df.populateStudents ( );		//display all the courses to course combobox from bank of course
			for (int i = 0; i < studentInfo.Count; i++)
			{
				removeStudentComboBox.Items.Add (studentInfo[i]);
			}
		}

		//Remove student
		private void removeStudentComboBox_SelectedIndexChanged (object sender, EventArgs e)
		{

		}

		/// <summary>
		/// removes a student from the database when the user hits the button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

        private void logoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			LoginForm lf1 = new LoginForm ( );
			lf1.Show ( );
			this.Hide ( );
        }

		

        private void displayAllQuestions()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd1.CommandText = "Select * from Question where Goal_Id =" + goalHolder;
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader1 = cmd1.ExecuteReader();
                //Ensure that sql data reader can read 
                while (dReader1.Read())
                {
                    //gets and display question and its correct answer  from question table
                    string questionHolder = dReader1["Question"].ToString();
                    string answerHolder = dReader1["Correct_Answer"].ToString();
                    checkedListBox1.Items.Add(questionHolder + " " + answerHolder);
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
        }

        private void getGoalId()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd1.CommandText = "Select * from Goal where Goal_Description ='" + chooseObjectiveComboBox.Text + "'";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader1 = cmd1.ExecuteReader();
                //Ensure that sql data reader can read 
                while (dReader1.Read())
                {
                    //gets and display question and its correct answer  from question table
                    goalHolder = int.Parse(dReader1["Goal_Id"].ToString());
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
        }

        public void getCourseNumber()
        {
            //split a course text using string array object
            string[] words = chooseCourseComboBoxAddQuestion.Text.Split(' ');
            //create a list of course with string array
            List<string> queryWords = words.ToList();

            //queryWords now contains the four words needed to  
            foreach (string word in words)
            {
                //If there is no word in list, it will remove it
                if (word == "")
                {
                    queryWords.Remove(word);
                }
            }

            courseNumber = int.Parse(queryWords[1]);
        }

        public void getGoalForQuestion()
        {


            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
            try
            {
                //reading data from database via SqlDataReader object
                SqlDataReader dReader;
                // Instantiate command with a query and  sql connection
                SqlCommand cmd = new SqlCommand();
                //Set the Connection property with command
                cmd.Connection = cn;
                //Set a commandtype property with  command text
                cmd.CommandType = CommandType.Text;
                //set a command text with sql connection
                cmd.CommandText = "Select * from Goal where( Course_Number = " + courseNumber+ ")";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                List<string> holders = new List<string>();
                //Ensure that sql data reader can read 
                while (dReader.Read())
                {
                    //display course ids  from course table
                    string holder = dReader["Goal_Description"].ToString();
                    holders.Add(holder);
                }

                for(int i = 0; i <= holders.Count()-1; i++)
                {
                    chooseObjectiveComboBox.Items.Add(holders[i]);
                }
              
            }
            catch (Exception)
            {
                //display if there are any errors are occured 
            }
            finally
            {
                cn.Close();
            }
        }

        private void removeQuestion()
        {
            DialogResult a = MessageBox.Show("Are you sure you want to remove this question?", "Exit", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
                try
                {
                    //reading data from database via SqlDataReader object
                    SqlDataReader dReader;
                    // Instantiate command with a query and  sql connection
                    SqlCommand cmd = new SqlCommand();
                    //Set the Connection property with command
                    cmd.Connection = cn;
                    //Set a commandtype property with  command text
                    cmd.CommandType = CommandType.Text;
                    //set a command text with sql connection
                    cmd.CommandText = "Delete from Question where Question_ID = " + questionHolder;
                    //open a connection
                    cn.Open();

                    //Call Execute reader to get query results
                    dReader = cmd.ExecuteReader();

                    MessageBox.Show("Question removed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dReader.Close();
                }

                catch (Exception)
                {
                    //display if there are any errors are occured
                }
                finally
                {
                    cn.Close();
                }
            }
            else
            {
                this.Refresh();
            }
        }

        private void getQuestionIdForDeletion()
        {

            string[] words = questionToRemove.Split(' ');

            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
            try
            {
                //reading data from database via SqlDataReader object
                SqlDataReader dReader;
                // Instantiate command with a query and  sql connection
                SqlCommand cmd = new SqlCommand();
                //Set the Connection property with command
                cmd.Connection = cn;
                //Set a commandtype property with  command text
                cmd.CommandType = CommandType.Text;
                //set a command text with sql connection
                cmd.CommandText = "Select * from Question where( Question = '" + words[0] + "' and Correct_Answer = '" + words[1] + "')";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                //Ensure that sql data reader can read 
                while (dReader.Read())
                {
                    //display course ids  from course table
                    questionHolder = int.Parse(dReader["Question_ID"].ToString());
                    
                }

            }
            catch (Exception)
            {
                //display if there are any errors are occured 
            }
            finally
            {
                cn.Close();
            }
        }

        private void questionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void goalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

		private void TeacherForm_FormClosing (object sender, FormClosingEventArgs e)
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

		private void checkedListBox1_SelectedIndexChanged (object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged (object sender, EventArgs e)
		{
			
		}

		private void totalStudentPerExamButton_Click (object sender, EventArgs e)
		{
			List<int> list1 = new List<int> ( );
			List<string> list2 = new List<string> ( );
			var list = new List<KeyValuePair<int, int>> ( );

			//Enable the sql connection with local database
			SqlConnection cn = new SqlConnection (@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
			try
			{
				//reading data from database via SqlDataReader object
				SqlDataReader dReader;
				// Instantiate command with a query and  sql connection
				SqlCommand cmd = new SqlCommand ( );
				//Set the Connection property with command
				cmd.Connection = cn;
				//Set a commandtype property with  command text
				cmd.CommandType = CommandType.Text;
				//set a command text with sql connection
				cmd.CommandText = "Select * from QuestionTracker";
				//open a connection
				cn.Open ( );

				//Call Execute reader to get query results
				dReader = cmd.ExecuteReader ( );

				//Ensure that sql data reader can read 
				while (dReader.Read ( ))
				{
					//display course ids  from course table
					int holder = int.Parse(dReader["Test_Id"].ToString ( ));
					list1.Add( holder);
					
				}
				dReader.Close ( );
				int testNum = 0; int studentNum = 0;
				testNum = list1[0];
				int items = list1.Count ( );
				int k = 0;
				for(k = 0;k<items;k++)
				{
					 
					if (list1[k] == testNum)
					{
						studentNum++;
					}
					else
					{
						
						list.Add (new KeyValuePair<int, int> (list1[k], studentNum));
						studentNum = 0;
						testNum++;
						k--;
					}
				}
				groupStudentTextbox.Text = "";
				list.Add (new KeyValuePair<int, int> (list1[k-1], studentNum));
				foreach (var s in list)
				{
					groupStudentTextbox.Text += "Exam No.:" + s.Key +"\tNumber of Students: " + s.Value + "\r\n";
				}
			}
			catch (Exception)
			{
				//display if there are any errors are occured 
			}
			finally
			{
				cn.Close ( );
			}	
		}

		

		private void studentsPerExamConcentrationButton_Click_1 (object sender, EventArgs e)
		{
			groupStudentTextbox.Clear ( );
			List<int> list1 = new List<int> ( );				//test num
			List<string> list2 = new List<string> ( );			//concentration
			List<string> list3 = new List<string> ( );			//student id
			var listACS = new List<KeyValuePair<int, int>> ( );
			var listIT = new List<KeyValuePair<int, int>> ( );

			//Enable the sql connection with local database
			SqlConnection cn = new SqlConnection (@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
			try
			{
				//reading data from database via SqlDataReader object
				SqlDataReader dReader;
				// Instantiate command with a query and  sql connection
				SqlCommand cmd = new SqlCommand ( );
				//Set the Connection property with command
				cmd.Connection = cn;
				//Set a commandtype property with  command text
				cmd.CommandType = CommandType.Text;
				//set a command text with sql connection

				cmd.CommandText = "Select * from QuestionTracker";
				//open a connection
				cn.Open ( );

				//Call Execute reader to get query results
				dReader = cmd.ExecuteReader ( );

				//Ensure that sql data reader can read 
				while (dReader.Read ( ))
				{
					//display course ids  from course table
					int holder = int.Parse (dReader["Test_Id"].ToString ( ));
					string holder1 = dReader["Student_Id"].ToString ( );
					list3.Add (holder1);
					list1.Add (holder);				
				}
				dReader.Close ( );
				cn.Close ( );
				//open a connection
				for(int i =0; i< list3.Count;i++){
					//Set the Connection property with command
					cmd.Connection = cn;
					//Set a commandtype property with  command text
					cmd.CommandType = CommandType.Text;
					//set a command text with sql connection for course
					cmd.CommandText = "Select * from Student where Student_ID = '" + list3[i] + "'";
					//open a connection
					cn.Open ( );
					//Call Execute reader to get query results
					dReader = cmd.ExecuteReader ( );
					//Ensure that sql data reader can read 
					if (dReader.HasRows == true)
					{
						//display all course table values from course table
						while (dReader.Read ( ))
						{
							string comboBoxInfo = dReader["Concentration"].ToString ( );
							//If the any course values are selected, it will added to comboboxes
							list2.Add(comboBoxInfo);
						}
					}
					else
					{
						//If there is no display, display error message
						MessageBox.Show ("Data not found");
					}
					//close the reader 
					dReader.Close ( );
					cn.Close ( );
				}
				int testNum = 0; int studentNum = 0;
				int testNum2 = 0; int studentNum2 = 0;

				testNum = list1[0];
				int items = list1.Count ( );
				int k = 0;
				for (k = 0; k < items; k++)
				{
					if (list2[k] == "ACS       ")
					{
							if (list1[k] == testNum){
								studentNum++;								
							}
							else{
								listACS.Add (new KeyValuePair<int, int> (testNum, studentNum));
								studentNum = 0;
								testNum++;
								k--;
							}
					}
					else if (list2[k] == "IT       ")
					{
						if (list1[k] == testNum2)
						{
							studentNum2++;
						}
						else
						{
							listIT.Add (new KeyValuePair<int, int> (testNum2, studentNum2));
							studentNum2 = 0;
							testNum2++;
							k--;
						}
					}
				}
				if (list2[k-1] == "ACS       ")
				{
					listACS.Add (new KeyValuePair<int, int> (testNum, studentNum));
				}
				else if (list2[k - 1] == "IT        ")
				{
					listIT.Add (new KeyValuePair<int, int> (testNum, studentNum));
				}
				groupStudentTextbox.Text += "ACS:\n";
				foreach (var s in listACS)
				{
					groupStudentTextbox.Text += "\tExam No.: " + s.Key + "\tNumber of Students: " + s.Value + "\r\n";
				}
				groupStudentTextbox.Text += "IT:\n";
				foreach (var s in listIT)
				{
					groupStudentTextbox.Text += "\tExam No.: " + s.Key + "\tNumber of Students: " + s.Value + "\r\n";
				}
			}
			catch (Exception)
			{
				//display if there are any errors are occured 
			}
			finally
			{
				cn.Close ( );
			}
		}

		private void averageScorePerCourseButton_Click (object sender, EventArgs e)
		{
			List<int> courseIdQT = new List<int> ( );			
			List<int> gradePerCourse = new List<int> ( );
			List<string> courseInfo = new List<String> ( );
			var list = new List<KeyValuePair<int, int>> ( );
			var list1 = new List<KeyValuePair<string, int>> ( );

			int testNum = 0;
			SqlConnection cn = new SqlConnection (@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + df.path + @"\GDTSDatabase.mdf;Integrated Security=True");
			try
			{
				//reading data from database via SqlDataReader object
				SqlDataReader dReader;
				// Instantiate command with a query and  sql connection
				SqlCommand cmd = new SqlCommand ( );
				//Set the Connection property with command
				cmd.Connection = cn;
				//Set a commandtype property with  command text
				cmd.CommandType = CommandType.Text;
				//set a command text with sql connection for course
				cmd.CommandText = "Select * from QuestionTracker";
				//open a connection
				cn.Open ( );
				//Call Execute reader to get query results
				dReader = cmd.ExecuteReader ( );
				//display all course table values from course table
				while (dReader.Read ( ))
				{

					int comboBoxInfo = int.Parse (dReader["Course_Id"].ToString ( ));
					//If the any course values are selected, it will added to comboboxes
					int comboBoxInfo1 = int.Parse (dReader["Grade"].ToString ( ));
					gradePerCourse.Add (comboBoxInfo1);
					courseIdQT.Add (comboBoxInfo);
				}					
				dReader.Close ( );

				testNum = courseIdQT[0];
				int items = courseIdQT.Count ( );
				int k = 0, studentNum=0;
				for (k = 0; k < items; k++)
				{


					if (courseIdQT[k] == testNum)
					{
						studentNum += courseIdQT[k];
					}
					else
					{
						list.Add (new KeyValuePair<int, int> (testNum, studentNum));
						studentNum = 0;
						testNum++;
						k--;

					}
				}
				list.Add (new KeyValuePair<int, int> (testNum, studentNum));
				foreach (var s in list)
				{
					
				}
			}
			catch (Exception)
			{
				//display if there are any errors are occured
			}
			finally
			{
				cn.Close ( );
			}		





		}
	}
}
