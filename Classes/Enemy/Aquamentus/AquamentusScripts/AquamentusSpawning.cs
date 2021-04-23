namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus.AquamentusScripts
{
    public class AquamentusSpawning : ICommand
    {
        private EnemyAquamentus aquamentus { get; set; }
        private AquamentusSpriteFactory aquaSpriteFactory { get; set; }
        private AquamentusStateMachine aquaStateMachine { get; set; }
        public AquamentusSpawning(EnemyAquamentus aquamentus, AquamentusSpriteFactory aquaSpriteFactory, AquamentusStateMachine aquaStateMachine)
        {
            this.aquamentus = aquamentus;
            this.aquaSpriteFactory = aquaSpriteFactory;
            this.aquaStateMachine = aquaStateMachine;
        }
        public void Execute()
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = 0;
            aquamentus.velocity.Y = 0;

            if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.spawning)
            {
                aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.spawning;
                aquamentus.mySprite = aquaSpriteFactory.SpawnAquamentus();
            }
        }
    }
}
