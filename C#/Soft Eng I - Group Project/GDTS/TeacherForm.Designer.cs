namespace GDTS
{
	partial class TeacherForm
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
			this.questionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.metricsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.studentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.questionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.addQuestionPanel = new System.Windows.Forms.Panel();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.removeQuestionButton = new System.Windows.Forms.Button();
			this.chooseObjectiveComboBox = new System.Windows.Forms.ComboBox();
			this.chooseCourseComboBoxAddQuestion = new System.Windows.Forms.ComboBox();
			this.addQuestionToBankButton = new System.Windows.Forms.Button();
			this.addStudentPanel = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.concentrationComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
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
			this.matrixStudentPanel = new System.Windows.Forms.Panel();
			this.totalStudentPerExamButton = new System.Windows.Forms.Button();
			this.groupStudentTextbox = new System.Windows.Forms.TextBox();
			this.studentsPerExamConcentrationButton = new System.Windows.Forms.Button();
			this.averageScorePerCourseButton = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.addQuestionPanel.SuspendLayout();
			this.addStudentPanel.SuspendLayout();
			this.removeStudentPanel.SuspendLayout();
			this.matrixStudentPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.questionToolStripMenuItem,
            this.studentToolStripMenuItem,
            this.metricsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(497, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// questionToolStripMenuItem
			// 
			this.questionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
			this.questionToolStripMenuItem.Name = "questionToolStripMenuItem";
			this.questionToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.questionToolStripMenuItem.Text = "Question";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.viewToolStripMenuItem.Text = "View";
			this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
			// 
			// studentToolStripMenuItem
			// 
			this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.removeToolStripMenuItem1});
			this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
			this.studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.studentToolStripMenuItem.Text = "Student";
			// 
			// addToolStripMenuItem1
			// 
			this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
			this.addToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
			this.addToolStripMenuItem1.Text = "Add";
			this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
			// 
			// removeToolStripMenuItem1
			// 
			this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
			this.removeToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
			this.removeToolStripMenuItem1.Text = "Remove";
			this.removeToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem1_Click);
			// 
			// metricsToolStripMenuItem
			// 
			this.metricsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentToolStripMenuItem1,
            this.questionToolStripMenuItem1});
			this.metricsToolStripMenuItem.Name = "metricsToolStripMenuItem";
			this.metricsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.metricsToolStripMenuItem.Text = "Metrics";
			// 
			// studentToolStripMenuItem1
			// 
			this.studentToolStripMenuItem1.Name = "studentToolStripMenuItem1";
			this.studentToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.studentToolStripMenuItem1.Text = "Group of Student";
			this.studentToolStripMenuItem1.Click += new System.EventHandler(this.studentToolStripMenuItem1_Click);
			// 
			// questionToolStripMenuItem1
			// 
			this.questionToolStripMenuItem1.Name = "questionToolStripMenuItem1";
			this.questionToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.questionToolStripMenuItem1.Text = "Student";
			this.questionToolStripMenuItem1.Click += new System.EventHandler(this.questionToolStripMenuItem1_Click);
			// 
			// addQuestionPanel
			// 
			this.addQuestionPanel.Controls.Add(this.checkedListBox1);
			this.addQuestionPanel.Controls.Add(this.removeQuestionButton);
			this.addQuestionPanel.Controls.Add(this.chooseObjectiveComboBox);
			this.addQuestionPanel.Controls.Add(this.chooseCourseComboBoxAddQuestion);
			this.addQuestionPanel.Controls.Add(this.addQuestionToBankButton);
			this.addQuestionPanel.Location = new System.Drawing.Point(15, 27);
			this.addQuestionPanel.Name = "addQuestionPanel";
			this.addQuestionPanel.Size = new System.Drawing.Size(473, 312);
			this.addQuestionPanel.TabIndex = 1;
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(15, 73);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.ScrollAlwaysVisible = true;
			this.checkedListBox1.Size = new System.Drawing.Size(436, 184);
			this.checkedListBox1.TabIndex = 22;
			this.checkedListBox1.Visible = false;
			this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
			// 
			// removeQuestionButton
			// 
			this.removeQuestionButton.Location = new System.Drawing.Point(244, 271);
			this.removeQuestionButton.Name = "removeQuestionButton";
			this.removeQuestionButton.Size = new System.Drawing.Size(207, 23);
			this.removeQuestionButton.TabIndex = 21;
			this.removeQuestionButton.Text = "Remove Question";
			this.removeQuestionButton.UseVisualStyleBackColor = true;
			this.removeQuestionButton.Click += new System.EventHandler(this.removeQuestionButton_Click);
			// 
			// chooseObjectiveComboBox
			// 
			this.chooseObjectiveComboBox.FormattingEnabled = true;
			this.chooseObjectiveComboBox.Location = new System.Drawing.Point(15, 42);
			this.chooseObjectiveComboBox.MaxDropDownItems = 20;
			this.chooseObjectiveComboBox.Name = "chooseObjectiveComboBox";
			this.chooseObjectiveComboBox.Size = new System.Drawing.Size(436, 21);
			this.chooseObjectiveComboBox.TabIndex = 20;
			this.chooseObjectiveComboBox.Visible = false;
			this.chooseObjectiveComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseObjectiveComboBox_SelectedIndexChanged);
			// 
			// chooseCourseComboBoxAddQuestion
			// 
			this.chooseCourseComboBoxAddQuestion.FormattingEnabled = true;
			this.chooseCourseComboBoxAddQuestion.Location = new System.Drawing.Point(127, 15);
			this.chooseCourseComboBoxAddQuestion.Name = "chooseCourseComboBoxAddQuestion";
			this.chooseCourseComboBoxAddQuestion.Size = new System.Drawing.Size(202, 21);
			this.chooseCourseComboBoxAddQuestion.TabIndex = 18;
			this.chooseCourseComboBoxAddQuestion.Text = "Choose a course...";
			this.chooseCourseComboBoxAddQuestion.SelectedIndexChanged += new System.EventHandler(this.chooseCourseComboBoxAddQuestion_SelectedIndexChanged);
			// 
			// addQuestionToBankButton
			// 
			this.addQuestionToBankButton.Location = new System.Drawing.Point(15, 271);
			this.addQuestionToBankButton.Name = "addQuestionToBankButton";
			this.addQuestionToBankButton.Size = new System.Drawing.Size(202, 23);
			this.addQuestionToBankButton.TabIndex = 17;
			this.addQuestionToBankButton.Text = "Add Question";
			this.addQuestionToBankButton.UseVisualStyleBackColor = true;
			this.addQuestionToBankButton.Click += new System.EventHandler(this.addQuestionToBankButton_Click);
			// 
			// addStudentPanel
			// 
			this.addStudentPanel.Controls.Add(this.label9);
			this.addStudentPanel.Controls.Add(this.concentrationComboBox);
			this.addStudentPanel.Controls.Add(this.label1);
			this.addStudentPanel.Controls.Add(this.addStudentButton);
			this.addStudentPanel.Controls.Add(this.addLastNameTextBox);
			this.addStudentPanel.Controls.Add(this.addFirstNameTextBox);
			this.addStudentPanel.Controls.Add(this.addStudentIDTextBox);
			this.addStudentPanel.Controls.Add(this.label10);
			this.addStudentPanel.Controls.Add(this.label8);
			this.addStudentPanel.Controls.Add(this.label5);
			this.addStudentPanel.Location = new System.Drawing.Point(3, 42);
			this.addStudentPanel.Name = "addStudentPanel";
			this.addStudentPanel.Size = new System.Drawing.Size(226, 170);
			this.addStudentPanel.TabIndex = 0;
			this.addStudentPanel.Visible = false;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 98);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(76, 13);
			this.label9.TabIndex = 31;
			this.label9.Text = "Concentration:";
			// 
			// concentrationComboBox
			// 
			this.concentrationComboBox.FormattingEnabled = true;
			this.concentrationComboBox.Items.AddRange(new object[] {
            "ACS",
            "IT"});
			this.concentrationComboBox.Location = new System.Drawing.Point(98, 95);
			this.concentrationComboBox.Name = "concentrationComboBox";
			this.concentrationComboBox.Size = new System.Drawing.Size(121, 21);
			this.concentrationComboBox.TabIndex = 30;
			this.concentrationComboBox.Text = "Pick Concentration...";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(44, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 13);
			this.label1.TabIndex = 22;
			this.label1.Text = "Add a student to the system.";
			// 
			// addStudentButton
			// 
			this.addStudentButton.Location = new System.Drawing.Point(77, 124);
			this.addStudentButton.Name = "addStudentButton";
			this.addStudentButton.Size = new System.Drawing.Size(69, 35);
			this.addStudentButton.TabIndex = 21;
			this.addStudentButton.Text = "Add Student";
			this.addStudentButton.UseVisualStyleBackColor = true;
			this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
			// 
			// addLastNameTextBox
			// 
			this.addLastNameTextBox.Location = new System.Drawing.Point(98, 69);
			this.addLastNameTextBox.Name = "addLastNameTextBox";
			this.addLastNameTextBox.Size = new System.Drawing.Size(118, 20);
			this.addLastNameTextBox.TabIndex = 20;
			// 
			// addFirstNameTextBox
			// 
			this.addFirstNameTextBox.Location = new System.Drawing.Point(98, 43);
			this.addFirstNameTextBox.Name = "addFirstNameTextBox";
			this.addFirstNameTextBox.Size = new System.Drawing.Size(118, 20);
			this.addFirstNameTextBox.TabIndex = 19;
			// 
			// addStudentIDTextBox
			// 
			this.addStudentIDTextBox.Location = new System.Drawing.Point(98, 17);
			this.addStudentIDTextBox.Name = "addStudentIDTextBox";
			this.addStudentIDTextBox.Size = new System.Drawing.Size(118, 20);
			this.addStudentIDTextBox.TabIndex = 18;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(14, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "Last Name: ";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(14, 46);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "First Name: ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Student ID:     E";
			// 
			// removeStudentPanel
			// 
			this.removeStudentPanel.Controls.Add(this.removeStudentButton);
			this.removeStudentPanel.Controls.Add(this.removeStudentComboBox);
			this.removeStudentPanel.Controls.Add(this.label7);
			this.removeStudentPanel.Location = new System.Drawing.Point(0, 50);
			this.removeStudentPanel.Name = "removeStudentPanel";
			this.removeStudentPanel.Size = new System.Drawing.Size(239, 181);
			this.removeStudentPanel.TabIndex = 2;
			this.removeStudentPanel.Visible = false;
			// 
			// removeStudentButton
			// 
			this.removeStudentButton.Location = new System.Drawing.Point(161, 101);
			this.removeStudentButton.Name = "removeStudentButton";
			this.removeStudentButton.Size = new System.Drawing.Size(67, 33);
			this.removeStudentButton.TabIndex = 5;
			this.removeStudentButton.Text = "Remove";
			this.removeStudentButton.UseVisualStyleBackColor = true;
			this.removeStudentButton.Click += new System.EventHandler(this.removeStudentButton_Click);
			// 
			// removeStudentComboBox
			// 
			this.removeStudentComboBox.FormattingEnabled = true;
			this.removeStudentComboBox.Location = new System.Drawing.Point(15, 85);
			this.removeStudentComboBox.Name = "removeStudentComboBox";
			this.removeStudentComboBox.Size = new System.Drawing.Size(135, 21);
			this.removeStudentComboBox.TabIndex = 4;
			this.removeStudentComboBox.Text = "Select a student...";
			this.removeStudentComboBox.SelectedIndexChanged += new System.EventHandler(this.removeStudentComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 28);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(209, 44);
			this.label7.TabIndex = 3;
			this.label7.Text = "Choose a student from the drop down box to remove them from the system.";
			// 
			// logoutLink
			// 
			this.logoutLink.AutoSize = true;
			this.logoutLink.Location = new System.Drawing.Point(189, 7);
			this.logoutLink.Name = "logoutLink";
			this.logoutLink.Size = new System.Drawing.Size(40, 13);
			this.logoutLink.TabIndex = 20;
			this.logoutLink.TabStop = true;
			this.logoutLink.Text = "Logout";
			this.logoutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLink_LinkClicked);
			// 
			// matrixStudentPanel
			// 
			this.matrixStudentPanel.Controls.Add(this.averageScorePerCourseButton);
			this.matrixStudentPanel.Controls.Add(this.studentsPerExamConcentrationButton);
			this.matrixStudentPanel.Controls.Add(this.groupStudentTextbox);
			this.matrixStudentPanel.Controls.Add(this.totalStudentPerExamButton);
			this.matrixStudentPanel.Location = new System.Drawing.Point(6, 30);
			this.matrixStudentPanel.Name = "matrixStudentPanel";
			this.matrixStudentPanel.Size = new System.Drawing.Size(498, 320);
			this.matrixStudentPanel.TabIndex = 32;
			this.matrixStudentPanel.Visible = false;
			// 
			// totalStudentPerExamButton
			// 
			this.totalStudentPerExamButton.Location = new System.Drawing.Point(25, 4);
			this.totalStudentPerExamButton.Name = "totalStudentPerExamButton";
			this.totalStudentPerExamButton.Size = new System.Drawing.Size(201, 23);
			this.totalStudentPerExamButton.TabIndex = 1;
			this.totalStudentPerExamButton.Text = "Total Student Per Exam";
			this.totalStudentPerExamButton.UseVisualStyleBackColor = true;
			this.totalStudentPerExamButton.Click += new System.EventHandler(this.totalStudentPerExamButton_Click);
			// 
			// groupStudentTextbox
			// 
			this.groupStudentTextbox.Location = new System.Drawing.Point(9, 144);
			this.groupStudentTextbox.Multiline = true;
			this.groupStudentTextbox.Name = "groupStudentTextbox";
			this.groupStudentTextbox.ReadOnly = true;
			this.groupStudentTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.groupStudentTextbox.Size = new System.Drawing.Size(473, 151);
			this.groupStudentTextbox.TabIndex = 2;
			// 
			// studentsPerExamConcentrationButton
			// 
			this.studentsPerExamConcentrationButton.Location = new System.Drawing.Point(25, 41);
			this.studentsPerExamConcentrationButton.Name = "studentsPerExamConcentrationButton";
			this.studentsPerExamConcentrationButton.Size = new System.Drawing.Size(201, 23);
			this.studentsPerExamConcentrationButton.TabIndex = 3;
			this.studentsPerExamConcentrationButton.Text = "Students Per Exam(By concentration)";
			this.studentsPerExamConcentrationButton.UseVisualStyleBackColor = true;
			this.studentsPerExamConcentrationButton.Click += new System.EventHandler(this.studentsPerExamConcentrationButton_Click_1);
			// 
			// averageScorePerCourseButton
			// 
			this.averageScorePerCourseButton.Location = new System.Drawing.Point(25, 84);
			this.averageScorePerCourseButton.Name = "averageScorePerCourseButton";
			this.averageScorePerCourseButton.Size = new System.Drawing.Size(201, 23);
			this.averageScorePerCourseButton.TabIndex = 4;
			this.averageScorePerCourseButton.Text = "Average Score Per Course";
			this.averageScorePerCourseButton.UseVisualStyleBackColor = true;
			this.averageScorePerCourseButton.Click += new System.EventHandler(this.averageScorePerCourseButton_Click);
			// 
			// TeacherForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(497, 351);
			this.Controls.Add(this.matrixStudentPanel);
			this.Controls.Add(this.addStudentPanel);
			this.Controls.Add(this.removeStudentPanel);
			this.Controls.Add(this.logoutLink);
			this.Controls.Add(this.addQuestionPanel);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "TeacherForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TeacherForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeacherForm_FormClosing);
			this.Load += new System.EventHandler(this.TeacherForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.addQuestionPanel.ResumeLayout(false);
			this.addStudentPanel.ResumeLayout(false);
			this.addStudentPanel.PerformLayout();
			this.removeStudentPanel.ResumeLayout(false);
			this.matrixStudentPanel.ResumeLayout(false);
			this.matrixStudentPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem questionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
		private System.Windows.Forms.Panel addQuestionPanel;
		private System.Windows.Forms.Button addQuestionToBankButton;
		private System.Windows.Forms.ComboBox chooseCourseComboBoxAddQuestion;
		private System.Windows.Forms.Panel addStudentPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button addStudentButton;
		private System.Windows.Forms.TextBox addLastNameTextBox;
		private System.Windows.Forms.TextBox addFirstNameTextBox;
		private System.Windows.Forms.TextBox addStudentIDTextBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel removeStudentPanel;
		private System.Windows.Forms.Button removeStudentButton;
		private System.Windows.Forms.ComboBox removeStudentComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.LinkLabel logoutLink;
		private System.Windows.Forms.ComboBox chooseObjectiveComboBox;
		private System.Windows.Forms.Button removeQuestionButton;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.ComboBox concentrationComboBox;
		private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metricsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem questionToolStripMenuItem1;
		private System.Windows.Forms.Panel matrixStudentPanel;
		private System.Windows.Forms.Button totalStudentPerExamButton;
		private System.Windows.Forms.TextBox groupStudentTextbox;
		private System.Windows.Forms.Button studentsPerExamConcentrationButton;
		private System.Windows.Forms.Button averageScorePerCourseButton;
	}
}