using CSE3902_Game_Sprint0.Classes.Enemy.Goriya;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class GoriyaStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyGoriya goriya;
        private GoriyaSpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down, NE, SE, SW, NW, none };
        public Direction direction { get; set; }  = Direction.down;
        public bool moving { get; set; }  = true;
        private bool spawning = true;
        private int timer = 90;
        private enum CurrentState {none, idleRight, idleLeft, idleUp, idleDown, movingUp, movingDown, movingLeft, movingRight, spawning};
        private CurrentState currentState = CurrentState.none;
        public GoriyaStateMachine(EnemyGoriya goriya)
        {
            this.goriya = goriya;
            game = goriya.game;
            enemySpriteFactory = new GoriyaSpriteFactory(game);
            this.goriya.mySprite = enemySpriteFactory.GoriyaIdleDown();
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                this.goriya.mySprite = enemySpriteFactory.SpawnGoriya();
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
            switch (direction)
            {
                case Direction.right:
                    if (currentState != CurrentState.idleRight)
                    {
                        currentState = CurrentState.idleRight;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaIdleRight();
                    }
                    break;

                case Direction.up:
                    if (currentState != CurrentState.idleUp)
                    {
                        currentState = CurrentState.idleUp;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaIdleUp();
                    }
                    break;

                case Direction.left:
                    if (currentState != CurrentState.idleLeft)
                    {
                        currentState = CurrentState.idleLeft;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaIdleLeft();
                    }
                    break;

                case Direction.down:
                    if (currentState != CurrentState.idleDown)
                    {
                        currentState = CurrentState.idleDown;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaIdleDown();
                    }
                    break;

                default:
                    break;
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
                        this.goriya.velocity.X = 1;
                        this.goriya.velocity.Y = 0;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaMovingRight();
                    }
                    break;

                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        this.goriya.velocity.X = 0;
                        this.goriya.velocity.Y = -1;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaMovingUp();
                    }
                    break;

                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        this.goriya.velocity.X = -1;
                        this.goriya.velocity.Y = 0;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaMovingLeft();
                    }
                    break;

                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        this.goriya.velocity.X = 0;
                        this.goriya.velocity.Y = 1;
                        this.goriya.mySprite = enemySpriteFactory.GoriyaMovingDown();
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
                    timer = 500;
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
