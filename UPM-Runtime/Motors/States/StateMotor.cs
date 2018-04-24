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

        public override void Move(MotorUser user, ref Vector2 velocity, ref CollisionStatus status) {
            var config = user.GetMotorConfig<StateMotorConfig>();
            if (config == null) {
                UPMDebug.LogWarning("Expected user " + user + " to have a StateMotorConfig but found none");
                return;
            }

            var m = config.StateMachine;
            if (m == null) {
                UPMDebug.LogWarning("Expected user " + user + " to have a state machine but found none");
                return;
            }

            m.Move(user, ref velocity, ref status, config);
        }

        public override bool RequiresConfig(MotorUser user) {
            return true;
        }

        public override MotorConfig CreateConfig(MotorUser user) {
            return user.gameObject.AddComponent<StateMotorConfig>();
        }
    }
}