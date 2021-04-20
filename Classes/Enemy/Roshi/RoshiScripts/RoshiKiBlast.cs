using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiKiBlast : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiKiBlast(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
        {
            this.roshi = roshi;
            this.spriteFactory = spriteFactory;
            this.roshiState = roshiState;
        }

        public void Execute()
        {
            roshi.spriteSize.X = 43;
            roshi.spriteSize.Y = 41;
            roshi.velocity.X = 0;
            roshi.velocity.Y = 0;

            if (roshiState.currentState != RoshiStateMachine.CurrentState.kiBlast)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.kiBlast;
                roshi.mySprite = spriteFactory.RoshiKiBlast();
            }

        }
    }
}
