namespace AndPerTagCore.Forms
{
    partial class TagForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.tagLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(50, 99);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(442, 27);
            this.nameTextBox.TabIndex = 0;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(446, 152);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(94, 29);
            this.acceptButton.TabIndex = 2;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(47, 67);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(125, 29);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tagLabel
            // 
            this.tagLabel.AutoSize = true;
            this.tagLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tagLabel.Location = new System.Drawing.Point(27, 25);
            this.tagLabel.Name = "tagLabel";
            this.tagLabel.Size = new System.Drawing.Size(54, 32);
            this.tagLabel.TabIndex = 5;
            this.tagLabel.Text = "Tag";
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.Color = System.Drawing.Color.LemonChiffon;
            this.colorDialog.FullOpen = true;
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(509, 98);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(31, 29);
            this.colorButton.TabIndex = 6;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // colorLabel
            // 
            this.colorLabel.Location = new System.Drawing.Point(505, 67);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(94, 29);
            this.colorLabel.TabIndex = 4;
            this.colorLabel.Text = "Color";
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TagForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(571, 196);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.tagLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.nameTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "nameLabel";
            this.Text = "AndPerTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label colorLabel;
        public System.Windows.Forms.TextBox nameTextBox;
        public System.Windows.Forms.Button colorButton;
        public System.Windows.Forms.ColorDialog colorDialog;
        public System.Windows.Forms.Button acceptButton;
        public System.Windows.Forms.Label tagLabel;
    }
}