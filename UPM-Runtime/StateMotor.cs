using System;
using UnityEngine;

namespace UPM {
    /// <inheritdoc />
    /// <summary>
    /// Um motor baseado em estados, muito usado em entidades que tem gravidade e se movimentam pelo chão.
    /// </summary>
    public class StateMotor : Motor {
        [SerializeField, HideInInspector]
        private StateMotorMachine machine;

        public override void Move(MotorUser user) {
            machine.Move(user);
        }
    }

    public sealed class StateMotorMachine {
        [SerializeField, HideInInspector]
        private State state;

        public State State {
            get {
                return state;
            }
            set {
                state = value;
            }
        }

        public void Move(MotorUser user) {
            state.Move(user, this);
        }
    }

    /// <summary>
    /// Representa um estado de um <see cref="StateMotor"/>.
    /// </summary>
    public abstract class State : ScriptableObject {
        public abstract void Move(MotorUser user, StateMotorMachine machine);
    }
}