using UnityEngine;
using UPM.Motors.Config;
using UPM.Util;

namespace UPM.Motors.States {
    /// <inheritdoc />
    /// <summary>
    /// Um <see cref="Motor"/> baseado em estados, muito usado em entidades que tem gravidade e se movimentam pelo chão.
    /// </summary>
    [CreateAssetMenu(menuName = "UPM/Motors/StateMotor")]
    public sealed class StateMotor : Motor {
        public State DefaultState;
        public LayerMask CollisionMask;
        public override void Move(IMovable user, ref Vector2 velocity, ref CollisionStatus status) {
            var config = user.GetMotorConfig<StateMotorConfig>();
            if (config == null) {
                UPMDebug.LogWarning("Expected user " + user + " to have a StateMotorConfig but found none");
                return;
            }

            var m = config.StateMachine;
            if (m == null) {
                UPMDebug.LogError("Expected user " + user + " to have a state machine but found none");
                return;
            }

            m.Move(user, ref velocity, ref status, config, CollisionMask);
        }

        public override bool RequiresConfig(IMovable user) {
            return true;
        }

        public override MotorConfig CreateConfig(IMovable user) {
            return user.GameObject.AddComponent<StateMotorConfig>();
        }
    }
}