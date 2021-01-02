using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public class SingleAdjacencyPattern : IAdjacencyPattern
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
            return Check(W , x - 1, y    , tiles, x, y) &&
                   Check(NW, x - 1, y - 1, tiles, x, y) &&
                   Check(N , x    , y - 1, tiles, x, y) &&
                   Check(NE, x + 1, y - 1, tiles, x, y) &&
                   Check(E , x + 1, y    , tiles, x, y) &&
                   Check(SE, x + 1, y + 1, tiles, x, y) &&
                   Check(S , x    , y + 1, tiles, x, y) &&
                   Check(SW, x - 1, y + 1, tiles, x, y);
        }
        bool Check(ushort? dir, int xs, int ys, ushort[,] tiles, int x, int y)
        {
            if (dir == null) return true;

            if (ys < 0 || xs < 0 || ys >= tiles.GetLength(0) || xs >= tiles.GetLength(1)) return true;
            return tiles[ys, xs] == dir;
        }
    }
}
