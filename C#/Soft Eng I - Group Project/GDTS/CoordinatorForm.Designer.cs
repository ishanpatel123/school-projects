namespace GDTS
{
	partial class CoordinatorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ( );
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.administerTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.administerTestPanel = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.chooseStudentComboBox = new System.Windows.Forms.ComboBox();
			this.chooseCourseComboBox = new System.Windows.Forms.ComboBox();
			this.administerTestCorrectAnswer = new System.Windows.Forms.Label();
			this.administerTestQuestion = new System.Windows.Forms.Label();
			this.administerTestNextButton = new System.Windows.Forms.Button();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label21 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.addStudentPanel = new System.Windows.Forms.Panel();
			this.concentrationComboBox = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.addStudentButton = new System.Windows.Forms.Button();
			this.addLastNameTextBox = new System.Windows.Forms.TextBox();
			this.addFirstNameTextBox = new System.Windows.Forms.TextBox();
			this.addStudentIDTextBox = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.removeStudentPanel = new System.Windows.Forms.Panel();
			this.removeStudentButton = new System.Windows.Forms.Button();
			this.removeStudentComboBox = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.logoutLink = new System.Windows.Forms.LinkLabel();
			this.menuStrip1.SuspendLayout();
			this.administerTestPanel.SuspendLayout();
			this.addStudentPanel.SuspendLayout();
			this.removeStudentPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.studentToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(497, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administerTestToolStripMenuItem});
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.testToolStripMenuItem.Text = "Test";
			// 
			// administerTestToolStripMenuItem
			// 
			this.administerTestToolStripMenuItem.Name = "administerTestToolStripMenuItem";
			this.administerTestToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
			this.administerTestToolStripMenuItem.Text = "Administer Test";
			this.administerTestToolStripMenuItem.Click += new System.EventHandler(this.administerTestToolStripMenuItem_Click);
			// 
			// studentToolStripMenuItem
			// 
			this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
			this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
			this.studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.studentToolStripMenuItem.Text = "Student";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
			// 
			// administerTestPanel
			// 
			this.administerTestPanel.Controls.Add(this.label4);
			this.administerTestPanel.Controls.Add(this.label2);
			this.administerTestPanel.Controls.Add(this.label1);
			this.administerTestPanel.Controls.Add(this.chooseStudentComboBox);
			this.administerTestPanel.Controls.Add(this.chooseCourseComboBox);
			this.administerTestPanel.Controls.Add(this.administerTestCorrectAnswer);
			this.administerTestPanel.Controls.Add(this.administerTestQuestion);
			this.administerTestPanel.Controls.Add(this.administerTestNextButton);
			this.administerTestPanel.Controls.Add(this.radioButton5);
			this.administerTestPanel.Controls.Add(this.radioButton4);
			this.administerTestPanel.Controls.Add(this.radioButton3);
			this.administerTestPanel.Controls.Add(this.radioButton2);
			this.administerTestPanel.Controls.Add(this.radioButton1);
			this.administerTestPanel.Controls.Add(this.label21);
			this.administerTestPanel.Controls.Add(this.label3);
			this.administerTestPanel.Location = new System.Drawing.Point(12, 30);
			this.administerTestPanel.Name = "administerTestPanel";
			this.administerTestPanel.Size = new System.Drawing.Size(473, 311);
			this.administerTestPanel.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(265, 272);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 13);
			this.label4.TabIndex = 28;
			this.label4.Text = "Correct (T)";
			this.label4.Visible = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(172, 272);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Average";
			this.label2.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(61, 272);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 26;
			this.label1.Text = "Wrong (F)";
			this.label1.Visible = false;
			// 
			// chooseStudentComboBox
			// 
			this.chooseStudentComboBox.FormattingEnabled = true;
			this.chooseStudentComboBox.Location = new System.Drawing.Point(27, 13);
			this.chooseStudentComboBox.Name = "chooseStudentComboBox";
			this.chooseStudentComboBox.Size = new System.Drawing.Size(179, 21);
			this.chooseStudentComboBox.TabIndex = 25;
			this.chooseStudentComboBox.Text = "Choose student...";
			this.chooseStudentComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseStudentComboBox_SelectedIndexChanged);
			// 
			// chooseCourseComboBox
			// 
			this.chooseCourseComboBox.FormattingEnabled = true;
			this.chooseCourseComboBox.Location = new System.Drawing.Point(280, 13);
			this.chooseCourseComboBox.Name = "chooseCourseComboBox";
			this.chooseCourseComboBox.Size = new System.Drawing.Size(178, 21);
			this.chooseCourseComboBox.TabIndex = 24;
			this.chooseCourseComboBox.Text = "Choose course...";
			this.chooseCourseComboBox.Visible = false;
			this.chooseCourseComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseCourseComboBox_SelectedIndexChanged);
			// 
			// administerTestCorrectAnswer
			// 
			this.administerTestCorrectAnswer.Location = new System.Drawing.Point(100, 166);
			this.administerTestCorrectAnswer.Name = "administerTestCorrectAnswer";
			this.administerTestCorrectAnswer.Size = new System.Drawing.Size(362, 65);
			this.administerTestCorrectAnswer.TabIndex = 23;
			this.administerTestCorrectAnswer.Text = "Correct Answer";
			this.administerTestCorrectAnswer.Visible = false;
			this.administerTestCorrectAnswer.Click += new System.EventHandler(this.administerTestCorrectAnswer_Click);
			// 
			// administerTestQuestion
			// 
			this.administerTestQuestion.Location = new System.Drawing.Point(100, 69);
			this.administerTestQuestion.Name = "administerTestQuestion";
			this.administerTestQuestion.Size = new System.Drawing.Size(362, 80);
			this.administerTestQuestion.TabIndex = 22;
			this.administerTestQuestion.Text = "Question";
			this.administerTestQuestion.Visible = false;
			this.administerTestQuestion.Click += new System.EventHandler(this.administerTestQuestion_Click);
			// 
			// administerTestNextButton
			// 
			this.administerTestNextButton.Location = new System.Drawing.Point(353, 245);
			this.administerTestNextButton.Name = "administerTestNextButton";
			this.administerTestNextButton.Size = new System.Drawing.Size(75, 23);
			this.administerTestNextButton.TabIndex = 21;
			this.administerTestNextButton.Text = "Next";
			this.administerTestNextButton.UseVisualStyleBackColor = true;
			this.administerTestNextButton.Visible = false;
			this.administerTestNextButton.Click += new System.EventHandler(this.administerTestNextButton_Click);
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(282, 248);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(31, 17);
			this.radioButton5.TabIndex = 20;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "5";
			this.radioButton5.UseVisualStyleBackColor = true;
			this.radioButton5.Visible = false;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(230, 248);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(31, 17);
			this.radioButton4.TabIndex = 19;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "4";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.Visible = false;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(175, 248);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(31, 17);
			this.radioButton3.TabIndex = 18;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "3";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.Visible = false;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(126, 248);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(31, 17);
			this.radioButton2.TabIndex = 17;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "2";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.Visible = false;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(73, 248);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(31, 17);
			this.radioButton1.TabIndex = 16;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "1";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.Visible = false;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(9, 166);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(85, 13);
			this.label21.TabIndex = 15;
			this.label21.Text = "Correct Answer: ";
			this.label21.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(39, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Question: ";
			this.label3.Visible = false;
			// 
			// addStudentPanel
			// 
			this.addStudentPanel.Controls.Add(this.concentrationComboBox);
			this.addStudentPanel.Controls.Add(this.label9);
			this.addStudentPanel.Controls.Add(this.label6);
			this.addStudentPanel.Controls.Add(this.addStudentButton);
			this.addStudentPanel.Controls.Add(this.addLastNameTextBox);
			this.addStudentPanel.Controls.Add(this.addFirstNameTextBox);
			this.addStudentPanel.Controls.Add(this.addStudentIDTextBox);
			this.addStudentPanel.Controls.Add(this.label10);
			this.addStudentPanel.Controls.Add(this.label8);
			this.addStudentPanel.Controls.Add(this.label5);
			this.addStudentPanel.Location = new System.Drawing.Point(6, 30);
			this.addStudentPanel.Name = "addStudentPanel";
			this.addStudentPanel.Size = new System.Drawing.Size(243, 179);
			this.addStudentPanel.TabIndex = 29;
			this.addStudentPanel.Visible = false;
			// 
			// concentrationComboBox
			// 
			this.concentrationComboBox.FormattingEnabled = true;
			this.concentrationComboBox.Items.AddRange(new object[] {
            "ACS",
            "IT"});
			this.concentrationComboBox.Location = new System.Drawing.Point(101, 97);
			this.concentrationComboBox.Name = "concentrationComboBox";
			this.concentrationComboBox.Size = new System.Drawing.Size(121, 21);
			this.concentrationComboBox.TabIndex = 29;
			this.concentrationComboBox.Text = "Pick Concentration...";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(15, 100);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(76, 13);
			this.label9.TabIndex = 15;
			this.label9.Text = "Concentration:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(55, 3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(141, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Add a student to the system.";
			// 
			// addStudentButton
			// 
			this.addStudentButton.Location = new System.Drawing.Point(88, 128);
			this.addStudentButton.Name = "addStudentButton";
			this.addStudentButton.Size = new System.Drawing.Size(69, 35);
			this.addStudentButton.TabIndex = 13;
			this.addStudentButton.Text = "Add Student";
			this.addStudentButton.UseVisualStyleBackColor = true;
			this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
			// 
			// addLastNameTextBox
			// 
			this.addLastNameTextBox.Location = new System.Drawing.Point(101, 70);
			this.addLastNameTextBox.Name = "addLastNameTextBox";
			this.addLastNameTextBox.Size = new System.Drawing.Size(118, 20);
			this.addLastNameTextBox.TabIndex = 12;
			// 
			// addFirstNameTextBox
			// 
			this.addFirstNameTextBox.Location = new System.Drawing.Point(101, 44);
			this.addFirstNameTextBox.Name = "addFirstNameTextBox";
			this.addFirstNameTextBox.Size = new System.Drawing.Size(118, 20);
			this.addFirstNameTextBox.TabIndex = 11;
			// 
			// addStudentIDTextBox
			// 
			this.addStudentIDTextBox.Location = new System.Drawing.Point(101, 18);
			this.addStudentIDTextBox.Name = "addStudentIDTextBox";
			this.addStudentIDTextBox.Size = new System.Drawing.Size(118, 20);
			this.addStudentIDTextBox.TabIndex = 10;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 73);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "Last Name: ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 47);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "First Name: ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Student ID:     E";
			// 
			// removeStudentPanel
			// 
			this.removeStudentPanel.Controls.Add(this.removeStudentButton);
			this.removeStudentPanel.Controls.Add(this.removeStudentComboBox);
			this.removeStudentPanel.Controls.Add(this.label7);
			this.removeStudentPanel.Location = new System.Drawing.Point(9, 33);
			this.removeStudentPanel.Name = "removeStudentPanel";
			this.removeStudentPanel.Size = new System.Drawing.Size(243, 160);
			this.removeStudentPanel.TabIndex = 15;
			this.removeStudentPanel.Visible = false;
			// 
			// removeStudentButton
			// 
			this.removeStudentButton.Location = new System.Drawing.Point(163, 96);
			this.removeStudentButton.Name = "removeStudentButton";
			this.removeStudentButton.Size = new System.Drawing.Size(67, 33);
			this.removeStudentButton.TabIndex = 2;
			this.removeStudentButton.Text = "Remove";
			this.removeStudentButton.UseVisualStyleBackColor = true;
			this.removeStudentButton.Click += new System.EventHandler(this.removeStudentButton_Click);
			// 
			// removeStudentComboBox
			// 
			this.removeStudentComboBox.FormattingEnabled = true;
			this.removeStudentComboBox.Location = new System.Drawing.Point(15, 67);
			this.removeStudentComboBox.Name = "removeStudentComboBox";
			this.removeStudentComboBox.Size = new System.Drawing.Size(135, 21);
			this.removeStudentComboBox.TabIndex = 1;
			this.removeStudentComboBox.Text = "Select a student...";
			this.removeStudentComboBox.SelectedIndexChanged += new System.EventHandler(this.removeStudentComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(209, 44);
			this.label7.TabIndex = 0;
			this.label7.Text = "Choose a student from the drop down box to remove them from the system.";
			// 
			// logoutLink
			// 
			this.logoutLink.AutoSize = true;
			this.logoutLink.Location = new System.Drawing.Point(199, 7);
			this.logoutLink.Name = "logoutLink";
			this.logoutLink.Size = new System.Drawing.Size(40, 13);
			this.logoutLink.TabIndex = 30;
			this.logoutLink.TabStop = true;
			this.logoutLink.Text = "Logout";
			this.logoutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLink_LinkClicked_1);
			// 
			// CoordinatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(497, 351);
			this.Controls.Add(this.logoutLink);
			this.Controls.Add(this.addStudentPanel);
			this.Controls.Add(this.administerTestPanel);
			this.Controls.Add(this.removeStudentPanel);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "CoordinatorForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Coordinator Form";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CoordinatorForm_FormClosing);
			this.Load += new System.EventHandler(this.CoordinatorForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.administerTestPanel.ResumeLayout(false);
			this.administerTestPanel.PerformLayout();
			this.addStudentPanel.ResumeLayout(false);
			this.addStudentPanel.PerformLayout();
			this.removeStudentPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem administerTestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.Panel administerTestPanel;
		private System.Windows.Forms.Label administerTestCorrectAnswer;
		private System.Windows.Forms.Label administerTestQuestion;
		private System.Windows.Forms.Button administerTestNextButton;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox chooseStudentComboBox;
		private System.Windows.Forms.ComboBox chooseCourseComboBox;
		private System.Windows.Forms.Panel addStudentPanel;
		private System.Windows.Forms.Button addStudentButton;
		private System.Windows.Forms.TextBox addLastNameTextBox;
		private System.Windows.Forms.TextBox addFirstNameTextBox;
		private System.Windows.Forms.TextBox addStudentIDTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel removeStudentPanel;
		private System.Windows.Forms.Button removeStudentButton;
		private System.Windows.Forms.ComboBox removeStudentComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.LinkLabel logoutLink;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox concentrationComboBox;
	}
}