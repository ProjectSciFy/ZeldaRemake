namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus.AquamentusScripts
{
    public class AquamentusRoaring : ICommand
    {
        private EnemyAquamentus aquamentus { get; set; }
        private AquamentusSpriteFactory aquaSpriteFactory { get; set; }
        private AquamentusStateMachine aquaStateMachine { get; set; }
        public AquamentusRoaring(EnemyAquamentus aquamentus, AquamentusSpriteFactory aquamentusSpriteFactory, AquamentusStateMachine aquamentusStateMachine)
        {
            this.aquamentus = aquamentus;
            this.aquaSpriteFactory = aquamentusSpriteFactory;
            this.aquaStateMachine = aquamentusStateMachine;
        }

        public void Execute()
        {
            aquamentus.spriteSize.X = AquamentusHelper.xsize;
            aquamentus.spriteSize.Y = AquamentusHelper.ysize;

            switch (aquaStateMachine.direction)
            {
                case AquamentusStateMachine.Direction.right:
                    if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.movingRight)
                    {
                        aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.movingRight;
                        aquamentus.velocity.X = AquamentusHelper.two;
                        aquamentus.velocity.Y = 0;
                        aquamentus.mySprite = aquaSpriteFactory.AquamentusRoaringRight();
                    }
                    break;
                case AquamentusStateMachine.Direction.left:
                    if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.movingLeft)
                    {
                        aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.movingLeft;
                        aquamentus.velocity.X = AquamentusHelper.minustwo;
                        aquamentus.velocity.Y = 0;
                        aquamentus.mySprite = aquaSpriteFactory.AquamentusRoaringLeft();
                    }
                    break;
                default:
                    break;
            }
            aquamentus.game.sounds["bossScream"].CreateInstance().Play();
        }
    }
}

