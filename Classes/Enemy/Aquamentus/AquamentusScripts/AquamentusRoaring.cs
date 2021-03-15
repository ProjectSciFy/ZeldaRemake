using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus.AquamentusScripts
{
    public class AquamentusRoaring : ICommand
    {
        private EnemyAquamentus aquamentus;
        private AquamentusSpriteFactory aquaSpriteFactory;
        private AquamentusStateMachine aquaStateMachine;
        public AquamentusRoaring(EnemyAquamentus aquamentus, AquamentusSpriteFactory aquamentusSpriteFactory, AquamentusStateMachine aquamentusStateMachine)
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
                        aquamentus.velocity.X = 2;
                        aquamentus.velocity.Y = 0;
                        aquamentus.mySprite = aquaSpriteFactory.AquamentusRoaringRight();
                    }
                    break;
                case AquamentusStateMachine.Direction.left:
                    if (aquaStateMachine.currentState != AquamentusStateMachine.CurrentState.movingLeft)
                    {
                        aquaStateMachine.currentState = AquamentusStateMachine.CurrentState.movingLeft;
                        aquamentus.velocity.X = -2;
                        aquamentus.velocity.Y = 0;
                        aquamentus.mySprite = aquaSpriteFactory.AquamentusRoaringLeft();
                    }
                    break;
                default:
                    break;
            }

        }
    }
}

