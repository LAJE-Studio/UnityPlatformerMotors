using UnityEngine;

namespace UPM.Util.Singleton {
    public class UPMSingletonScriptableObject<T> : ScriptableObject where T : UPMSingletonScriptableObject<T> {
        private static T instance;
        public static readonly string Path = "UPM/Resources/" + typeof(T).Name;

        public static T Instance {
            get {
                return instance ?? (instance = Load());
            }
        }

        private static T Load() {
            var found = Resources.Load<T>(Path);
            if (found != null) {
                return found;
            }

            UPMDebug.LogErrorFormat("Expected to find ScriptableObject at {0}, but there is none, please create one", Path);
            return null;
        }
    }
}