namespace UPM.Motors.States.BuiltIn {
    public sealed class MidAirState : State {
        public State OnGetOnGround;
        public State OnGetOnWall;
        public override void Move(MotorUser user, StateMotorMachine machine) { }
    }
}