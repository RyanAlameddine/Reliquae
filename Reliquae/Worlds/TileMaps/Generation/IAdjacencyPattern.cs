using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public interface IAdjacencyPattern
    {
        public Texture2D Texture { get; }

        public bool MatchOn(ushort[,] t, int x, int y);
    }
}
