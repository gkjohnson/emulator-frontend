using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EmulatorFrontEnd {
    static class EmulatorExecuter {
        const string ROM_TOKEN = "{{rom}}";

        // User32.dll functions        
        [DllImport("user32.dll")]
        // returns the intptr to the foreground window
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        // returns the process id of the passed window pointer
        private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        static Process _running = null;
        public static bool IsRunning { get { return _running != null && !_running.HasExited; } }

        #region API
        // Run a console or a rom
        public static bool Run(Rom rom) {
            return Run(rom.console, rom.console.cmdArguments.Replace("{{rom}}", rom.location));
        }

        public static bool Run(Console console, string args = "") {
            return Run(console.executableName, console.executableDirectory, args);
        }

        static bool Run(string fileName, string workDir, string args = "") {
            if (IsRunning) return false;

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.WorkingDirectory = workDir;
            processInfo.FileName = fileName;
            processInfo.Arguments = args;
            processInfo.CreateNoWindow = true;

            try {
                _running = Process.Start(processInfo);
            } catch {
                _running = null;
            }

            return IsRunning;
        }

        // Quit the current emulator
        public static bool Stop(bool force = false) {
            if (!IsRunning) return false;

            // if the foreground process is not the emulator
            // or our frontend, don't do anything
            uint currProcessid;
            GetWindowThreadProcessId(GetForegroundWindow(), out currProcessid);

            if (
                currProcessid != _running.Id &&
                currProcessid != Process.GetCurrentProcess().Id &&
                !force) {
                return false;
            }

            // kill the processs
            _running.Kill();

            return true;
        }
        #endregion
    }
}
