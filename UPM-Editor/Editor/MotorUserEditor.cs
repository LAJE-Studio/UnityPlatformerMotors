using System;
using UnityEditor;
using UnityEngine;
using UPM.Input;
using UPM.Motors;
using UPM.Motors.Config;

namespace UPM.Editor {
    [CustomEditor(typeof(BasicMovable))]
    public class MotorUserEditor : UnityEditor.Editor {
        private BasicMovable user;

        private void OnEnable() {
            user = (BasicMovable) target;
        }

        public override void OnInspectorGUI() {
            var motor = (Motor) EditorGUILayout.ObjectField("Motor", user.Motor, typeof(Motor), false);
            user.Motor = motor;
            var config = (MotorConfig) EditorGUILayout.ObjectField("Motor Config", user.MotorConfig, typeof(MotorConfig), true);
            user.MotorConfig = config;
            if (motor != null) {
                if (motor.RequiresConfig(user)) {
                    EditorGUILayout.HelpBox("Motor Config " + user.MotorConfig + " is required by motor " + motor, MessageType.Info);
                } else if (config != null) {
                    EditorGUILayout.HelpBox("Motor Config " + user.MotorConfig + " is not required by motor " + motor, MessageType.Info);
                }
            }

            user.InputProvider = (InputProvider) EditorGUILayout.ObjectField("Input Provider", user.InputProvider, typeof(InputProvider), true);
            user.MovementTransform = (Transform) EditorGUILayout.ObjectField("Movement Transform", user.MovementTransform, typeof(Transform), true);
            user.Hitbox = (Collider2D) EditorGUILayout.ObjectField("Hitbox", user.Hitbox, typeof(Collider2D), true);
            user.MaxSpeed = EditorGUILayout.FloatField("Max Speed", user.MaxSpeed);
            user.AccelerationCurve = EditorGUILayout.CurveField("Acceleration Curve", user.AccelerationCurve);
            user.HorizontalRaycasts = (byte) EditorGUILayout.IntField("Total Horizontal Raycast", user.HorizontalRaycasts);
            user.VerticalRaycasts = (byte) EditorGUILayout.IntField("Total Vertical Raycast", user.VerticalRaycasts);
            user.Inset = EditorGUILayout.FloatField("Inset", user.Inset);
        }
    }
}