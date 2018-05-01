using UnityEngine;
using UPM.Motors.Config;

namespace UPM.Motors.States.BuiltIn {
    public sealed class WallClimbingState : State {
        public State OnGetOnGround;
        public State OnWallJump;
        public override void Move(IMovable user, ref Vector2 velocity, ref CollisionStatus collisionStatus, StateMotorMachine machine, StateMotorConfig config, LayerMask collisionMask) { }
    }
}