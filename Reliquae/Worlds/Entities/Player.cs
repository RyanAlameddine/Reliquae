using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Drawing;
using Reliquae.Utilities.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities
{
    public class Player : ISolid, ISprite, IKinetic
    {
        public Texture2D ActiveTexture { get; private set; }
        public Vector2 Position { get; private set; }
        public KineticComponent KineticComponent { get; init; }
        public float Rotation { get; } = 0;
        public Rectangle HitBox { get; private set; }
    }
}
