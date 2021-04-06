using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Controllers.GameCommands;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.Scripts;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    class DeathState : IGameState
    {
        private ZeldaGame game;
        private int timer = -1;
        private ISprite texture;
        private Texture2D gameOverSpriteSheet;
        private float itemDepth = 0.4f;
        private const int HEIGHT = 60;
        private const int WIDTH = 360;

        public DeathState(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("GameOver", out gameOverSpriteSheet);
            texture = new UniversalSprite(game, gameOverSpriteSheet, new Rectangle(36, 126, WIDTH, HEIGHT), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        void IGameState.Draw()
        {
            this.game.link.Draw();
            texture.Draw(new Vector2(game.GraphicsDevice.Viewport.Width / 3 - WIDTH, game.GraphicsDevice.Viewport.Height / 2 - HEIGHT));
        }

        void IGameState.Update()
        {
            if (timer == -1)
            {
                this.game.link.linkState.dying = true;
                //Time it takes for both animations to play out
                timer = 80 + 180;
            }
            game.link.Update();
            game.link.Draw();


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

        void IGameState.UpdateCollisions()
        {

        }
    }
}
