using UPM.Motors.States;

namespace UPM.Motors.Config {
    public class StateMotorConfig : MotorConfig<StateMotor> {
        private StateMotorMachine cachedMachine;

        /// <summary>
        /// A maquina de está que pode ser usada por um <see cref="StateMotor"/> caso seja o tipo do <see cref="motor"/>
        /// </summary>
        public StateMotorMachine StateMachine {
            get {
                var u = User;
                if (u == null) {
                    return null;
                }

                var m = u.Motor as StateMotor;
                if (m == null) {
                    return null;
                }

                return cachedMachine ?? (cachedMachine = new StateMotorMachine(m.DefaultState));
            }
        }
    }
}