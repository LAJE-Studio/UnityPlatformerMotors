using UnityEngine;
using UPM.Motors.Config;
using UPM.Physics;

namespace UPM.Motors.States.BuiltIn {
    public sealed class GroundedState : State {
        public State OnGetOffGround;
        public static readonly VerticalPhysicsCheck VerticalVelocityCheck = new VerticalPhysicsCheck();
        public static readonly HorizontalPhysicsCheck HorizontalVelocityCheck = new HorizontalPhysicsCheck();
        public static readonly VerticalPhysicsCheck SlopeCheck = new VerticalPhysicsCheck(SlopeCheckProvider);

        public static readonly PhysicsBehaviour GroundedBehaviour = new PhysicsBehaviour(
            VerticalVelocityCheck,
            HorizontalVelocityCheck,
            SlopeCheck
        );

        private static Vector2 SlopeCheckProvider(MotorUser arg) {
            return Vector2.down * Time.fixedDeltaTime;
        }


        public override void Move(MotorUser user, ref Vector2 velocity, ref CollisionStatus collisionStatus, StateMotorMachine machine, StateMotorConfig config1) {
            var config = user.GetMotorConfig<GroundMotorConfig>();
            if (config == null) {
                return;
            }

            GroundedBehaviour.Check(user, ref velocity, ref collisionStatus);
        }
    }
}