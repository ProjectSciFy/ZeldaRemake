using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterStateMachine : IEnemyStateMachine
    {
        private EnemyWallmaster wallmaster;
        private EnemySpriteFactory enemySpriteFactory;

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
            enemySpriteFactory = wallmaster.enemySpriteFactory;
        }

        public void Idle()
        {
            if (currentState != CurrentState.idle)
            {
                currentState = CurrentState.idle;
                enemySpriteFactory.WallmasterIdle(wallmaster);
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
                        enemySpriteFactory.WallmasterMovingUp(wallmaster);
                    }
                    break;
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        enemySpriteFactory.WallmasterMovingRight(wallmaster);
                    }
                    break;
                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        enemySpriteFactory.WallmasterMovingDown(wallmaster);
                    }
                    break;
                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        enemySpriteFactory.WallmasterMovingLeft(wallmaster);
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
