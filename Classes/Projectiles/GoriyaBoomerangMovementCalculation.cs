using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class GoriyaBoomerangMovementCalculation
    {
        private GoriyaBoomerangStatemachine boomerangState;
        private GoriyaBoomerang boomerang;
        private enum Direction { right, up, left, down, NE, SE, SW, NW, none}; // NE = North East
        private Direction returnDirection;
        private Direction direction;
        public enum CurrentState { movingUp, movingDown, movingLeft, movingRight, movingNE, movingSE, movingSW, movingNW, none };
        public CurrentState currentState;
        private EnemySpriteFactory spriteFactory;
        public GoriyaBoomerangMovementCalculation(GoriyaBoomerangStatemachine boomerangState)
        {
            this.boomerangState = boomerangState;
            this.boomerang = boomerangState.boomerang;
            this.currentState = (CurrentState)boomerangState.currentState;
            this.spriteFactory = boomerangState.spriteFactory;
            this.returnDirection = (Direction) boomerangState.returnDirection;
        }
        public void MovementCalculationInward(float speed)
        {
            switch (returnDirection)
            {
                case Direction.down:
                        boomerang.velocity = new Vector2(0, speed);
                    break;
                case Direction.up:
                        boomerang.velocity = new Vector2(0, -speed);
                    break;
                case Direction.right:
                        boomerang.velocity = new Vector2(speed, 0);
                    break;
                case Direction.left:
                        boomerang.velocity = new Vector2(-speed, 0);
                    break;
                case Direction.NE:
                        boomerang.velocity = new Vector2(speed, -speed);
                    break;
                case Direction.SE:
                        boomerang.velocity = new Vector2(speed, speed);
                    break;
                case Direction.SW:
                        boomerang.velocity = new Vector2(-speed, speed);
                    break;
                case Direction.NW:
                        boomerang.velocity = new Vector2(-speed, -speed);
                    break;
                default:
                    break;
            }
        }
        public void MovementCalculationOutward(float speed)
        {
            switch (direction)
            {
                case Direction.down:
                    boomerang.velocity = new Vector2(0, speed);
                    break;
                case Direction.up:
                    boomerang.velocity = new Vector2(0, -speed);
                    break;
                case Direction.right:
                    boomerang.velocity = new Vector2(speed, 0);
                    break;
                case Direction.left:
                    boomerang.velocity = new Vector2(-speed, 0);
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {
            this.returnDirection = (Direction) boomerangState.returnDirection;
            this.direction = (Direction)boomerangState.direction;
        }
    }
}
