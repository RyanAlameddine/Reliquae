using Microsoft.Xna.Framework;
using Reliquae.Utilities.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities.Components
{
    public interface ITransform : IComponent
    {
        Transform Transform { get; }
    }
}
