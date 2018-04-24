namespace UPM.States.BuiltIn {
    public class WallClimbingState : State {
        public State OnGetOnGround;
        public State OnWallJump;
        public override void Move(MotorUser user, StateMotorMachine machine) { }
    }
}