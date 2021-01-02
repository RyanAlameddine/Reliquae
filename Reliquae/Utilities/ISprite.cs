using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Drawing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Utilities
{
    public interface ISprite : IPaintable
    {
        public Texture2D ActiveTexture { get; }
        public Vector2 Position { get; }
    }
}
