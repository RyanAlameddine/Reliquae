using Reliquae.Drawing;
using Reliquae.Utilities.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities.Components
{
    public interface ITrigger : IColliderTransform
    {
        public void OnTriggerEnter(CollisionEventArgs collisionEventArgs);
        public void OnTriggerExit(CollisionEventArgs collisionEventArgs);
    }
}
