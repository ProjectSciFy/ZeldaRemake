using CSE3902_Game_Sprint0.Classes._21._2._13;
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
        bool emerging = false;
        bool hiding = false;
        bool idle = true;
        private int timer = 0;
        public enum CurrentState { none, emerging, hiding, idle, movingUp, movingDown, movingLeft, movingRight };
        public CurrentState currentState = CurrentState.none;

        public WallmasterStateMachine(EnemyWallmaster wallmaster)
        {
            this.wallmaster = wallmaster;
            game = wallmaster.game;
            wallmasterSpriteFactory = new WallmasterSpriteFactory(game);
            this.wallmaster.mySprite = wallmasterSpriteFactory.WallmasterIdle();
        }
        public void Idle()
        {
            new WallmasterIdle(wallmaster, wallmasterSpriteFactory, this).Execute();
        }

        public void Moving()
        {
            new WallmasterMoving(wallmaster, wallmasterSpriteFactory, this).Execute();
        }

        public void Update()
        {
            if (timer <= 0)
            {
                if (idle)
                {
                    direction = Direction.up;
                    idle = false;
                    emerging = true;
                    timer = 32;

                }
                else if (emerging)
                {
                    direction = Direction.right;
                    emerging = false;
                    timer = 64;
                } else if (!emerging && !idle && !hiding)
                {
                    direction = Direction.down;
                    hiding = true;
                    timer = 32;
                }
                else if (hiding)
                {
                    idle = true;
                    hiding = false;
                    timer = 180;
                }
            }
            else
            {
                timer--;
            }

            if (idle)
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
