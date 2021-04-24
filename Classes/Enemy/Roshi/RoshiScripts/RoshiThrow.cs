namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiThrow : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiThrow(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
        {
            this.roshi = roshi;
            this.spriteFactory = spriteFactory;
            this.roshiState = roshiState;
        }

        public void Execute()
        {
            roshi.spriteSize.X = 44;
            roshi.spriteSize.Y = 45;
            roshi.velocity.X = 0;
            roshi.velocity.Y = 0;
            roshiState.spiritBomb.myState.charging = false;
            roshiState.spiritBomb.myState.fire = true;
            if (roshiState.currentState != RoshiStateMachine.CurrentState.throwing)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.throwing;
                roshi.mySprite = spriteFactory.RoshiThrow();
            }
        }
    }
}
