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

        public TileMap(ushort[,] tiles, Dictionary<ushort, AdjacencyMap> patterns)
        {
            Tile map(int x, int y, ushort template)
            {
                return new Tile(patterns[template].Match(tiles, x, y), new Vector2(x, y));
            }
            Tiles = tiles.Select(map);
        }

        public void Draw(PainterContext painter)
        {
            Tiles.Foreach((x, y, tile) => tile.Draw(painter));
        }
    }
}
