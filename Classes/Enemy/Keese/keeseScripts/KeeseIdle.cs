namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese.keeseScripts
{
    public class KeeseIdle : ICommand
    {
        private EnemyKeese keese { get; set; }
        private KeeseSpriteFactory enemySpriteFactory { get; set; }
        private KeeseStateMachine KeeseStateMachine { get; set; }
        public KeeseIdle(EnemyKeese keese, KeeseSpriteFactory enemySpriteFactory, KeeseStateMachine KeeseStateMachine)
        {
            this.keese = keese;
            this.enemySpriteFactory = enemySpriteFactory;
            this.KeeseStateMachine = KeeseStateMachine;
        }
        public void Execute()
        {
            keese.spriteSize.X = KeeseHelper.size;
            keese.spriteSize.Y = KeeseHelper.size;
            keese.velocity.X = 0;
            keese.velocity.Y = 0;

            if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.idle)
            {
                KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.idle;
                keese.mySprite = enemySpriteFactory.KeeseIdle();
            }
        }
    }
}