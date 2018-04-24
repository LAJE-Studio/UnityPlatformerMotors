using UnityEngine;

namespace UPM.Motors.Config {
    public abstract class MotorConfig : MonoBehaviour {
        public MotorUser User;
        public abstract bool IsCompatible(Motor motor);

        private void Reset() {
            User = GetComponentInParent<MotorUser>();
        }
    }

    public abstract class MotorConfig<M> : MotorConfig where M : Motor {
        public override bool IsCompatible(Motor motor) {
            return motor is M;
        }
    }
}