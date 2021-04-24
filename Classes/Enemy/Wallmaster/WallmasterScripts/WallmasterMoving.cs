namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster.WallmasterScripts
{
    public class WallmasterMoving : ICommand
    {
        private EnemyWallmaster wallmaster { get; set; }
        private WallmasterSpriteFactory wallmasterSpriteFactory { get; set; }
        private WallmasterStateMachine wallmasterStateMachine { get; set; }

        public WallmasterMoving(EnemyWallmaster wallmaster, WallmasterSpriteFactory wallmasterSpriteFactory, WallmasterStateMachine wallmasterStateMachine)
        {
            this.wallmaster = wallmaster;
            this.wallmasterSpriteFactory = wallmasterSpriteFactory;
            this.wallmasterStateMachine = wallmasterStateMachine;
        }

        public void Execute()
        {
            wallmaster.spriteSize.X = WallmasterHelper.size;
            wallmaster.spriteSize.Y = WallmasterHelper.size;

            switch (wallmasterStateMachine.direction)
            {
                case WallmasterStateMachine.Direction.up:
                    if (wallmasterStateMachine.currentState != WallmasterStateMachine.CurrentState.movingUp)
                    {
                        wallmasterStateMachine.currentState = WallmasterStateMachine.CurrentState.movingUp;
                        this.wallmaster.velocity.X = 0;
                        this.wallmaster.velocity.Y = WallmasterHelper.nvelocity;
                        this.wallmaster.mySprite = wallmasterSpriteFactory.WallmasterMovingUp();
                    }
                    break;
                case WallmasterStateMachine.Direction.right:
                    if (wallmasterStateMachine.currentState != WallmasterStateMachine.CurrentState.movingRight)
                    {
                        wallmasterStateMachine.currentState = WallmasterStateMachine.CurrentState.movingRight;
                        this.wallmaster.velocity.X = 1;
                        this.wallmaster.velocity.Y = 0;
                        this.wallmaster.mySprite = wallmasterSpriteFactory.WallmasterMovingRight();
                    }
                    break;
                case WallmasterStateMachine.Direction.down:
                    if (wallmasterStateMachine.currentState != WallmasterStateMachine.CurrentState.movingDown)
                    {
                        wallmasterStateMachine.currentState = WallmasterStateMachine.CurrentState.movingDown;
                        this.wallmaster.velocity.X = 0;
                        this.wallmaster.velocity.Y = 1;
                        this.wallmaster.mySprite = wallmasterSpriteFactory.WallmasterMovingDown();
                    }
                    break;
                case WallmasterStateMachine.Direction.left:
                    if (wallmasterStateMachine.currentState != WallmasterStateMachine.CurrentState.movingLeft)
                    {
                        wallmasterStateMachine.currentState = WallmasterStateMachine.CurrentState.movingLeft;
                        this.wallmaster.velocity.X = WallmasterHelper.nvelocity;
                        this.wallmaster.velocity.Y = 0;
                        this.wallmaster.mySprite = wallmasterSpriteFactory.WallmasterMovingLeft();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
