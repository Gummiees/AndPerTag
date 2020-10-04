namespace AndPerTagCore.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tagsLabel = new System.Windows.Forms.Label();
            this.macrosLabel = new System.Windows.Forms.Label();
            this.divider = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AndPerTag - Macros";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // tagsLabel
            // 
            this.tagsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tagsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tagsLabel.Location = new System.Drawing.Point(2, 9);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(400, 53);
            this.tagsLabel.TabIndex = 0;
            this.tagsLabel.Text = "Tags";
            this.tagsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // macrosLabel
            // 
            this.macrosLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.macrosLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.macrosLabel.Location = new System.Drawing.Point(440, 9);
            this.macrosLabel.Name = "macrosLabel";
            this.macrosLabel.Size = new System.Drawing.Size(400, 53);
            this.macrosLabel.TabIndex = 0;
            this.macrosLabel.Text = "Macros";
            this.macrosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider
            // 
            this.divider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider.Location = new System.Drawing.Point(400, 0);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(2, 870);
            this.divider.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(876, 1005);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.macrosLabel);
            this.Controls.Add(this.tagsLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AndPerTag";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.Label macrosLabel;
        private System.Windows.Forms.Label divider;
    }
}

