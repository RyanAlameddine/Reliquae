using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Drawing
{
    public struct PainterContext
    {
        Vector2 Position { get; set; }
        float PositionScalar { get; set; }
        float Zoom { get; set; }
        SpriteBatch SpriteBatch { get; set; }
        public GameTime GameTime { get; private set; }

        public PainterContext(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Position = Vector2.Zero;
            PositionScalar = 1;
            Zoom = 1;
            SpriteBatch = spriteBatch;
            GameTime = gameTime;
        }

        public void Draw(Texture2D texture, Vector2 position)
        {
            SpriteBatch.Draw(texture, position * PositionScalar * Zoom + Position, null, Color.White, 0f, Vector2.Zero, Zoom, SpriteEffects.None, 0);
        }

        public void MultiplyPositionScalar(float PositionScalar) { this.PositionScalar *= PositionScalar; }
        public void MultiplyZoom(float Zoom) { this.Zoom *= Zoom; }
    }
}
