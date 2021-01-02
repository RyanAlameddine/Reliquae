using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities
{
    /// <summary>
    /// Infinite list of T which holds the current T and indexes relative to the current.
    /// 
    /// </summary>
    public class Tape<T>
    {
        private readonly LinkedList<T> list; //list is arranged from bottom to top
        private LinkedListNode<T> current;

        private Func<T> generateTopLayer;
        private Func<T> generateBottomLayer;

        /// <summary>
        /// Height relative to the initial "Current" node
        /// </summary>
        public int Height { get; private set; }

        public Tape(IEnumerable<T> list, int currentIndex, Func<T> generateTopLayer, Func<T> generateBottomLayer)
        {
            this.list = new LinkedList<T>(list);
            this.generateTopLayer = generateTopLayer;
            this.generateBottomLayer = generateBottomLayer;

            current = this.list.First;
            for (int i = 0; i < currentIndex; i++) current = current.Next;
        }

        public T this[int i] 
        {
            get
            {
                T val;
                if (i > 0)
                {
                    MoveUp(i);
                    val = current.Value;
                    MoveDown(i);
                }
                else
                {
                    MoveDown(i);
                    val = current.Value;
                    MoveUp(i);
                }
                return val;
            }
        }

        public void MoveUp(int count)
        {
            for(int i = 0; i < count; i++)
            {
                if (current == null)
                {
                    list.AddLast(generateTopLayer());
                    current = list.Last;
                }

                current = current.Next;
                Height++;
            }
        }

        public void MoveDown(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (current == null)
                {
                    list.AddFirst(generateBottomLayer());
                    current = list.First;
                }

                current = current.Previous;
                Height--;
            }
        }
    }
}
