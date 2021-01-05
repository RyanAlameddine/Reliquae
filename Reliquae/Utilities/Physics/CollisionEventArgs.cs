using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public class CollisionEventArgs : EventArgs
    {
        public readonly Rectangle other;
    }
}
