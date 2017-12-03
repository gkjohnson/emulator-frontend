namespace NewEmulatorFrontEnd
{
    partial class GameList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameList));
            this.button1 = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.romsList = new System.Windows.Forms.ListBox();
            this.consoleBox = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openEmulatorButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.controllerDot3 = new System.Windows.Forms.Label();
            this.controllerDot2 = new System.Windows.Forms.Label();
            this.controllerDot1 = new System.Windows.Forms.Label();
            this.controllerDot0 = new System.Windows.Forms.Label();
            this.SearchClearButton = new System.Windows.Forms.Label();
            this.GearLightResource = new System.Windows.Forms.PictureBox();
            this.playerFilter = new System.Windows.Forms.ComboBox();
            this.GearResource = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GearLightResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GearResource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 530);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Play Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PlayButtonClick);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(265, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // romsList
            // 
            this.romsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.romsList.FormattingEnabled = true;
            this.romsList.ItemHeight = 17;
            this.romsList.Location = new System.Drawing.Point(15, 73);
            this.romsList.Name = "romsList";
            this.romsList.Size = new System.Drawing.Size(404, 446);
            this.romsList.Sorted = true;
            this.romsList.TabIndex = 3;
            this.romsList.DoubleClick += new System.EventHandler(this.RomListDoubleClick);
            this.romsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RomListKeyDown);
            // 
            // consoleBox
            // 
            this.consoleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.consoleBox.FormattingEnabled = true;
            this.consoleBox.Location = new System.Drawing.Point(15, 13);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.Size = new System.Drawing.Size(243, 21);
            this.consoleBox.TabIndex = 4;
            this.consoleBox.SelectedIndexChanged += new System.EventHandler(this.ConsoleListChanged);
            // 
            // searchBox
            // 
            this.searchBox.ForeColor = System.Drawing.Color.Black;
            this.searchBox.Location = new System.Drawing.Point(15, 40);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(325, 20);
            this.searchBox.TabIndex = 5;
            this.searchBox.TextChanged += new System.EventHandler(this.SearchOnTextChanged);
            this.searchBox.Enter += new System.EventHandler(this.SearchFocus);
            this.searchBox.Leave += new System.EventHandler(this.SearchUnfocus);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(345, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SettingsButtonClick);
            // 
            // openEmulatorButton
            // 
            this.openEmulatorButton.Location = new System.Drawing.Point(226, 530);
            this.openEmulatorButton.Name = "openEmulatorButton";
            this.openEmulatorButton.Size = new System.Drawing.Size(94, 23);
            this.openEmulatorButton.TabIndex = 7;
            this.openEmulatorButton.Text = "Open Emulator";
            this.openEmulatorButton.UseVisualStyleBackColor = true;
            this.openEmulatorButton.Click += new System.EventHandler(this.OpenEmuButtonClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(27, 527);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 37);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // controllerDot3
            // 
            this.controllerDot3.AutoSize = true;
            this.controllerDot3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerDot3.Location = new System.Drawing.Point(407, 545);
            this.controllerDot3.Name = "controllerDot3";
            this.controllerDot3.Size = new System.Drawing.Size(20, 26);
            this.controllerDot3.TabIndex = 11;
            this.controllerDot3.Text = "•";
            // 
            // controllerDot2
            // 
            this.controllerDot2.AutoSize = true;
            this.controllerDot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerDot2.Location = new System.Drawing.Point(392, 545);
            this.controllerDot2.Name = "controllerDot2";
            this.controllerDot2.Size = new System.Drawing.Size(20, 26);
            this.controllerDot2.TabIndex = 12;
            this.controllerDot2.Text = "•";
            // 
            // controllerDot1
            // 
            this.controllerDot1.AutoSize = true;
            this.controllerDot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerDot1.Location = new System.Drawing.Point(377, 545);
            this.controllerDot1.Name = "controllerDot1";
            this.controllerDot1.Size = new System.Drawing.Size(20, 26);
            this.controllerDot1.TabIndex = 13;
            this.controllerDot1.Text = "•";
            // 
            // controllerDot0
            // 
            this.controllerDot0.AutoSize = true;
            this.controllerDot0.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controllerDot0.Location = new System.Drawing.Point(362, 545);
            this.controllerDot0.Name = "controllerDot0";
            this.controllerDot0.Size = new System.Drawing.Size(20, 26);
            this.controllerDot0.TabIndex = 14;
            this.controllerDot0.Text = "•";
            // 
            // SearchClearButton
            // 
            this.SearchClearButton.AutoSize = true;
            this.SearchClearButton.BackColor = System.Drawing.Color.White;
            this.SearchClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchClearButton.ForeColor = System.Drawing.Color.Black;
            this.SearchClearButton.Location = new System.Drawing.Point(323, 43);
            this.SearchClearButton.Name = "SearchClearButton";
            this.SearchClearButton.Size = new System.Drawing.Size(14, 13);
            this.SearchClearButton.TabIndex = 15;
            this.SearchClearButton.Text = "X";
            this.SearchClearButton.Visible = false;
            this.SearchClearButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchClearButton_MouseClick);
            this.SearchClearButton.MouseEnter += new System.EventHandler(this.SearchClearButton_HoverEnter);
            this.SearchClearButton.MouseLeave += new System.EventHandler(this.SearchClearButton_MouseLeave);
            // 
            // GearLightResource
            // 
            this.GearLightResource.BackColor = System.Drawing.Color.White;
            this.GearLightResource.Image = ((System.Drawing.Image)(resources.GetObject("GearLightResource.Image")));
            this.GearLightResource.InitialImage = null;
            this.GearLightResource.Location = new System.Drawing.Point(282, 116);
            this.GearLightResource.Name = "GearLightResource";
            this.GearLightResource.Size = new System.Drawing.Size(17, 17);
            this.GearLightResource.TabIndex = 16;
            this.GearLightResource.TabStop = false;
            // 
            // playerFilter
            // 
            this.playerFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerFilter.FormattingEnabled = true;
            this.playerFilter.Items.AddRange(new object[] {
            "Any Player",
            "1 Player",
            "2 Player",
            "3 Player",
            "4 Player"});
            this.playerFilter.Location = new System.Drawing.Point(346, 39);
            this.playerFilter.Name = "playerFilter";
            this.playerFilter.Size = new System.Drawing.Size(73, 21);
            this.playerFilter.TabIndex = 17;
            this.playerFilter.SelectedIndexChanged += new System.EventHandler(this.playerFilter_SelectedIndexChanged);
            // 
            // GearResource
            // 
            this.GearResource.BackColor = System.Drawing.Color.White;
            this.GearResource.Image = ((System.Drawing.Image)(resources.GetObject("GearResource.Image")));
            this.GearResource.InitialImage = null;
            this.GearResource.Location = new System.Drawing.Point(282, 152);
            this.GearResource.Name = "GearResource";
            this.GearResource.Size = new System.Drawing.Size(17, 17);
            this.GearResource.TabIndex = 18;
            this.GearResource.TabStop = false;
            // 
            // GameList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 565);
            this.Controls.Add(this.GearLightResource);
            this.Controls.Add(this.GearResource);
            this.Controls.Add(this.playerFilter);
            this.Controls.Add(this.SearchClearButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.openEmulatorButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.romsList);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.controllerDot3);
            this.Controls.Add(this.controllerDot2);
            this.Controls.Add(this.controllerDot1);
            this.Controls.Add(this.controllerDot0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameList";
            this.Text = "Open Game";
            this.Activated += new System.EventHandler(this.OnApplicationActivated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RomListKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GearLightResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GearResource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ListBox romsList;
        private System.Windows.Forms.ComboBox consoleBox;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button openEmulatorButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label controllerDot3;
        private System.Windows.Forms.Label controllerDot2;
        private System.Windows.Forms.Label controllerDot1;
        private System.Windows.Forms.Label controllerDot0;
        private System.Windows.Forms.Label SearchClearButton;
        private System.Windows.Forms.PictureBox GearLightResource;
        private System.Windows.Forms.ComboBox playerFilter;
        private System.Windows.Forms.PictureBox GearResource;
    }
}

