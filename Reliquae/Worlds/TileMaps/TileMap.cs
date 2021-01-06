using Microsoft.Xna.Framework.Graphics;
using Reliquae.Drawing;
using Reliquae.Worlds.TileMaps.Generation;
using Reliquae.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Worlds.TileMaps
{
    public class TileMap : IDrawable
    {
        private Tile[,] Tiles { get; set; }
        private ushort[,] Templates { get; set; }
        private Dictionary<ushort, AdjacencyMap> Patterns { get; set; }

        public const int TileWidth = 16;

        public TileMap(ushort[,] templates, Dictionary<ushort, AdjacencyMap> patterns)
        {
            Templates = templates;
            Patterns = patterns;
            Tiles = new Tile[templates.GetLength(0), templates.GetLength(1)];

            Generate();
        }

        public void Draw(PainterContext painter)
        {
            painter.MultiplyPositionScalar(TileWidth);
            Tiles.Foreach((x, y, tile) => painter.Draw(tile.ActiveTexture, tile.Transform.Position));
        }

        /// <summary>
        /// Change the tile at the Point in Tile-relative coordinates
        /// </summary>
        public void ChangeTile(Microsoft.Xna.Framework.Point tilePosition, ushort tile)
        {
            Templates[tilePosition.Y, tilePosition.X] = tile;
            GenerateRange(tilePosition.X, tilePosition.Y, 1);
        }

        private void Generate()
        {
            GenerateRange(0, 0, int.MaxValue/10);
        }

        private void GenerateRange(int xs, int ys, int range)
        {
            for (int y = Math.Max(0, ys - range); y < Math.Min(Templates.GetLength(0), ys + range + 1); y++)
            {
                for (int x = Math.Max(0, xs - range); x < Math.Min(Templates.GetLength(1), xs + range + 1); x++)
                {
                    Tiles[y, x] = map(x, y, Templates[y, x]);
                }
            }
            Tile map(int x, int y, ushort template)
               => new Tile(Patterns[template].Match(Templates, x, y), new Microsoft.Xna.Framework.Vector2(x, y));
        }
    }
}
