using Microsoft.Xna.Framework;
using Reliquae.Utilities;
using Reliquae.Worlds.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities.Systems
{
    public class PhysicsSystem : SystemBase<ITransform>, Utilities.IUpdateable
    {
        public PhysicsSystem(Func<IEnumerable<IComponent>> getComponents) : base(getComponents)
        {
        }

        void Utilities.IUpdateable.Update(GameTime gameTime)
        {
            var transforms = GetComponents();
            var solids = SystemBase<ISolid>.SelectComponents(transforms);
            var triggers = SystemBase<ITrigger>.SelectComponents(transforms);
            var kinetics = SystemBase<IKinetic>.SelectComponents(transforms);

            //Calculate all forces on kinetic objects
            foreach(var kinetic in kinetics)
            {
                var k = kinetic.KineticComponent;

                //TODO: take snapshot of pos/vel/acc?

                k.ApplyForces(gameTime);
            }

            //Move all kinetic objects
            foreach(var kinetic in kinetics)
            {
                var k = kinetic.KineticComponent;
                var t = kinetic.Transform;
                t.Position += k.Velocity;
            }

        }
    }
}
