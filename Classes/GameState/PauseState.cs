using CSE3902_Game_Sprint0.Classes.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class PauseState : IGameState
    {
        private ZeldaGame game { get; set; }
        private ISprite texture { get; set; }
        private Texture2D pausedSpriteSheet;
        private float itemDepth { get; set; } = 0.4f;
        private const int HEIGHT = 7;
        private const int WIDTH = 47;
        public PauseState(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Fonts", out pausedSpriteSheet);
            texture = new UniversalSprite(game, pausedSpriteSheet, new Rectangle(364, 283, WIDTH, HEIGHT), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
        }

        void IGameState.Draw()
        {
            texture.Draw(new Vector2(game.GraphicsDevice.Viewport.Width /2 - WIDTH, game.GraphicsDevice.Viewport.Height / 2 - HEIGHT));
        }
        void IGameState.Update()
        {
            game.controllerList[0].Update();
            game.controllerList[1].Update();
        }

        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
