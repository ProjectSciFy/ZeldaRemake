using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese.keeseScripts
{
    public class flying : ICommand
    {
        private EnemyKeese keese;
        private KeeseSpriteFactory enemySpriteFactory;
        private KeeseStateMachine KeeseStateMachine;
        private float flightTurn = (float).02;
        public flying(EnemyKeese keese, KeeseSpriteFactory enemySpriteFactory, KeeseStateMachine KeeseStateMachine)
        {
            this.keese = keese;
            this.enemySpriteFactory = enemySpriteFactory;
            this.KeeseStateMachine = KeeseStateMachine;
        }
        public void Execute()
        {
            switch (KeeseStateMachine.direction)
            {
                case KeeseStateMachine.Direction.north:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingNorth)
                    {
                        keese.velocity.X = 0;
                        keese.velocity.Y = -2;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingNorth;
                        keese.mySprite = enemySpriteFactory.KeeseFlyingNorth();
                    }
                    break;

                case KeeseStateMachine.Direction.northEast:
                    if (keese.velocity.Y > -2)
                    {
                        keese.velocity.Y = keese.velocity.Y - flightTurn;
                    }

                    if (keese.velocity.X < 2)
                    {
                        keese.velocity.X = keese.velocity.X + flightTurn;
                    }

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingNorthEast)
                    {
                        keese.velocity.X = 2;
                        keese.velocity.Y = -2;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingNorthEast;
                        keese.mySprite = enemySpriteFactory.KeeseFlyingNorthEast();
                    }
                    break;

                case KeeseStateMachine.Direction.east:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingEast)
                    {
                        keese.velocity.X = 2;
                        keese.velocity.Y = 0;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingEast;
                       keese.mySprite = enemySpriteFactory.KeeseFlyingEast();
                    }
                    break;

                case KeeseStateMachine.Direction.southEast:
                    if (keese.velocity.Y < 2)
                    {
                        keese.velocity.Y = keese.velocity.Y + flightTurn;
                    }

                    if (keese.velocity.X < 2)
                    {
                        keese.velocity.X = keese.velocity.X + flightTurn;
                    }

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingSouthEast)
                    {
                        keese.velocity.X = 2;
                        keese.velocity.Y = 2;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingSouthEast;
                        keese.mySprite = enemySpriteFactory.KeeseFlyingSouthEast();
                    }
                    break;

                case KeeseStateMachine.Direction.south:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingSouth)
                    {
                        keese.velocity.X = 0;
                        keese.velocity.Y = 2;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingSouth;
                       keese.mySprite = enemySpriteFactory.KeeseFlyingSouth();
                    }
                    break;

                case KeeseStateMachine.Direction.southWest:
                    if (keese.velocity.Y < 2)
                    {
                        keese.velocity.Y = keese.velocity.Y + flightTurn;
                    }

                    if (keese.velocity.X > -2)
                    {
                        keese.velocity.X = keese.velocity.X - flightTurn;
                    }

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingSouthWest)
                    {
                        keese.velocity.X = -2;
                        keese.velocity.Y = 2;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingSouthWest;
                        keese.mySprite = enemySpriteFactory.KeeseFlyingSouthWest();
                    }
                    break;

                case KeeseStateMachine.Direction.west:
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

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingWest)
                    {
                        keese.velocity.X = -2;
                        keese.velocity.Y = 0;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingWest;
                        keese.mySprite = enemySpriteFactory.KeeseFlyingWest();
                    }
                    break;

                case KeeseStateMachine.Direction.northWest:
                    if (keese.velocity.Y > -2)
                    {
                        keese.velocity.Y = keese.velocity.Y - flightTurn;
                    }

                    if (keese.velocity.X > -2)
                    {
                        keese.velocity.X = keese.velocity.X - flightTurn;
                    }

                    if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.flyingNorthWest)
                    {
                        keese.velocity.X = -2;
                        keese.velocity.Y = -2;
                        KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.flyingNorthWest;
                        keese.mySprite = enemySpriteFactory.KeeseFlyingNorthWest();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}