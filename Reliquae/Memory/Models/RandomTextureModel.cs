using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Memory.Models
{
    public class RandomTextureModel
    {
        public string TexturePath { get; init; }
        public int RandomWeight { get; init; }

        public RandomTextureModel(string texturePath, int randomWeight)
        {
            TexturePath = texturePath;
            RandomWeight = randomWeight;
        }
    }
}
