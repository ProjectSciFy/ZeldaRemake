using CSE3902_Game_Sprint0.Classes.Projectiles;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts
{
    public class RoshiLift : ICommand
    {
        private EnemyRoshi roshi { get; set; }
        private RoshiSpriteFactory spriteFactory { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiLift(EnemyRoshi roshi, RoshiSpriteFactory spriteFactory, RoshiStateMachine roshiState)
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
            roshiState.spiritBomb = new SpiritBomb(roshi.game, roshi, roshiState, Vector2.Zero);
            roshi.game.projectileHandler.Add(roshiState.spiritBomb);

            if (roshiState.currentState != RoshiStateMachine.CurrentState.lift)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.lift;
                roshi.mySprite = spriteFactory.RoshiLift();
            }
        }
    }
}
