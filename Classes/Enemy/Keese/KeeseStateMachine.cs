using CSE3902_Game_Sprint0.Classes.Enemy.Keese.keeseScripts;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese
{
    public class KeeseStateMachine : IEnemyStateMachine
    {
        private ZeldaGame game;
        private EnemyKeese keese;
        private KeeseSpriteFactory enemySpriteFactory;

        public enum Direction { north, northEast, east, southEast, south, southWest, west, northWest };
        public Direction direction = Direction.north;
        private int directionNumber = 0;
        bool moving = false;
        bool landing = false;
        bool takeOff = false;
        bool spawning = true;
        private int timer = 90;
        private int directionTimer = 0;
        public enum CurrentState { none, idle, flyingNorth, flyingNorthEast, flyingEast, flyingSouthEast, flyingSouth, flyingSouthWest, flyingWest, flyingNorthWest, landingNorth, landingNorthEast, landingEast, landingSouthEast, landingSouth, landingSouthWest, landingWest, landingNorthWest, spawning };
        public CurrentState currentState = CurrentState.none;

        public KeeseStateMachine(EnemyKeese keese)
        {
            this.game = keese.game;
            this.keese = keese;
            enemySpriteFactory = new KeeseSpriteFactory(game);
        }

        private Direction ChangeDirection(ref int directionNumber)
        {
            var random = new Random();

            switch (random.Next(3))
            {
                case 0:
                    directionNumber = directionNumber - 1;
                    break;
                case 1:
                    //Maintain direction
                    break;
                case 2:
                    directionNumber = directionNumber + 1;
                    break;
                default:
                    break;
            }

            if (directionNumber > 7)
            {
                directionNumber = 0;
            }
            else if (directionNumber < 0)
            {
                directionNumber = 7;
            }

            switch (directionNumber)
            {
                case 0:
                    return Direction.north;
                case 1:
                    return Direction.northEast;
                case 2:
                    return Direction.east;
                case 3:
                    return Direction.southEast;
                case 4:
                    return Direction.south;
                case 5:
                    return Direction.southWest;
                case 6:
                    return Direction.west;
                case 7:
                    return Direction.northWest;
                default:
                    return Direction.north;
            }
        }

        public void Spawning()
        {
            timer=90;
            spawning=false;
            new spawning(keese, enemySpriteFactory, this).Execute();
            

          /*  if (timer <= 0)
            {
                spawning = false;
                currentState = CurrentState.none;
            }*/
        }

        public void Idle()
        {
            if(timer<=0){
            new idle(keese, enemySpriteFactory, this).Execute();
            }
           
        }

        public void Flying()
        {
           if(timer<=0){
                timer=60;
            new flying(keese, enemySpriteFactory, this).Execute();
                }
        }

        public void Landing()
        {
            if(timer<=0){
                timer=60;
            new Landing(keese, enemySpriteFactory, this, landing, takeOff).Execute();
                }
           
        }

        public void Update()
        {
            if (!spawning)
            {
                if (directionTimer <= 0)
                {
                    directionTimer = 30;
                    direction = ChangeDirection(ref directionNumber);
                }
                else
                {
                    directionTimer--;
                }

                if (timer <= 0)
                {
                    if (!moving && !landing && !takeOff)
                    {
                        timer = 120;
                        moving = true;
                        takeOff = true;
                    }
                    else if (moving && takeOff)
                    {
                        timer = 180;
                        takeOff = false;
                    }
                    else if (moving && !landing && !takeOff)
                    {
                        timer = 120;
                        landing = true;
                    }
                    else if (moving && landing)
                    {
                        timer = 180;
                        moving = false;
                        landing = false;
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
                if (moving)
                {
                    if (landing || takeOff)
                    {
                        Landing();
                    }
                    else
                    {
                        Flying();
                    }
                }
                else
                {
                    Idle();
                }
            }
        }
    }
}
