namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster.WallmasterScripts
{
    public class WallmasterTurnClockwise : ICommand
    {
        WallmasterStateMachine wallmasterStateMachine { get; set; }
        public WallmasterTurnClockwise(WallmasterStateMachine wallmasterStateMachine)
        {
            this.wallmasterStateMachine = wallmasterStateMachine;
        }

        public void Execute()
        {
            switch (wallmasterStateMachine.direction)
            {
                case WallmasterStateMachine.Direction.up:
                    wallmasterStateMachine.direction = WallmasterStateMachine.Direction.right;
                    break;
                case WallmasterStateMachine.Direction.down:
                    wallmasterStateMachine.direction = WallmasterStateMachine.Direction.left;
                    break;
                case WallmasterStateMachine.Direction.left:
                    wallmasterStateMachine.direction = WallmasterStateMachine.Direction.up;
                    break;
                case WallmasterStateMachine.Direction.right:
                    wallmasterStateMachine.direction = WallmasterStateMachine.Direction.down;
                    break;
                default:
                    break;
            }
        }
    }
}
