using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Utilities;

namespace Reliquae.TileMaps
{
    public class Tile : ISprite
    {
        public Texture2D ActiveTexture { get; protected set; }
        public Vector2 Position { get; protected set; }

        public Tile(Texture2D activeTexture, Vector2 position)
        {
            ActiveTexture = activeTexture;
            Position = position;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(ActiveTexture, Position * 16, Color.White);
        }
    }
}