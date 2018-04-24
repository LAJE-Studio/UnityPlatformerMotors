using System;
using UnityEngine;
using UPM.Motors;
using UPM.Util;

namespace UPM.Physics {
    public class VerticalPhysicsCheck : PhysicsCheck {
        public RaycastHit2D? LastHit {
            get;
            private set;
        }

        private readonly Func<MotorUser, Vector2> customVelocityProvider;
        public VerticalPhysicsCheck() { }

        public VerticalPhysicsCheck(Func<MotorUser, Vector2> customVelocityProvider) {
            this.customVelocityProvider = customVelocityProvider;
        }

        public override void Check(MotorUser user, ref Vector2 velocity, ref CollisionStatus collStatus, LayerMask mask, Bounds2D bounds, Bounds2D shrinkedBounds) {
            //Direction
            var vel = customVelocityProvider == null ? velocity : customVelocityProvider(user);
            var direction = Math.Sign(vel.y);
            var verticalRays = user.VerticalRaycasts;
            var directionVector = new Vector2(0, vel.y * Time.deltaTime);
            // Bounds2D
            var bMin = bounds.Min;
            var bMax = bounds.Max;
            var positiveDir = direction == 1;

            var originX = shrinkedBounds.Min.x;
            var originY = positiveDir ? bMax.y : bMin.y;
            var origin = new Vector2(originX, originY);
            var width = shrinkedBounds.Size.x;
            var spacing = width / (verticalRays - 1);
            var rayLength = directionVector.magnitude;
            LastHit = null;
            var hitDown = false;
            for (byte x = 0; x < verticalRays; x++) {
                var raycast = Physics2D.Raycast(origin, directionVector, rayLength, mask);
                Debug.DrawRay(origin, directionVector, raycast ? Color.green : Color.red);
                if (raycast && !raycast.collider.isTrigger) {
                    LastHit = raycast;
                    vel.y = raycast.distance / Time.deltaTime * direction;
                    rayLength = raycast.distance;
                    collStatus.Down = direction == -1;
                    collStatus.Up = direction == 1;
                    if (!hitDown) {
                        hitDown = direction == -1;
                    }
                }

                origin.x += spacing;
            }

            if (!hitDown) {
                collStatus.Down = false;
            }
        }
    }
}