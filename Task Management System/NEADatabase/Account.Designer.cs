namespace NEADatabase
{
    partial class Account
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
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.grpSortBy = new System.Windows.Forms.GroupBox();
            this.rdoDateSet = new System.Windows.Forms.RadioButton();
            this.rdoPriority = new System.Windows.Forms.RadioButton();
            this.rdoDate = new System.Windows.Forms.RadioButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSetTask = new System.Windows.Forms.Button();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.grpCompleteTask = new System.Windows.Forms.GroupBox();
            this.btnCmpltTask = new System.Windows.Forms.Button();
            this.txtCmpltdTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.grpSortBy.SuspendLayout();
            this.grpCompleteTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTasks
            // 
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(38, 29);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.Size = new System.Drawing.Size(591, 192);
            this.dgvTasks.TabIndex = 0;
            this.dgvTasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellContentClick);
            // 
            // grpSortBy
            // 
            this.grpSortBy.Controls.Add(this.rdoDateSet);
            this.grpSortBy.Controls.Add(this.rdoPriority);
            this.grpSortBy.Controls.Add(this.rdoDate);
            this.grpSortBy.Location = new System.Drawing.Point(38, 246);
            this.grpSortBy.Name = "grpSortBy";
            this.grpSortBy.Size = new System.Drawing.Size(126, 101);
            this.grpSortBy.TabIndex = 1;
            this.grpSortBy.TabStop = false;
            this.grpSortBy.Text = "Sort By";
            this.grpSortBy.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdoDateSet
            // 
            this.rdoDateSet.AutoSize = true;
            this.rdoDateSet.Location = new System.Drawing.Point(6, 55);
            this.rdoDateSet.Name = "rdoDateSet";
            this.rdoDateSet.Size = new System.Drawing.Size(67, 17);
            this.rdoDateSet.TabIndex = 3;
            this.rdoDateSet.TabStop = true;
            this.rdoDateSet.Text = "Date Set";
            this.rdoDateSet.UseVisualStyleBackColor = true;
            this.rdoDateSet.CheckedChanged += new System.EventHandler(this.rdoDateSet_CheckedChanged);
            // 
            // rdoPriority
            // 
            this.rdoPriority.AutoSize = true;
            this.rdoPriority.Location = new System.Drawing.Point(6, 78);
            this.rdoPriority.Name = "rdoPriority";
            this.rdoPriority.Size = new System.Drawing.Size(56, 17);
            this.rdoPriority.TabIndex = 2;
            this.rdoPriority.TabStop = true;
            this.rdoPriority.Text = "Priority";
            this.rdoPriority.UseVisualStyleBackColor = true;
            this.rdoPriority.CheckedChanged += new System.EventHandler(this.rdoPriority_CheckedChanged);
            // 
            // rdoDate
            // 
            this.rdoDate.AutoSize = true;
            this.rdoDate.Location = new System.Drawing.Point(6, 32);
            this.rdoDate.Name = "rdoDate";
            this.rdoDate.Size = new System.Drawing.Size(71, 17);
            this.rdoDate.TabIndex = 2;
            this.rdoDate.TabStop = true;
            this.rdoDate.Text = "Date Due";
            this.rdoDate.UseVisualStyleBackColor = true;
            this.rdoDate.CheckedChanged += new System.EventHandler(this.rdoDate_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(682, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSetTask
            // 
            this.btnSetTask.Location = new System.Drawing.Point(213, 246);
            this.btnSetTask.Name = "btnSetTask";
            this.btnSetTask.Size = new System.Drawing.Size(142, 43);
            this.btnSetTask.TabIndex = 3;
            this.btnSetTask.Text = "Set Task";
            this.btnSetTask.UseVisualStyleBackColor = true;
            this.btnSetTask.Click += new System.EventHandler(this.btnSetTask_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(213, 295);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(142, 48);
            this.btnCreateGroup.TabIndex = 4;
            this.btnCreateGroup.Text = "Create Group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // grpCompleteTask
            // 
            this.grpCompleteTask.Controls.Add(this.btnCmpltTask);
            this.grpCompleteTask.Controls.Add(this.txtCmpltdTaskID);
            this.grpCompleteTask.Controls.Add(this.lblTaskID);
            this.grpCompleteTask.Location = new System.Drawing.Point(38, 363);
            this.grpCompleteTask.Name = "grpCompleteTask";
            this.grpCompleteTask.Size = new System.Drawing.Size(126, 75);
            this.grpCompleteTask.TabIndex = 5;
            this.grpCompleteTask.TabStop = false;
            this.grpCompleteTask.Text = "Complete Task";
            // 
            // btnCmpltTask
            // 
            this.btnCmpltTask.Location = new System.Drawing.Point(34, 49);
            this.btnCmpltTask.Name = "btnCmpltTask";
            this.btnCmpltTask.Size = new System.Drawing.Size(67, 22);
            this.btnCmpltTask.TabIndex = 7;
            this.btnCmpltTask.Text = "Complete";
            this.btnCmpltTask.UseVisualStyleBackColor = true;
            this.btnCmpltTask.Click += new System.EventHandler(this.btnCmpltTask_Click);
            // 
            // txtCmpltdTaskID
            // 
            this.txtCmpltdTaskID.Location = new System.Drawing.Point(54, 23);
            this.txtCmpltdTaskID.Name = "txtCmpltdTaskID";
            this.txtCmpltdTaskID.Size = new System.Drawing.Size(47, 20);
            this.txtCmpltdTaskID.TabIndex = 6;
            this.txtCmpltdTaskID.TextChanged += new System.EventHandler(this.txtCmpltdTaskID_TextChanged);
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Location = new System.Drawing.Point(6, 26);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(42, 13);
            this.lblTaskID.TabIndex = 6;
            this.lblTaskID.Text = "TaskID";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(402, 246);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 6;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.grpCompleteTask);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.btnSetTask);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpSortBy);
            this.Controls.Add(this.dgvTasks);
            this.Name = "Account";
            this.Load += new System.EventHandler(this.Account_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.grpSortBy.ResumeLayout(false);
            this.grpSortBy.PerformLayout();
            this.grpCompleteTask.ResumeLayout(false);
            this.grpCompleteTask.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.GroupBox grpSortBy;
        private System.Windows.Forms.RadioButton rdoPriority;
        private System.Windows.Forms.RadioButton rdoDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSetTask;
        private System.Windows.Forms.RadioButton rdoDateSet;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.GroupBox grpCompleteTask;
        private System.Windows.Forms.Button btnCmpltTask;
        private System.Windows.Forms.TextBox txtCmpltdTaskID;
        private System.Windows.Forms.Label lblTaskID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}