using UnityEngine;

namespace UPM.Input {
    /// <inheritdoc />
    /// <summary>
    /// Representa uma fonte de input, seja ou player, ou AI.
    /// </summary>
    public abstract class InputProvider : MonoBehaviour {
        public abstract float GetHorizontal();
        public abstract float GetVertical();
        public abstract float GetAxis(string key);
        public abstract float GetAxis(int id);
        public abstract bool GetButtonDown(string key);
        public abstract bool GetButtonDown(int id);
        public abstract bool GetButton(string key);
        public abstract bool GetButton(int id);
        public abstract bool GetButtonUp(string key);
        public abstract bool GetButtonUp(int id);
    }
}