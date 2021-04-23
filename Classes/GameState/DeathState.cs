using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    class DeathState : IGameState
    {
        private ZeldaGame game { get; set; }
        private int timer { get; set; } = -1;
        private ISprite texture { get; set; }
        private readonly Texture2D gameOverSpriteSheet;
        private float itemDepth { get; set; } = 0.4f;
        private const int HEIGHT = 60;
        private const int WIDTH = 360;
        private const int ANIMATION_TIMER = 260;

        public DeathState(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("GameOver", out gameOverSpriteSheet);
            texture = new UniversalSprite(game, gameOverSpriteSheet, new Rectangle(36, 126, WIDTH, HEIGHT), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            this.game.link.drawLocation = new Vector2(this.game.GraphicsDevice.Viewport.Width / 2, this.game.GraphicsDevice.Viewport.Height / 2 + ParserUtility.GAME_FRAME_ADJUST);
        }

        public void Draw()
        {
            texture.Draw(new Vector2(game.GraphicsDevice.Viewport.Width / 3 - WIDTH, game.GraphicsDevice.Viewport.Height / 2 - HEIGHT));
            game.link.Draw();
        }

        public void Update()
        {
            if (timer == -1)
            {
                this.game.link.linkState.dying = true;
                //Time it takes for both animations to play out
                timer = ANIMATION_TIMER;
            }
            game.link.Update();

            if (timer > 0)
            {
                timer--;
            }

            if (timer <= 0)
            {
                new Reset(game).Execute();
                MediaPlayer.Play(game.song);
            }
        }
        public void UpdateCollisions()
        {

        }
    }
}
