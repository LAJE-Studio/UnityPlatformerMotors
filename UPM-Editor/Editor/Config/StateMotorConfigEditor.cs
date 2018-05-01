using UnityEditor;
using UnityEngine;
using UPM.Motors.Config;

namespace UPM.Editor.Config {
    [CustomEditor(typeof(StateMotorConfig), editorForChildClasses: true)]
    public class StateMotorConfigEditor : MotorConfigEditor {
        private StateMotorConfig config;

        protected override void OnEnable() {
            base.OnEnable();
            config = (StateMotorConfig) target;
        }

        public override void OnInspectorGUI() {
            var sm = config.StateMachine;
            var defaultColor = GUI.contentColor;
            var msg = "Config State Machine: ";
            if (sm == null) {
                GUI.contentColor = Color.red;
                msg += "null";
            } else {
                msg += sm;
            }

            EditorGUILayout.LabelField(msg);
            GUI.contentColor = defaultColor;
            base.OnInspectorGUI();
        }
    }
}