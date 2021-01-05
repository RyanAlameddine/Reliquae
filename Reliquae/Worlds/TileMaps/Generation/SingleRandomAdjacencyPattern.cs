using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public class DirectRandomAdjacencyPattern : IAdjacencyPattern
    {
        public Texture2D Texture { get; private set; }
        public RandomTexture[] Textures { get; init; }
        public ushort? W { get; init; }
        public ushort? N { get; init; }
        public ushort? E { get; init; }
        public ushort? S { get; init; }

        public DirectRandomAdjacencyPattern(RandomTexture[] textures, ushort? w, ushort? n, ushort? e, ushort? s)
        {
            Textures = textures;
            Texture = textures[0].Texture;
            W = w;
            N = n;
            E = e;
            S = s;
        }

        public bool MatchOn(ushort[,] tiles, int x, int y)
        {
            int hash = MathHelper.Hash(x * tiles[y, x], y);
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
