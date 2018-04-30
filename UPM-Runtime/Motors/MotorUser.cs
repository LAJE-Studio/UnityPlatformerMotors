using UnityEngine;
using UPM.Input;
using UPM.Motors.Config;
using UPM.Motors.States;
using UPM.Util;

namespace UPM.Motors {
    /// <inheritdoc />
    /// <summary>
    /// Representa algo que pode se movimentar utilizando um <see cref="motor"/>.
    /// <br/>
    /// Esta classe é responsavel por definir variáveis de como seu correspondente usuário deve se movimentar.
    /// <br/>
    /// Normalmente, uma instância desta classe e uma de um <see cref="motor"/> são referênciadas por uma instância de
    /// classe de uma entidade, e essa por sua vez, usa o motor para movimentar o usuário, ou seja, há uma relação de
    /// um para um entre um MotorUser e uma entidade.
    /// </summary>
    public sealed class MotorUser : MonoBehaviour {
        /// <summary>
        /// Curva que define o quanto de aceleração deve ser aplicada baseada em sua velocidade atual.
        /// <br/>
        /// Esta curva pode ser interpretada diferentemente por diferentes <see cref="motor"/>s.
        /// <br/>
        /// A curva deve sempre se situar entre 0 e 1;
        /// </summary>
        public AnimationCurve AccelerationCurve;

        /// <summary>
        /// Hitbox usada para checar colisões
        /// </summary>
        public Collider2D Hitbox;

        /// <summary>
        /// O quanto as bordas da <see cref="Hitbox"/> são encolhidas para checar por colisões 
        /// </summary>
        public float Inset;

        /// <summary>
        /// O total de raycasts que são executados quando checando por colisões horizontais 
        /// </summary>
        public byte HorizontalRaycasts = 3;

        /// <summary>
        /// O total de raycasts que são executados quando checando por colisões verticais 
        /// </summary>
        public byte VerticalRaycasts = 3;

        /// <summary>
        /// A fonte de input do qual o <see cref="motor"/> selecionado usa para inputs
        /// <seealso cref="InputProvider"/>
        /// </summary>
        public InputProvider InputProvider;

        /// <summary>
        /// A velocidade máxima em que este usuário pode se encontrar. 
        /// </summary>
        public float MaxSpeed;

        /// <summary>
        /// O <see cref="Transform"/> ao qual o <see cref="motor"/> aplica movimentação.
        /// </summary>
        public Transform MovementTransform;

        [SerializeField]
        private Motor motor;

        /// <summary>
        /// O <see cref="Motors.Motor"/> usado por esse usuário.
        /// </summary>
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
        }


        /// <summary>
        /// A velocidade que é aplicada a cada <see cref="FixedUpdate"/>
        /// </summary>
        public Vector2 Velocity;

        // Usamos FixedUpdate para evitar problemas de frame rate
        private void FixedUpdate() {
            Move();
            MovementTransform.position += (Vector3) Velocity * Time.fixedDeltaTime;
        }


        [SerializeField]
        private MotorConfig motorConfig;

        public CollisionStatus CollisionStatus;

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
            MovementTransform = transform;
            Hitbox = GetComponentInChildren<Collider2D>();
            AccelerationCurve = AnimationCurve.Constant(0, 1, 1);
            Inset = 0.1F;
            Motor = null;
            MotorConfig = GetComponentInChildren<MotorConfig>();
        }
    }
}