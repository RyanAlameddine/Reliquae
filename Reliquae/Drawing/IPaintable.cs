using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reliquae.Drawing
{
    public interface IPaintable
    {
        public void Draw(PainterContext painter);
    }
}
