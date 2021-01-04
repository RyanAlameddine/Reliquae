using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public interface IAdjacencyPattern
    {
        public Texture2D Texture { get; }

        /// <summary>
        /// Returns true if the tile at (x, y) matches the expected pattern in the ushort[,]
        /// </summary>
        public bool MatchOn(ushort[,] t, int x, int y);
    }
}
