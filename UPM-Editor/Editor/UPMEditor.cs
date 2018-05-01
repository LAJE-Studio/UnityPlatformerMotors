using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UPM.Editor {
    public class StateData {
        public StateData(Type type) {
            Type = type;
            Valid = type.GetConstructor(Type.EmptyTypes) != null;
        }

        public Type Type {
            get;
            set;
        }

        public bool Valid {
            get;
            private set;
        }
    }

    public static class UPMEditor {
        public static GUIContent AddStateContent = new GUIContent("Add State");
        private static List<string> layers;
        private static string[] layerNames;

        public static LayerMask LayerMaskField(string label, LayerMask selected) {
            if (layers == null) {
                layers = new List<string>();
                layerNames = new string[4];
            } else {
                layers.Clear();
            }

            var emptyLayers = 0;
            for (var i = 0; i < 32; i++) {
                var layerName = LayerMask.LayerToName(i);

                if (layerName != "") {
                    for (; emptyLayers > 0; emptyLayers--)
                        layers.Add("Layer " + (i - emptyLayers));
                    layers.Add(layerName);
                } else {
                    emptyLayers++;
                }
            }

            if (layerNames.Length != layers.Count) {
                layerNames = new string[layers.Count];
            }

            for (var i = 0; i < layerNames.Length; i++)
                layerNames[i] = layers[i];

            selected.value = EditorGUILayout.MaskField(label, selected.value, layerNames);

            return selected;
        }
    }
}