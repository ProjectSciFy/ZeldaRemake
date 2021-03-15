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
        private float flightTurn = (float).02;
        private float landingTurn = (float).02;
        private enum CurrentState { none, idle, flyingNorth, flyingNorthEast, flyingEast, flyingSouthEast, flyingSouth, flyingSouthWest, flyingWest, flyingNorthWest, landingNorth, landingNorthEast, landingEast, landingSouthEast, landingSouth, landingSouthWest, landingWest, landingNorthWest, spawning };
        private CurrentState currentState = CurrentState.none;

        public KeeseStateMachine(EnemyKeese keese)
        {
            game=keese.game;
            this.keese.mySprite = enemySpriteFactory.KeeseIdle();
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
            if (currentState != CurrentState.spawning)
            {
                currentState = CurrentState.spawning;
                this.keese.mySprite= enemySpriteFactory.SpawnKeese();
            }

            if (timer <= 0)
            {
                spawning = false;
                currentState = CurrentState.none;
            }
        }

        public void Idle()
        {
            if (currentState != CurrentState.idle)
            {
                currentState = CurrentState.idle;
                this.keese.mySprite=enemySpriteFactory.KeeseIdle();
            }
        }

        public void Flying()
        {
            switch (direction)
            {
                case Direction.north:
                    if (keese.velocity.Y > -2)
                    {
                        keese.velocity.Y = keese.velocity.Y - flightTurn;
                    }

                    if (keese.velocity.X > 0)
                    {
                        keese.velocity.X = keese.velocity.X - flightTurn;
                    }
                    else if (keese.velocity.X < 0)
                    {
                        keese.velocity.X = keese.velocity.X + flightTurn;
                    }

                    if (currentState != CurrentState.flyingNorth)
                    {
                        currentState = CurrentState.flyingNorth;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingNorth();
                    }
                    break;

                case Direction.northEast:
                    if (keese.velocity.Y > -2)
                    {
                        keese.velocity.Y = keese.velocity.Y - flightTurn;
                    }

                    if (keese.velocity.X < 2)
                    {
                        keese.velocity.X = keese.velocity.X + flightTurn;
                    }

                    if (currentState != CurrentState.flyingNorthEast)
                    {
                        currentState = CurrentState.flyingNorthEast;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingNorthEast();
                    }
                    break;

                case Direction.east:
                    if (keese.velocity.Y > 0)
                    {
                        keese.velocity.Y = keese.velocity.Y - flightTurn;
                    }
                    else if (keese.velocity.Y < 0)
                    {
                        keese.velocity.Y = keese.velocity.Y + flightTurn;
                    }

                    if (keese.velocity.X < 2)
                    {
                        keese.velocity.X = keese.velocity.X + flightTurn;
                    }

                    if (currentState != CurrentState.flyingEast)
                    {
                        currentState = CurrentState.flyingEast;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingEast();
                    }
                    break;

                case Direction.southEast:
                    if (keese.velocity.Y < 2)
                    {
                        keese.velocity.Y = keese.velocity.Y + flightTurn;
                    }

                    if (keese.velocity.X < 2)
                    {
                        keese.velocity.X = keese.velocity.X + flightTurn;
                    }

                    if (currentState != CurrentState.flyingSouthEast)
                    {
                        currentState = CurrentState.flyingSouthEast;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingSouthEast();
                    }
                    break;

                case Direction.south:
                    if (keese.velocity.Y < 2)
                    {
                        keese.velocity.Y = keese.velocity.Y + flightTurn;
                    }

                    if (keese.velocity.X > 0)
                    {
                        keese.velocity.X = keese.velocity.X - flightTurn;
                    }
                    else if (keese.velocity.X < 0)
                    {
                        keese.velocity.X = keese.velocity.X + flightTurn;
                    }

                    if (currentState != CurrentState.flyingSouth)
                    {
                        currentState = CurrentState.flyingSouth;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingSouth();
                    }
                    break;

                case Direction.southWest:
                    if (keese.velocity.Y < 2)
                    {
                        keese.velocity.Y = keese.velocity.Y + flightTurn;
                    }

                    if (keese.velocity.X > -2)
                    {
                        keese.velocity.X = keese.velocity.X - flightTurn;
                    }

                    if (currentState != CurrentState.flyingSouthWest)
                    {
                        currentState = CurrentState.flyingSouthWest;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingSouthWest();
                    }
                    break;

                case Direction.west:
                    if (keese.velocity.Y > 0)
                    {
                        keese.velocity.Y = keese.velocity.Y - flightTurn;
                    }
                    else if (keese.velocity.Y < 0)
                    {
                        keese.velocity.Y = keese.velocity.Y + flightTurn;
                    }

                    if (keese.velocity.X > -2)
                    {
                        keese.velocity.X = keese.velocity.X - flightTurn;
                    }

                    if (currentState != CurrentState.flyingWest)
                    {
                        currentState = CurrentState.flyingWest;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingWest();
                    }
                    break;

                case Direction.northWest:
                    if (keese.velocity.Y > -2)
                    {
                        keese.velocity.Y = keese.velocity.Y - flightTurn;
                    }

                    if (keese.velocity.X > -2)
                    {
                        keese.velocity.X = keese.velocity.X - flightTurn;
                    }

                    if (currentState != CurrentState.flyingNorthWest)
                    {
                        currentState = CurrentState.flyingNorthWest;
                        this.keese.mySprite=enemySpriteFactory.KeeseFlyingNorthWest();
                    }
                    break;

                default:
                    break;
            }
        }

        public void Landing()
        {
            switch (direction)
            {
                case Direction.north:
                    if (landing)
                    {
                        if (keese.velocity.Y < 0)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X > 0)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                        else if (keese.velocity.X < 0)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y > -2)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }

                        if (keese.velocity.X > 0)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                        else if (keese.velocity.X < 0)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }

                    if (currentState != CurrentState.landingNorth)
                    {
                        currentState = CurrentState.landingNorth;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingNorth();
                    }
                    break;

                case Direction.northEast:
                    if (landing)
                    {
                        if (keese.velocity.Y < 0)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X > 0)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y > -2)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }

                        if (keese.velocity.X < 2)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }

                    if (landing && keese.velocity.Y < 0)
                    {
                        keese.velocity.Y = keese.velocity.Y + landingTurn;
                    }
                    if (currentState != CurrentState.landingNorthEast)
                    {
                        currentState = CurrentState.landingNorthEast;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingNorthEast();
                    }
                    break;

                case Direction.east:
                    if (landing)
                    {
                        if (keese.velocity.Y > 0)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }
                        else if (keese.velocity.Y < 0)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X > 0)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y > 0)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }
                        else if (keese.velocity.Y < 0)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X < 2)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }

                    if (currentState != CurrentState.landingEast)
                    {
                        currentState = CurrentState.landingEast;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingEast();
                    }
                    break;

                case Direction.southEast:
                    if (landing)
                    {
                        if (keese.velocity.Y > 0)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }

                        if (keese.velocity.X > 0)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y < 2)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X < 2)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }

                    if (currentState != CurrentState.landingSouthEast)
                    {
                        currentState = CurrentState.landingSouthEast;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingSouthEast();
                    }
                    break;

                case Direction.south:
                    if (landing)
                    {
                        if (keese.velocity.Y > 0)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }

                        if (keese.velocity.X > 0)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                        else if (keese.velocity.X < 0)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y < 2)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X > 0)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                        else if (keese.velocity.X < 0)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }

                    if (currentState != CurrentState.landingSouth)
                    {
                        currentState = CurrentState.landingSouth;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingSouth();
                    }
                    break;

                case Direction.southWest:
                    if (landing)
                    {
                        if (keese.velocity.Y > 0)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }

                        if (keese.velocity.X < 0)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y < 2)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X > -2)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                    }

                    if (currentState != CurrentState.landingSouthWest)
                    {
                        currentState = CurrentState.landingSouthWest;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingSouthWest();
                    }
                    break;

                case Direction.west:
                    if (landing)
                    {
                        if (keese.velocity.Y > 0)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }
                        else if (keese.velocity.Y < 0)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X < 0)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y > 0)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }
                        else if (keese.velocity.Y < 0)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X > -2)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                    }

                    if (currentState != CurrentState.landingWest)
                    {
                        currentState = CurrentState.landingWest;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingWest();
                    }
                    break;

                case Direction.northWest:
                    if (landing)
                    {
                        if (keese.velocity.Y < 0)
                        {
                            keese.velocity.Y = keese.velocity.Y + landingTurn;
                        }

                        if (keese.velocity.X < 0)
                        {
                            keese.velocity.X = keese.velocity.X + landingTurn;
                        }
                    }
                    else if (takeOff)
                    {
                        if (keese.velocity.Y > -2)
                        {
                            keese.velocity.Y = keese.velocity.Y - landingTurn;
                        }

                        if (keese.velocity.X > -2)
                        {
                            keese.velocity.X = keese.velocity.X - landingTurn;
                        }
                    }

                    if (currentState != CurrentState.landingNorthWest)
                    {
                        currentState = CurrentState.landingNorthWest;
                        this.keese.mySprite=enemySpriteFactory.KeeseLandingNorthWest();
                    }
                    break;

                default:
                    break;
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
