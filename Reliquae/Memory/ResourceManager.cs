using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Memory.Models;
using Reliquae.Worlds.TileMaps.Generation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Reliquae.Memory
{
    public class ResourceManager
    {
        public BlockManager BlockManager { get; private set; } = new BlockManager();

        /// <typeparam name="T">The model for the adjacency pattern</typeparam>
        public BlockModel<T> ParseBlock<T>(string json) where T : IAdjacencyModel
        {
            var block = JsonSerializer.Deserialize<BlockModel<T>>(json, new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
            });
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

                BlockModel model; 

                //TODO: replace this with reflection to follow SOLID principles:
                if (file.EndsWith("_d.json"))
                {
                    model = ParseBlock<DirectAdjacencyModel>(json);
                }
                else if (file.EndsWith("_s.json"))
                {
                    model = ParseBlock<SingleAdjacencyModel>(json);
                }
                else throw new Exception("Block file name must end with \"_s\" or another adjacency model tag!");

                models.Add(model);
            }

            foreach(var model in models)
            {
                var patterns = model.Generate(BlockManager.BlockRegistry, content);
                BlockManager.Patterns.Add(model.BlockID, new AdjacencyMap(patterns));
            }
        }
    }
}
