namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiMoving : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiMoving(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
        {
            this.roshi = roshi;
            this.spriteFactory = spriteFactory;
            this.roshiState = roshiState;
        }

        public void Execute()
        {
            roshi.spriteSize.X = 43;
            roshi.spriteSize.Y = 41;

            switch (roshiState.direction)
            {
                case RoshiStateMachine.Direction.up:
                    if (roshiState.currentState != RoshiStateMachine.CurrentState.movingUp)
                    {
                        roshiState.currentState = RoshiStateMachine.CurrentState.movingUp;
                        roshi.velocity.X = 0;
                        roshi.velocity.Y = -1;
                        roshi.mySprite = spriteFactory.RoshiMoving();
                    }
                    break;
                case RoshiStateMachine.Direction.down:
                    if (roshiState.currentState != RoshiStateMachine.CurrentState.movingDown)
                    {
                        roshiState.currentState = RoshiStateMachine.CurrentState.movingDown;
                        roshi.velocity.X = 0;
                        roshi.velocity.Y = 1;
                        roshi.mySprite = spriteFactory.RoshiMoving();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
