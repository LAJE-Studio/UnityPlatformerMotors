using UnityEngine;

namespace UPM.Motors.States {
    /// <inheritdoc />
    /// <summary>
    /// Um <see cref="Motor"/> baseado em estados, muito usado em entidades que tem gravidade e se movimentam pelo chão.
    /// </summary>
    [CreateAssetMenu(menuName = "UPM/Motors/StateMotor")]
    public sealed class StateMotor : Motor {
        public State DefaultState;
        public override void Move(MotorUser user) {
            var m = user.StateMachine;
            if (m == null) {
                Debug.LogWarning("Expected user " + user + " to have a state machine but found none");
                return;
            }

            m.Move(user);
        }
    }
}