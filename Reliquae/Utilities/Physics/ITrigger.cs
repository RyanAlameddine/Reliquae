using Reliquae.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public interface ITrigger : IIntersectable
    {
        public void OnTriggerEnter(CollisionEventArgs collisionEventArgs);
        public void OnTriggerExit (CollisionEventArgs collisionEventArgs);
    }
}
