using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Input
{
    public class InputManager : Reliquae.Utilities.IUpdateable
    {
        public InputManager(Func<Vector2> getCamOffset)
        {
            this.getCamOffset = getCamOffset;
        }

        Func<Vector2> getCamOffset { get; }
        private MouseState LastMS { get; set; }
        private KeyboardState LastKS { get; set; }

        private MouseState MS { get; set; }
        private KeyboardState KS { get; set; }

        public bool LeftButtonDown => MS.LeftButton == ButtonState.Pressed;
        public bool RightButtonDown => MS.RightButton == ButtonState.Pressed;
        public bool LeftButtonClicked => MS.LeftButton == ButtonState.Released && LastMS.LeftButton == ButtonState.Pressed;
        public bool RightButtonClicked => MS.RightButton == ButtonState.Released && LastMS.RightButton == ButtonState.Pressed;
        public Point MouseTilePosition => new Point((int) Math.Floor((MS.Position.X + getCamOffset().X) / 16 / 4), (int) Math.Floor((MS.Position.Y + getCamOffset().Y) / 16 / 4));
        public Point MousePosition => MS.Position + getCamOffset().ToPoint();

        public float HorizontalAxis => GetInputStrength(Keys.D) - GetInputStrength(Keys.A);
        public float VerticalAxis => GetInputStrength(Keys.S) - GetInputStrength(Keys.W);


        public void Update(GameTime gameTime)
        {
            LastMS = MS;
            LastKS = KS;

            MS = Mouse.GetState();
            KS = Keyboard.GetState();
        }

        private float GetInputStrength(Keys key) => KS.IsKeyDown(key) ? 1 : 0;
    }
}
