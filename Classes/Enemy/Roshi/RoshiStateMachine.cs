using CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using System;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi
{
    public class RoshiStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game { get; set; }
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }

        public enum Direction { up, down };
        public Direction direction = Direction.up;
        public bool spawning { get; set; } = true;
        public bool moving { get; set; } = false;
        public bool damaged { get; set; } = false;
        public int timer { get; set; } = 180;
        public int attackTimer { get; set; } = 179;
        public int deathTimer { get; set; } = 330;
        public enum CurrentState { none, movingUp, movingDown, spawning, dying, damaged, kiBlast, kamehameha, lift, charging, throwing, hold };
        public CurrentState currentState = CurrentState.none;
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public float spriteScalar;
        public Kamehameha kamehameha { get; set; }
        public KiBlast kiBlast { get; set; }
        public SpiritBomb spiritBomb { get; set; }
        public int enrageTimer { get; set; } = 900;

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
            new RoshiSpawning(roshi, spriteFactory, this).Execute();
        }
        public void Dying()
        {
            new RoshiDying(roshi, spriteFactory, this).Execute();
        }
        public void Damaged()
        {
            new RoshiDamaged(roshi, spriteFactory, this).Execute();
        }
        public void Moving()
        {
            new RoshiMoving(roshi, spriteFactory, this).Execute();
        }
        public void KiBlast()
        {
            new RoshiKiBlast(roshi, spriteFactory, this).Execute();
        }
        public void Kamehameha()
        {
            new RoshiKamehameha(roshi, spriteFactory, this).Execute();
        }
        public void Lift()
        {
            roshi.drawLocation = roshi.spawnLocation;
            new RoshiLift(roshi, spriteFactory, this).Execute();
        }
        public void Charge()
        {
            new RoshiCharge(roshi, spriteFactory, this).Execute();
        }
        public void Throw()
        {
            new RoshiThrow(roshi, spriteFactory, this).Execute();
        }
        public void Hold()
        {
            new RoshiHold(roshi, spriteFactory, this).Execute();
        }
        public void Explode()
        {
            new RoshiExplosion(roshi, spriteFactory, this).Execute();
        }
        public void Enrage()
        {
            if (enrageTimer == 900)
            {
                Lift();
                enrageTimer--;
            }
            else if (enrageTimer == 870)
            {
                Charge();
                enrageTimer--;
            }
            else if (enrageTimer == 180)
            {
                Throw();
                enrageTimer--;
            }
            else if (enrageTimer == 150)
            {
                Hold();
                enrageTimer--;
            }
            else if (enrageTimer == 15)
            {
                Explode();
                enrageTimer--;
            }
            else if (enrageTimer == 0)
            {
                game.util.numLives = 0;
            }
            else
            {
                enrageTimer--;
            }
        }
        public void Update()
        {
            if (roshi.health < 10) 
            {
                moving = false;
                Enrage();
            }
            else
            {
                if (!spawning && !damaged)
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
                        Kamehameha();
                    }
                    else if (attackTimer == 870)
                    {
                        game.projectileHandler.Remove(kamehameha);
                        game.collisionManager.collisionEntities.Remove(kamehameha);
                    }
                    else if (attackTimer == 800 || attackTimer == 600 || attackTimer == 400 || attackTimer == 200)
                    {
                        KiBlast();
                    }
                }
                else
                {
                    timer--;
                }
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
            else if (damaged)
            {
                Damaged();
            }
            else if (moving)
            {
                Moving();
            }
        }
    }
}

