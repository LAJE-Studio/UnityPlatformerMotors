using UnityEngine;

namespace UPM.States {
    /// <inheritdoc />
    /// <summary>
    /// Representa um estado de um <see cref="T:UPM.States.StateMotor" />.
    /// </summary>
    public abstract class State : ScriptableObject {
        public abstract void Move(MotorUser user, StateMotorMachine machine);
    }
}