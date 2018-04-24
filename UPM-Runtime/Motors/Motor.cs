using UnityEngine;
using UPM.Motors.Config;

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
        public void Move(MotorUser user) {
            var vel = user.Velocity;
            var status = user.CollisionStatus;
            Move(user, ref vel, ref status);
            user.CollisionStatus = status;
            user.Velocity = vel;
        }

        public abstract void Move(MotorUser user, ref Vector2 velocity, ref CollisionStatus status);
        public abstract bool RequiresConfig(MotorUser user);
        public abstract MotorConfig CreateConfig(MotorUser user);
    }
}