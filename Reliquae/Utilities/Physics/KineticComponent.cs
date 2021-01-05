using Microsoft.Xna.Framework;
using Reliquae.Utilities.Physics.Forces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public class KineticComponent
    {
        public Vector2 Velocity { get; private set; }
        public Vector2 Accelleration { get; private set; }
        public float Mass { get; init; }
        public IReadOnlyList<IForce> Forces { get => forces; }

        readonly List<IForce> forces;

        public KineticComponent(List<IForce> forces, float mass)
        {
            this.forces = forces;
            Mass = mass;
        }
    }
}
