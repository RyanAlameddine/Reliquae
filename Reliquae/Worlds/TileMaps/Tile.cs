using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Drawing;

namespace Reliquae.Worlds.TileMaps
{
    public class Tile : ISprite
    {
        public Texture2D ActiveTexture { get; protected set; }
        public Vector2 Position { get; protected set; }
        public float Rotation { get; protected set; }

        public Tile(Texture2D activeTexture, Vector2 position)
        {
            ActiveTexture = activeTexture;
            Position = position;
        }
    }
}