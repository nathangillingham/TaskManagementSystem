namespace NEADatabase
{
    partial class AddTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpAddTask = new System.Windows.Forms.GroupBox();
            this.txtGroups = new System.Windows.Forms.TextBox();
            this.lblGroups = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnSetTask = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.grpAddTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAddTask
            // 
            this.grpAddTask.Controls.Add(this.txtGroups);
            this.grpAddTask.Controls.Add(this.btnSetTask);
            this.grpAddTask.Controls.Add(this.lblGroups);
            this.grpAddTask.Controls.Add(this.label5);
            this.grpAddTask.Controls.Add(this.label4);
            this.grpAddTask.Controls.Add(this.label3);
            this.grpAddTask.Controls.Add(this.label2);
            this.grpAddTask.Controls.Add(this.label1);
            this.grpAddTask.Controls.Add(this.dateTimePicker);
            this.grpAddTask.Controls.Add(this.txtDescription);
            this.grpAddTask.Controls.Add(this.txtPriority);
            this.grpAddTask.Controls.Add(this.txtUser);
            this.grpAddTask.Controls.Add(this.txtTitle);
            this.grpAddTask.Location = new System.Drawing.Point(12, 40);
            this.grpAddTask.Name = "grpAddTask";
            this.grpAddTask.Size = new System.Drawing.Size(444, 346);
            this.grpAddTask.TabIndex = 0;
            this.grpAddTask.TabStop = false;
            this.grpAddTask.Text = "Add Task";
            // 
            // txtGroups
            // 
            this.txtGroups.Location = new System.Drawing.Point(185, 108);
            this.txtGroups.Name = "txtGroups";
            this.txtGroups.Size = new System.Drawing.Size(177, 20);
            this.txtGroups.TabIndex = 11;
            this.txtGroups.Text = "GroupID1,GroupID2...";
            this.txtGroups.TextChanged += new System.EventHandler(this.txtGroups_TextChanged);
            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Location = new System.Drawing.Point(80, 111);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(41, 13);
            this.lblGroups.TabIndex = 10;
            this.lblGroups.Text = "Groups";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Date Due";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Priority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Title";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(185, 279);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(177, 20);
            this.dateTimePicker.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(185, 178);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(177, 83);
            this.txtDescription.TabIndex = 3;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(185, 138);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(177, 20);
            this.txtPriority.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(185, 78);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(177, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(185, 45);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(177, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // btnSetTask
            // 
            this.btnSetTask.Location = new System.Drawing.Point(290, 319);
            this.btnSetTask.Name = "btnSetTask";
            this.btnSetTask.Size = new System.Drawing.Size(72, 21);
            this.btnSetTask.TabIndex = 1;
            this.btnSetTask.Text = "Set Task";
            this.btnSetTask.UseVisualStyleBackColor = true;
            this.btnSetTask.Click += new System.EventHandler(this.btnSetTask_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(462, 41);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(326, 345);
            this.dgvUsers.TabIndex = 2;
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.grpAddTask);
            this.Name = "AddTask";
            this.Text = "AddTask";
            this.Load += new System.EventHandler(this.AddTask_Load);
            this.grpAddTask.ResumeLayout(false);
            this.grpAddTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAddTask;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnSetTask;
        private System.Windows.Forms.TextBox txtGroups;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.DataGridView dgvUsers;
    }
}