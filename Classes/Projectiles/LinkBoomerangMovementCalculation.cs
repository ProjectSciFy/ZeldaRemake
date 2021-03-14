using CSE3902_Game_Sprint0.Classes._21._2._13;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class LinkBoomerangMovementCalculation
    {
        private LinkBoomerangStateMachine boomerangState;
        private LinkBoomerang boomerang;
        private enum Direction { right, up, left, down, NE, SE, SW, NW, none }; // NE = North East
        private Direction returnDirection;
        public enum CurrentState { movingUp, movingDown, movingLeft, movingRight, movingNE, movingSE, movingSW, movingNW, none };
        public CurrentState currentState;
        private EnemySpriteFactory spriteFactory;
        public LinkBoomerangMovementCalculation(LinkBoomerangStateMachine boomerangState)
        {
            this.boomerangState = boomerangState;
            this.boomerang = boomerangState.boomerang;
            this.currentState = (CurrentState) boomerangState.currentState;
            this.spriteFactory = boomerangState.spriteFactory;
        }
        public CurrentState MovementCalculation(float speed)
        {
            switch (returnDirection)
            {
                case Direction.down:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        boomerang.trajectory = new Vector2(0, speed);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                case Direction.up:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        boomerang.trajectory = new Vector2(0, -speed);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                case Direction.right:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        boomerang.trajectory = new Vector2(speed, 0);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                case Direction.left:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        boomerang.trajectory = new Vector2(-speed, 0);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                case Direction.NE:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingNE)
                    {
                        currentState = CurrentState.movingNE;
                        boomerang.trajectory = new Vector2(speed, -speed);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                case Direction.SE:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingSE)
                    {
                        currentState = CurrentState.movingSE;
                        boomerang.trajectory = new Vector2(speed, speed);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                case Direction.SW:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingSW)
                    {
                        currentState = CurrentState.movingSW;
                        boomerang.trajectory = new Vector2(-speed, speed);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                case Direction.NW:
                    if ((CurrentState)boomerangState.currentState != CurrentState.movingNW)
                    {
                        currentState = CurrentState.movingNW;
                        boomerang.trajectory = new Vector2(-speed, -speed);
                        boomerangState.spriteFactory.LinkBoomerangAttack(boomerang);
                    }
                    break;
                default:
                    break;
            }
            return currentState;
        }
        public void Update()
        {
            this.returnDirection = (Direction)boomerangState.returnDirection;
            this.currentState = (CurrentState)boomerangState.currentState;
        }
    }
}
