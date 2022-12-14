namespace NEADatabase
{
    partial class CreateGroup
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
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.grpCreateGroup = new System.Windows.Forms.GroupBox();
            this.txtMembers = new System.Windows.Forms.TextBox();
            this.lblMembers = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.dgvOwnedGroups = new System.Windows.Forms.DataGridView();
            this.dgvUsersInGroup = new System.Windows.Forms.DataGridView();
            this.dgvTasksInGroup = new System.Windows.Forms.DataGridView();
            this.grpDisplayGroupProps = new System.Windows.Forms.GroupBox();
            this.lblGroupID = new System.Windows.Forms.Label();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.btnDisplayGroupProps = new System.Windows.Forms.Button();
            this.grpAddTaskToGroup = new System.Windows.Forms.GroupBox();
            this.txtGroupID2 = new System.Windows.Forms.TextBox();
            this.lblGroupID2 = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.lblTaskID = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.grpCreateGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwnedGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksInGroup)).BeginInit();
            this.grpDisplayGroupProps.SuspendLayout();
            this.grpAddTaskToGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(242, 79);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(120, 21);
            this.btnCreateGroup.TabIndex = 3;
            this.btnCreateGroup.Text = "Create Group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // grpCreateGroup
            // 
            this.grpCreateGroup.Controls.Add(this.btnCreateGroup);
            this.grpCreateGroup.Controls.Add(this.txtMembers);
            this.grpCreateGroup.Controls.Add(this.lblMembers);
            this.grpCreateGroup.Controls.Add(this.lblGroupName);
            this.grpCreateGroup.Controls.Add(this.txtGroupName);
            this.grpCreateGroup.Location = new System.Drawing.Point(12, 341);
            this.grpCreateGroup.Name = "grpCreateGroup";
            this.grpCreateGroup.Size = new System.Drawing.Size(377, 108);
            this.grpCreateGroup.TabIndex = 2;
            this.grpCreateGroup.TabStop = false;
            this.grpCreateGroup.Text = "Create Group";
            // 
            // txtMembers
            // 
            this.txtMembers.Location = new System.Drawing.Point(185, 53);
            this.txtMembers.Name = "txtMembers";
            this.txtMembers.Size = new System.Drawing.Size(177, 20);
            this.txtMembers.TabIndex = 7;
            this.txtMembers.Text = "UserID1,UserID2...";
            this.txtMembers.TextChanged += new System.EventHandler(this.txtMembers_TextChanged);
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Location = new System.Drawing.Point(81, 53);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(50, 13);
            this.lblMembers.TabIndex = 4;
            this.lblMembers.Text = "Members";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(81, 22);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(67, 13);
            this.lblGroupName.TabIndex = 5;
            this.lblGroupName.Text = "Group Name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(185, 19);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(177, 20);
            this.txtGroupName.TabIndex = 0;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            // 
            // dgvOwnedGroups
            // 
            this.dgvOwnedGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOwnedGroups.Location = new System.Drawing.Point(12, 77);
            this.dgvOwnedGroups.Name = "dgvOwnedGroups";
            this.dgvOwnedGroups.Size = new System.Drawing.Size(237, 192);
            this.dgvOwnedGroups.TabIndex = 3;
            this.dgvOwnedGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellContentClick);
            // 
            // dgvUsersInGroup
            // 
            this.dgvUsersInGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsersInGroup.Location = new System.Drawing.Point(255, 77);
            this.dgvUsersInGroup.Name = "dgvUsersInGroup";
            this.dgvUsersInGroup.Size = new System.Drawing.Size(255, 192);
            this.dgvUsersInGroup.TabIndex = 4;
            // 
            // dgvTasksInGroup
            // 
            this.dgvTasksInGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasksInGroup.Location = new System.Drawing.Point(516, 77);
            this.dgvTasksInGroup.Name = "dgvTasksInGroup";
            this.dgvTasksInGroup.Size = new System.Drawing.Size(255, 192);
            this.dgvTasksInGroup.TabIndex = 5;
            // 
            // grpDisplayGroupProps
            // 
            this.grpDisplayGroupProps.Controls.Add(this.btnDisplayGroupProps);
            this.grpDisplayGroupProps.Controls.Add(this.txtGroupID);
            this.grpDisplayGroupProps.Controls.Add(this.lblGroupID);
            this.grpDisplayGroupProps.Location = new System.Drawing.Point(12, 275);
            this.grpDisplayGroupProps.Name = "grpDisplayGroupProps";
            this.grpDisplayGroupProps.Size = new System.Drawing.Size(377, 67);
            this.grpDisplayGroupProps.TabIndex = 6;
            this.grpDisplayGroupProps.TabStop = false;
            this.grpDisplayGroupProps.Text = "Display Group Properties";
            // 
            // lblGroupID
            // 
            this.lblGroupID.AutoSize = true;
            this.lblGroupID.Location = new System.Drawing.Point(98, 26);
            this.lblGroupID.Name = "lblGroupID";
            this.lblGroupID.Size = new System.Drawing.Size(50, 13);
            this.lblGroupID.TabIndex = 7;
            this.lblGroupID.Text = "GroupID ";
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(169, 19);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(193, 20);
            this.txtGroupID.TabIndex = 7;
            this.txtGroupID.TextChanged += new System.EventHandler(this.txtGroupID_TextChanged);
            // 
            // btnDisplayGroupProps
            // 
            this.btnDisplayGroupProps.Location = new System.Drawing.Point(242, 45);
            this.btnDisplayGroupProps.Name = "btnDisplayGroupProps";
            this.btnDisplayGroupProps.Size = new System.Drawing.Size(120, 21);
            this.btnDisplayGroupProps.TabIndex = 8;
            this.btnDisplayGroupProps.Text = "Display";
            this.btnDisplayGroupProps.UseVisualStyleBackColor = true;
            this.btnDisplayGroupProps.Click += new System.EventHandler(this.btnDisplayGroupProps_Click);
            // 
            // grpAddTaskToGroup
            // 
            this.grpAddTaskToGroup.Controls.Add(this.btnAddTask);
            this.grpAddTaskToGroup.Controls.Add(this.lblTaskID);
            this.grpAddTaskToGroup.Controls.Add(this.txtTaskID);
            this.grpAddTaskToGroup.Controls.Add(this.txtGroupID2);
            this.grpAddTaskToGroup.Controls.Add(this.lblGroupID2);
            this.grpAddTaskToGroup.Location = new System.Drawing.Point(399, 285);
            this.grpAddTaskToGroup.Name = "grpAddTaskToGroup";
            this.grpAddTaskToGroup.Size = new System.Drawing.Size(289, 122);
            this.grpAddTaskToGroup.TabIndex = 7;
            this.grpAddTaskToGroup.TabStop = false;
            this.grpAddTaskToGroup.Text = "Add Task to Group";
            // 
            // txtGroupID2
            // 
            this.txtGroupID2.Location = new System.Drawing.Point(67, 17);
            this.txtGroupID2.Name = "txtGroupID2";
            this.txtGroupID2.Size = new System.Drawing.Size(193, 20);
            this.txtGroupID2.TabIndex = 8;
            this.txtGroupID2.TextChanged += new System.EventHandler(this.txtGroupID2_TextChanged);
            // 
            // lblGroupID2
            // 
            this.lblGroupID2.AutoSize = true;
            this.lblGroupID2.Location = new System.Drawing.Point(11, 20);
            this.lblGroupID2.Name = "lblGroupID2";
            this.lblGroupID2.Size = new System.Drawing.Size(50, 13);
            this.lblGroupID2.TabIndex = 9;
            this.lblGroupID2.Text = "GroupID ";
            // 
            // txtTaskID
            // 
            this.txtTaskID.Location = new System.Drawing.Point(67, 56);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(193, 20);
            this.txtTaskID.TabIndex = 10;
            this.txtTaskID.TextChanged += new System.EventHandler(this.txtTaskID_TextChanged);
            // 
            // lblTaskID
            // 
            this.lblTaskID.AutoSize = true;
            this.lblTaskID.Location = new System.Drawing.Point(11, 59);
            this.lblTaskID.Name = "lblTaskID";
            this.lblTaskID.Size = new System.Drawing.Size(42, 13);
            this.lblTaskID.TabIndex = 11;
            this.lblTaskID.Text = "TaskID";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(140, 95);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(120, 21);
            this.btnAddTask.TabIndex = 12;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // CreateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpAddTaskToGroup);
            this.Controls.Add(this.grpDisplayGroupProps);
            this.Controls.Add(this.dgvTasksInGroup);
            this.Controls.Add(this.dgvUsersInGroup);
            this.Controls.Add(this.dgvOwnedGroups);
            this.Controls.Add(this.grpCreateGroup);
            this.Name = "CreateGroup";
            this.Text = "CreateGroup";
            this.Load += new System.EventHandler(this.CreateGroup_Load);
            this.grpCreateGroup.ResumeLayout(false);
            this.grpCreateGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOwnedGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsersInGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasksInGroup)).EndInit();
            this.grpDisplayGroupProps.ResumeLayout(false);
            this.grpDisplayGroupProps.PerformLayout();
            this.grpAddTaskToGroup.ResumeLayout(false);
            this.grpAddTaskToGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.GroupBox grpCreateGroup;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtMembers;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.DataGridView dgvOwnedGroups;
        private System.Windows.Forms.DataGridView dgvUsersInGroup;
        private System.Windows.Forms.DataGridView dgvTasksInGroup;
        private System.Windows.Forms.GroupBox grpDisplayGroupProps;
        private System.Windows.Forms.Button btnDisplayGroupProps;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.Label lblGroupID;
        private System.Windows.Forms.GroupBox grpAddTaskToGroup;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Label lblTaskID;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.TextBox txtGroupID2;
        private System.Windows.Forms.Label lblGroupID2;
    }
}