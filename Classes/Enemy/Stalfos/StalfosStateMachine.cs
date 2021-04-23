using CSE3902_Game_Sprint0.Classes.Enemy.Stalfos;
using CSE3902_Game_Sprint0.Classes.Enemy.Stalfos.StalfosScripts;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Interfaces;
using System;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class StalfosStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game { get; set; }
        private EnemyStalfos stalfos { get; set; }
        private StalfosSpriteFactory stalfosSpriteFactory { get; set; }

        public enum Direction { right, up, left, down };
        public Direction direction { get; set; } = Direction.down;
        bool spawning { get; set; } = true;
        public int timer { get; set; } = 0;
        private int deathTimer { get; set; } = 30;
        public enum CurrentState { none, idle, movingUp, movingDown, movingLeft, movingRight, spawning, dying };
        public CurrentState currentState { get; set; } = CurrentState.none;

        public StalfosStateMachine(EnemyStalfos stalfos)
        {
            this.game = stalfos.game;
            this.stalfos = stalfos;
            stalfosSpriteFactory = new StalfosSpriteFactory(game);
        }
        public void Spawning()
        {
            timer = 90;
            spawning = false;
            new StalfosSpawning(stalfos, stalfosSpriteFactory, this).Execute();
        }
        public void Dying()
        {
            new StalfosDying(stalfos, stalfosSpriteFactory, this).Execute();
        }
        public void Moving()
        {
            if (timer <= 0)
            {
                timer = 60;
                new StalfosMoving(stalfos, stalfosSpriteFactory, this).Execute();
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
            }

            if (stalfos.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    new DropMinorItem(stalfos.game, stalfos.drawLocation).Execute();
                    stalfos.game.currentRoom.removeEnemy(stalfos);
                }
            }
            else if (spawning)
            {
                Spawning();
            }
            else
            {
                Moving();
            }
        }
    }
}
