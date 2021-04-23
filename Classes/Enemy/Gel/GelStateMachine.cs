using CSE3902_Game_Sprint0.Classes.Enemy.Gel;
using CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Interfaces;
using System;

namespace CSE3902_Game_Sprint0.Classes.Enemy
{
    public class GelStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game { get; set; }
        private EnemySlime gel { get; set; }
        private GelSpriteFactory gelSpriteFactory { get; set; }

        public enum Direction { right, up, left, down };
        public Direction direction { get; set; } = Direction.down;
        bool moving { get; set; } = true;
        bool spawning { get; set; } = true;
        private int timer { get; set; } = 0;
        private int deathTimer { get; set; } = 30;
        public enum CurrentState { none, idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, spawning, dying };
        public CurrentState currentState { get; set; } = CurrentState.none;

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

            if (gel.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    new DropMinorItem(gel.game, gel.drawLocation).Execute();
                    gel.game.currentRoom.removeEnemy(gel);
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
