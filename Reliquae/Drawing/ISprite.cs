using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities.Physics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Drawing
{
    public interface ISprite : ITransform
    {
        public Texture2D ActiveTexture { get; }
        public float Rotation { get; }
    }
}
