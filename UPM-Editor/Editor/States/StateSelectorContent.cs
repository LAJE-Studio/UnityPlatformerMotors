using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UPM.Motors.States;

namespace UPM.Editor.States {
    public class StateSelectorContent : PopupWindowContent {
        private const float Width = 200;
        private readonly StateMotor motor;

        public StateSelectorContent(StateMotor motor) {
            this.motor = motor;
        }

        public override Vector2 GetWindowSize() {
            var height = EditorGUIUtility.singleLineHeight * UPMAssemblyUtil.KnownPossibleStates.Count;
            return new Vector2(Width, height);
        }

        public override void OnGUI(Rect rect) {
            var data = UPMAssemblyUtil.KnownPossibleStates;
            for (var i = 0; i < data.Count; i++) {
                var s = data[i];
                var pos = rect.GetLine((uint) i, EditorGUIUtility.singleLineHeight);
                GUI.enabled = s.Valid;
                var type = s.Type;
                if (!GUI.Button(pos, type.Name)) {
                    continue;
                }

                var instance = (State) ScriptableObject.CreateInstance(type);
                instance.name = type.Name;
                AssetDatabase.AddObjectToAsset(instance, motor);
                AssetDatabase.SaveAssets();
                UPMEditorUtil.NotifyNewInstance(motor, instance);
            }
        }
    }
}