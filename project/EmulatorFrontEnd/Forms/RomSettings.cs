using System;
using System.Windows.Forms;

namespace NewEmulatorFrontEnd
{
    public partial class RomSettings : Form
    {
        // Static
        public static void Edit(Rom r) { new RomSettings(r); }
        
        // Dialog Instance
        Rom _currRom;

        RomSettings() { InitializeComponent(); }
        RomSettings(Rom rom) : this()
        {
            SetRom(rom);
            ShowDialog();
        }
        
        // sets the given rom for editting
        void SetRom(Rom r )
        {
            _currRom = r;

            romFileName.Text = r.fileName;
            romCleanName.Text = r.name;

            displayName.Text = r.displayName;
            tags.Text = r.tags;

            maxPlayers.SelectedIndex = r.players > 0 ? r.players : 0;
        }

        #region Events
        private void cancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void saveClick(object sender, EventArgs e)
        {
            _currRom.displayName = displayName.Text;
            _currRom.tags = tags.Text;
            _currRom.players = maxPlayers.SelectedIndex;
            _currRom.players = _currRom.players  == 0 ? -1 : _currRom.players;

            RomManager.SaveOutRomSettings();

            Close();
        }
        
        private void restoreDefaultsClick(object sender, EventArgs e)
        {
            displayName.Text = _currRom.name;
            tags.Text = "";
            maxPlayers.SelectedIndex = 0;
        }
        #endregion
    }
}
