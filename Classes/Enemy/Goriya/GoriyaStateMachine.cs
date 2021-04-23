using CSE3902_Game_Sprint0.Classes.Enemy.Goriya;
using CSE3902_Game_Sprint0.Classes.Enemy.Goriya.Scripts;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Interfaces;
using System;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class GoriyaStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game { get; set; }
        private EnemyGoriya goriya { get; set; }
        private readonly GoriyaSpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down, NE, SE, SW, NW, none };
        public Direction direction = Direction.down;
        public bool moving { get; set; } = false;
        public bool spawning { get; set; } = true;
        private int timer { get; set; } = 90;
        private int deathTimer { get; set; } = 30;
        public enum CurrentState { none, idleRight, idleLeft, idleUp, idleDown, movingUp, movingDown, movingLeft, movingRight, spawning, dying };
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
        public void Dying()
        {
            new GoriyaDying(goriya, enemySpriteFactory, this).Execute();
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
                if (!goriya.throwing && timer <= 0)
                {
                    timer = 60;
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
                    moving = true;
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

            if (goriya.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    new DropMinorItem(goriya.game, goriya.drawLocation).Execute();
                    goriya.game.currentRoom.removeEnemy(goriya);
                }
            }
            else if (spawning)
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
