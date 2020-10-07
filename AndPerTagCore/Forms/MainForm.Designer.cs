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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.createTagButton = new System.Windows.Forms.Button();
            this.splitter = new System.Windows.Forms.Label();
            this.tagLabel = new System.Windows.Forms.Label();
            this.addMacroButton = new System.Windows.Forms.Button();
            this.macrosLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AndPerTag - Macros";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(64, 24);
            this.toolStripMenuItem1.Text = "&About";
            // 
            // splitContainer
            // 
            this.splitContainer.CausesValidation = false;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 28);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.createTagButton);
            this.splitContainer.Panel1.Controls.Add(this.splitter);
            this.splitContainer.Panel1.Controls.Add(this.tagLabel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.addMacroButton);
            this.splitContainer.Panel2.Controls.Add(this.macrosLabel);
            this.splitContainer.Size = new System.Drawing.Size(882, 825);
            this.splitContainer.SplitterDistance = 435;
            this.splitContainer.SplitterWidth = 10;
            this.splitContainer.TabIndex = 3;
            this.splitContainer.Text = "splitContainer1";
            // 
            // createTagButton
            // 
            this.createTagButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.createTagButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTagButton.Image = ((System.Drawing.Image)(resources.GetObject("createTagButton.Image")));
            this.createTagButton.Location = new System.Drawing.Point(355, 40);
            this.createTagButton.Name = "createTagButton";
            this.createTagButton.Size = new System.Drawing.Size(40, 40);
            this.createTagButton.TabIndex = 2;
            this.createTagButton.UseVisualStyleBackColor = false;
            this.createTagButton.Click += new System.EventHandler(this.createTagButton_Click);
            // 
            // splitter
            // 
            this.splitter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter.Location = new System.Drawing.Point(434, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(2, 800);
            this.splitter.TabIndex = 1;
            // 
            // tagLabel
            // 
            this.tagLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tagLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tagLabel.Location = new System.Drawing.Point(28, 27);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(252, 57);
            this.tagLabel.TabIndex = 0;
            this.tagLabel.Text = "Tags";
            this.tagLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addMacroButton
            // 
            this.addMacroButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addMacroButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addMacroButton.Image = ((System.Drawing.Image)(resources.GetObject("addMacroButton.Image")));
            this.addMacroButton.Location = new System.Drawing.Point(364, 40);
            this.addMacroButton.Name = "addMacroButton";
            this.addMacroButton.Size = new System.Drawing.Size(40, 40);
            this.addMacroButton.TabIndex = 2;
            this.addMacroButton.UseVisualStyleBackColor = false;
            this.addMacroButton.Click += new System.EventHandler(this.addMacroButton_Click);
            // 
            // macrosLabel
            // 
            this.macrosLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.macrosLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.macrosLabel.Location = new System.Drawing.Point(28, 27);
            this.macrosLabel.Name = "macrosLabel";
            this.macrosLabel.Size = new System.Drawing.Size(252, 57);
            this.macrosLabel.TabIndex = 0;
            this.macrosLabel.Text = "Macros";
            this.macrosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(882, 853);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AndPerTag";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label tagLabel;
        private System.Windows.Forms.Label macrosLabel;
        public System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label splitter;
        private System.Windows.Forms.Button createTagButton;
        private System.Windows.Forms.Button addMacroButton;
    }
}

