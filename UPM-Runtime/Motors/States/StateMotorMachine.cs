using System;
using UnityEngine;

namespace UPM.Motors.States {
    [Serializable]
    public sealed class StateMotorMachine {
        public StateMotorMachine(State state) {
            this.state = state;
        }

        [SerializeField]
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
}