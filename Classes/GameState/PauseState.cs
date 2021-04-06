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
        private ZeldaGame game;
        private ISprite texture;
        private Texture2D pausedSpriteSheet;
        private float itemDepth = 0.4f;
        private const  HEIGHT = 7;
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
            foreach (IController controller in game.controllerList) 
            {
                controller.Update();
            }
        }

        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
