using System;
using UnityEngine;
using UPM.Motors.Config;

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

        public void Move(MotorUser user, ref Vector2 velocity, ref CollisionStatus status, StateMotorConfig config) {
            state.Move(user, ref velocity, ref status, this, config);
        }
    }
}