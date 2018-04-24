using UnityEngine;

namespace UPM.Motors {
    /// <inheritdoc />
    /// <summary>
    /// Um "motor" representa uma maneira em que um <see cref="T:UPM.MotorUser" /> pode se movimentar.
    /// <br />
    /// Podem, e na esmagadora maioria das vezes, devem, existir mais de uma instância de uma subclasse de um motor, mas
    /// com configurações diferentes usadas por diferentes usuários.
    /// </summary>
    public abstract class Motor : ScriptableObject {
        /// <summary>
        /// Função usada para movimentar um <see cref="MotorUser"/>
        /// </summary>
        /// <param name="user"></param>
        public abstract void Move(MotorUser user);
    }
}