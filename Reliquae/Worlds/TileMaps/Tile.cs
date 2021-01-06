using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Drawing;
using Reliquae.Utilities.Physics;

namespace Reliquae.Worlds.TileMaps
{
    public class Tile : ISprite
    {
        public Texture2D ActiveTexture { get; protected set; }
        public Transform Transform { get; protected set; }
        public float Rotation { get; protected set; }


        public Tile(Texture2D activeTexture, Vector2 position)
        {
            ActiveTexture = activeTexture;
            Transform = new Transform() { Position = position };
        }
    }
}