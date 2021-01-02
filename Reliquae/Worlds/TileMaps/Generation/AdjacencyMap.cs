using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public class AdjacencyMap
    {
        readonly IAdjacencyPattern[] rules;

        public AdjacencyMap(IAdjacencyPattern[] rules)
        {
            this.rules = rules;
        }

        public Texture2D Match(ushort[,] t, int x, int y)
        {
            foreach(var pattern in rules)
            {
                if (pattern.MatchOn(t, x, y))
                {
                    return pattern.Texture;
                }
            }
            throw new Exception("Unable to match arrangement with texture");
        }
    }
}
