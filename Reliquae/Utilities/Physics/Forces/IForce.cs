using Microsoft.Xna.Framework;

namespace Reliquae.Utilities.Physics.Forces
{
    public interface IForce
    {
        /// <summary>
        /// Returns true if the force has completed it's execution and should be removed
        /// from the list for optimization.
        /// </summary>
        public bool ForceComplete { get; }
        
        /// <returns>Force vector in units per second</returns>
        public Vector2 GetForce(GameTime time);
    }
}