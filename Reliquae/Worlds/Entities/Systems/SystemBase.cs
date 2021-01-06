using Reliquae.Drawing;
using Reliquae.Utilities;
using Reliquae.Worlds.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities.Systems
{
    public abstract class SystemBase<T> : SystemBase where T : class, IComponent
    {
        protected readonly Func<IEnumerable<T>> GetComponents;

        public SystemBase(Func<IEnumerable<IComponent>> getComponents)
        {
            GetComponents = () => SelectComponents(getComponents());
        }

        protected static IEnumerable<T> SelectComponents(IEnumerable<IComponent> gameObjects)
                => gameObjects.Select((x) => x as T).Where((x) => x != null);
    }

    public abstract class SystemBase { }
}
