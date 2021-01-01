using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Utilities
{
    interface IPaintable
    {
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
