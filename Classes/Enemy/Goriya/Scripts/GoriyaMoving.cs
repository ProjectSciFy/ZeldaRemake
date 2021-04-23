using CSE3902_Game_Sprint0.Classes._21._2._13;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Goriya.Scripts
{
    public class GoriyaMoving : ICommand
    {
        private EnemyGoriya goriya { get; set; }
        private GoriyaSpriteFactory enemySpriteFactory { get; set; }
        private GoriyaStateMachine GoriyaStateMachine { get; set; }
        public GoriyaMoving(EnemyGoriya goriya, GoriyaSpriteFactory enemySpriteFactory, GoriyaStateMachine GoriyaStateMachine)
        {
            this.goriya = goriya;
            this.enemySpriteFactory = enemySpriteFactory;
            this.GoriyaStateMachine = GoriyaStateMachine;
        }
        public void Execute()
        {
            switch (GoriyaStateMachine.direction)
            {
                case GoriyaStateMachine.Direction.right:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.movingRight)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.movingRight;
                        goriya.velocity.X = 1;
                        goriya.velocity.Y = 0;
                        goriya.mySprite = enemySpriteFactory.GoriyaMovingRight();
                    }
                    break;

                case GoriyaStateMachine.Direction.up:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.movingUp)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.movingUp;
                        goriya.velocity.X = 0;
                        goriya.velocity.Y = -1;
                        goriya.mySprite = enemySpriteFactory.GoriyaMovingUp();
                    }
                    break;

                case GoriyaStateMachine.Direction.left:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.movingLeft)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.movingLeft;
                        goriya.velocity.X = -1;
                        goriya.velocity.Y = 0;
                        goriya.mySprite = enemySpriteFactory.GoriyaMovingLeft();
                    }
                    break;

                case GoriyaStateMachine.Direction.down:
                    if (GoriyaStateMachine.currentState != GoriyaStateMachine.CurrentState.movingDown)
                    {
                        GoriyaStateMachine.currentState = GoriyaStateMachine.CurrentState.movingDown;
                        goriya.velocity.X = 0;
                        goriya.velocity.Y = 1;
                        goriya.mySprite = enemySpriteFactory.GoriyaMovingDown();
                    }
                    break;

                default:
                    break;
            }
        }
    }


}