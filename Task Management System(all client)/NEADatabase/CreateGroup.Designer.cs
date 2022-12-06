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
            this.grpCreateGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(378, 337);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(120, 21);
            this.btnCreateGroup.TabIndex = 3;
            this.btnCreateGroup.Text = "Create Group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // grpCreateGroup
            // 
            this.grpCreateGroup.Controls.Add(this.txtMembers);
            this.grpCreateGroup.Controls.Add(this.lblMembers);
            this.grpCreateGroup.Controls.Add(this.lblGroupName);
            this.grpCreateGroup.Controls.Add(this.txtGroupName);
            this.grpCreateGroup.Location = new System.Drawing.Point(54, 149);
            this.grpCreateGroup.Name = "grpCreateGroup";
            this.grpCreateGroup.Size = new System.Drawing.Size(444, 151);
            this.grpCreateGroup.TabIndex = 2;
            this.grpCreateGroup.TabStop = false;
            this.grpCreateGroup.Text = "Create Group";
            // 
            // txtMembers
            // 
            this.txtMembers.Location = new System.Drawing.Point(185, 90);
            this.txtMembers.Name = "txtMembers";
            this.txtMembers.Size = new System.Drawing.Size(177, 20);
            this.txtMembers.TabIndex = 7;
            this.txtMembers.Text = "UserID1,UserID2...";
            this.txtMembers.TextChanged += new System.EventHandler(this.txtMembers_TextChanged);
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Location = new System.Drawing.Point(81, 97);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(50, 13);
            this.lblMembers.TabIndex = 4;
            this.lblMembers.Text = "Members";
            // 
            // lblGroupName
            // 
            this.lblGroupName.AutoSize = true;
            this.lblGroupName.Location = new System.Drawing.Point(81, 48);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(67, 13);
            this.lblGroupName.TabIndex = 5;
            this.lblGroupName.Text = "Group Name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(185, 45);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(177, 20);
            this.txtGroupName.TabIndex = 0;
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtGroupName_TextChanged);
            // 
            // CreateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.grpCreateGroup);
            this.Name = "CreateGroup";
            this.Text = "CreateGroup";
            this.Load += new System.EventHandler(this.CreateGroup_Load);
            this.grpCreateGroup.ResumeLayout(false);
            this.grpCreateGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.GroupBox grpCreateGroup;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TextBox txtMembers;
        private System.Windows.Forms.Label lblMembers;
    }
}