using UnityEngine;
using UPM.Motors;
using UPM.Util;

namespace UPM.Physics {
    public abstract class PhysicsCheck {
        public abstract void Check(MotorUser user, ref Vector2 vel, ref CollisionStatus collStatus, LayerMask mask, Bounds2D bounds, Bounds2D shrinkedBounds);
    }
}