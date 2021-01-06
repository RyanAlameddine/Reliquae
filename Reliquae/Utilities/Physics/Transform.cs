using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public class Transform
    {
        private Vector2 position;
        public virtual Vector2 Position { get => position; set => position = value; }
    }
}
