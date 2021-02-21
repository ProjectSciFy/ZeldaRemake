using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class StalfosStateMachine : IEnemyStateMachine
    {
        private EnemyStalfos stalfos;
        private EnemySpriteFactory enemySpriteFactory;

        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        bool moving = true;
        bool spawning = true;
        private int timer = 90;
        private enum CurrentState { idleUp, idleDown, idleLeft, idleRight, movingUp, movingDown, movingLeft, movingRight, spawning};
        private CurrentState currentState = CurrentState.idleDown;

        public StalfosStateMachine(EnemyStalfos stalfos)
        {
            this.stalfos = stalfos;
            enemySpriteFactory = stalfos.enemySpriteFactory;
        }

        public void Spawning()
        {
            if (timer > 0)
            {
                timer--;
            }
            else
            {
                spawning = false;
            }

            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                enemySpriteFactory.SpawnStalfos(stalfos);
            }
        }

        public void Idle()
        {
            // construct nonanimated link facing up with sprite factory
            if (currentState != CurrentState.idleRight)
            {
                currentState = CurrentState.idleRight;
                enemySpriteFactory.StalfosIdle(stalfos);
            }
        }

        public void Moving()
        {
            switch (direction)
            {
                case Direction.right:
                    if (currentState != CurrentState.movingRight)
                    {
                        currentState = CurrentState.movingRight;
                        enemySpriteFactory.StalfosMovingRight(stalfos);
                    }
                    break;

                case Direction.up:
                    if (currentState != CurrentState.movingUp)
                    {
                        currentState = CurrentState.movingUp;
                        enemySpriteFactory.StalfosMovingUp(stalfos);
                    }
                    break;

                case Direction.left:
                    if (currentState != CurrentState.movingLeft)
                    {
                        currentState = CurrentState.movingLeft;
                        enemySpriteFactory.StalfosMovingLeft(stalfos);
                    }
                    break;

                case Direction.down:
                    if (currentState != CurrentState.movingDown)
                    {
                        currentState = CurrentState.movingDown;
                        enemySpriteFactory.StalfosMovingDown(stalfos);
                    }
                    break;

                default:
                    break;
            }
        }



        public void Update()
        {
            if (timer == 0 && !spawning)
            {
                var random = new Random();
                timer = 60;
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
            else
            {
                timer--;
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
