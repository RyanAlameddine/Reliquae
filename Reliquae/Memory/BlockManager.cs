using Microsoft.Xna.Framework.Graphics;
using Reliquae.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Memory
{
    class BlockManager
    {
        public Map<ushort, string> BlockRegistry { get; private set; } = new Map<ushort, string>();

        public Dictionary<ushort, AdjacencyMap> Patterns { get; private set; } = new Dictionary<ushort, AdjacencyMap>();
    }
}
