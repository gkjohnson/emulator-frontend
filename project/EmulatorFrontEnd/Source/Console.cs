using System.Text.RegularExpressions;

namespace EmulatorFrontEnd {
    // Information about a rom
    public class Rom {
        readonly Regex PAREN_REGEX = new Regex("\\(.*\\)");

        public string location { get; private set; }
        public Console console { get; private set; }
        public string displayName = "";
        public string tags = "";
        public int players = -1;

        public string fileName {
            get {
                int lastTokenStart = location.LastIndexOf('\\');
                int fileNameLength = location.Length - lastTokenStart - 1;
                return location.Substring(lastTokenStart + 1, fileNameLength);
            }
        }

        public string name {
            get {
                string name = fileName;

                // Remove the file extension
                int nameLength = name.LastIndexOf('.');
                if (nameLength > 0) name = name.Substring(0, nameLength);

                return PAREN_REGEX.Replace(name, "").Trim();
            }
        }

        public Rom(string location, Console console) {
            this.console = console;
            this.location = location;
            this.displayName = name;
        }

        public override string ToString() { return displayName; }
    }

    // Information about the game console
    public class Console {
        public string location { get; private set; }
        public string displayName { get; private set; }
        public string cmdArguments { get; private set; }
        public string romDirectory { get; private set; }

        public string executableName {
            get {
                string name = location;

                int lastSlash = name.LastIndexOf('\\');
                if (lastSlash != -1) name = name.Substring(lastSlash + 1, name.Length - lastSlash - 1);

                return name;
            }
        }

        public string executableDirectory {
            get {
                string dir = location;

                int lastSlash = dir.LastIndexOf('\\');
                if (lastSlash != -1) dir = dir.Substring(0, lastSlash + 1);

                return dir;
            }
        }

        public Console(string location, string displayName, string cmdArguments, string romDirectory) {
            this.location = location;
            this.displayName = displayName;
            this.cmdArguments = cmdArguments;
            this.romDirectory = romDirectory;
        }

        public override string ToString() { return displayName; }
    }
}
