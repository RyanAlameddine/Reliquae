using Reliquae.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities
{
    public interface IDrawable
    {
        public void Draw(PainterContext painter);
    }
}
