namespace AndPerTagCore.Forms
{
    partial class AboutForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutDescriptionLabel = new System.Windows.Forms.Label();
            this.creditsLabel = new System.Windows.Forms.Label();
            this.divider = new System.Windows.Forms.Label();
            this.deleteButtonLink = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.editButtonLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // aboutDescriptionLabel
            // 
            this.aboutDescriptionLabel.Location = new System.Drawing.Point(12, 9);
            this.aboutDescriptionLabel.Name = "aboutDescriptionLabel";
            this.aboutDescriptionLabel.Size = new System.Drawing.Size(600, 82);
            this.aboutDescriptionLabel.TabIndex = 0;
            this.aboutDescriptionLabel.Text = "This application was created with the functional purpose, not the design one.";
            // 
            // creditsLabel
            // 
            this.creditsLabel.AutoSize = true;
            this.creditsLabel.Location = new System.Drawing.Point(12, 108);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(63, 23);
            this.creditsLabel.TabIndex = 2;
            this.creditsLabel.Text = "Credits";
            // 
            // divider
            // 
            this.divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider.Location = new System.Drawing.Point(0, 91);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(800, 2);
            this.divider.TabIndex = 3;
            // 
            // deleteButtonLink
            // 
            this.deleteButtonLink.AutoSize = true;
            this.deleteButtonLink.Location = new System.Drawing.Point(12, 136);
            this.deleteButtonLink.Name = "deleteButtonLink";
            this.deleteButtonLink.Size = new System.Drawing.Size(462, 23);
            this.deleteButtonLink.TabIndex = 4;
            this.deleteButtonLink.TabStop = true;
            this.deleteButtonLink.Text = "Delete button icon made by Freepik from www.flaticon.com";
            this.deleteButtonLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 46);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // editButtonLink
            // 
            this.editButtonLink.AutoSize = true;
            this.editButtonLink.Location = new System.Drawing.Point(12, 163);
            this.editButtonLink.Name = "editButtonLink";
            this.editButtonLink.Size = new System.Drawing.Size(432, 23);
            this.editButtonLink.TabIndex = 4;
            this.editButtonLink.TabStop = true;
            this.editButtonLink.Text = "Edit button icon made by Becris from www.flaticon.com";
            this.editButtonLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editButtonLink_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(670, 204);
            this.Controls.Add(this.editButtonLink);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.deleteButtonLink);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.creditsLabel);
            this.Controls.Add(this.aboutDescriptionLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AndPerTag - About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label aboutDescriptionLabel;
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.Label divider;
        private System.Windows.Forms.LinkLabel deleteButtonLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel editButtonLink;
    }
}

