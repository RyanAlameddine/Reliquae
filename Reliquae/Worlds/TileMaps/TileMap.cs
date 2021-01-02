using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Drawing;
using Reliquae.Worlds.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Worlds.TileMaps
{
    public class TileMap : IPaintable
    {
        private Tile[,] Tiles { get; set; }
        private ushort[,] Templates { get; set; }
        private Dictionary<ushort, AdjacencyMap> Patterns { get; set; }

        public TileMap(ushort[,] templates, Dictionary<ushort, AdjacencyMap> patterns)
        {
            Templates = templates;
            Patterns = patterns;

            Generate();
        }

        public void Draw(PainterContext painter)
        {
            Tiles.Foreach((x, y, tile) => tile.Draw(painter));
        }

        public void ChangeTile(int x, int y, ushort tile)
        {
            Templates[y, x] = tile;
            Generate();
        }

        private void Generate()
        {
            Tile map(int x, int y, ushort template)
            {
                return new Tile(Patterns[template].Match(Templates, x, y), new Vector2(x, y));
            }
            Tiles = Templates.Select(map);
        }
    }
}
