using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EmulatorFrontEnd {
    static class EmulatorExecuter {
        const string ROM_TOKEN = "{{rom}}";

        #region User32 dll Functions
        // returns the intptr to the foreground window
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        // returns the process id of the passed window pointer
        [DllImport("user32.dll")]
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        #endregion

        static Process _running = null;
        public static bool Running { get { return _running != null && !_running.HasExited; } }

        #region API
        public static bool Run(Rom rom) {
            return Run(rom.console, rom.console.cmdArguments.Replace("{{rom}}", rom.location));
        }

        public static bool Run(Console console, string args = "") {
            return Run(console.executableName, console.executableDirectory, args);
        }

        private static bool Run(string consoleExePath, string workDir, string args = "") {
            if (Running) return false;

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.WorkingDirectory = workDir;
            processInfo.FileName = consoleExePath;
            processInfo.Arguments = args;
            processInfo.CreateNoWindow = true;

            try {
                _running = Process.Start(processInfo);
            } catch {
                _running = null;
            }

            return Running;
        }

        // Quit the current emulator
        public static bool Stop(bool force = false) {
            if (!Running) return false;

            // if the foreground process is not the emulator
            // or our frontend, don't do anything
            uint currProcessid;
            GetWindowThreadProcessId(GetForegroundWindow(), out currProcessid);

            bool isEmulatorFocused = currProcessid == _running.Id;
            bool isFrontEndFocused = currProcessid == Process.GetCurrentProcess().Id;
            if (!isEmulatorFocused && !isFrontEndFocused && !force) {
                return false;
            }

            _running.Kill();

            return true;
        }
        #endregion
    }
}
