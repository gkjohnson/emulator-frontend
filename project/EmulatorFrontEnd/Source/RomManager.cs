using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EmulatorFrontEnd {
    public static class RomManager {
        // Emulator Process Management
        public static bool RunEmulator(Rom r) { return EmulatorExecuter.Run(r); }
        public static bool RunEmulator(string consoleName) { return EmulatorExecuter.Run(ConsoleCache.GetConsole(consoleName)); }
        public static bool StopEmulator() { return EmulatorExecuter.Stop(); }
        public static bool IsEmulatorRunning() { return EmulatorExecuter.IsRunning; }

        // Settings Save management
        public static void SaveOutNewConsoleDirectories(List<Console> consoles) { ConsoleCache.Save(consoles); }
        public static void SaveOutRomSettings() { ConsoleCache.Save(); }
        public static void RefreshRomList() { ConsoleCache.Refresh(); }

        // Emulator Fetching Management
        public static ReadOnlyCollection<Console> GetConsoles() { return ConsoleCache.Consoles; }
        public static ReadOnlyCollection<Rom> GetRoms(string console) { return ConsoleCache.GetRoms(console); }
        public static ReadOnlyCollection<Rom> GetRoms(Console console) { return ConsoleCache.GetRoms(console); }
        public static ReadOnlyCollection<Rom> GetRoms() { return ConsoleCache.Roms; }
    }
}
