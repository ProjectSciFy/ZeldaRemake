using CSE3902_Game_Sprint0.Classes.Enemy.Redead.RedeadScripts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead
{
    public class RedeadStateMachine
    {
        private ZeldaGame game { get; set; }
        private EnemyRedead redead { get; set; }
        private RedeadSpriteFactory redeadSpriteFactory { get; set; }

        public enum Direction { right, up, left, down };
        public Direction direction { get; set; } = Direction.down;
        bool spawning { get; set; } = true;
        public bool idle { get; set; } = true;
        public int timer { get; set; } = 0;
        private int deathTimer { get; set; } = 30;
        public int shriekTimer { get; set; } = 0;
        public enum CurrentState { none, idle, movingUp, movingDown, movingLeft, movingRight, spawning, dying };
        public CurrentState currentState { get; set; } = CurrentState.none;

        public RedeadStateMachine(EnemyRedead redead)
        {
            this.game = redead.game;
            this.redead = redead;
            redeadSpriteFactory = new RedeadSpriteFactory(game);
        }
        public void Spawning()
        {
            timer = 90;
            spawning = false;
            new RedeadSpawning(redead, redeadSpriteFactory, this).Execute();
        }
        public void Dying()
        {
            new RedeadDying(redead, redeadSpriteFactory, this).Execute();
        }
        public void Moving()
        {
            if (timer <= 0)
            {
                timer = 60;
                new RedeadMoving(redead, redeadSpriteFactory, this).Execute();
            }
        }
        public void Idle()
        {
            if (timer <= 0)
            {
                new RedeadIdle(redead, redeadSpriteFactory, this).Execute();
            }
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }
            if (shriekTimer <= 0)
            {
                idle = true;
            }
            else
            {
                shriekTimer--;
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

            if (redead.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    redead.game.currentRoom.removeEnemy(redead);
                }
            }
            else if (spawning)
            {
                Spawning();
            }
            else if (idle)
            {
                Idle();
            }
            else
            {
                Moving();
            }
        }
    }
}
