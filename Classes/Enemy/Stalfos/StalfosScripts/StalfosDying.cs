using CSE3902_Game_Sprint0.Classes._21._2._13;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Stalfos.StalfosScripts
{
    public class StalfosDying : ICommand
    {
        private EnemyStalfos stalfos { get; set; }
        private StalfosSpriteFactory spriteFactory { get; set; }
        private StalfosStateMachine stalfosStateMachine { get; set; }

        public StalfosDying(EnemyStalfos stalfos, StalfosSpriteFactory spriteFactory, StalfosStateMachine stalfosStateMachine)
        {
            this.stalfos = stalfos;
            this.spriteFactory = spriteFactory;
            this.stalfosStateMachine = stalfosStateMachine;
        }

        public void Execute()
        {
            stalfos.spriteSize.X = StalfosHelper.size;
            stalfos.spriteSize.Y = StalfosHelper.size;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = 0;

            if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.dying)
            {
                stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.dying;
                stalfos.mySprite = spriteFactory.SpawnStalfos();
                stalfos.game.collisionManager.collisionEntities.Remove(stalfos);
                stalfos.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
