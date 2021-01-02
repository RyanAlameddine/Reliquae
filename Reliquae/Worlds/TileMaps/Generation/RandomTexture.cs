using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.TileMaps.Generation
{
    public class RandomTexture
    {
        public Texture2D Texture { get; init; }
        public int RandomWeight { get; init; }

        public RandomTexture(Texture2D texture, int randomWeight)
        {
            Texture = texture;
            RandomWeight = randomWeight;
        }
    }
}
