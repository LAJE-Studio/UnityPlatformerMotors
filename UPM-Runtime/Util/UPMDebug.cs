using UnityEngine;

namespace UPM.Util {
    public static class UPMDebug {
        public const string Prefix = "[UPM] ";

        public static void LogErrorFormat(string error, params object[] format) {
            Debug.LogErrorFormat(Prefix + error, format);
        }

        public static void LogWarning(string s) {
            Debug.LogWarning(Prefix + s);
        }
    }
}