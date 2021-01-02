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
    public class DirectAdjacencyModel : IAdjacencyModel
    {
        public string TexturePath { get; init; }
        public string W  { get; init; }
        public string NW { get; init; }
        public string N  { get; init; }
        public string NE { get; init; }
        public string E  { get; init; }
        public string SE { get; init; }
        public string S  { get; init; }
        public string SW { get; init; }

        public DirectAdjacencyModel(string texturePath, string w, string nW, string n, string nE, string e, string sE, string s, string sW)
        {
            TexturePath = texturePath;
            W = w;
            NW = nW;
            N = n;
            NE = nE;
            E = e;
            SE = sE;
            S = s;
            SW = sW;
        }

        public IAdjacencyPattern Generate(Map<ushort, string> blockRegistry, ContentManager content, string parentPath)
        {
            Texture2D texture = content.Load<Texture2D>(Path.Combine(parentPath, TexturePath));

            return new DirectAdjacencyPattern(texture,
                get(W), get(N), get(E), get(S));

            ushort? get(string blockName) => blockName == null ? null : blockRegistry.Reverse[blockName];
        }
    }
}
