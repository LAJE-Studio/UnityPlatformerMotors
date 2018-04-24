using System;
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
    }
}