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
    public class TileMap
    {
        private Tile[,] Tiles { get; set; }
        private ushort[,] Templates { get; set; }
        private Dictionary<ushort, AdjacencyMap> Patterns { get; set; }

        public const int TileWidth = 16;

        public TileMap(ushort[,] templates, Dictionary<ushort, AdjacencyMap> patterns)
        {
            Templates = templates;
            Patterns = patterns;

            Generate();
        }

        public void Draw(PainterContext painter)
        {
            painter.MultiplyPositionScalar(TileWidth);
            Tiles.Foreach((x, y, tile) => painter.Draw(tile.ActiveTexture, tile.Position));
        }

        /// <summary>
        /// Change the tile at the Point in Tile-relative coordinates
        /// </summary>
        public void ChangeTile(Point tilePosition, ushort tile)
        {
            Templates[tilePosition.Y, tilePosition.X] = tile;
            Generate();
        }

        private void Generate()
        {
            Tile map(int x, int y, ushort template) 
                => new Tile(Patterns[template].Match(Templates, x, y), new Vector2(x, y));

            Tiles = Templates.Select(map);
        }
    }
}
