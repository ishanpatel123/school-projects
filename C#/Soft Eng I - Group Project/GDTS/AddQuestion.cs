/*
	Project:		Project 1 V 2
	File Name:		AddQuestion.cs
	Description:	A form for teachers to add and questions.	
	Course:			CSCI 3250 - 001 Software Engineer I
	Author:			Team Blue (Marc Giuffrida (giuffrida@goldmail.etsu.edu), Michael Espy (espymr@goldmail.etsu.edu)
						Charles Fleming (FLEMINGCE@goldmail.etsu.edu), Philip Snider (sniderp@goldmail.etsu.edu)
							Ishan Patel (pateli@goldmail.etsu.edu))
	Created:			Thursday, October 2, 2014

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
using System.Text.RegularExpressions;

namespace GDTS
{
	public partial class AddQuestion : Form
	{
        databaseFunctions df = new databaseFunctions();
        int courseNumber;
        int goalHolder;

		public AddQuestion ( )
		{
			InitializeComponent ( );
		}

		private void AddQuestion_Load (object sender, EventArgs e)
		{
            courseComboBox.Items.Clear();

            List<string> courseInfo = new List<string>();
            //use to poplulate courses now
            courseInfo = df.populateCourses();		//display all the courses to course combobox from bank of course
            for (int i = 0; i < courseInfo.Count; i++)
            {
                courseComboBox.Items.Add(courseInfo[i]);
            }
		}

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            Match m3 = Regex.Match(yearTextBox.Text, @"\d+");
            Match m4 = Regex.Match(teacherTextBox.Text, @"^[a-zA-Z]+$");

            if (semesterTextBox.Text.ToUpper() == "SPRING" || semesterTextBox.Text.ToUpper() == "FALL")
                    {
                        if (m3.Success && yearTextBox.Text.Length == 4)
                        {
                            if (m4.Success)
                            {
                                getGoalId();
                                df.addQuestions(questionTextBox.Text, answerTextBox.Text, goalHolder, semesterTextBox.Text, yearTextBox.Text, teacherTextBox.Text);
                                semesterTextBox.Text = "";
                                yearTextBox.Text = "";
                                teacherTextBox.Text = "";
                                TeacherForm tf = new TeacherForm();
                                tf.Show();
                                this.Hide();
                            }
                            else
                            {
								MessageBox.Show ("The teacher name must only contain letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
							MessageBox.Show ("The year must only be numbers and be 4 numbers long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
						MessageBox.Show ("The semester must only be Spring or Fall.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
        }

        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            getCourseNumber();
            getGoalForQuestion();
        }

        private void objectiveComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void getCourseNumber()
        {
            //split a course text using string array object
            string[] words = courseComboBox.Text.Split(' ');
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
                cmd1.CommandText = "Select * from Goal where Goal_Description ='" + objectiveComboBox.Text + "'";
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
                cmd.CommandText = "Select * from Goal where( Course_Number = " + courseNumber + ")";
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

                for (int i = 0; i < holders.Count() - 1; i++)
                {
                    objectiveComboBox.Items.Add(holders[i]);
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
	}
}