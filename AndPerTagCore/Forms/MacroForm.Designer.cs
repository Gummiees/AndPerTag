namespace AndPerTagCore.Forms
{
    partial class MacroForm
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
            this.macroLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tagLabel = new System.Windows.Forms.Label();
            this.tagComboBox = new System.Windows.Forms.ComboBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // macroLabel
            // 
            this.macroLabel.AutoSize = true;
            this.macroLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.macroLabel.Location = new System.Drawing.Point(37, 37);
            this.macroLabel.Name = "macroLabel";
            this.macroLabel.Size = new System.Drawing.Size(87, 32);
            this.macroLabel.TabIndex = 5;
            this.macroLabel.Text = "Macro";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(57, 121);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(361, 27);
            this.nameTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(57, 89);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(125, 29);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tagLabel
            // 
            this.tagLabel.Location = new System.Drawing.Point(455, 89);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(125, 29);
            this.tagLabel.TabIndex = 4;
            this.tagLabel.Text = "Tag";
            this.tagLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tagComboBox
            // 
            this.tagComboBox.FormattingEnabled = true;
            this.tagComboBox.Location = new System.Drawing.Point(455, 122);
            this.tagComboBox.Name = "tagComboBox";
            this.tagComboBox.Size = new System.Drawing.Size(368, 28);
            this.tagComboBox.TabIndex = 6;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(729, 493);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(94, 29);
            this.acceptButton.TabIndex = 7;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(57, 200);
            this.textTextBox.Multiline = true;
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(766, 272);
            this.textTextBox.TabIndex = 8;
            // 
            // textLabel
            // 
            this.textLabel.Location = new System.Drawing.Point(57, 168);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(125, 29);
            this.textLabel.TabIndex = 4;
            this.textLabel.Text = "Text";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // MacroForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(853, 542);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.textTextBox);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.tagComboBox);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.macroLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MacroForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AndPerTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label tagLabel;
        public System.Windows.Forms.TextBox nameTextBox;
        public System.Windows.Forms.Label macroLabel;
        public System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label textLabel;
        public System.Windows.Forms.TextBox textTextBox;
        public System.Windows.Forms.ComboBox tagComboBox;
    }
}