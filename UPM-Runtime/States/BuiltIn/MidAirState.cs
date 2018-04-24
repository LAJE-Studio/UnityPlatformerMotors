namespace UPM.States.BuiltIn {
    public class MidAirState : State {
        public State OnGetOnGround;
        public State OnGetOnWall;
        public override void Move(MotorUser user, StateMotorMachine machine) { }
    }
}