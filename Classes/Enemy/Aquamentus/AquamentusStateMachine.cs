using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{
    public class AquamentusStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyAquamentus aquamentus;
        private EnemySpriteFactory enemySpriteFactory;

        public enum Direction { right, left };
        public Direction direction = Direction.right;
        bool spawning = true;
        bool roaring = false;
        private int timer = 90;
        private enum CurrentState { none, movingLeft, movingRight, roaringLeft, roaringRight, spawning };
        private CurrentState currentState = CurrentState.none;

        public AquamentusStateMachine(EnemyAquamentus aquamentus)
        {
            game=aquamentus.game;
            this.aquamentus = aquamentus;
            /*enemySpriteFactory = aquamentus.enemySpriteFactory;*/
            enemySpriteFactory = new EnemySpriteFactory(game);
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                enemySpriteFactory.SpawnAquamentus(aquamentus);
            }

            if (timer <= 0)
            {
                spawning = false;
                currentState = CurrentState.none;
            }
        }

        public void Moving()
        {
            if (roaring)
            {
                switch (direction)
                {
                    case Direction.left:
                        if (currentState != CurrentState.roaringLeft)
                        {
                            currentState = CurrentState.roaringLeft;
                            enemySpriteFactory.AquamentusRoaringLeft(aquamentus);
                        }
                        break;
                    case Direction.right:
                        if (currentState != CurrentState.roaringRight)
                        {
                            currentState = CurrentState.roaringRight;
                            enemySpriteFactory.AquamentusRoaringRight(aquamentus);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case Direction.left:
                        if (currentState != CurrentState.movingLeft)
                        {
                            currentState = CurrentState.movingLeft;
                            enemySpriteFactory.AquamentusMovingLeft(aquamentus);
                        }
                        break;
                    case Direction.right:
                        if (currentState != CurrentState.movingRight)
                        {
                            currentState = CurrentState.movingRight;
                            enemySpriteFactory.AquamentusMovingRight(aquamentus);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void Update()
        {
            if (!spawning)
            {
                if (timer <= 0)
                {
                    var random = new Random();
                    int randomRoar = random.Next(2);

                    if (randomRoar > 0)
                    {
                        direction = Direction.left;
                    }
                    else
                    {
                        direction = Direction.right;
                    }

                    randomRoar = random.Next(3);

                    if (randomRoar > 0)
                    {
                        roaring = false;
                        timer = 90;
                    }
                    else
                    {
                        roaring = true;
                        timer = 45;
                    }
                }
                else
                {
                    timer--;
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
                Moving();
            }
        }
    }
}
