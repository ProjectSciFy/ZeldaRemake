using CSE3902_Game_Sprint0.Classes.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class RoshiDialogState : IGameState
    {
        private ZeldaGame game { get; set; }
        private ISprite texture { get; set; }
        private Texture2D roshiDialog;
        private float itemDepth { get; set; } = 0.4f;
        private const int HEIGHT = 53;
        private const int WIDTH = 263;
        public RoshiDialogState(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Fonts", out roshiDialog);
            texture = new UniversalSprite(game, roshiDialog, new Rectangle(301, 317, WIDTH, HEIGHT), Color.White, SpriteEffects.None, new Vector2(3, 1), 10, itemDepth);
        }

        void IGameState.Draw()
        {
            texture.Draw(new Vector2(game.GraphicsDevice.Viewport.Width / 2 - WIDTH, game.GraphicsDevice.Viewport.Height / 2 - HEIGHT));
        }
        void IGameState.Update()
        {
            texture.Update();
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
