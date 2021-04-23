namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese.keeseScripts
{
    public class KeeseFlying : ICommand
    {
        private EnemyKeese keese { get; set; }
        private KeeseSpriteFactory enemySpriteFactory { get; set; }
        private KeeseStateMachine KeeseStateMachine { get; set; }
        private readonly float flightTurn = (float).02;
        public KeeseFlying(EnemyKeese keese, KeeseSpriteFactory enemySpriteFactory, KeeseStateMachine KeeseStateMachine)
        {
            this.keese = keese;
            this.enemySpriteFactory = enemySpriteFactory;
            this.KeeseStateMachine = KeeseStateMachine;
        }

        public void Execute()
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;

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