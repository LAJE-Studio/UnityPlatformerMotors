using UnityEngine;
using UPM.Input;
using UPM.Motors.Config;

namespace UPM.Motors {
    /// <summary>
    /// Representa algo que pode se movimentar utilizando um <see cref="Motor"/>.
    /// <br/>
    /// Esta classe é responsavel por definir variáveis de como seu correspondente usuário deve se movimentar.
    /// <br/>
    /// Normalmente, uma instância desta classe e uma de um <see cref="Motor"/> são referênciadas por uma instância de
    /// classe de uma entidade, e essa por sua vez, usa o Motor para movimentar o usuário, ou seja, há uma relação de
    /// um para um entre um MotorUser e uma entidade.
    /// </summary>
    public interface IMovable {
        GameObject GameObject {
            get;
        }

        InputProvider InputProvider {
            get;
        }

        /// <summary>
        /// Curva que define o quanto de aceleração deve ser aplicada baseada em sua velocidade atual.
        /// <br/>
        /// Esta curva pode ser interpretada diferentemente por diferentes <see cref="Motor"/>s.
        /// <br/>
        /// A curva deve sempre se situar entre 0 e 1;
        /// </summary>
        AnimationCurve AccelerationCurve {
            get;
        }

        /// <summary>
        /// Hitbox usada para checar colisões
        /// </summary>
        Collider2D Hitbox {
            get;
        }

        /// <summary>
        /// O quanto as bordas da <see cref="Hitbox"/> são encolhidas para checar por colisões 
        /// </summary>
        float Inset {
            get;
        }

        /// <summary>
        /// O total de raycasts que são executados quando checando por colisões horizontais 
        /// </summary>
        byte HorizontalRaycasts {
            get;
        }

        /// <summary>
        /// O total de raycasts que são executados quando checando por colisões verticais 
        /// </summary>
        byte VerticalRaycasts {
            get;
        }

        /// <summary>
        /// A velocidade máxima em que este usuário pode se encontrar. 
        /// </summary>
        float MaxSpeed {
            get;
        }

        /// <summary>
        /// O <see cref="Transform"/> ao qual o <see cref="Motor"/> aplica movimentação.
        /// </summary>
        Transform MovementTransform {
            get;
        }

        /// <summary>
        /// O <see cref="Motors.Motor"/> usado por esse usuário.
        /// </summary>
        Motor Motor {
            get;
        }

        void Move();

        /// <summary>
        /// A velocidade que é aplicada a cada <see cref="FixedUpdate"/>
        /// </summary>
        Vector2 Velocity {
            get;
            set;
        }

        CollisionStatus CollisionStatus {
            get;
            set;
        }

        MotorConfig MotorConfig {
            get;
        }

        float SpeedPercent {
            get;
        }

        C GetMotorConfig<C>() where C : MotorConfig;
    }
}