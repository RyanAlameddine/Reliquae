using Microsoft.Xna.Framework.Content;
using Reliquae.Worlds.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reliquae.Memory.Models
{
    public class BlockModel
    {
        public ushort BlockID { get; init; }
        public string BlockName { get; init; }
        public string TexturePath { get; init; }

        public IAdjacencyModel[] Patterns { get; init; }

        public BlockModel(ushort BlockID, string BlockName, string TexturePath, IAdjacencyModel[] Patterns)
        {
            this.BlockID = BlockID;
            this.BlockName = BlockName;
            this.Patterns = Patterns;
            this.TexturePath = TexturePath;
        }

        public IAdjacencyPattern[] Generate(Map<ushort, string> blockRegistry, ContentManager content)
        {
            ushort? getID(string blockName) => blockName == null ? null : blockRegistry.Reverse[blockName];

            return Patterns.Select((x) => x.Generate(getID, content, TexturePath)).ToArray();
        }
    }

    public class BlockModel<T> : BlockModel where T : IAdjacencyModel
    {
        public new T[] Patterns { get; init; }
        public BlockModel(ushort BlockID, string BlockName, string TexturePath, T[] Patterns) 
            : base(BlockID, BlockName, TexturePath, Patterns.Cast<IAdjacencyModel>().ToArray())
        {
            this.Patterns = Patterns;
        }
    }
}
