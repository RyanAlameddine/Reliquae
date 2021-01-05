using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public class DirectAdjacencyPattern : IAdjacencyPattern
    {
        public Texture2D Texture { get; init; }
        public ushort? W { get; init; }
        public ushort? N { get; init; }
        public ushort? E { get; init; }
        public ushort? S { get; init; }

        public DirectAdjacencyPattern(Texture2D texture, ushort? w, ushort? n, ushort? e, ushort? s)
        {
            Texture = texture;
            W = w;
            N = n;
            E = e;
            S = s;
        }

        public bool MatchOn(ushort[,] tiles, int x, int y)
        {
            return Check(W , x - 1, y    , tiles, x, y) &&
                   Check(N , x    , y - 1, tiles, x, y) &&
                   Check(E , x + 1, y    , tiles, x, y) &&
                   Check(S , x    , y + 1, tiles, x, y);
        }
        static bool Check(ushort? dir, int xs, int ys, ushort[,] tiles, int x, int y)
        {
            if (dir == null) return true;

            if (ys < 0 || xs < 0 || ys >= tiles.GetLength(0) || xs >= tiles.GetLength(1)) return true;
            return tiles[ys, xs] == dir;
        }
    }
}
