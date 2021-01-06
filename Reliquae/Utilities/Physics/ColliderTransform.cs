using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public class ColliderTransform : Transform
    {

        public Rectangle Hitbox { get; set; }
        public override Vector2 Position 
        { 
            get => base.Position; 
            set
            {
                Point offset = (base.Position - value).ToPoint(); //TODO: Fix the fact that this might cause rounding errors to accumulate
                Hitbox = new Rectangle(Hitbox.Location + offset, Hitbox.Size);
                base.Position = value;
            }
        }

        public ColliderTransform(Rectangle hitbox, Vector2 position)
        {
            Position = position;
            Hitbox = hitbox;
        }
    }
}
