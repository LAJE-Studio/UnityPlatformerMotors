using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UPM.Motors.States;

namespace UPM.Editor {
    public static class UPMEditorUtil {
        private static readonly Dictionary<StateMotor, List<State>> StatesCache = new Dictionary<StateMotor, List<State>>();

        public static List<State> GetAllStates(StateMotor motor) {
            if (StatesCache.ContainsKey(motor)) {
                return StatesCache[motor];
            }

            var path = AssetDatabase.GetAssetPath(motor);
            var found = AssetDatabase.LoadAllAssetsAtPath(path).OfType<State>().ToList();
            StatesCache[motor] = found;
            return found;
        }

        public static void NotifyNewInstance(StateMotor motor, State instance) {
            var s = GetAllStates(motor);
            if (!s.Contains(instance)) {
                s.Add(instance);
            }
        }

        public static void DeleteInstance(StateMotor motor, State state) {
            var s = GetAllStates(motor);
            if (s.Contains(state)) {
                s.Remove(state);
            }

            Object.DestroyImmediate(state, true);
        }
    }
}