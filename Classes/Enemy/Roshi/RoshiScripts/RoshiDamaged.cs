namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiDamaged : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiDamaged(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
        {
            this.roshi = roshi;
            this.spriteFactory = spriteFactory;
            this.roshiState = roshiState;
        }

        public void Execute()
        {
            roshi.spriteSize.X = 43;
            roshi.spriteSize.Y = 41;
            roshi.velocity.X = 0;
            roshi.velocity.Y = 0;
            roshiState.timer = 30;
            roshiState.moving = false;
            roshiState.damaged = false;
            if (roshiState.kiBlast != null)
            {
                roshi.game.projectileHandler.Remove(roshiState.kiBlast);
                roshi.game.collisionManager.collisionEntities.Remove(roshiState.kiBlast);
            }
            if (roshiState.currentState != RoshiStateMachine.CurrentState.damaged)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.damaged;
                roshi.mySprite = spriteFactory.RoshiDamaged();
            }
        }
    }
}
