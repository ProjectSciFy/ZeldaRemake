using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyWallmaster wallmaster;
        private WallmasterSpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.up;
        bool emerging = false;
        bool hiding = false;
        bool idle = true;
        private int timer = 0;
        private enum CurrentState { none, emerging, hiding, idle, movingUp, movingDown, movingLeft, movingRight };
        private CurrentState currentState = CurrentState.none;

        public WallmasterStateMachine(EnemyWallmaster wallmaster)
        {
            this.wallmaster = wallmaster;
            game = wallmaster.game;
            enemySpriteFactory = new WallmasterSpriteFactory(game);
            this.wallmaster.mySprite = enemySpriteFactory.WallmasterIdle();
        }

        public void Idle()
        {
            if (currentState != CurrentState.idle)
            {
                currentState = CurrentState.idle;
                enemySpriteFactory.WallmasterIdle();
            }
        }

        public void Moving()
        {
            switch (direction)
            {
                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        this.wallmaster.velocity.X = 0;
                        this.wallmaster.velocity.Y = -1;
                        this.wallmaster.mySprite = enemySpriteFactory.WallmasterMovingUp();
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        this.wallmaster.velocity.X = 1;
                        this.wallmaster.velocity.Y = 0;
                        this.wallmaster.mySprite = enemySpriteFactory.WallmasterMovingRight();
                    }
                    break;
                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        this.wallmaster.velocity.X = 0;
                        this.wallmaster.velocity.Y = 1;
                        this.wallmaster.mySprite = enemySpriteFactory.WallmasterMovingDown();
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        this.wallmaster.velocity.X = -1;
                        this.wallmaster.velocity.Y = 0;
                        this.wallmaster.mySprite = enemySpriteFactory.WallmasterMovingLeft();
                    }
                    break;
                default:
                    break;
            }

        }

        public void Update()
        {
            if (timer <= 0)
            {
                if (idle)
                {
                    direction = Direction.up;
                    idle = false;
                    emerging = true;
                    timer = 32;

                }
                else if (emerging)
                {
                    direction = Direction.right;
                    emerging = false;
                    timer = 64;
                } else if (!emerging && !idle && !hiding)
                {
                    direction = Direction.down;
                    hiding = true;
                    timer = 32;
                }
                else if (hiding)
                {
                    idle = true;
                    hiding = false;
                    timer = 180;
                }
            }
            else
            {
                timer--;
            }

            if (idle)
            {
                Idle();
            }
            else
            {
                Moving();
            }
        }
    }
}
