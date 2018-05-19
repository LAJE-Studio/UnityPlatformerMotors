using System;

namespace UPM {
    [Serializable]
    public struct CollisionStatus {
        [Flags]
        public enum CollisionDirection {
            Up = 1 << 0,
            Down = 1 << 1,
            Left = 1 << 2,
            Right = 1 << 3
        }

        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;

        public int HorizontalCollisionDir {
            get {
                return GetCollisionDir(Right, Left);
            }
        }

        public int VerticalCollisionDir {
            get {
                return GetCollisionDir(Up, Down);
            }
        }

        private static int GetCollisionDir(bool positive, bool negative) {
            if (positive == negative) {
                return 0;
            }

            if (positive) {
                return -1;
            }

            return 1;
        }

        public bool HasAll() {
            return Up && Down && Left && Right;
        }

        public bool HasAny() {
            return Up || Down || Left || Right;
        }

        public bool HasAll(CollisionDirection direction) {
            if ((direction & CollisionDirection.Up) == CollisionDirection.Up && !Up) {
                return false;
            }

            if ((direction & CollisionDirection.Down) == CollisionDirection.Down && !Down) {
                return false;
            }

            if ((direction & CollisionDirection.Left) == CollisionDirection.Left && !Left) {
                return false;
            }

            if ((direction & CollisionDirection.Right) == CollisionDirection.Right && !Right) {
                return false;
            }

            return true;
        }

        public bool HasAny(CollisionDirection direction) {
            if ((direction & CollisionDirection.Up) == CollisionDirection.Up && Up) {
                return true;
            }

            if ((direction & CollisionDirection.Down) == CollisionDirection.Down && Down) {
                return true;
            }

            if ((direction & CollisionDirection.Left) == CollisionDirection.Left && Left) {
                return true;
            }

            if ((direction & CollisionDirection.Right) == CollisionDirection.Right && Right) {
                return true;
            }

            return false;
        }
    }
}