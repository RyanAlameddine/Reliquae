using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reliquae.Drawing;
using Reliquae.Utilities.Physics;
using Reliquae.Worlds.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliquae.Worlds.Entities
{
    public class Player : ISolid, ISprite, IKinetic
    {
        public Texture2D ActiveTexture { get; set; }

        public float Rotation { get; } = 0;

        public KineticComponent KineticComponent { get; init; }

        public ColliderTransform ColliderTransform { get; set; }

        public Transform Transform => Transform;

        public Player(Texture2D activeTexture, KineticComponent kineticComponent, ColliderTransform transform)
        {
            ActiveTexture = activeTexture;
            KineticComponent = kineticComponent;
            ColliderTransform = transform;
        }
    }
}
