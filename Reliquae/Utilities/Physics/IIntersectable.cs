using Microsoft.Xna.Framework;
using Reliquae.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public interface IIntersectable : ISprite
    {
        Rectangle HitBox { get; }
    }
}
