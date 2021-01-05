using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public interface IKinetic : ITransform
    {
        public KineticComponent KineticComponent { get; }

    }
}
