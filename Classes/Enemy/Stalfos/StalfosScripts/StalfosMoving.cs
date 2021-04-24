using CSE3902_Game_Sprint0.Classes._21._2._13;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Stalfos.StalfosScripts
{
    public class StalfosMoving : ICommand
    {
        private EnemyStalfos stalfos { get; set; }
        private StalfosSpriteFactory stalfosSpriteFactory { get; set; }
        private StalfosStateMachine stalfosStateMachine { get; set; }
        public StalfosMoving(EnemyStalfos stalfos, StalfosSpriteFactory stalfosSpriteFactory, StalfosStateMachine stalfosStateMachine)
        {
            this.stalfos = stalfos;
            this.stalfosSpriteFactory = stalfosSpriteFactory;
            this.stalfosStateMachine = stalfosStateMachine;
        }

        public void Execute()
        {
            stalfos.spriteSize.X = StalfosHelper.size;
            stalfos.spriteSize.Y = StalfosHelper.size;

            switch (stalfosStateMachine.direction)
            {
                case StalfosStateMachine.Direction.right:
                    if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.movingRight)
                    {
                        stalfos.velocity.X = 1;
                        stalfos.velocity.Y = 0;
                        stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.movingRight;
                        stalfos.mySprite = stalfosSpriteFactory.StalfosMovingRight();
                    }
                    break;
                case StalfosStateMachine.Direction.up:
                    if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.movingUp)
                    {
                        stalfos.velocity.X = 0;
                        stalfos.velocity.Y = StalfosHelper.nvelocity;
                        stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.movingUp;
                        stalfos.mySprite = stalfosSpriteFactory.StalfosMovingUp();
                    }
                    break;
                case StalfosStateMachine.Direction.left:
                    if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.movingLeft)
                    {
                        stalfos.velocity.X = StalfosHelper.nvelocity;
                        stalfos.velocity.Y = 0;
                        stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.movingLeft;
                        stalfos.mySprite = stalfosSpriteFactory.StalfosMovingLeft();
                    }
                    break;
                case StalfosStateMachine.Direction.down:
                    if (stalfosStateMachine.currentState != StalfosStateMachine.CurrentState.movingDown)
                    {
                        stalfos.velocity.X = 0;
                        stalfos.velocity.Y = 1;
                        stalfosStateMachine.currentState = StalfosStateMachine.CurrentState.movingDown;
                        stalfos.mySprite = stalfosSpriteFactory.StalfosMovingDown();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
