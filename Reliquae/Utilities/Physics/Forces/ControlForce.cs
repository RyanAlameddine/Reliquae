using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics.Forces
{
    public class ControlForce : IForce
    {
        readonly Func<float> getInput;
        readonly Vector2 axisVector;

        /// <param name="getInput">Function which returns the input (usually from -1 to 1) from the control on the given axis</param>
        /// <param name="axisVector">After being normalized, will represent the axis on which the input value is used to calculate direction</param>
        public ControlForce(Func<float> getInput, Vector2 axisVector)
        {
            this.getInput = getInput;
            this.axisVector = axisVector.Copy();
            this.axisVector.Normalize();
        }

        public bool ForceComplete => false;

        public Vector2 GetForce(GameTime time)
        {
            return axisVector * getInput();
        }
    }
}
