namespace NewEmulatorFrontEnd
{
    partial class RomSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.displayName = new System.Windows.Forms.TextBox();
            this.tags = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxPlayers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.romFileName = new System.Windows.Forms.TextBox();
            this.romCleanName = new System.Windows.Forms.TextBox();
            this.romRestoreDefaults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Display Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tags";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(300, 108);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(58, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(236, 108);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(58, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveClick);
            // 
            // displayName
            // 
            this.displayName.Location = new System.Drawing.Point(92, 57);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(266, 20);
            this.displayName.TabIndex = 6;
            // 
            // tags
            // 
            this.tags.Location = new System.Drawing.Point(91, 83);
            this.tags.Name = "tags";
            this.tags.Size = new System.Drawing.Size(267, 20);
            this.tags.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Max Players";
            // 
            // maxPlayers
            // 
            this.maxPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxPlayers.FormattingEnabled = true;
            this.maxPlayers.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4"});
            this.maxPlayers.Location = new System.Drawing.Point(92, 109);
            this.maxPlayers.Name = "maxPlayers";
            this.maxPlayers.Size = new System.Drawing.Size(34, 21);
            this.maxPlayers.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "File Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Clean Name";
            // 
            // romFileName
            // 
            this.romFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.romFileName.Location = new System.Drawing.Point(92, 10);
            this.romFileName.Name = "romFileName";
            this.romFileName.ReadOnly = true;
            this.romFileName.Size = new System.Drawing.Size(266, 13);
            this.romFileName.TabIndex = 12;
            // 
            // romCleanName
            // 
            this.romCleanName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.romCleanName.Location = new System.Drawing.Point(92, 33);
            this.romCleanName.Name = "romCleanName";
            this.romCleanName.ReadOnly = true;
            this.romCleanName.Size = new System.Drawing.Size(266, 13);
            this.romCleanName.TabIndex = 13;
            // 
            // romRestoreDefaults
            // 
            this.romRestoreDefaults.Location = new System.Drawing.Point(132, 108);
            this.romRestoreDefaults.Name = "romRestoreDefaults";
            this.romRestoreDefaults.Size = new System.Drawing.Size(98, 23);
            this.romRestoreDefaults.TabIndex = 14;
            this.romRestoreDefaults.Text = "Restore Defaults";
            this.romRestoreDefaults.UseVisualStyleBackColor = true;
            this.romRestoreDefaults.Click += new System.EventHandler(this.restoreDefaultsClick);
            // 
            // RomSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 141);
            this.Controls.Add(this.romRestoreDefaults);
            this.Controls.Add(this.romCleanName);
            this.Controls.Add(this.romFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxPlayers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tags);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RomSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "RomSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox displayName;
        private System.Windows.Forms.TextBox tags;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox maxPlayers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox romFileName;
        private System.Windows.Forms.TextBox romCleanName;
        private System.Windows.Forms.Button romRestoreDefaults;
    }
}