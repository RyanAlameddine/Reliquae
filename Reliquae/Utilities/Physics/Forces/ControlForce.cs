using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics.Forces
{
    /// <summary>
    /// A force inversely proportional to velocity that is controlled by an input function.
    /// </summary>
    public class ControlForce : IForce
    {
        readonly Func<Vector2> getVelocity;
        readonly Func<float> getInput;
        readonly Vector2 axisVector;

        /// <param name="getInput">Function which returns the input from the control on the given axis.</param>
        /// <param name="axisVector">After being normalized, will represent the axis on which the input value is used to calculate direction</param>
        public ControlForce(Func<float> getInput, Func<Vector2> getVelocity,  Vector2 axisVector)
        {
            this.getInput = getInput;
            this.getVelocity = getVelocity;
            this.axisVector = axisVector.Copy();
            this.axisVector.Normalize();
        }

        public bool ForceComplete => false;

        public Vector2 GetForce(GameTime time)
        {
            return axisVector * getInput() / (float)Math.Max(1, getVelocity().LengthSquared());
        }
    }
}
