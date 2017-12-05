using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Input;

namespace NewEmulatorFrontEnd {
    class ControllerUpdater {
        public static void UpdateDots(Label[] dots) {
            for (int i = 0; i < 4; i++) {
                GamePadState gc = GamePad.GetState((Microsoft.Xna.Framework.PlayerIndex)i);
                if (gc.IsConnected) {
                    dots[i].ForeColor = Color.FromArgb(0, 200, 83);
                } else {
                    dots[i].ForeColor = Color.FromArgb(190, 190, 190);
                }
            }
        }
    }
}
