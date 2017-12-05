using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace NewEmulatorFrontEnd {
    // middleman used to update the front end with data from the RomManager
    class FrontEndUpdater {
        // loads the consoles into the combobox
        public static void LoadConsoles(ComboBox cb) {
            int origIndex = cb.SelectedIndex;

            cb.Items.Clear();
            cb.Items.Add("All");
            foreach (Console c in RomManager.GetConsoles()) {
                if (RomManager.GetRoms(c).Count <= 0) continue;
                cb.Items.Add(c.displayName);
            }

            origIndex = Math.Max(Math.Min(origIndex, cb.Items.Count - 1), 0);
            cb.SelectedIndex = origIndex;
        }

        // loads the roms into the listbox
        public static void LoadConsolesRoms(ListBox romList, string console, string filter = "", int minPlayers = 0) {
            ReadOnlyCollection<Rom> roms;
            if (console == "All") roms = RomManager.GetRoms();
            else roms = RomManager.GetRoms(console);

            int origIndex = romList.SelectedIndex;
            romList.Items.Clear();

            // get all search terms into an array
            string[] terms = filter.Split(new char[] { ',', ' ', '\t' });
            for (int i = 0; i < terms.Length; i++) terms[i] = terms[i].ToLower().Trim();

            System.Console.WriteLine(roms.Count);

            // filter the games
            foreach (Rom r in roms) {
                // check if the games have less than the desired number of players, dont add it
                bool playerMatch = minPlayers == 0 || r.players >= minPlayers;

                //see if it matches the tags
                bool tagMatch = false;
                string match = r.tags.ToLower() + r.displayName.ToLower();
                foreach (string term in terms) tagMatch |= match.Contains(term);

                if (playerMatch && tagMatch) romList.Items.Add(r);
            }

            origIndex = Math.Min(origIndex, romList.Items.Count - 1);
            romList.SelectedIndex = origIndex;
        }
    }
}
