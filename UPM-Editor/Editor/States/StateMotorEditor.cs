using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UPM.Motors.States;

namespace UPM.Editor.States {
    [CustomEditor(typeof(StateMotor))]
    public class StateMotorEditor : UnityEditor.Editor {
        private StateSelectorContent stateSelector;
        private StateMotor motor;

        private void OnEnable() {
            motor = (StateMotor) target;
            stateSelector = new StateSelectorContent(motor);
        }

        public override void OnInspectorGUI() {
            var e = Event.current;
            var states = UPMEditorUtil.GetAllStates(motor);
            motor.DefaultState = (State) EditorGUILayout.ObjectField("Default State", motor.DefaultState, typeof(State), false);
            var notEmpty = states.Count > 0;
            EditorGUILayout.PrefixLabel((notEmpty ? states.Count.ToString() : "No") + " states found");

            if (notEmpty) {
                var toRemove = new List<State>();
                foreach (var state in states) {
                    EditorGUILayout.BeginHorizontal();
                    state.name = EditorGUILayout.TextField(state.name);
                    if (GUILayout.Button("Delete")) {
                        toRemove.Add(state);
                    }

                    EditorGUILayout.EndHorizontal();
                }

                foreach (var state in toRemove) {
                    UPMEditorUtil.DeleteInstance(motor, state);
                    AssetDatabase.SaveAssets();
                }
            }

            if (!GUILayout.Button(UPMEditor.AddStateContent)) {
                return;
            }

            var rect = new Rect(e.mousePosition, stateSelector.GetWindowSize());
            PopupWindow.Show(rect, stateSelector);
        }
    }
}