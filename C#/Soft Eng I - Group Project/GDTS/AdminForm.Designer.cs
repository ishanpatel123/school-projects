namespace GDTS
{
	partial class AdminForm
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
			this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addCourseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.removeCourseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.addUserPanel = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.removeUserPanel = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.removeCoursePanel = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.removeCourseButton = new System.Windows.Forms.Button();
			this.removeCourseComboBox = new System.Windows.Forms.ComboBox();
			this.removeUserButton = new System.Windows.Forms.Button();
			this.removeUserComboBox = new System.Windows.Forms.ComboBox();
			this.addUserButton = new System.Windows.Forms.Button();
			this.addPasswordTextBox = new System.Windows.Forms.TextBox();
			this.addUsernameTextBox = new System.Windows.Forms.TextBox();
			this.addUserTypeTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.addCoursePanel = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.addCourseButton = new System.Windows.Forms.Button();
			this.courseNumberTextBox = new System.Windows.Forms.TextBox();
			this.coursePrefixTextBox = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.logoutLabel = new System.Windows.Forms.LinkLabel();
			this.menuStrip1.SuspendLayout();
			this.addUserPanel.SuspendLayout();
			this.removeUserPanel.SuspendLayout();
			this.removeCoursePanel.SuspendLayout();
			this.addCoursePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.courseToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(284, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// userToolStripMenuItem
			// 
			this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.removeUserToolStripMenuItem});
			this.userToolStripMenuItem.Name = "userToolStripMenuItem";
			this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.userToolStripMenuItem.Text = "User";
			// 
			// addUserToolStripMenuItem
			// 
			this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
			this.addUserToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.addUserToolStripMenuItem.Text = "Add";
			this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
			// 
			// removeUserToolStripMenuItem
			// 
			this.removeUserToolStripMenuItem.Name = "removeUserToolStripMenuItem";
			this.removeUserToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.removeUserToolStripMenuItem.Text = "Remove";
			this.removeUserToolStripMenuItem.Click += new System.EventHandler(this.removeUserToolStripMenuItem_Click);
			// 
			// courseToolStripMenuItem
			// 
			this.courseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCourseToolStripMenuItem1,
            this.removeCourseToolStripMenuItem1});
			this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
			this.courseToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.courseToolStripMenuItem.Text = "Course";
			// 
			// addCourseToolStripMenuItem1
			// 
			this.addCourseToolStripMenuItem1.Name = "addCourseToolStripMenuItem1";
			this.addCourseToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
			this.addCourseToolStripMenuItem1.Text = "Add";
			this.addCourseToolStripMenuItem1.Click += new System.EventHandler(this.addCourseToolStripMenuItem1_Click);
			// 
			// removeCourseToolStripMenuItem1
			// 
			this.removeCourseToolStripMenuItem1.Name = "removeCourseToolStripMenuItem1";
			this.removeCourseToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
			this.removeCourseToolStripMenuItem1.Text = "Remove";
			this.removeCourseToolStripMenuItem1.Click += new System.EventHandler(this.removeCourseToolStripMenuItem1_Click);
			// 
			// addUserPanel
			// 
			this.addUserPanel.Controls.Add(this.label6);
			this.addUserPanel.Controls.Add(this.addUserButton);
			this.addUserPanel.Controls.Add(this.addPasswordTextBox);
			this.addUserPanel.Controls.Add(this.addUsernameTextBox);
			this.addUserPanel.Controls.Add(this.addUserTypeTextBox);
			this.addUserPanel.Controls.Add(this.label3);
			this.addUserPanel.Controls.Add(this.label2);
			this.addUserPanel.Controls.Add(this.label1);
			this.addUserPanel.Location = new System.Drawing.Point(20, 26);
			this.addUserPanel.Name = "addUserPanel";
			this.addUserPanel.Size = new System.Drawing.Size(250, 219);
			this.addUserPanel.TabIndex = 1;
			this.addUserPanel.Visible = false;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(37, 10);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(201, 27);
			this.label6.TabIndex = 8;
			this.label6.Text = "Add user to system. Assign a 1 for Teacher and a 2 for Coordinator.";
			// 
			// removeUserPanel
			// 
			this.removeUserPanel.Controls.Add(this.label4);
			this.removeUserPanel.Controls.Add(this.removeUserButton);
			this.removeUserPanel.Controls.Add(this.removeUserComboBox);
			this.removeUserPanel.Location = new System.Drawing.Point(12, 28);
			this.removeUserPanel.Name = "removeUserPanel";
			this.removeUserPanel.Size = new System.Drawing.Size(255, 219);
			this.removeUserPanel.TabIndex = 7;
			this.removeUserPanel.Visible = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(28, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(194, 35);
			this.label4.TabIndex = 2;
			this.label4.Text = "Choose a user from the drop down list below to remove them from the system.\r\n";
			// 
			// removeCoursePanel
			// 
			this.removeCoursePanel.Controls.Add(this.label5);
			this.removeCoursePanel.Controls.Add(this.removeCourseButton);
			this.removeCoursePanel.Controls.Add(this.removeCourseComboBox);
			this.removeCoursePanel.Location = new System.Drawing.Point(9, 27);
			this.removeCoursePanel.Name = "removeCoursePanel";
			this.removeCoursePanel.Size = new System.Drawing.Size(255, 219);
			this.removeCoursePanel.TabIndex = 22;
			this.removeCoursePanel.Visible = false;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(28, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(194, 35);
			this.label5.TabIndex = 5;
			this.label5.Text = "Choose a course from the drop down list below to remove it from the system.\r\n";
			// 
			// removeCourseButton
			// 
			this.removeCourseButton.Location = new System.Drawing.Point(169, 98);
			this.removeCourseButton.Name = "removeCourseButton";
			this.removeCourseButton.Size = new System.Drawing.Size(77, 38);
			this.removeCourseButton.TabIndex = 4;
			this.removeCourseButton.Text = "Remove";
			this.removeCourseButton.UseVisualStyleBackColor = true;
			// 
			// removeCourseComboBox
			// 
			this.removeCourseComboBox.FormattingEnabled = true;
			this.removeCourseComboBox.Location = new System.Drawing.Point(3, 58);
			this.removeCourseComboBox.Name = "removeCourseComboBox";
			this.removeCourseComboBox.Size = new System.Drawing.Size(164, 21);
			this.removeCourseComboBox.TabIndex = 3;
			this.removeCourseComboBox.Text = "Select a course...";
			// 
			// removeUserButton
			// 
			this.removeUserButton.Location = new System.Drawing.Point(166, 111);
			this.removeUserButton.Name = "removeUserButton";
			this.removeUserButton.Size = new System.Drawing.Size(77, 38);
			this.removeUserButton.TabIndex = 1;
			this.removeUserButton.Text = "Remove";
			this.removeUserButton.UseVisualStyleBackColor = true;
			this.removeUserButton.Click += new System.EventHandler(this.removeUserButton_Click);
			// 
			// removeUserComboBox
			// 
			this.removeUserComboBox.FormattingEnabled = true;
			this.removeUserComboBox.Location = new System.Drawing.Point(8, 69);
			this.removeUserComboBox.Name = "removeUserComboBox";
			this.removeUserComboBox.Size = new System.Drawing.Size(142, 21);
			this.removeUserComboBox.TabIndex = 0;
			this.removeUserComboBox.Text = "Select a user...";
			// 
			// addUserButton
			// 
			this.addUserButton.Location = new System.Drawing.Point(79, 170);
			this.addUserButton.Name = "addUserButton";
			this.addUserButton.Size = new System.Drawing.Size(82, 28);
			this.addUserButton.TabIndex = 6;
			this.addUserButton.Text = "Add User";
			this.addUserButton.UseVisualStyleBackColor = true;
			this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
			// 
			// addPasswordTextBox
			// 
			this.addPasswordTextBox.Location = new System.Drawing.Point(89, 89);
			this.addPasswordTextBox.Name = "addPasswordTextBox";
			this.addPasswordTextBox.Size = new System.Drawing.Size(100, 20);
			this.addPasswordTextBox.TabIndex = 2;
			// 
			// addUsernameTextBox
			// 
			this.addUsernameTextBox.Location = new System.Drawing.Point(89, 50);
			this.addUsernameTextBox.Name = "addUsernameTextBox";
			this.addUsernameTextBox.Size = new System.Drawing.Size(100, 20);
			this.addUsernameTextBox.TabIndex = 1;
			// 
			// addUserTypeTextBox
			// 
			this.addUserTypeTextBox.Location = new System.Drawing.Point(89, 129);
			this.addUserTypeTextBox.Name = "addUserTypeTextBox";
			this.addUserTypeTextBox.Size = new System.Drawing.Size(33, 20);
			this.addUserTypeTextBox.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 132);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "User Type:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// addCoursePanel
			// 
			this.addCoursePanel.Controls.Add(this.label7);
			this.addCoursePanel.Controls.Add(this.addCourseButton);
			this.addCoursePanel.Controls.Add(this.courseNumberTextBox);
			this.addCoursePanel.Controls.Add(this.coursePrefixTextBox);
			this.addCoursePanel.Controls.Add(this.label12);
			this.addCoursePanel.Controls.Add(this.label11);
			this.addCoursePanel.Location = new System.Drawing.Point(17, 31);
			this.addCoursePanel.Name = "addCoursePanel";
			this.addCoursePanel.Size = new System.Drawing.Size(255, 219);
			this.addCoursePanel.TabIndex = 3;
			this.addCoursePanel.Visible = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(67, 59);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(120, 27);
			this.label7.TabIndex = 23;
			this.label7.Text = "Add Course To System";
			// 
			// addCourseButton
			// 
			this.addCourseButton.Location = new System.Drawing.Point(79, 180);
			this.addCourseButton.Name = "addCourseButton";
			this.addCourseButton.Size = new System.Drawing.Size(92, 34);
			this.addCourseButton.TabIndex = 21;
			this.addCourseButton.Text = "Add Course";
			this.addCourseButton.UseVisualStyleBackColor = true;
			this.addCourseButton.Click += new System.EventHandler(this.addCourseButton_Click);
			// 
			// courseNumberTextBox
			// 
			this.courseNumberTextBox.Location = new System.Drawing.Point(124, 119);
			this.courseNumberTextBox.Name = "courseNumberTextBox";
			this.courseNumberTextBox.Size = new System.Drawing.Size(102, 20);
			this.courseNumberTextBox.TabIndex = 17;
			// 
			// coursePrefixTextBox
			// 
			this.coursePrefixTextBox.Location = new System.Drawing.Point(124, 89);
			this.coursePrefixTextBox.Name = "coursePrefixTextBox";
			this.coursePrefixTextBox.ReadOnly = true;
			this.coursePrefixTextBox.Size = new System.Drawing.Size(102, 20);
			this.coursePrefixTextBox.TabIndex = 16;
			this.coursePrefixTextBox.Text = "CSCI";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(19, 122);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(86, 13);
			this.label12.TabIndex = 12;
			this.label12.Text = "Course Number: ";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(27, 92);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 13);
			this.label11.TabIndex = 11;
			this.label11.Text = "Course Prefix: ";
			// 
			// logoutLabel
			// 
			this.logoutLabel.AutoSize = true;
			this.logoutLabel.Location = new System.Drawing.Point(217, 9);
			this.logoutLabel.Name = "logoutLabel";
			this.logoutLabel.Size = new System.Drawing.Size(40, 13);
			this.logoutLabel.TabIndex = 23;
			this.logoutLabel.TabStop = true;
			this.logoutLabel.Text = "Logout";
			this.logoutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLabel_LinkClicked);
			// 
			// AdminForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.logoutLabel);
			this.Controls.Add(this.removeCoursePanel);
			this.Controls.Add(this.removeUserPanel);
			this.Controls.Add(this.addUserPanel);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.addCoursePanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "AdminForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AdminForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
			this.Load += new System.EventHandler(this.AdminForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.addUserPanel.ResumeLayout(false);
			this.addUserPanel.PerformLayout();
			this.removeUserPanel.ResumeLayout(false);
			this.removeCoursePanel.ResumeLayout(false);
			this.addCoursePanel.ResumeLayout(false);
			this.addCoursePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeUserToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addCourseToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem removeCourseToolStripMenuItem1;
		private System.Windows.Forms.Panel addUserPanel;
		private System.Windows.Forms.Button addUserButton;
		private System.Windows.Forms.TextBox addPasswordTextBox;
		private System.Windows.Forms.TextBox addUsernameTextBox;
		private System.Windows.Forms.TextBox addUserTypeTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel removeUserPanel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button removeUserButton;
		private System.Windows.Forms.ComboBox removeUserComboBox;
		private System.Windows.Forms.Panel addCoursePanel;
        private System.Windows.Forms.Button addCourseButton;
		private System.Windows.Forms.TextBox courseNumberTextBox;
        private System.Windows.Forms.TextBox coursePrefixTextBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel removeCoursePanel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button removeCourseButton;
		private System.Windows.Forms.ComboBox removeCourseComboBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel logoutLabel;
	}
}