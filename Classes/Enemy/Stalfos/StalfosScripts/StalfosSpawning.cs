using CSE3902_Game_Sprint0.Classes._21._2._13;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Stalfos.StalfosScripts
{
    public class StalfosSpawning : ICommand
    {
        private EnemyStalfos stalfos { get; set; }
        private StalfosSpriteFactory spriteFactory { get; set; }
        private StalfosStateMachine stalfosStateMachine { get; set; }

        public StalfosSpawning(EnemyStalfos stalfos, StalfosSpriteFactory spriteFactory, StalfosStateMachine stalfosStateMachine)
        {
            this.stalfos = stalfos;
            this.spriteFactory = spriteFactory;
            this.stalfosStateMachine = stalfosStateMachine;
        }

        public void Execute()
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = 0;

            if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.spawning)
            {
                stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.spawning;
                stalfos.mySprite = spriteFactory.SpawnStalfos();
            }
        }
    }
}
