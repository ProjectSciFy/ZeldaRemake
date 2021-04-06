using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster.WallmasterScripts;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class WallmasterStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyWallmaster wallmaster;
        private WallmasterSpriteFactory wallmasterSpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.up;
        private int staging = 0;
        public bool activating = false;
        public bool active = false;
        public int timer = 0;
        private int deathTimer = 30;
        public enum CurrentState { none, emerging, hiding, idle, movingUp, movingDown, movingLeft, movingRight, dying };
        public CurrentState currentState = CurrentState.none;

        public WallmasterStateMachine(EnemyWallmaster wallmaster)
        {
            this.wallmaster = wallmaster;
            game = wallmaster.game;
            wallmasterSpriteFactory = new WallmasterSpriteFactory(game);
        }
        public void Dying()
        {
            new WallmasterDying(wallmaster, wallmasterSpriteFactory, this).Execute();
        }
        public void Idle()
        {
            new WallmasterIdle(wallmaster, wallmasterSpriteFactory, this).Execute();
        }

        public void Moving()
        {
            new WallmasterMoving(wallmaster, wallmasterSpriteFactory, this).Execute();
        }

        public void Hiding()
        {
            if (timer <= 0)
            {
                new WallmasterHiding(wallmaster, wallmasterSpriteFactory).Execute();
            }
        }

        public void Update()
        {
            if (wallmaster.health <= 0)
            {
                Dying();
                deathTimer--;
                if (deathTimer == 0)
                {
                    wallmaster.game.currentRoom.removeEnemy(wallmaster);
                }
            }
            if (timer <= 0)
            {
                if (activating && !active)
                {
                    timer = 32;
                    activating = false;
                    active = true;
                    Moving();
                }
                else if (active)
                {
                    switch (staging)
                    {
                        case 0:
                            timer = 64;
                            new WallmasterTurnClockwise(this).Execute();
                            Moving();
                            break;
                        case 1:
                            timer = 128;
                            new WallmasterTurnClockwise(this).Execute();
                            Moving();
                            break;
                        case 2:
                            Hiding();
                            active = false;
                            staging = -1;
                            break;
                        default:
                            break;
                    }
                    staging++;
                }
            }
            else
            {
                timer--;
            }
        }
    }
}
