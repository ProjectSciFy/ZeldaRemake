namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead.RedeadScripts
{
    public class RedeadSpawning : ICommand
    {
        private EnemyRedead redead { get; set; }
        private RedeadSpriteFactory spriteFactory { get; set; }
        private RedeadStateMachine redeadStateMachine { get; set; }

        public RedeadSpawning(EnemyRedead redead, RedeadSpriteFactory spriteFactory, RedeadStateMachine redeadStateMachine)
        {
            this.redead = redead;
            this.spriteFactory = spriteFactory;
            this.redeadStateMachine = redeadStateMachine;
        }

        public void Execute()
        {
            redead.spriteSize.X = RedeadHelper.size;
            redead.spriteSize.Y = RedeadHelper.size;
            redead.velocity.X = 0;
            redead.velocity.Y = 0;

            if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.spawning)
            {
                redeadStateMachine.currentState = RedeadStateMachine.CurrentState.spawning;
                redead.mySprite = spriteFactory.SpawnRedead();
            }
        }
    }
}
