namespace UPM.Input {
    public class ConstantInputProvider : InputProvider {
        public float Horizontal;
        public float Vertical;

        public override float GetHorizontal() {
            return Horizontal;
        }

        public override float GetVertical() {
            return Vertical;
        }

        public override float GetAxis(string key) {
            return 0;
        }

        public override float GetAxis(int id) {
            return 0;
        }

        public override bool GetButtonDown(string key) {
            return false;
        }

        public override bool GetButtonDown(int id) {
            return false;
        }

        public override bool GetButton(string key) {
            return false;
        }

        public override bool GetButton(int id) {
            return false;
        }

        public override bool GetButtonUp(string key) {
            return false;
        }

        public override bool GetButtonUp(int id) {
            return false;
        }
    }
}