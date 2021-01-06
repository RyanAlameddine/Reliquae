using Reliquae.Drawing;
using Reliquae.Utilities;
using Reliquae.Worlds.Entities.Components;
using Reliquae.Worlds.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities
{
    public class EntityMap : IUpdateable
    {
        readonly List<IComponent> gameObjects;

        readonly List<SystemBase> systems;

        public EntityMap(IComponent gameObject)
        {
            gameObjects = new List<IComponent>();
            systems = new List<SystemBase>();
            gameObjects.Add(gameObject);
            Func<IEnumerable<IComponent>> getComponents = () => gameObjects;

            systems.Add(new PhysicsSystem(getComponents));
            systems.Add(new RenderSystem(getComponents));
        }

        public void Draw(PainterContext painter)
        {
            var drawables = systems.WhereCast<SystemBase, IDrawable>();
            drawables.ForEach((x) => x.Draw(painter));
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            var updatables = systems.WhereCast<SystemBase, IUpdateable>();
            updatables.ForEach((x) => x.Update(gameTime));

        }
    }
}
