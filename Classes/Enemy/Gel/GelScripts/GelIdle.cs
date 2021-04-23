namespace CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts
{
    public class GelIdle : ICommand
    {
        private EnemySlime gel { get; set; }
        private GelSpriteFactory gelSpriteFactory { get; set; }
        private GelStateMachine gelStateMachine { get; set; }

        public GelIdle(EnemySlime gel, GelSpriteFactory gelSpriteFactory, GelStateMachine gelStateMachine)
        {
            this.gel = gel;
            this.gelSpriteFactory = gelSpriteFactory;
            this.gelStateMachine = gelStateMachine;
        }

        public void Execute()
        {
            gel.spriteSize.X = 16;
            gel.spriteSize.Y = 16;
            gel.velocity.X = 0;
            gel.velocity.Y = 0;

            if (gelStateMachine.currentState != GelStateMachine.CurrentState.idleRight)
            {
                gelStateMachine.currentState = GelStateMachine.CurrentState.idleRight;
                gel.mySprite = gelSpriteFactory.GelIdle();
            }
        }
    }
}
