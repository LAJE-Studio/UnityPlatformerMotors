using UnityEngine;
using UPM.Util.Singleton;

namespace UPM {
    public class UPMResources : UPMSingletonScriptableObject<UPMResources> {
        public LayerMask CollisionMask;
        public float Gravity;
    }
}