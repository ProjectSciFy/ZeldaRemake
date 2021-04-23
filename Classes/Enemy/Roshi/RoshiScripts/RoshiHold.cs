using CSE3902_Game_Sprint0.Classes.Projectiles;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiHold : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiHold(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
        {
            this.roshi = roshi;
            this.spriteFactory = spriteFactory;
            this.roshiState = roshiState;
        }

        public void Execute()
        {
            roshi.spriteSize.X = 44;
            roshi.spriteSize.Y = 45;
            roshi.velocity.X = 0;
            roshi.velocity.Y = 0;
            if (roshiState.currentState != RoshiStateMachine.CurrentState.hold)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.hold;
                roshi.mySprite = spriteFactory.RoshiThrow();
            }
        }
    }
}
