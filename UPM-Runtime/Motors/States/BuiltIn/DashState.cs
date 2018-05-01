using UnityEngine;
using UPM.Motors.Config;

namespace UPM.Motors.States.BuiltIn {
    public sealed class DashState : State {
        public override void Move(IMovable user, ref Vector2 velocity, ref CollisionStatus collisionStatus, StateMotorMachine machine, StateMotorConfig config, LayerMask collisionMask) { }
    }
}