using UnityEngine;
using UPM.Motors.Config;

namespace UPM.Motors.States {
    /// <inheritdoc />
    /// <summary>
    /// Representa um estado de um <see cref="T:UPM.Motors.States.StateMotor" />.
    /// </summary>
    public abstract class State : ScriptableObject {
        public abstract void Move(IMovable user, ref Vector2 velocity, ref CollisionStatus collisionStatus, StateMotorMachine machine, StateMotorConfig config, LayerMask collisionMask);
    }
}