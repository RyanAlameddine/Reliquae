using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.TileMaps.Generation
{
    class SingleAdjacencyPattern : IAdjacencyPattern
    {
        public Texture2D Texture { get; init; }
        public ushort? W { get; init; }
        public ushort? NW { get; init; }
        public ushort? N { get; init; }
        public ushort? NE { get; init; }
        public ushort? E { get; init; }
        public ushort? SE { get; init; }
        public ushort? S { get; init; }
        public ushort? SW { get; init; }

        public SingleAdjacencyPattern(Texture2D texture, ushort? w, ushort? nw, ushort? n, ushort? ne, ushort? e, ushort? se, ushort? s, ushort? sw)
        {
            Texture = texture;
            W = w;
            NW = nw;
            N = n;
            NE = ne;
            E = e;
            SE = se;
            S = s;
            SW = sw;
        }

        public bool MatchOn(ushort[,] tiles, int x, int y)
        {
            return (W  == tiles.Get(x - 1, y    ) || W  == null) &&
                   (NW == tiles.Get(x - 1, y - 1) || NW == null) &&
                   (N  == tiles.Get(x    , y - 1) || N  == null) &&
                   (NE == tiles.Get(x + 1, y - 1) || NE == null) &&
                   (E  == tiles.Get(x + 1, y    ) || E  == null) &&
                   (SE == tiles.Get(x + 1, y + 1) || SE == null) &&
                   (S  == tiles.Get(x    , y + 1) || S  == null) &&
                   (SW == tiles.Get(x - 1, y + 1) || SW == null);
        }
    }
}
