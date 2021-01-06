using Microsoft.Xna.Framework;
using Reliquae.Drawing;
using Reliquae.Utilities;
using Reliquae.Utilities.Physics;
using Reliquae.Worlds.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities.Systems
{
    public class RenderSystem : SystemBase<ISprite>, Utilities.IDrawable
    {
        public RenderSystem(Func<IEnumerable<IComponent>> getComponents) : base(getComponents)
        {
        }

        void Utilities.IDrawable.Draw(PainterContext painterContext)
        {
            var drawables = GetComponents();
            
            foreach(var drawable in drawables)
            {
                painterContext.Draw(drawable.ActiveTexture, drawable.Transform.Position);
            }

        }
    }
}
