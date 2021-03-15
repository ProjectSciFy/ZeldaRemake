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
        private AquamentusSpriteFactory enemySpriteFactory;

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
            enemySpriteFactory = new AquamentusSpriteFactory(game);
        }

        public void Spawning()
        {
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                this.aquamentus.mySprite = enemySpriteFactory.SpawnAquamentus();
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
                            this.aquamentus.velocity.X = -1;
                            this.aquamentus.velocity.Y = 0;
                            this.aquamentus.mySprite = enemySpriteFactory.AquamentusRoaringLeft();
                        }
                        break;
                    case Direction.right:
                        if (currentState != CurrentState.roaringRight)
                        {
                            currentState = CurrentState.roaringRight;
                            this.aquamentus.velocity.X = 1;
                            this.aquamentus.velocity.Y = 0;
                            this.aquamentus.mySprite = enemySpriteFactory.AquamentusRoaringRight();
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
                            this.aquamentus.velocity.X = -1;
                            this.aquamentus.velocity.Y = 0;
                            this.aquamentus.mySprite = enemySpriteFactory.AquamentusMovingLeft();
                        }
                        break;
                    case Direction.right:
                        if (currentState != CurrentState.movingRight)
                        {
                            currentState = CurrentState.movingRight;
                            this.aquamentus.velocity.X = 1;
                            this.aquamentus.velocity.Y = 0;
                            this.aquamentus.mySprite = enemySpriteFactory.AquamentusMovingRight();
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
