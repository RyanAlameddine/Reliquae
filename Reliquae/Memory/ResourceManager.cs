using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Memory.Models;
using Reliquae.TileMaps.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Reliquae.Memory
{
    class ResourceManager
    {
        public BlockManager BlockManager { get; private set; } = new BlockManager();

        /// <typeparam name="T">The model for the adjacency pattern</typeparam>
        public BlockModel<T> ParseBlock<T>(string json) where T : IAdjacencyModel
        {
            var block = JsonSerializer.Deserialize<BlockModel<T>>(json);
            BlockManager.BlockRegistry.Add(block.BlockID, block.BlockName);
            return block;
        }

        public void LoadBlocks(ContentManager content)
        {
            List<BlockModel> models = new List<BlockModel>();
            foreach (var file in Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Content", "blockdata")))
            {
                if (!file.EndsWith(".json")) continue;

                string json = File.ReadAllText(file);

                models.Add(ParseBlock<SingleAdjacencyModel>(json));
            }

            foreach(var model in models)
            {
                var patterns = model.Patterns.Select((x) => x.Generate(BlockManager.BlockRegistry, content)).ToArray();
                BlockManager.Patterns.Add(model.BlockID, new AdjacencyMap(patterns));
            }
        }
    }
}
