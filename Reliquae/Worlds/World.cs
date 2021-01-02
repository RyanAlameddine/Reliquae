using Microsoft.Xna.Framework;
using Reliquae.Drawing;
using Reliquae.Utilities;
using Reliquae.Worlds.EntityMaps;
using Reliquae.Worlds.TileMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds
{
    public class World : IPaintable, IUpdatable
    {
        public Tape<(TileMap tileMap, EntityMap entityMap)> Layers { get; set; }

        public void Draw(PainterContext painter)
        {
            var (tileMap, entityMap) = Layers[0];

            tileMap.Draw(painter);
            entityMap.Draw(painter);
        }

        public void Update(GameTime gameTime)
        {
            var (_, entityMap) = Layers[0];

            entityMap.Update(gameTime);
        }
    }
}
