using UPM.Motors.States;

namespace UPM.Motors.Config {
    public class GroundMotorConfig : StateMotorConfig {
        public float MaxAngle = 45;
        public float GravityScale = 1;
        public float JumpForce = 5;
        public float JumpCutGravityModifier = 1;
    }
}