using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.TileMaps
{
    class TileMap : IPaintable
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

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Tiles.Foreach((x, y, tile) => tile.Draw(spriteBatch, gameTime));
        }
    }
}
