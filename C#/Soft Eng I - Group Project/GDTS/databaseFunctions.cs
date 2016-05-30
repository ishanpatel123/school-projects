/*
	Project:		Project 1 V 2
	File Name:		databaseFunctions.cs
	Description:	Holds the functions that access the database	
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

namespace GDTS
{
    class databaseFunctions
    {
        int courseIdToAddQuestion;			//Store Course ID to add new question
        public int courseIdToGiveQuestion;			//Store Course ID to display a new question
        int courseIdForDeletion;			//Store Course ID to delete it from the database
        int courseNumberToGetQuestion;       //Store Course Number to get question.
        public int testId;
        //int goalIdForQuestion;              //Store Goal ID to select valid question
        string studentIdToRemove;			//Store a student ID to remove from database
        public string studentIdForTest;			//store a student ID to track the student who took the test.
        public int counter;					//hold a number to track how many questions to display at a time
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;		//get the path directory to estiblish connection with database
        public List<int> questionToRandomize = new List<int>();											//holds a random list of questions
        public List<List<int>> questionsToGive = new List<List<int>>();
        public List<int> randomListOfGoals = new List<int>();

        /// <summary>
        /// Used to add course to the database
        /// </summary>
        /// <param name="courseNum">holds the course number</param>
        /// <param name="coursePre">holds the course prefix</param>
        /// <param name="semester">holds the semester of the course</param>
        /// <param name="year">holds the year the course was taught</param>
        /// <param name="teacher">holds the teacher thath taught the course</param>
        public void addCourses(string courseNum, string coursePre)
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            //open a sql connection
            cn.Open();
            // Instantiate command with a query and  sql connection
            SqlCommand exeSql = new SqlCommand("", cn);
            //set a command text with sql connection to database
            exeSql.CommandText = "insert into Course (Course_Number, Course_Prefix) values ('"
                                                + courseNum + "', '" + coursePre + "')";
            //call a ExecuteNonQuery to send command via connection
            exeSql.ExecuteNonQuery();
            //display a message that course is added to database
            MessageBox.Show("Course successfully added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //close a connection with databse
            cn.Close();

        }

        /// <summary>
        /// adds students to database
        /// </summary>
        /// <param name="studentId">holds the students ID</param>
        /// <param name="studentFName">holds the students first name</param>
        /// <param name="studentLName">holds the students last name</param>
        public void addStudents(string studentId, string studentFName, string studentLName, string concentration)
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            //open a sql connection
            cn.Open();
            // Instantiate command with a query and  sql connection
            SqlCommand exeSql = new SqlCommand("", cn);
            //set a command text with sql connection to database
            exeSql.CommandText = "insert into Student (Student_ID, First__Name, Last_Name, Concentration) values ('" + studentId + "', '" + studentFName + "', '" + studentLName + "', '" + concentration + "')";
            //call a ExecuteNonQuery to send command via connection
            exeSql.ExecuteNonQuery();
            //display a message that student is added to database	
            MessageBox.Show("Student successfully added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //close a connection with databse
            cn.Close();

        }

        /// <summary>
        /// adds questions to database
        /// </summary>
        /// <param name="questionText">holds the question</param>
        /// <param name="correctAnswerText">holds the correct answer</param>
        public void addQuestions(string questionText, string correctAnswerText, int goal, string semester, string year, string teacher)
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            //open a sql connection
            cn.Open();
            // Instantiate command with a query and  sql connection
            SqlCommand exeSql = new SqlCommand("", cn);
            //set a command text with sql connection to database
            exeSql.CommandText = "insert into Question (Question, Correct_Answer, Goal_ID, Question_Semester, Question_Year, Question_Teacher) values ('" + questionText + "', '" + correctAnswerText + "'," + goal + ", '" + semester + "','" + year + "','" + teacher + "')";
            //call a ExecuteNonQuery to send command via connection
            exeSql.ExecuteNonQuery();
            //display a message that question is added to database	
            MessageBox.Show("Question successfully added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //close a connection with databse
            cn.Close();

        }

        public void figureStudentIdForTesting(string student)
        {
            //split a student text using string array object
            string[] words = student.Split(' ');
            //create a list of students with string array
            studentIdForTest = words[0];
        }

        public List<string> populateCoursesForTesting()
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            string concentration = "";

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
                //set a command text with sql connection for course
                cmd.CommandText = "Select * from Student where Student_ID = '" + studentIdForTest + "'";
                //open a connection
                cn.Open();
                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader.HasRows == true)
                {
                    //display all course table values from course table
                    while (dReader.Read())
                    {
                        string comboBoxInfo = dReader["Concentration"].ToString();
                        //If the any course values are selected, it will added to comboboxes
                        concentration = comboBoxInfo;
                    }
                }
                else
                {
                    //If there is no display, display error message
                    MessageBox.Show("Data not found");
                }
                //close the reader 
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

            List<string> courseInfo = new List<string>();
            List<int> listOfCourses = new List<int>();

            if (concentration.ToLower() == "acs")
            {
                listOfCourses.Add(5200);
                listOfCourses.Add(5230);
                listOfCourses.Add(5300);
                listOfCourses.Add(5150);
                listOfCourses.Add(5250);
                listOfCourses.Add(5220);
                listOfCourses.Add(5460);
            }
            else
            {
                listOfCourses.Add(5200);
                listOfCourses.Add(5230);
                listOfCourses.Add(5300);
                listOfCourses.Add(5710);
                listOfCourses.Add(5720);
                listOfCourses.Add(5730);
                listOfCourses.Add(5800);
            }
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
                //set a command text with sql connection for course
                cmd.CommandText = "Select * from Course where Course_Number in ( " + listOfCourses[0] + " , " + listOfCourses[1] + " , " + listOfCourses[2] + " , " + listOfCourses[3] + " , " + listOfCourses[4] + " , " + listOfCourses[5] + " , " + listOfCourses[6] + " ) ";
                //open a connection
                cn.Open();
                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader.HasRows == true)
                {
                    //display all course table values from course table
                    while (dReader.Read())
                    {
                        string comboBoxInfo = dReader["Course_Prefix"].ToString() + dReader["Course_Number"].ToString() + dReader["Course_Semester"].ToString() + dReader["Course_Year"].ToString();
                        //If the any course values are selected, it will added to comboboxes
                        courseInfo.Add(comboBoxInfo);
                    }
                }
                else
                {
                    //If there is no display, display error message
                    MessageBox.Show("Data not found");
                }
                //close the reader 
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

            return courseInfo;
        }
        /// <summary>
        /// populates courses when needed
        /// </summary>
        /// <returns></returns>
        public List<string> populateCourses()
        {

            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            List<string> courseInfo = new List<string>();

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
                //set a command text with sql connection for course
                cmd.CommandText = "Select * from Course";
                //open a connection
                cn.Open();
                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader.HasRows == true)
                {
                    //display all course table values from course table
                    while (dReader.Read())
                    {
                        string comboBoxInfo = dReader["Course_Prefix"].ToString() + dReader["Course_Number"].ToString() + dReader["Course_Semester"].ToString() + dReader["Course_Year"].ToString();
                        //If the any course values are selected, it will added to comboboxes
                        courseInfo.Add(comboBoxInfo);
                    }
                }
                else
                {
                    //If there is no display, display error message
                    MessageBox.Show("Data not found");
                }
                //close the reader 
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

            return courseInfo;
        }

        /// <summary>
        /// Used to populate the user combo boxes by returning a list of user names 
        /// </summary>
        /// <returns></returns>
        public List<string> populateUsers()
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            List<string> userInfo = new List<string>();

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
                //set a command text with sql connection for course
                cmd.CommandText = "Select * from Idiots";
                //open a connection
                cn.Open();
                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader.HasRows == true)
                {
                    //display all course table values from course table
                    while (dReader.Read())
                    {
                        string comboBoxInfo = dReader["User_Name"].ToString().Trim();
                        //If the any course values are selected, it will added to comboboxes
                        userInfo.Add(comboBoxInfo);
                    }
                }
                else
                {
                    //If there is no display, display error message
                    MessageBox.Show("Data not found");
                }

                //close the reader 
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


            SqlConnection cn1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");

            try
            {
                //reading data from database via SqlDataReader object
                SqlDataReader dReader1;
                // Instantiate command with a query and  sql connection
                SqlCommand cmd1 = new SqlCommand();
                //Set the Connection property with command
                cmd1.Connection = cn1;
                //Set a commandtype property with  command text
                cmd1.CommandType = CommandType.Text;
                //set a command text with sql connection for course
                cmd1.CommandText = "Select * from Idiots";
                //open a connection
                cn1.Open();
                //Call Execute reader to get query results
                dReader1 = cmd1.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader1.HasRows == true)
                {
                    //display all course table values from course table
                    while (dReader1.Read())
                    {
                        int type = int.Parse(dReader1["Type"].ToString());
                        string uName = dReader1["User_Name"].ToString();
                        //If the any course values are selected, it will added to comboboxes

                        if (type == 0)
                        {
                            userInfo.Remove(uName.Trim());
                        }

                    }
                }
                else
                {
                    //If there is no display, display error message
                    MessageBox.Show("Data not found");
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
                cn1.Close();
            }

            return userInfo;
        }

        /// <summary>
        /// Populates the students in student combo boxes.
        /// </summary>
        public List<string> populateStudents()
        {

            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            List<string> studentInfo = new List<string>();


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
                //set a command text with sql connection for student
                cmd.CommandText = "Select * from Student order by Last_Name";
                //open a connection
                cn.Open();
                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader.HasRows == true)
                {
                    //display all student table values from student table
                    while (dReader.Read())
                    {
                        string comboBoxInfo = dReader["Student_ID"].ToString() + " " + dReader["Last_Name"].ToString() + ", " + dReader["First__Name"].ToString();
                        //If the any student values are selected, it will added to comboboxes
                        studentInfo.Add(comboBoxInfo);
                    }
                }
                else
                {
                    //If not, display an error message
                    MessageBox.Show("Data not found");
                }
                //close the reader
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

            return studentInfo;
        }

        /// <summary>
        /// gets course id from user to display questions
        /// </summary>
        /// <param name="course">holds the course</param>
        public void getCourseIdForQuestion(string course)
        {
            //split a course text using string array object
            string[] words = course.Split(' ');
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
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Select * from Course where( Course_Number = " + queryWords[1] + " and Course_PreFix = '" + queryWords[0] + "' and Course_Semester = '" + queryWords[2] + "' and Course_Year = " + queryWords[3] + ")";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                while (dReader.Read())
                {
                    //display course ids  from course table
                    string holder = dReader["Course_Id"].ToString();
                    //hold a course id to add a question
                    courseIdToAddQuestion = int.Parse(holder);
                    //close the reader
                    dReader.Close();
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

        /// <summary>
        /// gets the course id to display for test
        /// </summary>
        /// <param name="course">holds the courses</param>
        public void getCourseIdForTesting(string course)
        {

            //split a course text using string array object
            string[] words = course.Split(' ');
            //create a list of course with string array words
            List<string> queryWords = words.ToList();

            //queryWords now contains the four words needed to  
            foreach (string word in words)
            {
                //If there is no word in list, it will removed
                if (word == "")
                {
                    queryWords.Remove(word);
                }
            }
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Select * from Course where( Course_Number = " + queryWords[1] + " and Course_PreFix = '" + queryWords[0] + "' and Course_Semester = '" + queryWords[2] + "' and Course_Year = " + queryWords[3] + ")";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                //Ensure that sql data reader can read 
                while (dReader.Read())
                {
                    //display course ids  from course table
                    string holder = dReader["Course_Id"].ToString();
                    string holder1 = dReader["Course_Number"].ToString();
                    //hold a course id to give a question
                    courseIdToGiveQuestion = int.Parse(holder);
                    courseNumberToGetQuestion = int.Parse(holder1);
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

        /// <summary>
        /// gets the course id to display for test
        /// </summary>
        /// <param name="course">holds the courses</param>
        public void getGoalForQuestion()
        {


            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Select * from Goal where( Course_Number = " + courseNumberToGetQuestion + ")";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                List<int> holders = new List<int>();
                //Ensure that sql data reader can read 
                while (dReader.Read())
                {
                    //display course ids  from course table
                    string holder = dReader["Goal_Id"].ToString();
                    holders.Add(int.Parse(holder));
                }

                Random r = new Random();
                //if statement to check to see is empty thus not questions for that course
                while (holders.Count() != 0)
                {
                    //holds a number generated from random object
                    int num = r.Next(0, (holders.Count() - 1));
                    randomListOfGoals.Add(holders[num]);
                    holders.RemoveAt(num);
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

        /// <summary>
        /// gets the students id for deleting
        /// </summary>
        /// <param name="student">holds the student</param>
        public void getStudentIdForDeleting(string student)
        {
            //split a student text using string array object
            string[] words = student.Split(' ');
            //create a list of students with string array
            studentIdToRemove = words[0];
        }

        /// <summary>
        /// figure out what the course id that was picked from so it can be used to delete
        /// </summary>
        /// <param name="course">holds the course</param>
        public void getCourseIdForDeleting(string course)
        {
            //split a course text using string array object
            string[] words = course.Split(' ');
            //create a list of course with string array words
            List<string> queryWords = words.ToList();

            //queryWords now contains the four words needed to  
            foreach (string word in words)
            {
                //If there is no word in list, it will removed
                if (word == "")
                {
                    queryWords.Remove(word);
                }
            }
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Select * from Course where( Course_Number = " + queryWords[1] + " and Course_PreFix = '" + queryWords[0] + "' and Course_Semester = '" + queryWords[2] + "' and Course_Year = " + queryWords[3] + ")";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                //Ensure that sql data reader can read 
                while (dReader.Read())
                {
                    //display course ids  from course table
                    string holder = dReader["Course_Id"].ToString();
                    //hold a course id to give a question
                    courseIdForDeletion = int.Parse(holder);
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
        /// <summary>
        /// generate a list of questions from specific course
        /// </summary>
        public void generateListOfQuestions()
        {
            int count = 0;
            while (count != randomListOfGoals.Count())
            {
                //Enable the sql connection with local database
                SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                    //set a command text with sql connection for a question based on course id
                    cmd.CommandText = "Select * from Question where Goal_ID = " + randomListOfGoals[count];
                    //open a connection
                    cn.Open();

                    //Call Execute reader to get query results
                    dReader = cmd.ExecuteReader();
                    //Ensure that sql data reader can read 
                    while (dReader.Read())
                    {
                        //hold question id from course table
                        int holder = int.Parse(dReader["Question_ID"].ToString());
                        //add question to a list of questions
                        questionToRandomize.Add(holder);
                    }
                    Random r = new Random();
                    List<int> randomQuestions = new List<int>();
                    //if statement to check to see is empty thus not questions for that course
                    while (questionToRandomize.Count() != 0)
                    {
                        //holds a number generated from random object
                        int num = r.Next(0, (questionToRandomize.Count() - 1));

                        randomQuestions.Add(questionToRandomize[num]);
                        questionToRandomize.RemoveAt(num);
                    }

                    questionsToGive.Add(randomQuestions);
                }
                catch (Exception)
                {
                    //display if there are any errors are occured 

                }
                finally
                {
                    //close a connection
                    cn.Close();
                }
                count++;
            }
        }

        public void createTest()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            //open a sql connection
            cn.Open();
            // Instantiate command with a query and  sql connection
            SqlCommand exeSql = new SqlCommand("", cn);
            //set a command text with sql connection to database
            exeSql.CommandText = "insert into Test (Student_Id) output inserted.Test_Id values ('" + studentIdForTest + "')";
            //call a ExecuteNonQuery to send command via connection
            try
            {
                testId = int.Parse(exeSql.ExecuteScalar().ToString());
            }
            catch (Exception)
            {

            } //close a connection with databse
            cn.Close();
        }

        /// <summary>
        /// Used to remove a student from the database
        /// </summary>
        public void removeStudent()
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Delete from Student where Student_ID = '" + studentIdToRemove + "'";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                MessageBox.Show("Student removed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        /// <summary>
        /// Used to access the database and remove a user when called
        /// </summary>
        /// <param name="uName">holds the users username</param>
        public void removeUser(string uName)
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Delete from Idiots where User_Name = '" + uName + "'";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                MessageBox.Show("User removed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dReader.Close();

            }
            catch (Exception)
            {
                //display if there are any errors are occured
            }

        }

        /// <summary>
        /// removes a course from the database
        /// </summary>
        public void removeCourse()
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Delete from Course where Course_Id = " + courseIdForDeletion + "";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                MessageBox.Show("Course removed successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        /// <summary>
        /// Checks to see if what the user inputs are valid credentials or not
        /// </summary>
        /// <param name="uName">holds the users username</param>
        /// <param name="password">holds the users password</param>
        /// <returns></returns>
        public bool loginCheck(string uName, string password)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            string pword = "";		//used to hold the password returned from the database

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
                cmd.CommandText = "Select * from Idiots where User_Name = '" + uName.Trim() + "'";				//open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader.Read())
                {
                    pword = dReader["Password"].ToString();
                }
                else
                {
                    return false;
                }
                pword.Trim();			//trim any white space
                password.Trim();		//trim any white space

                //for loop to check and see if the password stored in the database
                //and the password the user entered are the same or not
                for (int i = 0; i < pword.Count(); i++)
                {
                    if (pword[i] != password[i])
                    {
                        return false;
                    }
                }

                dReader.Close();

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }

            return true;
        }

        /// <summary>
        /// Used to get the type of instructor from the data base.
        /// </summary>
        /// <param name="uName">holds the users username</param>
        /// <returns></returns>
        public int getType(string uName)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            int type = 3;
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
                cmd.CommandText = "Select * from Idiots where User_Name = '" + uName.Trim() + "'";				//open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();
                //Ensure that sql data reader can read 
                if (dReader.Read())
                {
                    type = int.Parse(dReader["Type"].ToString());
                }
                dReader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                cn.Close();
            }

            return type;
        }

        /// <summary>
        /// adds a user to the database
        /// </summary>
        /// <param name="uName">holds the users username</param>
        /// <param name="password">holds the users password</param>
        /// <param name="type">holds the type of user number</param>
        public void addUser(string uName, string password, int type)
        {
            try
            {
                //Enable the sql connection with local database
                SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
                //open a sql connection
                cn.Open();
                // Instantiate command with a query and  sql connection
                SqlCommand exeSql = new SqlCommand("", cn);
                //set a command text with sql connection to database
                exeSql.CommandText = "insert into Idiots (User_Name, Password, Type) values ('" + uName + "', '" + password + "', " + type + ")";
                //call a ExecuteNonQuery to send command via connection
                exeSql.ExecuteNonQuery();
                //display a message that student is added to database	
                MessageBox.Show("User successfully added!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //close a connection with databse
                cn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Either tried to input invalid data or user already exists.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Used to check and see if a users has been previously logged in or not.
        /// </summary>
        /// <param name="uName">holds the users username</param>
        /// <returns></returns>
        public int checkLoginCounter(string uName)
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
            int counter = 0;

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
                cmd.CommandText = "Select * from Idiots where User_Name = '" + uName + "'";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                if (dReader.Read())
                {
                    counter = int.Parse(dReader["Login_Count"].ToString());
                }
                //Ensure that sql data reader can read 
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

            return counter;
        }

        /// <summary>
        /// used to update the current users information
        /// </summary>
        /// <param name="uName">holds the users username</param>
        /// <param name="fName">holds the users first name</param>
        /// <param name="lName">holds the users last name</param>
        /// <param name="cRank">holds the users classroom rank</param>
        /// <param name="gRank">holds the users gradaution rank</param>
        /// <param name="dept">holds the users department</param>
        public void updateUser(string uName, string fName, string lName, string cRank, string gRank)
        {
            //Enable the sql connection with local database
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\GDTSDatabase.mdf;Integrated Security=True");
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
                cmd.CommandText = "Update Idiots set Login_Count = 1, First_Name = '" + fName + "', Last_Name = '" + lName + "', Classroom_Rank = '" + cRank + "', Graduate_Rank = '" + gRank + "' where User_Name = '" + uName + "'";
                //open a connection
                cn.Open();

                //Call Execute reader to get query results
                dReader = cmd.ExecuteReader();

                //Ensure that sql data reader can read 
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

		public void scorePerQuestion() 
		{ 
			
		}		
    }
}
