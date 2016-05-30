namespace GDTS
{
	partial class AddQuestion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.addQuestionButton = new System.Windows.Forms.Button();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.objectiveComboBox = new System.Windows.Forms.ComboBox();
            this.semesterTextBox = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.teacherTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Correct Answer";
            // 
            // questionTextBox
            // 
            this.questionTextBox.Location = new System.Drawing.Point(90, 105);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(422, 82);
            this.questionTextBox.TabIndex = 2;
            // 
            // answerTextBox
            // 
            this.answerTextBox.Location = new System.Drawing.Point(90, 202);
            this.answerTextBox.Multiline = true;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(422, 81);
            this.answerTextBox.TabIndex = 3;
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Location = new System.Drawing.Point(203, 303);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(123, 23);
            this.addQuestionButton.TabIndex = 4;
            this.addQuestionButton.Text = "Add Question";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            this.addQuestionButton.Click += new System.EventHandler(this.addQuestionButton_Click);
            // 
            // courseComboBox
            // 
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Location = new System.Drawing.Point(8, 12);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(154, 21);
            this.courseComboBox.TabIndex = 5;
            this.courseComboBox.Text = "Choose a course...";
            this.courseComboBox.SelectedIndexChanged += new System.EventHandler(this.courseComboBox_SelectedIndexChanged);
            // 
            // objectiveComboBox
            // 
            this.objectiveComboBox.FormattingEnabled = true;
            this.objectiveComboBox.Location = new System.Drawing.Point(8, 51);
            this.objectiveComboBox.Name = "objectiveComboBox";
            this.objectiveComboBox.Size = new System.Drawing.Size(516, 21);
            this.objectiveComboBox.TabIndex = 6;
            this.objectiveComboBox.Text = "Choose an objective...";
            this.objectiveComboBox.SelectedIndexChanged += new System.EventHandler(this.objectiveComboBox_SelectedIndexChanged);
            // 
            // semesterTextBox
            // 
            this.semesterTextBox.Location = new System.Drawing.Point(168, 12);
            this.semesterTextBox.Name = "semesterTextBox";
            this.semesterTextBox.Size = new System.Drawing.Size(116, 20);
            this.semesterTextBox.TabIndex = 7;
            this.semesterTextBox.Text = "Enter Spring or Fall";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(290, 12);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(116, 20);
            this.yearTextBox.TabIndex = 8;
            this.yearTextBox.Text = "Enter a Year";
            // 
            // teacherTextBox
            // 
            this.teacherTextBox.Location = new System.Drawing.Point(412, 12);
            this.teacherTextBox.Name = "teacherTextBox";
            this.teacherTextBox.Size = new System.Drawing.Size(116, 20);
            this.teacherTextBox.TabIndex = 9;
            this.teacherTextBox.Text = "Enter a Teacher";
            // 
            // AddQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 348);
            this.Controls.Add(this.teacherTextBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.semesterTextBox);
            this.Controls.Add(this.objectiveComboBox);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.addQuestionButton);
            this.Controls.Add(this.answerTextBox);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddQuestion";
            this.Text = "AddQuestion";
            this.Load += new System.EventHandler(this.AddQuestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox questionTextBox;
		private System.Windows.Forms.TextBox answerTextBox;
		private System.Windows.Forms.Button addQuestionButton;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.ComboBox objectiveComboBox;
        private System.Windows.Forms.TextBox semesterTextBox;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox teacherTextBox;
	}
}