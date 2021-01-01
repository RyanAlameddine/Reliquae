using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Memory.Models
{
    class SingleAdjacencyModel : IAdjacencyModel
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

        public SingleAdjacencyModel(string texturePath, string w, string nW, string n, string nE, string e, string sE, string s, string sW)
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

        public IAdjacencyPattern Generate(Map<ushort, string> blockRegistry, ContentManager content)
        {
            Texture2D texture = content.Load<Texture2D>(TexturePath);

            return new SingleAdjacencyPattern(texture,
                get(W), get(NW), get(N), get(NE), get(E), get(SE), get(S), get(SW));

            ushort? get(string blockName) => blockName == null ? null : blockRegistry.Reverse[blockName];
        }
    }
}
