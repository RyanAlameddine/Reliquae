using Microsoft.Xna.Framework.Content;
using Reliquae.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Memory.Models
{
    interface IAdjacencyModel
    {
        public IAdjacencyPattern Generate(Map<ushort, string> blockRegistry, ContentManager content);
    }
}
