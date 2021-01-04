using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities.EntityMaps
{
    public interface ISolid : IIntersectable
    {
        public void OnIntersect(ISolid other) { }
    }
}
