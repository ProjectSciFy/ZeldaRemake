using CSE3902_Game_Sprint0.Classes.Enemy.Goriya;
using CSE3902_Game_Sprint0.Classes.Enemy.Goriya.Scripts;
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
        public enum CurrentState {none, idleRight, idleLeft, idleUp, idleDown, movingUp, movingDown, movingLeft, movingRight, spawning};
        public CurrentState currentState = CurrentState.none;
        public GoriyaStateMachine(EnemyGoriya goriya)
        {
            this.goriya = goriya;
            game = goriya.game;
            enemySpriteFactory = new GoriyaSpriteFactory(game);
            this.goriya.mySprite = enemySpriteFactory.GoriyaIdleDown();
        }

        public void Spawning()
        {
            spawning = false;
            new GoriyaSpawning(goriya, enemySpriteFactory, this).Execute();
        }

        public void Idle()
        {
            new GoriyaIdle(goriya, enemySpriteFactory, this).Execute();
        }

        public void Moving()
        {
            new GoriyaMoving(goriya, enemySpriteFactory, this).Execute();
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
