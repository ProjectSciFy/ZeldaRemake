using CSE3902_Game_Sprint0.Classes.Projectiles;
using Microsoft.Xna.Framework;

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

            roshiState.timer = 60;
            roshiState.moving = false;
            roshiState.attackTimer--;
            Vector2 trajectory = Vector2.Multiply(Vector2.Normalize(Vector2.Subtract(roshi.game.link.drawLocation, Vector2.Add(roshi.drawLocation, new Vector2(40 * 3, 5 * 3)))), new Vector2(20, 20));
            roshiState.kiBlast = new KiBlast(roshi.game, roshi, roshiState, trajectory);
            roshi.game.projectileHandler.Add(roshiState.kiBlast);

            if (roshiState.currentState != RoshiStateMachine.CurrentState.kiBlast)
            {
                roshiState.currentState = RoshiStateMachine.CurrentState.kiBlast;
                roshi.mySprite = spriteFactory.RoshiKiBlast();
            }

        }
    }
}
