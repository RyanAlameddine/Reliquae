using Reliquae.Drawing;
using Reliquae.Utilities;
using Reliquae.Worlds.Entities;
using Reliquae.Worlds.TileMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds
{
    public class World : IUpdateable, IDrawable
    {
        public Tape<(TileMap tileMap, EntityMap entityMap)> Layers { get; set; }

        public World(IEnumerable<(TileMap tileMap, EntityMap entityMap)> list, int currentIndex, Func<(TileMap tileMap, EntityMap entityMap)> generateTopLayer, Func<(TileMap tileMap, EntityMap entityMap)> generateBottomLayer)
        {
            Layers = new Tape<(TileMap tileMap, EntityMap entityMap)>(list, currentIndex, generateTopLayer, generateBottomLayer);
        }

        public void Draw(PainterContext painter)
        {
            var (tileMap, entityMap) = Layers[0];

            tileMap.Draw(painter);
            entityMap.Draw(painter);
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            var (_, entityMap) = Layers[0];

            entityMap.Update(gameTime);
        }
    }
}
