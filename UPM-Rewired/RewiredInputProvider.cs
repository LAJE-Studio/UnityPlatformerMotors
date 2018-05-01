using Rewired;
using UPM.Input;

namespace UPM.Addons.Rewired {
    public class RewiredInputProvider : InputProvider {
        private Player player;
        public int PlayerID;
        public int HorizontalActionId = 0;
        public int VerticalActionId = 1;

        private void Start() {
            player = ReInput.players.GetPlayer(PlayerID);
        }

        public override float GetHorizontal() {
            return player.GetAxisRaw(HorizontalActionId);
        }

        public override float GetVertical() {
            return player.GetAxisRaw(VerticalActionId);
        }

        public override float GetAxis(string key) {
            return player.GetAxis(key);
        }

        public override float GetAxis(int id) {
            return player.GetAxis(id);
        }

        public override bool GetButtonDown(string key) {
            return player.GetButtonDown(key);
        }

        public override bool GetButtonDown(int id) {
            return player.GetButtonDown(id);
        }

        public override bool GetButton(string key) {
            return player.GetButton(key);
        }

        public override bool GetButton(int id) {
            return player.GetButton(id);
        }

        public override bool GetButtonUp(string key) {
            return player.GetButtonUp(key);
        }

        public override bool GetButtonUp(int id) {
            return player.GetButtonUp(id);
        }
    }
}