using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics.Forces
{
    public class FunctionForce : IForce
    {
        readonly Func<GameTime, (bool complete, Vector2 force)> forceFunc;

        public FunctionForce(Func<GameTime, (bool complete, Vector2 force)> forceFunc)
        {
            this.forceFunc = forceFunc;
        }

        public bool ForceComplete { get; private set; }

        public Vector2 GetForce(GameTime time) 
        {
            var (complete, force) = forceFunc(time);
            ForceComplete = complete;
            return force;
        }


    }
}
