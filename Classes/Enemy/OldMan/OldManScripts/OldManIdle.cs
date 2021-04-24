namespace CSE3902_Game_Sprint0.Classes.Enemy.OldMan.OldManScripts
{
    public class OldManIdle : ICommand
    {
        private EnemyOldMan oldMan { get; set; }
        private OldManSpriteFactory oldManSpriteFactory { get; set; }
        private OldManStateMachine oldManStateMachine { get; set; }
        private int size = 16;

        public OldManIdle(EnemyOldMan oldMan, OldManSpriteFactory oldManSpriteFactory, OldManStateMachine oldManStateMachine)
        {
            this.oldMan = oldMan;
            this.oldManSpriteFactory = oldManSpriteFactory;
            this.oldManStateMachine = oldManStateMachine;
        }
        public void Execute()
        {
            oldMan.spriteSize.X = size;
            oldMan.spriteSize.Y = size;
            oldMan.velocity.X = 0;
            oldMan.velocity.Y = 0;

            if (oldManStateMachine.currentState != OldManStateMachine.CurrentState.idleRight)
            {
                oldManStateMachine.currentState = OldManStateMachine.CurrentState.idleRight;
                oldMan.mySprite = oldManSpriteFactory.OldManIdle();
            }

        }
    }
}
