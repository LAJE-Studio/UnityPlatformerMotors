using System;

namespace UPM {
    [Serializable]
    public struct CollisionStatus {
        public bool Up;
        public bool Down;
        public bool Left;
        public bool Right;

        public int HorizontalCollisionDir {
            get {
                if (Left == Right) {
                    return 0;
                }

                if (Left) {
                    return -1;
                }

                if (Right) {
                    return 1;
                }

                return 0;
            }
        }
    }
}