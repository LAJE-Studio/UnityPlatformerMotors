namespace UPM.Input {
    public class NativeInputProvider : InputProvider {
        public override float GetHorizontal() {
            return GetAxis("Horizontal");
        }

        public override float GetVertical() {
            return GetAxis("Vertical");
        }

        public override float GetAxis(string key) {
            return UnityEngine.Input.GetAxisRaw(key);
        }

        public override float GetAxis(int key) {
            return 0;
        }

        public override bool GetButtonDown(string key) {
            return UnityEngine.Input.GetButtonDown(key);
        }

        public override bool GetButtonDown(int id) {
            return false;
        }

        public override bool GetButton(string key) {
            return UnityEngine.Input.GetButton(key);
        }

        public override bool GetButton(int id) {
            return false;
        }

        public override bool GetButtonUp(string key) {
            return UnityEngine.Input.GetButton(key);
        }

        public override bool GetButtonUp(int id) {
            return false;
        }
    }
}