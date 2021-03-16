using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese.keeseScripts
{
    public class Landing : ICommand
    {
        private float landingTurn = (float).02;
        private EnemyKeese keese;
        private KeeseSpriteFactory enemySpriteFactory;
        private KeeseStateMachine KeeseStateMachine;
        bool landing;
        bool takeOff;
        public Landing(EnemyKeese keese, KeeseSpriteFactory enemySpriteFactory, KeeseStateMachine KeeseStateMachine,
            bool landing, bool takeOff)
        {
            this.keese = keese;
            this.enemySpriteFactory = enemySpriteFactory;
            this.KeeseStateMachine = KeeseStateMachine;
            this.landing = landing;
            this.takeOff = takeOff;

        }
        public void Execute()
        {
            switch (KeeseStateMachine.direction)
            {
                case KeeseStateMachine.Direction.north:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingNorth)
                    {
                        keese.velocity.X = 0;
                        keese.velocity.Y = -1;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingNorth;
                        keese.mySprite = enemySpriteFactory.KeeseLandingNorth();
                    }
                    break;

                case KeeseStateMachine.Direction.northEast:
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
                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingNorthEast)
                    {
                        keese.velocity.X = 1;
                        keese.velocity.Y = -1;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingNorthEast;
                        keese.mySprite = enemySpriteFactory.KeeseLandingNorthEast();
                    }
                    break;

                case KeeseStateMachine.Direction.east:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingEast)
                    {
                        keese.velocity.X =1;
                        keese.velocity.Y =  0;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingEast;
                        keese.mySprite = enemySpriteFactory.KeeseLandingEast();
                    }
                    break;

                case KeeseStateMachine.Direction.southEast:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingSouthEast)
                    {
                        keese.velocity.X = 1;
                        keese.velocity.Y = 1;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingSouthEast;
                        keese.mySprite = enemySpriteFactory.KeeseLandingSouthEast();
                    }
                    break;

                case KeeseStateMachine.Direction.south:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingSouth)
                    {
                        keese.velocity.X = 0;
                        keese.velocity.Y = 1;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingSouth;
                        keese.mySprite = enemySpriteFactory.KeeseLandingSouth();
                    }
                    break;

                case KeeseStateMachine.Direction.southWest:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingSouthWest)
                    {
                        keese.velocity.X = -1;
                        keese.velocity.Y = 1;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingSouthWest;
                        keese.mySprite = enemySpriteFactory.KeeseLandingSouthWest();
                    }
                    break;

                case KeeseStateMachine.Direction.west:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingWest)
                    {
                        keese.velocity.X = -1;
                        keese.velocity.Y = 0;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingWest;
                        keese.mySprite = enemySpriteFactory.KeeseLandingWest();
                    }
                    break;

                case KeeseStateMachine.Direction.northWest:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.landingNorthWest)
                    {
                        keese.velocity.X = -1;
                        keese.velocity.Y = -1;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.landingNorthWest;
                        keese.mySprite = enemySpriteFactory.KeeseLandingNorthWest();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}