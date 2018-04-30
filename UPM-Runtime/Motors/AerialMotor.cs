using System;
using UnityEngine;
using UPM.Motors.Config;
using UPM.Physics;

namespace UPM.Motors {
    [CreateAssetMenu(menuName = "UPM/Motors/AerialMotor")]
    public sealed class AerialMotor : Motor {
        public override void Move(MotorUser user, ref Vector2 velocity, ref CollisionStatus status) {
            ProcessInputs(ref velocity, user);
            velocity = Vector2.ClampMagnitude(velocity, user.MaxSpeed);
            AerialBehaviour.Check(user, ref velocity, ref status);
        }

        public override bool RequiresConfig(MotorUser user) {
            return false;
        }

        public override MotorConfig CreateConfig(MotorUser user) {
            return null;
        }

        public static readonly PhysicsBehaviour AerialBehaviour = new PhysicsBehaviour(
            new HorizontalPhysicsCheck(),
            new VerticalPhysicsCheck()
        );


        private static void ProcessInputs(ref Vector2 vel, MotorUser user) {
            var provider = user.InputProvider;
            if (provider == null) {
                return;
            }

            var xInput = provider.GetHorizontal();
            var yInput = provider.GetVertical();
            var xInputDir = Math.Sign(xInput);
            var yInputDir = Math.Sign(yInput);
            var maxSpeed = user.MaxSpeed;
            var xPercent = vel.x / maxSpeed;
            var yPercent = vel.y / maxSpeed;
            var xAcceleration = user.AccelerationCurve.Evaluate(xPercent) * xInputDir;
            var yAcceleration = user.AccelerationCurve.Evaluate(yPercent) * yInputDir;
            vel.x += xAcceleration;
            vel.y += yAcceleration;
            var deacceleration = user.AccelerationCurve.Evaluate(1 - user.SpeedPercent);
            if (Mathf.Abs(xInput) > 0 || Mathf.Abs(yInput) > 0) {
                return;
            }

            var de = deacceleration / 2;
            if (vel.magnitude <= de) {
                vel = Vector2.zero;
            } else {
                vel += de * -vel.normalized;
            }
        }
    }
}