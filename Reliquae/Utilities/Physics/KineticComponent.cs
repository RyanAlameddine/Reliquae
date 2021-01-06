using Microsoft.Xna.Framework;
using Reliquae.Utilities.Physics.Forces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Utilities.Physics
{
    public class KineticComponent
    {
        /// <summary>
        /// units per (elapsed seconds since last tick)
        /// </summary>
        public Vector2 Velocity { get; private set; }
        /// <summary>
        /// units per (elapsed seconds since last tick)^2
        /// </summary>
        public Vector2 Accelleration { get; private set; }

        /// <summary>kg?</summary>
        public float Mass { get; private set; }
        public List<IForce> Forces { get; init; }

        public float FrictionCoefficient { get; set; }

        public KineticComponent(List<IForce> forces, float mass, float frictionCoefficient = 1f)
        {
            this.Forces = forces;
            Mass = mass;
            FrictionCoefficient = frictionCoefficient;
        }

        
        /// <summary>
        /// Applies the forces in the Forces list to the Accelleration and then the Velocity.
        /// Does not directly affect any transforms or positions.
        /// </summary>
        public void ApplyForces(GameTime gameTime)
        {
            Vector2 accelleration = Vector2.Zero;

            for (int i = 0; i < Forces.Count; i++)
            {
                accelleration += Forces[i].GetForce(gameTime);
                if (Forces[i].ForceComplete)
                {
                    Forces.RemoveAt(i);
                    i--;
                }
            }

            Accelleration = accelleration * (float)(gameTime.ElapsedGameTime.TotalSeconds / Mass);
            Velocity += Accelleration;

            if (Velocity == Vector2.Zero) return;
            //apply friction
            Vector2 friction = -Velocity.Copy();
            friction.Normalize();
            friction *= FrictionCoefficient * 9.8f * Mass; //uk*Fn
            friction *= (float)(gameTime.ElapsedGameTime.TotalSeconds / Mass); //F=ma

            if(friction.LengthSquared() > Velocity.LengthSquared())
            {
                Velocity = Vector2.Zero;
                Accelleration += friction * (float)(Math.Sqrt(friction.LengthSquared()) - Math.Sqrt(Velocity.LengthSquared()));
            }
            else
            {
                Velocity += friction;
                Accelleration += friction;
            }
        }
    }
}
