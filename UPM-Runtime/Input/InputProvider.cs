using UnityEngine;

namespace UPM.Input {
    /**
     * Representa uma fonte de input, seja ou player, ou AI.
     */
    public abstract class InputProvider : MonoBehaviour {
        public abstract float GetHorizontal();
        public abstract float GetVertical();
        public abstract float GetAxis(string key);
        public abstract float GetAxis(int key);
    }
}