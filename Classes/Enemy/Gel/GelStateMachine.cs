using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using CSE3902_Game_Sprint0.Classes.Enemy.Gel;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts;

namespace CSE3902_Game_Sprint0.Classes.Enemy
{
    public class GelStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemySlime gel;
        private GelSpriteFactory gelSpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = true;
        bool spawning = true;
        private int timer = 0;
        private int deathTimer = 30;
        public enum CurrentState {none, idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, spawning, dying };
        public CurrentState currentState = CurrentState.none;

        public GelStateMachine(EnemySlime gel)
        {
            this.gel = gel;
            game = gel.game;
            gelSpriteFactory = new GelSpriteFactory(game);
            this.gel.mySprite = gelSpriteFactory.GelIdle();
        }
        public void Spawning()
        {
            timer = 90;
            spawning = false;
            new GelSpawning(gel, gelSpriteFactory, this).Execute();
        }
        public void Dying()
        {
            new GelDying(gel, gelSpriteFactory, this).Execute();
        }
        public void Idle()
        {
            if (timer <= 0)
            {
                timer = 52;
                new GelIdle(gel, gelSpriteFactory, this).Execute();
            }
        }

        public void Moving()
        {
            if (timer <= 0)
            {
                timer = 8;
                new GelMoving(gel, gelSpriteFactory, this).Execute();
            }
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }
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
            if (gel.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    gel.game.currentRoom.removeEnemy(gel);
                }
            }
        }
    }
}
