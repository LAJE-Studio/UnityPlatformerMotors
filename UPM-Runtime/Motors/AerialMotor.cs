using UnityEngine;
using UPM.Motors.Config;

namespace UPM.Motors {
    [CreateAssetMenu(menuName = "UPM/Motors/AerialMotor")]
    public sealed class AerialMotor : Motor {
        public override void Move(MotorUser user, ref Vector2 velocity, ref CollisionStatus status) {
            //TODO: Implement
        }

        public override bool RequiresConfig(MotorUser user) {
            return false;
        }

        public override MotorConfig CreateConfig(MotorUser user) {
            return null;
        }
    }
}