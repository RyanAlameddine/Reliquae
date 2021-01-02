using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Worlds.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reliquae.Memory.Models
{
    public class SingleRandomAdjacencyModel : IAdjacencyModel
    {
        public RandomTextureModel[] Textures { get; init; }
        public string W  { get; init; }
        public string NW { get; init; }
        public string N  { get; init; }
        public string NE { get; init; }
        public string E  { get; init; }
        public string SE { get; init; }
        public string S  { get; init; }
        public string SW { get; init; }

        public SingleRandomAdjacencyModel(RandomTextureModel[] textures, string w, string nw, string n, string ne, string e, string se, string s, string sw)
        {
            Textures = textures;
            W = w;
            NW = nw;
            N = n;
            NE = ne;
            E = e;
            SE = se;
            S = s;
            SW = sw;
        }

        public IAdjacencyPattern Generate(Map<ushort, string> blockRegistry, ContentManager content, string parentPath)
        {
            List<RandomTexture> textures = new List<RandomTexture>();
            foreach(var rtm in Textures)
            {
                var t = content.Load<Texture2D>(Path.Combine(parentPath, rtm.TexturePath));
                var rt = new RandomTexture(t, rtm.RandomWeight);
                textures.Add(rt);
            }

            return new SingleRandomAdjacencyPattern(textures.ToArray(),
                get(W), get(NW), get(N), get(NE), get(E), get(SE), get(S), get(SW));

            ushort? get(string blockName) => blockName == null ? null : blockRegistry.Reverse[blockName];
        }
    }
}
