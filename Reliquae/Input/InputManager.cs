using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Input
{
    public class InputManager
    {
        private MouseState LastMS { get; set; }
        private KeyboardState LastKS { get; set; }

        private MouseState MS { get; set; }
        private KeyboardState KS { get; set; }

        public bool LeftButtonDown { get => MS.LeftButton == ButtonState.Pressed; }
        public bool RightButtonDown { get => MS.RightButton == ButtonState.Pressed; }
        public bool LeftButtonClicked { get => MS.LeftButton == ButtonState.Released && LastMS.LeftButton == ButtonState.Pressed; }
        public bool RightButtonClicked { get => MS.RightButton == ButtonState.Released && LastMS.RightButton == ButtonState.Pressed; }
        public Point MousePosition { get => new Point(MS.Position.X / 16 / 5, MS.Position.Y / 16 / 5); }

        public void Update()
        {
            LastMS = MS;
            LastKS = KS;

            MS = Mouse.GetState();
            KS = Keyboard.GetState();
        }
    }
}
