using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Events
{
    class EventSystem
    {
        Dictionary<string, SortedList<float, Action<EventArgs>>> eventReferences;
    }
}
