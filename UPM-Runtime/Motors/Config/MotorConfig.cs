using UnityEngine;

namespace UPM.Motors.Config {
    public abstract class MotorConfig : MonoBehaviour, ISerializationCallbackReceiver {
        public IMovable User;

        public abstract bool IsCompatible(Motor motor);

        private void Reset() {
            User = GetComponentInParent<IMovable>();
        }

        [SerializeField, HideInInspector]
        private Object user;

        public void OnBeforeSerialize() {
            user = User as Object;
        }

        public void OnAfterDeserialize() {
            User = user as IMovable;
        }
    }

    public abstract class MotorConfig<M> : MotorConfig where M : Motor {
        public override bool IsCompatible(Motor motor) {
            return motor is M;
        }
    }
}