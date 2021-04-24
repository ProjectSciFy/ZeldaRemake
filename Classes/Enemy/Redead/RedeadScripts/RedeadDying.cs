namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead.RedeadScripts
{
    public class RedeadDying : ICommand
    {
        private EnemyRedead redead { get; set; }
        private RedeadSpriteFactory spriteFactory { get; set; }
        private RedeadStateMachine redeadStateMachine { get; set; }

        public RedeadDying(EnemyRedead redead, RedeadSpriteFactory spriteFactory, RedeadStateMachine redeadStateMachine)
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

            if (redeadStateMachine.currentState != RedeadStateMachine.CurrentState.dying)
            {
                redeadStateMachine.currentState = RedeadStateMachine.CurrentState.dying;
                redead.mySprite = spriteFactory.SpawnRedead();
                redead.game.collisionManager.collisionEntities.Remove(redead);
                redead.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
