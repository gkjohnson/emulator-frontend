using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;

namespace EmulatorFrontEnd {

    // Function for updating the connected controller dots in the UI
    class ControllerUpdater {
        static readonly Color CONNECTED_COLOR = Color.FromArgb(0, 200, 83);
        static readonly Color DISCONNECTED_COLOR = Color.FromArgb(190, 190, 190);
        public static void UpdateDots(Label[] connectedDots) {
            for (int i = 0; i < Math.Min(4, connectedDots.Length); i++) {
                GamePadState gc = GamePad.GetState((Microsoft.Xna.Framework.PlayerIndex)i);
                connectedDots[i].ForeColor = gc.IsConnected ? CONNECTED_COLOR : DISCONNECTED_COLOR;
            }
        }
    }
}
