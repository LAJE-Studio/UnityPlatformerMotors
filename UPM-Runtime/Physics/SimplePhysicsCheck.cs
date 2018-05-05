using UnityEngine;
using UPM.Motors;
using UPM.Util;

namespace UPM.Physics {
    public delegate Vector2 CustomVelocityProvider(IMovable movable);

    public abstract class SimplePhysicsCheck : PhysicsCheck {
        private readonly CustomVelocityProvider customVelocityProvider;

        protected SimplePhysicsCheck(CustomVelocityProvider customVelocityProvider = null) {
            this.customVelocityProvider = customVelocityProvider;
        }

        public override void Check(IMovable user, ref Vector2 vel, ref CollisionStatus collStatus, LayerMask mask,
            Bounds2D bounds,
            Bounds2D shrinkedBounds) {
            var hasProvider = customVelocityProvider != null;
            var velocity = hasProvider ? customVelocityProvider(user) : vel;
            DoCheck(user, ref velocity, ref collStatus, mask, bounds, shrinkedBounds);
            if (!hasProvider) {
                vel = velocity;
            }
        }

        protected abstract void DoCheck(IMovable user, ref Vector2 vel, ref CollisionStatus collStatus, LayerMask mask,
            Bounds2D bounds,
            Bounds2D shrinkedBounds);
    }
}