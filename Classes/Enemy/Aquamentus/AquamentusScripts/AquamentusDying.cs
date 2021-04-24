namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus.AquamentusScripts
{
    public class AquamentusDying : ICommand
    {
        private EnemyAquamentus aquamentus { get; set; }
        private AquamentusSpriteFactory aquaSpriteFactory { get; set; }
        private AquamentusStateMachine aquaStateMachine { get; set; }
        public AquamentusDying(EnemyAquamentus aquamentus, AquamentusSpriteFactory aquaSpriteFactory, AquamentusStateMachine aquaStateMachine)
        {
            this.aquamentus = aquamentus;
            this.aquaSpriteFactory = aquaSpriteFactory;
            this.aquaStateMachine = aquaStateMachine;
        }
        public void Execute()
        {
            aquamentus.spriteSize.X = AquamentusHelper.xsize;
            aquamentus.spriteSize.Y = AquamentusHelper.ysize;
            aquamentus.velocity.X = 0;
            aquamentus.velocity.Y = 0;

            if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.dying)
            {
                aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.dying;
                aquamentus.mySprite = aquaSpriteFactory.SpawnAquamentus();
                aquamentus.game.collisionManager.collisionEntities.Remove(aquamentus);
                aquamentus.game.sounds["enemyDie"].CreateInstance().Play();
            }
        }
    }
}
