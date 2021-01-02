﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Worlds.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reliquae.Memory.Models
{
    public class SingleAdjacencyModel : IAdjacencyModel
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

        public SingleAdjacencyModel(string texturePath, string w, string nw, string n, string ne, string e, string se, string s, string sw)
        {
            TexturePath = texturePath;
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
            Texture2D texture = content.Load<Texture2D>(Path.Combine(parentPath, TexturePath));

            return new SingleAdjacencyPattern(texture,
                get(W), get(NW), get(N), get(NE), get(E), get(SE), get(S), get(SW));

            ushort? get(string blockName) => blockName == null ? null : blockRegistry.Reverse[blockName];
        }
    }
}
