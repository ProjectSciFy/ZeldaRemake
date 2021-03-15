using CSE3902_Game_Sprint0.Classes.Enemy.Stalfos;
using CSE3902_Game_Sprint0.Classes.Enemy.Stalfos.StalfosScripts;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class StalfosStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyStalfos stalfos;
        private StalfosSpriteFactory stalfosSpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = true;
        bool spawning = true;
        public int timer = 0;
        public enum CurrentState {none, idle, movingUp, movingDown, movingLeft, movingRight, spawning};
        public CurrentState currentState = CurrentState.none;

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


        public void Idle()
        {
            if (timer <= 0)
            {
                new StalfosIdle(stalfos, stalfosSpriteFactory, this).Execute();
            }
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
        }
    }
}
