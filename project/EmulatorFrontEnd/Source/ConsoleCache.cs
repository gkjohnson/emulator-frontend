using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace NewEmulatorFrontEnd
{
    static class ConsoleCache
    {
        // Parsing Constants
        const string CONSOLE_CMD_FILE           = "consoleCmd.txt";
        const string ROM_SETTINGS_FILE          = "romSettings.txt";
        const string SEPERATOR_TOKEN            = "|";
        static readonly string[] ILLEGAL_EXT    = { ".wbf1" };

        // Cached Data
        static Dictionary<string, Console> _consoles = new Dictionary<string, Console>();
        static Dictionary<string, Rom> _roms = new Dictionary<string, Rom>();
        static Dictionary<Console, List<Rom>> _consoleRoms = new Dictionary<Console, List<Rom>>();
        static List<Console> _consoleList = new List<Console>();
        static List<Rom> _romList = new List<Rom>();

        // Getters
        public static ReadOnlyCollection<Console> Consoles { get { return _consoleList.AsReadOnly(); } }
        public static ReadOnlyCollection<Rom> Roms { get { return _romList.AsReadOnly(); } }

        public static ReadOnlyCollection<Rom> GetRoms(string console) { return _consoles.ContainsKey(console) ? GetRoms(_consoles[console]) : null; }
        public static ReadOnlyCollection<Rom> GetRoms(Console console) { return _consoleRoms.ContainsKey(console) ? _consoleRoms[console].AsReadOnly() : null; }
        public static Console GetConsole(string console) { return _consoles.ContainsKey(console) ? _consoles[console] : null; }

        #region API
        public static void Load()
        {
            Refresh();
        }

        public static void Refresh()
        {
            _consoles.Clear();
            _roms.Clear();
            _consoleRoms.Clear();

            _consoleList.Clear();
            _romList.Clear();

            LoadConsoles();
            LoadRoms();
        }
        
        public static void Save(List<Console> consoles = null)
        {
            SaveConsoleDirectories(consoles);
            SaveRomSettings();

            Refresh();
        }
        #endregion

        #region Load Functions
        // Load all Console information
        static void LoadConsoles()
        {
            if (!File.Exists(CONSOLE_CMD_FILE)) return;

            string[] lines = File.ReadAllLines(CONSOLE_CMD_FILE);
            string[] splitChars = new string[] { SEPERATOR_TOKEN };

            foreach (string s in lines)
            {
                // Format
                // displayName | execPath | cmdArgs | romDir

                string[] split = s.Split(splitChars, StringSplitOptions.None);


                string name =       split.Length >= 1 ? split[0] : "";
                string execPath =   split.Length >= 2 ? split[1] : "";
                string cmdArgs =    split.Length >= 3 ? split[2] : "";
                string romDir =     split.Length >= 4 ? split[3] : "";

                Console console = new Console(execPath, name, cmdArgs, romDir);
                
                if (_consoles.ContainsKey(console.displayName)) continue;
                
                _consoles.Add(console.displayName, console);
                _consoleList.Add(console);
            }
        }

        // Load the roms associated with the loaded consoles
        static void LoadRoms()
        {
            foreach (var kv in _consoles)
            {
                Console console = kv.Value;
                List<Rom> roms = new List<Rom>();
                _consoleRoms.Add(console, roms);

                string dir = console.romDirectory.Replace(".\\", Directory.GetCurrentDirectory() + "\\");
                if (!Directory.Exists(dir)) continue;

                string[] files = Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
                foreach (var location in files)
                {
                    Rom rom = new Rom(location, console);

                    // TODO: Ensure this rom hasn't been added

                    // Ensure we're not using an illegal extension
                    bool illegalExtension = false;
                    foreach (string ext in ILLEGAL_EXT)
                    {
                        illegalExtension |= rom.fileName.ToLower().Contains(ext);
                    }

                    if (illegalExtension) continue;

                    _roms.Add(rom.fileName, rom);
                    _romList.Add(rom);
                    roms.Add(rom);
                }

                // Apply Rom Settings
                LoadRomSettings();
            }
        }

        // Load the extra settings from file
        static void LoadRomSettings()
        {
            if (!File.Exists(ROM_SETTINGS_FILE)) return;

            string[] lines = File.ReadAllLines(ROM_SETTINGS_FILE);

            foreach(string line in lines)
            {
                // Format
                // fileName | displayName | tags | players
                string[] param = line.Split(new string[] { SEPERATOR_TOKEN }, StringSplitOptions.None);

                try
                {
                    string fileName     = param[0].Trim();
                    string displayName  = param[1].Trim();
                    string tags         = param[2].Trim();
                    string players      = param[3].Trim();

                    Rom rom = _roms[fileName];

                    if (displayName != "") rom.displayName = displayName;
                    rom.tags = tags;
                    if (players != "") rom.players = int.Parse(players);
                }
                catch
                {
                    continue;
                }
            }
        }
        #endregion

        #region Save Functions
        // Save the state of the console settings
        static void SaveConsoleDirectories(List<Console> consoles = null)
        {
            if (consoles == null) consoles = _consoleList;

            string s = "";
            foreach(var kv in _consoles)
            {
                Console c = kv.Value;

                if (c.displayName + c.executableDirectory + c.executableName + c.cmdArguments + c.romDirectory == "") continue;

                s += c.displayName + SEPERATOR_TOKEN;
                s += c.executableDirectory + c.executableName + SEPERATOR_TOKEN;
                s += c.cmdArguments + SEPERATOR_TOKEN;
                s += c.romDirectory + '\n';
            }

            if (s != "") File.WriteAllText(CONSOLE_CMD_FILE, s);
            else File.Delete(CONSOLE_CMD_FILE);
        }

        // Save the rom settings
        static void SaveRomSettings()
        {
            string s = "";

            foreach(var kv in _roms)
            {
                Rom rom = kv.Value;

                bool nameChanged = rom.displayName != rom.name && rom.displayName != "";
                bool tagsChanged = rom.tags != "";
                bool playersChanged = rom.players != -1;

                s += rom.fileName + SEPERATOR_TOKEN;
                s += (nameChanged ? rom.displayName : "") + SEPERATOR_TOKEN;
                s += (tagsChanged ? rom.tags : "") + SEPERATOR_TOKEN;
                s += (playersChanged ? rom.players.ToString() : "") + "\n";
            }

            if (s != "") File.WriteAllText(ROM_SETTINGS_FILE, s);
            else File.Delete(ROM_SETTINGS_FILE);
        }
        #endregion
    }
}
