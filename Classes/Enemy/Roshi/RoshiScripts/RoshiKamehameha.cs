using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiKamehameha : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiKamehameha(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
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

            if (roshiState.currentState != RoshiStateMachine.CurrentState.kamehameha)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.kamehameha;
                roshi.mySprite = spriteFactory.RoshiKamehameha();
            }

        }
    }
}
