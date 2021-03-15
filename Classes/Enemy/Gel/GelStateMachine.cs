using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using CSE3902_Game_Sprint0.Classes.Enemy.Gel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy
{
    public class GelStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyGel gel;
        private GelSpriteFactory enemySpriteFactory;

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
            game = gel.game;
            enemySpriteFactory = new GelSpriteFactory(game);
            this.gel.mySprite = enemySpriteFactory.GelIdle();
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                enemySpriteFactory.SpawnGel();
            }

            if (timer <= 0)
            {
                spawning = false;
                currentState = CurrentState.none;
            }
        }

        public void Idle()
        {
            if (currentState != CurrentState.idleRight)
            {
                timer = 52;

                currentState = CurrentState.idleRight;
                enemySpriteFactory.GelIdle();
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
                        this.gel.velocity.X = 2;
                        this.gel.velocity.Y = 0;
                        this.gel.mySprite = enemySpriteFactory.GelMovingRight();
                    }
                    break;

                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        timer = 8;

                        currentState = CurrentState.movingUp;
                        this.gel.velocity.X = 0;
                        this.gel.velocity.Y = -2;
                        this.gel.mySprite = enemySpriteFactory.GelMovingUp();
                    }
                    break;

                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        timer = 8;

                        currentState = CurrentState.movingLeft;
                        this.gel.velocity.X = -2;
                        this.gel.velocity.Y = 0;
                        this.gel.mySprite = enemySpriteFactory.GelMovingLeft();
                    }
                    break;

                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        timer = 8;

                        currentState = CurrentState.movingDown;
                        this.gel.velocity.X = 0;
                        this.gel.velocity.Y = 2;
                        this.gel.mySprite = enemySpriteFactory.GelMovingDown();
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
