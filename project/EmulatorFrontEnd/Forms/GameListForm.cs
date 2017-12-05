using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EmulatorFrontEnd
{
    public partial class GameList : Form
    {

        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);


        //search box text
        const string SEARCH_BOX_TEXT = "Filter by name or tags";

        //initialization
        public GameList()
        {
            InitializeComponent();
            SearchUnfocus(null, null);

            playerFilter.SelectedIndex = 0;

            GenerateSettingsButtons();
            RefreshAll();

            RegisterHotKey(this.Handle, 1203948, 2, (int)Keys.Q);
        }

        //way for app to get CTRL+Q keypress from anywhere
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == 1203948)
            {

                RomManager.StopEmulator();
            }
            base.WndProc(ref m);
        }

        #region Rom Settings Edit
        //generate the gear icons for the list
        List<PictureBox> _gearIcons = new List<PictureBox>();
        List<Label> _playerTex = new List<Label>();
        void GenerateSettingsButtons()
        {
            const int GEAR_DIM = 17;
            int TOP_PADDING = romsList.Location.Y + 2;
            int LEFT_PADDING = romsList.Location.X - 36;


            //add callbacks for icon show
            EventHandler mouseEnterFunc = delegate(object sender, EventArgs e)
            {
                (sender as PictureBox).Image = GearResource.Image;
                (sender as PictureBox).Cursor = Cursors.Hand;
            };

            //icon hide
            EventHandler mouseExitFunc = delegate(object sender, EventArgs e)
            {
                (sender as PictureBox).Image = GearLightResource.Image;
            };

            //figuring out which index it is
            EventHandler mouseClickFunc = delegate(object sender, EventArgs e)
            {
                int distFromTopOfList = (sender as PictureBox).Location.Y - TOP_PADDING + romsList.TopIndex * 17;
                int index = distFromTopOfList / 17;

                string romName = romsList.Items[index].ToString();

                RomSettings.Edit(romsList.Items[index] as Rom);
            };

            for (int i = 0; i < romsList.Height / GEAR_DIM ; i ++ )
            {
                if (i < _gearIcons.Count) continue;





                Label tb = new Label();
                tb.Width = 50;
                tb.Height = GEAR_DIM;
                tb.BackColor = Color.White;
                tb.Text = "";
                tb.ForeColor = Color.FromArgb(180, 180, 180);

                tb.Location = new Point(LEFT_PADDING + romsList.Width - 45, TOP_PADDING + i * GEAR_DIM );

                this.Controls.Add(tb);
                tb.BringToFront();
                _playerTex.Add(tb);



                //create the picture
                PictureBox pb = new PictureBox();
                pb.Image = GearLightResource.Image;
                pb.Width = GEAR_DIM;
                pb.Height = GEAR_DIM;
                pb.BackColor = Color.White;

                //place it
                pb.Location = new Point(LEFT_PADDING + romsList.Width, TOP_PADDING + i * GEAR_DIM);

                //add callbacks
                pb.MouseEnter += mouseEnterFunc;
                pb.MouseLeave += mouseExitFunc;
                pb.Click += mouseClickFunc;

                //add it on top
                this.Controls.Add(pb);
                pb.BringToFront();

                //store it in the array
                _gearIcons.Add(pb);
            }

            GearLightResource.Visible = false;
            GearResource.Visible = false;
        }
        //refresh the positions of the gear icons
        void RefreshGearSettingsButtons()
        {
            for (int i = 0; i < _gearIcons.Count; i++)
            {
                bool atFilledRow = i < romsList.Items.Count;

                _playerTex[i].Visible = false;// atFilledRow;
                _gearIcons[i].Visible = atFilledRow;

                if (!atFilledRow) continue;


                int xPos = romsList.Location.X + romsList.Width - 36;
                if (romsList.Items.Count <= _gearIcons.Count) xPos += 18;

                _gearIcons[i].Location = new Point( xPos , _gearIcons[i].Location.Y);


                int index = i + romsList.TopIndex;
                int players = (romsList.Items[index] as Rom).players;
                
                string text = players + " Player";
                if (players == -1) text = "";
                _playerTex[i].Text = text;

                
            }
        }

        #endregion

        #region Helpers
        //refetches the rom list
        void RefetchRomList()
        {
            if (consoleBox.SelectedIndex == -1) return;

            string searchText = searchBox.Text;
            if (searchBox.ForeColor == Color.Gray) searchText = "";

            FrontEndUpdater.LoadConsolesRoms(romsList, consoleBox.SelectedItem.ToString(), searchText, playerFilter.SelectedIndex );

            RefreshGearSettingsButtons();
        }
        //refreshes everything (Fires refetch)
        void RefreshAll()
        {
            RomManager.RefreshRomList();
            FrontEndUpdater.LoadConsoles(consoleBox);
        }
        //plays the selected game
        void PlayGame()
        {
            RomManager.RunEmulator((Rom)romsList.SelectedItem);
        }
        //opens the emulator for the selected console
        void OpenEmu()
        {
            string console = (romsList.SelectedItem as Rom).console.displayName;
            RomManager.RunEmulator(console);
        }
        #endregion

        #region Search Box
        //filter the games if the text changes, show all if text is empty
        private void SearchOnTextChanged(object sender, EventArgs e)
        {
            if (searchBox.ForeColor == Color.Gray) return;
            RefetchRomList();

            if (searchBox.Text == "")
            {
                SearchClearButton.Visible = false;
            }
            else
            {
                SearchClearButton.Visible = true;
                SearchClearButton_MouseLeave(null, null);
            }
        }

        //hide the text if it's the search text
        private void SearchFocus(object sender, EventArgs e)
        {
            if (searchBox.ForeColor == Color.Gray )
            {
                searchBox.Text = "";
                searchBox.ForeColor = Color.Black;
            }
        }

        //show the the search text if the field is empty
        private void SearchUnfocus(object sender, EventArgs e)
        {
            if ( searchBox.Text == "")
            {
                searchBox.ForeColor = Color.Gray;
                searchBox.Text = SEARCH_BOX_TEXT;
            }
        }
        #endregion

        #region Other Buttons
        //refresh everything when the refresh button is clicked
        private void RefreshButtonClick(object sender, EventArgs e)
        {
            RefreshAll();
        }
        //open the settings for the application when the button is clicked
        private void SettingsButtonClick(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
        //open the emulator when the button is pressed
        private void OpenEmuButtonClick(object sender, EventArgs e)
        {
            OpenEmu();
        }
        #endregion

        #region Console and Rom Lists
        //when the console list changes, refresh the rom list
        private void ConsoleListChanged(object sender, EventArgs e)
        {
            RefetchRomList();
        }
        //when a rom is clicked, open it
        private void RomListDoubleClick(object sender, EventArgs e)
        {
            PlayGame();
        }
        //when the play button is clicked, open it
        private void PlayButtonClick(object sender, EventArgs e)
        {
            PlayGame();
        }
        //key events for navigating the game list with keyboard keys
        private void RomListKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (consoleBox.SelectedIndex - 1 < 0) consoleBox.SelectedIndex = consoleBox.Items.Count - 1;
                    else consoleBox.SelectedIndex--;

                    romsList.SelectedIndex = Math.Min( romsList.SelectedIndex + 1, romsList.Items.Count - 1 );

                    break;
                case Keys.Right:
                    
                    if (consoleBox.SelectedIndex + 1 >= consoleBox.Items.Count) consoleBox.SelectedIndex = 0;
                    else consoleBox.SelectedIndex++;

                    if (romsList.SelectedIndex != romsList.Items.Count - 1)
                    {
                        romsList.SelectedIndex = romsList.SelectedIndex = Math.Min(romsList.SelectedIndex - 1, romsList.Items.Count - 1);
                    }
                    break;
                case Keys.Up:
                    break;
                case Keys.Down:
                    break;

                case Keys.Enter:
                    PlayGame();
                    break;
            }
        }
        #endregion
        
        #region Application Loop
        //when the application loads
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //used to regulate the frames persecond to 60
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Show();

            Label[] dots = 
                {
                    controllerDot0, 
                    controllerDot1, 
                    controllerDot2, 
                    controllerDot3 
                };

            //run the loop here
            while (!this.IsDisposed)
            {
                //Console.WriteLine(stopwatch.Elapsed);
                //if the ellapsed frame time has ellapsed, do work and restart the timer
                if (stopwatch.ElapsedMilliseconds >= 16)
                {
                    ControllerUpdater.UpdateDots(dots);

                    stopwatch.Restart();

                    Enabled = !RomManager.IsEmulatorRunning();
                    openEmulatorButton.Enabled = (romsList.SelectedIndex != -1);
                }



                //allow the form app to call its events
                Application.DoEvents();
            }
        }

        //refetch everything when the application is refocused on to verify that the roms are up to date
        private void OnApplicationActivated(object sender, EventArgs e)
        {
            RefreshAll();
        }
        #endregion

        #region Searchbox Clear Button
        //when hovering over the search's "X", darken it
        private void SearchClearButton_HoverEnter(object sender, EventArgs e)
        {
            SearchClearButton.ForeColor = Color.FromArgb(60, 60, 60);
            SearchClearButton.Cursor = Cursors.Hand;
        }
        //lighten it when leaving
        private void SearchClearButton_MouseLeave(object sender, EventArgs e)
        {
            SearchClearButton.ForeColor = Color.FromArgb(150, 150, 150);
        }
        //clear the search field after clicking it
        private void SearchClearButton_MouseClick(object sender, MouseEventArgs e)
        {
            searchBox.Text = "";
            SearchUnfocus(null, null);
        }
        #endregion

        //refresh the rom list when the player filter changes
        private void playerFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefetchRomList();
        }
    }
}
