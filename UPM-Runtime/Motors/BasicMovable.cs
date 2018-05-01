using UnityEngine;
using UPM.Input;
using UPM.Motors.Config;
using UPM.Motors.States;
using UPM.Util;

namespace UPM.Motors {
    public sealed class BasicMovable : MonoBehaviour, IMovable {
        [SerializeField]
        private Motor motor;

        [SerializeField]
        private AnimationCurve accelerationCurve;

        [SerializeField]
        private Collider2D hitbox;

        [SerializeField]
        private InputProvider inputProvider;

        [SerializeField]
        private float inset;

        [SerializeField]
        private byte horizontalRaycasts = 3;

        [SerializeField]
        private byte verticalRaycasts = 3;

        [SerializeField]
        private float maxSpeed;

        [SerializeField]
        private Transform movementTransform;


        [SerializeField]
        private CollisionStatus collisionStatus;

        public GameObject GameObject {
            get {
                return gameObject;
            }
        }

        public InputProvider InputProvider {
            get {
                return inputProvider;
            }
            set {
                inputProvider = value;
            }
        }

        public AnimationCurve AccelerationCurve {
            get {
                return accelerationCurve;
            }
            set {
                accelerationCurve = value;
            }
        }

        public Collider2D Hitbox {
            get {
                return hitbox;
            }
            set {
                hitbox = value;
            }
        }

        public float Inset {
            get {
                return inset;
            }
            set {
                inset = value;
            }
        }

        public byte HorizontalRaycasts {
            get {
                return horizontalRaycasts;
            }
            set {
                horizontalRaycasts = value;
            }
        }

        public byte VerticalRaycasts {
            get {
                return verticalRaycasts;
            }
            set {
                verticalRaycasts = value;
            }
        }

        public float MaxSpeed {
            get {
                return maxSpeed;
            }
            set {
                maxSpeed = value;
            }
        }

        public Transform MovementTransform {
            get {
                return movementTransform;
            }
            set {
                movementTransform = value;
            }
        }

        public CollisionStatus CollisionStatus {
            get {
                return collisionStatus;
            }
            set {
                collisionStatus = value;
            }
        }

        public Motor Motor {
            get {
                return motor;
            }
            set {
                motor = value;
                if (value == null || !motor.RequiresConfig(this)) {
                    return;
                }

                var config = MotorConfig;
                if (config != null && config.IsCompatible(motor)) {
                    return;
                }

                var foundConfig = GetComponentInChildren<MotorConfig>();
                var foundValid = foundConfig != null && foundConfig.IsCompatible(motor);
                MotorConfig = foundValid ? foundConfig : value.CreateConfig(this);
            }
        }

        public void Move() {
            motor.Move(this);
            MovementTransform.position += (Vector3) Velocity * Time.fixedDeltaTime;
        }

        private void FixedUpdate() {
            Move();
        }

        public Vector2 Velocity {
            get;
            set;
        }


        [SerializeField]
        private MotorConfig motorConfig;

        public MotorConfig MotorConfig {
            get {
                return motorConfig;
            }

            set {
                if (value != null) {
                    var m = motor;
                    if (m != null && m.RequiresConfig(this) && !value.IsCompatible(m)) {
                        UPMDebug.LogWarning("Attempted to set motor config " + value + " incompatible to motor " + motor);
                        return;
                    }
                } else if (motor.RequiresConfig(this)) {
                    UPMDebug.LogWarning("Attempted to remove motor config required by motor " + motor);
                    return;
                }

                motorConfig = value;
            }
        }

        public float SpeedPercent {
            get {
                return Velocity.magnitude / MaxSpeed;
            }
        }

        public C GetMotorConfig<C>() where C : MotorConfig {
            return motorConfig as C;
        }

        private void Reset() {
//Ao ser resetado, o transform de movimento torna-se o transform ao qual o component está anexado
            movementTransform = transform;
            hitbox = GetComponentInChildren<Collider2D>();
            accelerationCurve = AnimationCurve.Constant(0, 1, 1);
            inset = 0.1F;
            MaxSpeed = 10;
            Motor = null;
            horizontalRaycasts = 3;
            verticalRaycasts = 3;
            MotorConfig = GetComponentInChildren<MotorConfig>();
            InputProvider = GetComponentInChildren<InputProvider>();
        }
    }
}