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
        public int timer { get; set; } = RoshiStateMachineStorage.INTIAL_TIMER;
        public int attackTimer { get; set; } = RoshiStateMachineStorage.ATTACK_TIMER;
        public int deathTimer { get; set; } = RoshiStateMachineStorage.DEATH_TIMER;
        public enum CurrentState { none, movingUp, movingDown, spawning, dying, damaged, kiBlast, kamehameha, lift, charging, throwing, hold };
        public CurrentState currentState = CurrentState.none;
        public Rectangle collisionRectangle = Rectangle.Empty;
        public float spriteScalar;
        public Kamehameha kamehameha { get; set; }
        public KiBlast kiBlast { get; set; }
        public SpiritBomb spiritBomb { get; set; }
        public int enrageTimer { get; set; } = RoshiStateMachineStorage.ENRAGE_TIMER;
        private readonly RoshiStateMachineHelper helper;
        public RoshiStateMachine(EnemyRoshi roshi)
        {
            game = roshi.game;
            this.roshi = roshi;
            spriteFactory = new RoshiSpriteFactory(game);
            this.helper = new RoshiStateMachineHelper(roshi, this);
        }
        public Rectangle CollisionRectangle() { return collisionRectangle; }
        public void Update()
        {
            if (roshi.health < RoshiStateMachineStorage.ENRAGE_HEALTH_TRIGGER)
            {
                moving = false;
                helper.Enrage();
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
                            timer = RoshiStateMachineStorage.TIMER_RESET;
                            direction = Direction.up;
                        }
                        else
                        {
                            timer = RoshiStateMachineStorage.TIMER_RESET;
                            direction = Direction.down;
                        }
                    }
                    else
                    {
                        timer--;
                        attackTimer--;
                    }

                    if (attackTimer == 0) { helper.Kamehameha(); }
                    else if (attackTimer == RoshiStateMachineStorage.KAMEHAMEHA_DESPAWN_TIME)
                    {
                        game.projectileHandler.Remove(kamehameha);
                        game.collisionManager.collisionEntities.Remove(kamehameha);
                    }
                    else if (attackTimer == RoshiStateMachineStorage.ATTACK_TRIGGER_ONE || attackTimer == RoshiStateMachineStorage.ATTACK_TRIGGER_TWO ||
                        attackTimer == RoshiStateMachineStorage.ATTACK_TRIGGER_THREE || attackTimer == RoshiStateMachineStorage.ATTACK_TRIGGER_FOUR)
                    { helper.KiBlast(); }
                }
                else { timer--; }
            }
            if (roshi.health <= 0)
            {
                helper.Dying();
                deathTimer--;
                spiritBomb.collided = true;
                if (deathTimer == 5) { roshi.game.currentRoom.removeEnemy(roshi); }
            }
            else if (spawning) { helper.Spawning(); }
            else if (damaged) { helper.Damaged(); }
            else if (moving) { helper.Moving(); }
        }
    }
}

