using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reliquae.Memory.Models
{
    class BlockModel
    {
        public ushort BlockID { get; init; }
        public string BlockName { get; init; }

        public IAdjacencyModel[] Patterns { get; init; }

        public BlockModel(ushort BlockID, string BlockName, IAdjacencyModel[] Patterns)
        {
            this.BlockID = BlockID;
            this.BlockName = BlockName;
            this.Patterns = Patterns;
        }
    }

    class BlockModel<T> : BlockModel where T : IAdjacencyModel
    {
        public new T[] Patterns { get; init; }
        public BlockModel(ushort BlockID, string BlockName, T[] Patterns) 
            : base(BlockID, BlockName, Patterns.Cast<IAdjacencyModel>().ToArray())
        {
            this.Patterns = Patterns;
        }
    }
}
