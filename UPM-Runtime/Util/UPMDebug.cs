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

        public static void DrawBox2DWire(Vector2 center, Vector2 size) {
            var halfWidth = size.x / 2;
            var halfHeight = size.y / 2;
            var bottomLeft = new Vector2(center.x - halfWidth, center.y - halfHeight);
            var topLeft = new Vector2(center.x - halfWidth, center.y + halfHeight);
            var bottomRight = new Vector2(center.x + halfWidth, center.y - halfHeight);
            var topRight = new Vector2(center.x + halfWidth, center.y + halfHeight);
            Debug.DrawLine(bottomLeft, topLeft);
            Debug.DrawLine(topLeft, topRight);
            Debug.DrawLine(topRight, bottomRight);
            Debug.DrawLine(bottomRight, bottomLeft);
        }

        public static void DrawBox2DWire(Vector2 center, Vector2 size, Color color) {
            var halfWidth = size.x / 2;
            var halfHeight = size.y / 2;
            var bottomLeft = new Vector2(center.x - halfWidth, center.y - halfHeight);
            var topLeft = new Vector2(center.x - halfWidth, center.y + halfHeight);
            var bottomRight = new Vector2(center.x + halfWidth, center.y - halfHeight);
            var topRight = new Vector2(center.x + halfWidth, center.y + halfHeight);
            Debug.DrawLine(bottomLeft, topLeft, color);
            Debug.DrawLine(topLeft, topRight, color);
            Debug.DrawLine(topRight, bottomRight, color);
            Debug.DrawLine(bottomRight, bottomLeft, color);
        }


        public static void DrawRay(Vector2 pos, Vector2 dir) {
            Debug.DrawLine(pos, pos + dir);
        }

        public static void DrawBounds2D(Bounds bounds, Color color) {
            DrawBox2DWire(bounds.center, bounds.size, color);
        }

        public static void DrawBounds2D(Bounds2D bounds, Color color) {
            DrawBox2DWire(bounds.Center, bounds.Size, color);
        }
    }
}