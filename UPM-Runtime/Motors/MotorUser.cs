﻿using UnityEngine;
using UPM.Input;
using UPM.Motors;
using UPM.Motors.States;

namespace UPM {
    /// <inheritdoc />
    /// <summary>
    /// Representa algo que pode se movimentar utilizando um <see cref="Motor"/>.
    /// <br/>
    /// Esta classe é responsavel por definir variáveis de como seu correspondente usuário deve se movimentar.
    /// <br/>
    /// Normalmente, uma instância desta classe e uma de um <see cref="Motor"/> são referênciadas por uma instância de
    /// classe de uma entidade, e essa por sua vez, usa o motor para movimentar o usuário, ou seja, há uma relação de
    /// um para um entre um MotorUser e uma entidade.
    /// </summary>
    public sealed class MotorUser : MonoBehaviour {
        /// <summary>
        /// Curva que define o quanto de aceleração deve ser aplicada baseada em sua velocidade atual.
        /// <br/>
        /// Esta curva pode ser interpretada diferentemente por diferentes <see cref="Motor"/>s.
        /// <br/>
        /// A curva deve sempre se situar entre 0 e 1;
        /// </summary>
        public AnimationCurve AccelerationCurve;

        /// <summary>
        /// A fonte de input do qual o <see cref="Motor"/> selecionado usa para inputs
        /// <seealso cref="InputProvider"/>
        /// </summary>
        public InputProvider InputProvider;

        /// <summary>
        /// A velocidade máxima em que este usuário pode se encontrar. 
        /// </summary>
        public float MaxSpeed;

        /// <summary>
        /// O <see cref="Transform"/> ao qual o <see cref="Motor"/> aplica movimentação.
        /// </summary>
        public Transform MovementTransform;

        /// <summary>
        /// O <see cref="Motors.Motor"/> usado por esse usuário?
        /// </summary>
        public Motor Motor;

        public void Move() {
            Motor.Move(this);
        }
        private StateMotorMachine cachedMachine;

        /// <summary>
        /// A maquina de está que pode ser usada por um <see cref="StateMotor"/> caso seja o tipo do <see cref="Motor"/>
        /// </summary>
        public StateMotorMachine StateMachine {
            get {
                var m = Motor as StateMotor;
                if (m == null) {
                    return null;
                }

                return cachedMachine ?? (cachedMachine = new StateMotorMachine(m.DefaultState));
            }
        }

        private void Reset() {
            //Ao ser resetado, o transform de movimento torna-se o transform ao qual o component está anexado
            MovementTransform = transform;
        }
    }
}