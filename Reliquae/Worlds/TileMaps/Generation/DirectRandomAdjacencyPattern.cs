using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public class SingleRandomAdjacencyPattern : IAdjacencyPattern
    {
        public Texture2D Texture { get; private set; }
        public RandomTexture[] Textures { get; init; }
        public ushort? W { get; init; }
        public ushort? NW { get; init; }
        public ushort? N { get; init; }
        public ushort? NE { get; init; }
        public ushort? E { get; init; }
        public ushort? SE { get; init; }
        public ushort? S { get; init; }
        public ushort? SW { get; init; }

        public SingleRandomAdjacencyPattern(RandomTexture[] textures, ushort? w, ushort? nw, ushort? n, ushort? ne, ushort? e, ushort? se, ushort? s, ushort? sw)
        {
            Textures = textures;
            Texture = textures[0].Texture;
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
            int hash = MathHelper.Hash(x, y);
            Random rand = new Random(hash);
            int total = Textures.Select((x) => x.RandomWeight).Sum();
            int selection = rand.Next(0, total);

            int current = 0;
            foreach(var texture in Textures)
            {
                current += texture.RandomWeight;
                if(current >= selection)
                {
                    Texture = texture.Texture;
                    break;
                }
            }

            return Check(W , x - 1, y    , tiles, x, y) &&
                   Check(NW, x - 1, y - 1, tiles, x, y) &&
                   Check(N , x    , y - 1, tiles, x, y) &&
                   Check(NE, x + 1, y - 1, tiles, x, y) &&
                   Check(E , x + 1, y    , tiles, x, y) &&
                   Check(SE, x + 1, y + 1, tiles, x, y) &&
                   Check(S , x    , y + 1, tiles, x, y) &&
                   Check(SW, x - 1, y + 1, tiles, x, y);
        }

        static bool Check(ushort? dir, int xs, int ys, ushort[,] tiles, int x, int y)
        {
            if (dir == null) return true;

            if (ys < 0 || xs < 0 || ys >= tiles.GetLength(0) || xs >= tiles.GetLength(1)) return true;
            return tiles[ys, xs] == dir;
        }
    }
}
