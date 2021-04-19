using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus.AquamentusScripts
{
    public class AquamentusMoving : ICommand
    {
        private EnemyAquamentus aquamentus { get; set; }
        private AquamentusSpriteFactory aquaSpriteFactory { get; set; }
        private AquamentusStateMachine aquaStateMachine { get; set; }
        public AquamentusMoving(EnemyAquamentus aquamentus, AquamentusSpriteFactory aquamentusSpriteFactory, AquamentusStateMachine aquamentusStateMachine)
        {
            this.aquamentus = aquamentus;
            this.aquaSpriteFactory = aquamentusSpriteFactory;
            this.aquaStateMachine = aquamentusStateMachine;
        }

        public void Execute()
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;

            switch (aquaStateMachine.direction)
            {
                case AquamentusStateMachine.Direction.right:
                    if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.movingRight)
                    {
                        aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.movingRight;
                        aquamentus.velocity.X = 1;
                        aquamentus.velocity.Y = 0;
                        aquamentus.mySprite = aquaSpriteFactory.AquamentusMovingRight();
                    }
                    break;
                case AquamentusStateMachine.Direction.left:
                    if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.movingLeft)
                    {
                        aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.movingLeft;
                        aquamentus.velocity.X = -1;
                        aquamentus.velocity.Y = 0;
                        aquamentus.mySprite = aquaSpriteFactory.AquamentusMovingLeft();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
