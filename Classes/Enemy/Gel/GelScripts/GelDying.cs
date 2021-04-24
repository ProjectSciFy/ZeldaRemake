namespace CSE3902_Game_Sprint0.Classes.Enemy.Gel.GelScripts
{
    public class GelDying : ICommand
    {
        private EnemySlime gel { get; set; }
        private GelSpriteFactory gelSpriteFactory { get; set; }
        private GelStateMachine gelStateMachine { get; set; }

        public GelDying(EnemySlime gel, GelSpriteFactory gelSpriteFactory, GelStateMachine gelStateMachine)
        {
            this.gel = gel;
            this.gelSpriteFactory = gelSpriteFactory;
            this.gelStateMachine = gelStateMachine;
        }

        public void Execute()
        {
            gel.spriteSize.X = GelHelper.size;
            gel.spriteSize.Y = GelHelper.size;
            gel.velocity.X = 0;
            gel.velocity.Y = 0;

            if (gelStateMachine.currentState != GelStateMachine.CurrentState.dying)
            {
                gelStateMachine.currentState = GelStateMachine.CurrentState.dying;
                gel.mySprite = gelSpriteFactory.SpawnGel();
                gel.game.collisionManager.collisionEntities.Remove(gel);
                gel.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
