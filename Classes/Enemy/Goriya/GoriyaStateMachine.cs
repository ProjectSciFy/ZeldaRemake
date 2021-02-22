using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class GoriyaStateMachine : IEnemyStateMachine
    {
        private EnemyGoriya goriya;
        private EnemySpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = true;
        bool spawning = true;
        private int timer = 90;
        private enum CurrentState {none, idle, movingUp, movingDown, movingLeft, movingRight, spawning};
        private CurrentState currentState = CurrentState.none;

        public GoriyaStateMachine(EnemyGoriya goriya)
        {
            this.goriya = goriya;
            enemySpriteFactory = goriya.enemySpriteFactory;
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                enemySpriteFactory.SpawnGoriya(goriya);
            }

            if (timer <= 0)
            {
                spawning = false;
                currentState = CurrentState.none;
            }
        }

        public void Idle()
        {
            // construct nonanimated link facing up with sprite factory
            if (currentState != CurrentState.idle)
            {
                currentState = CurrentState.idle;
                //enemySpriteFactory.GoriyaIdle(goriya);
            }
        }

        public void Moving()
        {
            switch (direction)
            {
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                       // enemySpriteFactory.GoriyaMovingRight(goriya);
                    }
                    break;

                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                       // enemySpriteFactory.GoriyaMovingUp(Goriya);
                    }
                    break;

                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                      //  enemySpriteFactory.GoriyaMovingLeft(goriya);
                    }
                    break;

                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                       // enemySpriteFactory.GoriyaMovingDown(goriya);
                    }
                    break;

                default:
                    break;
            }
        }



        public void Update()
        {
            if (!spawning)
            {
                if (timer <= 0)
                {
                    var random = new Random();
                    timer = 60;
                    switch (random.Next(4))
                    {
                        case 0:
                            direction = Direction.up;
                            break;
                        case 1:
                            direction = Direction.down;
                            break;
                        case 2:
                            direction = Direction.left;
                            break;
                        case 3:
                            direction = Direction.right;
                            break;
                        default:
                            direction = Direction.down;
                            break;
                    }
                }
                else
                {
                    timer--;
                }
            }
            else
            {
                timer--;
            }

            if (spawning)
            {
                Spawning();
            }
            else
            {
                if (moving)
                {
                    Moving();
                }
                else
                {
                    Idle();
                }
            }
        }
    }
}
