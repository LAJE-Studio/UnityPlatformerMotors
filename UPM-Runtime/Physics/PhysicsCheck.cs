using UnityEngine;
using UPM.Motors;
using UPM.Util;

namespace UPM.Physics {
    public abstract class PhysicsCheck {
        public abstract void Check(IMovable user, ref Vector2 vel, ref CollisionStatus collStatus, LayerMask mask, Bounds2D bounds, Bounds2D shrinkedBounds);
    }
}