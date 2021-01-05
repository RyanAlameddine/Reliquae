using Microsoft.Xna.Framework.Content;
using Reliquae.Worlds.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Memory.Models
{
    public interface IAdjacencyModel
    {
        public IAdjacencyPattern Generate(Func<string, ushort?> getID, ContentManager content, string parentPath);
    }
}
