namespace NewEmulatorFrontEnd
{
    partial class SettingsForm
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
            this.settingsContainer = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.consoleNameLabel = new System.Windows.Forms.Label();
            this.executableLabel = new System.Windows.Forms.Label();
            this.argumentsLabel = new System.Windows.Forms.Label();
            this.romDirLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // settingsContainer
            // 
            this.settingsContainer.AutoScroll = true;
            this.settingsContainer.Location = new System.Drawing.Point(12, 29);
            this.settingsContainer.Name = "settingsContainer";
            this.settingsContainer.Size = new System.Drawing.Size(844, 323);
            this.settingsContainer.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(700, 358);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(781, 358);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
            // 
            // consoleNameLabel
            // 
            this.consoleNameLabel.AutoSize = true;
            this.consoleNameLabel.Location = new System.Drawing.Point(12, 13);
            this.consoleNameLabel.Name = "consoleNameLabel";
            this.consoleNameLabel.Size = new System.Drawing.Size(76, 13);
            this.consoleNameLabel.TabIndex = 0;
            this.consoleNameLabel.Text = "Console Name";
            this.consoleNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // executableLabel
            // 
            this.executableLabel.AutoSize = true;
            this.executableLabel.Location = new System.Drawing.Point(146, 13);
            this.executableLabel.Name = "executableLabel";
            this.executableLabel.Size = new System.Drawing.Size(60, 13);
            this.executableLabel.TabIndex = 1;
            this.executableLabel.Text = "Executable";
            this.executableLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // argumentsLabel
            // 
            this.argumentsLabel.AutoSize = true;
            this.argumentsLabel.Location = new System.Drawing.Point(314, 13);
            this.argumentsLabel.Name = "argumentsLabel";
            this.argumentsLabel.Size = new System.Drawing.Size(57, 13);
            this.argumentsLabel.TabIndex = 2;
            this.argumentsLabel.Text = "Arguments";
            this.argumentsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // romDirLabel
            // 
            this.romDirLabel.AutoSize = true;
            this.romDirLabel.Location = new System.Drawing.Point(479, 13);
            this.romDirLabel.Name = "romDirLabel";
            this.romDirLabel.Size = new System.Drawing.Size(74, 13);
            this.romDirLabel.TabIndex = 3;
            this.romDirLabel.Text = "Rom Directory";
            this.romDirLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 393);
            this.Controls.Add(this.romDirLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.argumentsLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.executableLabel);
            this.Controls.Add(this.settingsContainer);
            this.Controls.Add(this.consoleNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel settingsContainer;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label romDirLabel;
        private System.Windows.Forms.Label argumentsLabel;
        private System.Windows.Forms.Label executableLabel;
        private System.Windows.Forms.Label consoleNameLabel;

    }
}