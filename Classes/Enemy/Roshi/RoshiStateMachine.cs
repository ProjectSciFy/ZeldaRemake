using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus.AquamentusScripts;
using CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi
{
    public class RoshiStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game { get; set; }
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }

        public enum Direction { up, down };
        public Direction direction = Direction.up;
        bool spawning = true;
        bool moving = false;
        private int timer = 120;
        private int attackTimer = 100;
        private int deathTimer = 30;
        public enum CurrentState { none, movingUp, movingDown, spawning, dying, damaged, kiBlast, kamehameha };
        public CurrentState currentState = CurrentState.none;
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public float spriteScalar;
        private Kamehameha kamehameha;

        public RoshiStateMachine(EnemyRoshi roshi)
        {
            game = roshi.game;
            this.roshi = roshi;
            spriteFactory = new RoshiSpriteFactory(game);
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Spawning()
        {
            timer = 90;
            spawning = false;
            new RoshiSpawning(roshi, spriteFactory, this).Execute();
        }
        public void Dying()
        {
            //new RoshiDying(roshi, spriteFactory, this).Execute();
        }
        public void Moving()
        {
            new RoshiMoving(roshi, spriteFactory, this).Execute();
        }

        public void KiBlast()
        {
            // executes one ki blast toward link
            // if under 50% health fires 3 ki blasts
            new RoshiKiBlast(roshi, spriteFactory, this).Execute();
            Vector2 trajectory = Vector2.Multiply(Vector2.Normalize(Vector2.Subtract(game.link.drawLocation, Vector2.Add(roshi.drawLocation, new Vector2(40 * 3, 5 * 3)))), new Vector2(20,20));
            game.projectileHandler.Add(new KiBlast(game, roshi, this, trajectory));
        }

        public void Kamehameha()
        {
            //fires big kamehameha blast
            new RoshiKamehameha(roshi, spriteFactory, this).Execute();
            kamehameha = new Kamehameha(game, roshi, this);
            game.projectileHandler.Add(kamehameha);
        }

        public void Update()
        {
            if (!spawning)
            {
                if (timer <= 0)
                {
                    var random = new Random();
                    int swapDirection = random.Next(2);
                    moving = true;

                    if (swapDirection > 0)
                    {
                        timer = 120;
                        direction = Direction.up;
                    }
                    else
                    {
                        timer = 120;
                        direction = Direction.down;
                    }
                }
                else
                {
                    timer--;
                    attackTimer--;
                }

                if (attackTimer == 0)
                {
                    timer = 130;
                    moving = false;
                    Kamehameha();
                    attackTimer = 1000;
                }
                else if (attackTimer == 870)
                {
                    game.projectileHandler.Remove(kamehameha);
                    game.collisionManager.collisionEntities.Remove(kamehameha);
                }
                else if (attackTimer == 800 || attackTimer == 600 || attackTimer == 400 || attackTimer == 200)
                {
                    timer = 60;
                    moving = false;
                    KiBlast();
                    attackTimer--;
                }
            }
            else
            {
                timer--;
            }

            if (roshi.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    roshi.game.currentRoom.removeEnemy(roshi);
                }
            }
            else if (spawning)
            {
                Spawning();
            }
            else if (moving)
            {
                Moving();
            }
        }
    }
}

