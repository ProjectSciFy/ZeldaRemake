using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy
{
    public class GelStateMachine : IEnemyStateMachine
    {
        private EnemyGel gel;
        private EnemySpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = true;
        bool spawning = true;
        private int timer = 90;
        private enum CurrentState {none, idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, spawning };
        private CurrentState currentState = CurrentState.none;

        public GelStateMachine(EnemyGel gel)
        {
            this.gel = gel;
            enemySpriteFactory = gel.enemySpriteFactory;
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                enemySpriteFactory.SpawnGel(gel);
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
            if (currentState != CurrentState.idleRight)
            {
                timer = 52;

                currentState = CurrentState.idleRight;
                enemySpriteFactory.GelIdle(gel);
            }
        }

        public void Moving()
        {
            switch (direction)
            {
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        timer = 8;

                        currentState = CurrentState.movingRight;
                        enemySpriteFactory.GelMovingRight(gel);
                    }
                    break;

                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        timer = 8;

                        currentState = CurrentState.movingUp;
                        enemySpriteFactory.GelMovingUp(gel);
                    }
                    break;

                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        timer = 8;

                        currentState = CurrentState.movingLeft;
                        enemySpriteFactory.GelMovingLeft(gel);
                    }
                    break;

                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        timer = 8;

                        currentState = CurrentState.movingDown;
                        enemySpriteFactory.GelMovingDown(gel);
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

                    moving = !moving;
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
