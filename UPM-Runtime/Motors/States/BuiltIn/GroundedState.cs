namespace UPM.Motors.States.BuiltIn {
    public sealed class GroundedState : State {
        public float Gravity = -19.62F;
        public State OnGetOffGround;
        public override void Move(MotorUser user, StateMotorMachine machine) { }
    }
}