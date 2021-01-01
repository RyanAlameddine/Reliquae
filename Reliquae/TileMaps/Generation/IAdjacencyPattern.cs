using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.TileMaps.Generation
{
    interface IAdjacencyPattern
    {
        public Texture2D Texture { get; }

        public bool MatchOn(ushort[,] t, int x, int y);
    }
}
