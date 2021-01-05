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
    public class DirectRandomAdjacencyModel : IAdjacencyModel
    {
        public RandomTextureModel[] Textures { get; init; }
        public string W  { get; init; }
        public string N  { get; init; }
        public string E  { get; init; }
        public string S  { get; init; }

        public DirectRandomAdjacencyModel(RandomTextureModel[] textures, string w, string n, string e, string s)
        {
            Textures = textures;
            W = w;
            N = n;
            E = e;
            S = s;
        }

        public IAdjacencyPattern Generate(Func<string, ushort?> getID, ContentManager content, string parentPath)
        {
            List<RandomTexture> textures = new List<RandomTexture>();
            foreach(var rtm in Textures)
            {
                var t = content.Load<Texture2D>(Path.Combine(parentPath, rtm.TexturePath));
                var rt = new RandomTexture(t, rtm.RandomWeight);
                textures.Add(rt);
            }

            return new DirectRandomAdjacencyPattern(textures.ToArray(), getID(W), getID(N), getID(E), getID(S));
        }
    }
}
