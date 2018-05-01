using UnityEditor;
using UnityEngine;
using UPM.Motors;
using UPM.Motors.Config;

namespace UPM.Editor.Config {
    [CustomEditor(typeof(MotorConfig), editorForChildClasses: true)]
    public class MotorConfigEditor : UnityEditor.Editor {
        private MotorConfig config;

        protected virtual void OnEnable() {
            config = (MotorConfig) target;
        }

        public override void OnInspectorGUI() {
            var u = config.User as Object;
            config.User = EditorGUILayout.ObjectField("User", u, typeof(Component), true) as IMovable;
            base.OnInspectorGUI();
        }
    }
}