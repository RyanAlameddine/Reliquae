using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Utilities
{
    public interface IUpdateable
    {
        public void Update(GameTime gameTime);
    }
}
