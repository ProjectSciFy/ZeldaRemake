using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class BladeTrapStateMachine
    {
        private EeveeSim game;
        private BladeTrap BladeTrap;
        private EnemySpriteFactory spriteFactory;
        private Link link;
        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        private Boolean InRange;
        private Boolean away = false;
        private enum CurrentState { idle, attackingUp, attackingDown, attackingRight, attackingLeft, retractingUp, retractingDown, retractingRight, retractingLeft };
        private CurrentState currentState = CurrentState.idle;
        private const int TRAP_WIDTH = 8;
        public BladeTrapStateMachine(BladeTrap enemy, Link link)
        {
            this.BladeTrap = enemy;
            this.game = BladeTrap.game;
            this.link = link;
            spriteFactory = new EnemySpriteFactory(this.game);
            spriteFactory.BladeTrapIdle(BladeTrap);
        }

        public void Idle()
        {
            if (currentState != CurrentState.idle)
            {
                currentState = CurrentState.idle;
                spriteFactory.BladeTrapIdle(BladeTrap);
            }
        }
        public void Attack()
        {
            switch (direction)
            {
                case Direction.down:
                    if (currentState != CurrentState.attackingDown)
                    {
                        currentState = CurrentState.attackingDown;
                        spriteFactory.BladeTrapDown(BladeTrap);
                    }break;
                case Direction.up:
                    if (currentState != CurrentState.attackingUp)
                    {
                        currentState = CurrentState.attackingUp;
                        spriteFactory.BladeTrapUp(BladeTrap);
                    }break;
                case Direction.right:
                    if (currentState != CurrentState.attackingRight)
                    {
                        currentState = CurrentState.attackingRight;
                        spriteFactory.BladeTrapRight(BladeTrap);
                    }break;
                case Direction.left:
                    if (currentState != CurrentState.attackingLeft)
                    {
                        currentState = CurrentState.attackingLeft;
                        spriteFactory.BladeTrapLeft(BladeTrap);
                    }break;
                default:
                    break;
            }
        }
        public void Retract()
        {
            switch (direction)
            {
                case Direction.down:
                    if (currentState != CurrentState.retractingDown)
                    {
                        currentState = CurrentState.retractingDown;
                        spriteFactory.BladeTrapUp(BladeTrap);
                    }
                    break;
                case Direction.up:
                    if (currentState != CurrentState.retractingUp)
                    {
                        currentState = CurrentState.retractingUp;
                        spriteFactory.BladeTrapDown(BladeTrap);
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.retractingRight)
                    {
                        currentState = CurrentState.retractingRight;
                        spriteFactory.BladeTrapLeft(BladeTrap);
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.retractingLeft)
                    {
                        currentState = CurrentState.retractingLeft;
                        spriteFactory.BladeTrapRight(BladeTrap);
                    }
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {
            //direction
            if ((Math.Abs(link.drawLocation.X - BladeTrap.spawnLocation.X) <= BladeTrap.range.X) && Math.Abs(link.drawLocation.Y - BladeTrap.spawnLocation.Y) < TRAP_WIDTH)
            {
                InRange = true;
                if (link.drawLocation.X > BladeTrap.spawnLocation.X)
                {
                    direction = Direction.right;
                }
                else if (link.drawLocation.X < BladeTrap.spawnLocation.X)
                {
                    direction = Direction.left;
                }
            }
            else if ((Math.Abs(link.drawLocation.Y - BladeTrap.spawnLocation.Y) <= BladeTrap.range.Y) && Math.Abs(link.drawLocation.X - BladeTrap.spawnLocation.X) < TRAP_WIDTH)
            {
                InRange = true;
                if (link.drawLocation.Y > BladeTrap.spawnLocation.Y)
                {
                    direction = Direction.up;
                }
                else if (link.drawLocation.Y < BladeTrap.spawnLocation.Y)
                {
                    direction = Direction.down;
                }
            }
            else
            {
                InRange = false;
            }

            if (BladeTrap.drawLocation == BladeTrap.spawnLocation)
            {
                away = false;
            }
            else
            {
                away = true;
                if ((Math.Abs(BladeTrap.drawLocation.X - BladeTrap.spawnLocation.X) == BladeTrap.range.X) && (BladeTrap.drawLocation.Y == BladeTrap.spawnLocation.Y))
                {
                    if (direction == Direction.right)
                    {
                        direction = Direction.left;
                    }
                    else if (direction == Direction.left)
                    {
                        direction = Direction.right;
                    }
                }
                else if ((Math.Abs(BladeTrap.drawLocation.Y - BladeTrap.spawnLocation.Y) == BladeTrap.range.Y) && (BladeTrap.drawLocation.X == BladeTrap.spawnLocation.X))
                {
                    if (direction == Direction.up)
                    {
                        direction = Direction.down;
                    }
                    else if (direction == Direction.down)
                    {
                        direction = Direction.up;
                    }
                }
            }
            if (!away && !InRange)
            {
                Idle();
            }
            else if (!away && InRange)
            {
                Attack();
            }
            else if (away)
            {
                Retract();
            }
        }
    }
}
