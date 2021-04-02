using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Enemy.BladeTrap;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class BladeTrapStateMachine
    {
        private ZeldaGame game;
        private BladeTrap BladeTrap;
        private BladeTrapSpriteFactory spriteFactory;
        private Link link;
        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        private Boolean InRange;
        private Boolean attacking = false, nested = true, returning = false, pivot = false;
        private enum CurrentState { idle, attackingUp, attackingDown, attackingRight, attackingLeft, retractingUp, retractingDown, retractingRight, retractingLeft };
        private CurrentState currentState = CurrentState.idle;
        private const int TRAP_WIDTH = 8;
        public BladeTrapStateMachine(BladeTrap enemy, Link link)
        {
            this.BladeTrap = enemy;
            this.game = BladeTrap.game;
            this.link = link;
            spriteFactory = new BladeTrapSpriteFactory(this.game);
            this.BladeTrap.mySprite = spriteFactory.BladeTrapIdle();
        }

        public void Idle()
        {
            if (currentState != CurrentState.idle)
            {
                currentState = CurrentState.idle;
                this.BladeTrap.velocity = new Vector2(0, 0);
                this.BladeTrap.mySprite = spriteFactory.BladeTrapIdle();
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
                        this.BladeTrap.velocity.X = 0;
                        this.BladeTrap.velocity.Y = 1;
                        this.BladeTrap.mySprite = spriteFactory.BladeTrapDown();
                    }
                    break;
                case Direction.up:
                    if (currentState != CurrentState.attackingUp)
                    {
                        currentState = CurrentState.attackingUp;
                        this.BladeTrap.velocity.X = 0;
                        this.BladeTrap.velocity.Y = -1;
                        this.BladeTrap.mySprite = spriteFactory.BladeTrapUp();
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.attackingRight)
                    {
                        currentState = CurrentState.attackingRight;
                        this.BladeTrap.velocity.X = 1;
                        this.BladeTrap.velocity.Y = 0;
                        this.BladeTrap.mySprite = spriteFactory.BladeTrapRight();
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.attackingLeft)
                    {
                        currentState = CurrentState.attackingLeft;
                        this.BladeTrap.velocity.X = -1;
                        this.BladeTrap.velocity.Y = 0;
                        this.BladeTrap.mySprite = spriteFactory.BladeTrapLeft();
                    }
                    break;
                default:
                    break;
            }
        }
        public void Update()
        {
            if ((Math.Abs(link.drawLocation.X - BladeTrap.spawnLocation.X) <= BladeTrap.range.X) && Math.Abs(link.drawLocation.Y - BladeTrap.spawnLocation.Y) < TRAP_WIDTH && !returning)
            {
                attacking = true;
                nested = false;
                if (link.drawLocation.X > BladeTrap.spawnLocation.X)
                {
                    direction = Direction.right;
                }
                else if (link.drawLocation.X < BladeTrap.spawnLocation.X)
                {
                    direction = Direction.left;
                }
            }
            else if ((Math.Abs(link.drawLocation.Y - BladeTrap.spawnLocation.Y) <= BladeTrap.range.Y) && Math.Abs(link.drawLocation.X - BladeTrap.spawnLocation.X) < TRAP_WIDTH && !returning)
            {
                attacking = true;
                nested = false;
                if (link.drawLocation.Y > BladeTrap.spawnLocation.Y)
                {
                    direction = Direction.down;
                }
                else if (link.drawLocation.Y < BladeTrap.spawnLocation.Y)
                {
                    direction = Direction.up;
                }
            }

            if (((int)Math.Abs(BladeTrap.drawLocation.X - BladeTrap.spawnLocation.X) > BladeTrap.range.X) && (BladeTrap.drawLocation.Y - BladeTrap.spawnLocation.Y) < TRAP_WIDTH && !returning)
            {
                returning = true;
                if (direction == Direction.right)
                {
                    direction = Direction.left;
                }
                else if (direction == Direction.left)
                {
                    direction = Direction.right;
                }
            }
            else if ((int)Math.Abs(BladeTrap.drawLocation.Y - BladeTrap.spawnLocation.Y) > BladeTrap.range.Y && (BladeTrap.drawLocation.X - BladeTrap.spawnLocation.X) < TRAP_WIDTH && !returning)
            {
                returning = true;
                if (direction == Direction.up)
                {
                    direction = Direction.down;
                }
                else if (direction == Direction.down)
                {
                    direction = Direction.up;
                }
            }
            if ((int)Vector2.Distance(BladeTrap.drawLocation, BladeTrap.spawnLocation) == 0 && returning)
            {
                nested = true;
                returning = false;
            }
            if (nested)
            {
                Idle();
            }
            else if (attacking && !returning)
            {
                Attack();
            }
            else if (returning)
            {
                Attack();
            }
        }
    }
}
