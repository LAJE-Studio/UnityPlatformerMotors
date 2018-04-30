using UnityEngine;
using UPM.Util.Singleton;

namespace UPM {
    [CreateAssetMenu(menuName = "UPM/UPMResources")]
    public class UPMResources : UPMSingletonScriptableObject<UPMResources> {
        public LayerMask CollisionMask;
        public float Gravity;
    }
}