using CSE3902_Game_Sprint0.Classes.Enemy.Stalfos;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class StalfosStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyStalfos stalfos;
        private StalfosSpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = true;
        bool spawning = true;
        private int timer = 90;
        private enum CurrentState {none, idle, movingUp, movingDown, movingLeft, movingRight, spawning};
        private CurrentState currentState = CurrentState.none;

        public StalfosStateMachine(EnemyStalfos stalfos)
        {
            this.game = stalfos.game;
            this.stalfos = stalfos;
            enemySpriteFactory = new StalfosSpriteFactory(game);
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                this.stalfos.mySprite=enemySpriteFactory.SpawnStalfos();
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
                this.stalfos.mySprite=enemySpriteFactory.StalfosIdle();
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
                        this.stalfos.mySprite = enemySpriteFactory.StalfosMovingRight();
                    }
                    break;

                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        this.stalfos.mySprite = enemySpriteFactory.StalfosMovingUp();
                    }
                    break;

                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        this.stalfos.mySprite = enemySpriteFactory.StalfosMovingLeft();
                    }
                    break;

                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        this.stalfos.mySprite = enemySpriteFactory.StalfosMovingDown();
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
