using UnityEngine;
using UPM.Motors;

namespace UPM.Physics {
    /// <summary>
    /// Define uma lista que checagens que juntos modelam um certo comportamento de física.
    /// <br/>
    /// Para conseguir acesso aos resultados específicos de algum checagem, é recomendado manter alguma referência
    /// á instância dessa checagem e criar um campo dentro da checagem para guardar o resultado.
    /// <br/>
    /// Veja um exemplo em <see cref="UPM.Motors.States.BuiltIn.GroundedState"/> e
    /// <see cref="UPM.Physics.VerticalPhysicsCheck"/>.
    /// </summary>
    public sealed class PhysicsBehaviour {
        private readonly PhysicsCheck[] checks;

        public PhysicsBehaviour(params PhysicsCheck[] checks) {
            this.checks = checks;
        }

        public void Check(MotorUser user, ref Vector2 velocity, ref CollisionStatus status) {
            var bounds = user.Hitbox.bounds;
            var shrinkedBounds = bounds;
            shrinkedBounds.Expand(user.Inset * -2);
            var layerMask = UPMResources.Instance.CollisionMask;
            foreach (var check in checks) {
                check.Check(user, ref velocity, ref status, layerMask, bounds, shrinkedBounds);
            }
        }
    }
}