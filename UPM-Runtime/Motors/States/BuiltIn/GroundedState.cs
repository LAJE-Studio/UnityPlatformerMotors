using System;
using UnityEngine;
using UPM.Motors.Config;
using UPM.Physics;
using UPM.Util;

namespace UPM.Motors.States.BuiltIn {
    public sealed class GroundedState : State {
        public State OnGetOffGround;
        public float Gravity = 19.62F;
        public static readonly VerticalPhysicsCheck VerticalVelocityCheck = new VerticalPhysicsCheck();
        public static readonly HorizontalPhysicsCheck HorizontalVelocityCheck = new HorizontalPhysicsCheck();
        public static readonly VerticalPhysicsCheck SlopeCheck = new VerticalPhysicsCheck(SlopeCheckProvider);

        public static readonly PhysicsBehaviour GroundedBehaviour = new PhysicsBehaviour(
            VerticalVelocityCheck,
            HorizontalVelocityCheck,
            SlopeCheck
        );

        private static Vector2 SlopeCheckProvider(MotorUser arg) {
            return Vector2.down * Time.fixedDeltaTime;
        }


        public override void Move(MotorUser user, ref Vector2 velocity, ref CollisionStatus collisionStatus, StateMotorMachine machine, StateMotorConfig config1) {
            var config = user.GetMotorConfig<GroundMotorConfig>();
            if (config == null) {
                UPMDebug.LogWarning("Expected GroundMotorConfig for GroundedState @ " + user);
                return;
            }

            ProcessInputs(user, config, ref velocity, ref collisionStatus);
            velocity.y += Gravity * config.GravityScale * Time.fixedDeltaTime;
            var max = user.MaxSpeed;
            velocity.x = Mathf.Clamp(velocity.x, -max, max);
            GroundedBehaviour.Check(user, ref velocity, ref collisionStatus);
        }

        private void ProcessInputs(MotorUser user, GroundMotorConfig config, ref Vector2 velocity, ref CollisionStatus collisionStatus) {
            var provider = user.InputProvider;
            var hasProvider = provider != null;
            var xInput = hasProvider ? provider.GetHorizontal() : 0;
            var inputDir = Math.Sign(xInput);
            if (hasProvider) {
                var jump = provider.GetButtonDown("Jump");
                if (collisionStatus.Down) {
                    if (jump) {
                        velocity.y = config.JumpForce;
                    }
                } else {
                    if (velocity.y > 0 && !jump) {
                        velocity.y += Gravity * Time.deltaTime * config.GravityScale * config.JumpCutGravityModifier;
                    }
                }
            }

            var velDir = Math.Sign(velocity.x);
            var curve = user.AccelerationCurve;
            var speedPercent = user.SpeedPercent;
            var rawAcceleration = curve.Evaluate(speedPercent);
            var acceleration = rawAcceleration * inputDir;
            var maxSpeed = user.MaxSpeed * Mathf.Abs(xInput);
            var speed = Mathf.Abs(velocity.x);
            if (velDir == 0 || velDir == inputDir && inputDir != 0) {
                //Accelerating
                if (speed < maxSpeed) {
                    velocity.x += acceleration;
                }

                return;
            }

            var deacceleration = curve.Evaluate(1 - speedPercent);
            if (Mathf.Abs(xInput) > 0) {
                //Changing direction, Double deacceleration
                velocity.x += deacceleration * inputDir * 2;
                return;
            }

            //Not inputting
            if (speed < rawAcceleration) {
                velocity.x = 0;
            } else {
                velocity.x += deacceleration * -velDir;
            }
        }
    }
}