using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers
{
    class CMouse : IController
    {
        Dictionary<int, ICommand> keyBinds = new Dictionary<int, ICommand>();
        private int currentQuad;
        private EeveeSim game;

        public CMouse(EeveeSim game)
        {
            this.game = game;
            keyBinds.Add(0, new ShutDownGame(game));
            keyBinds.Add(1, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2)), new Vector2(0, 0), new Rectangle(21, 0, 21, 24), Color.White, new Vector2(1, 1)));
            keyBinds.Add(2, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (22 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(0, 0), new Rectangle(75, 70, 22, 21), Color.White, new Vector2(1, 3)));
            keyBinds.Add(3, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, new Vector2(1, 1)));
            keyBinds.Add(4, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, new Vector2(1, 3)));
            currentQuad = 1;
        }

        public void Update()
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X > game.GraphicsDevice.Viewport.Width / 2)
            {
                currentQuad++;
            }
            if (mouseState.Y > game.GraphicsDevice.Viewport.Height / 2)
            {
                currentQuad += 2;
            }

            if (mouseState.RightButton == ButtonState.Pressed)
            {
                keyBinds[0].Execute();
            }
            else if (mouseState.LeftButton == ButtonState.Pressed)
            {
                keyBinds[currentQuad].Execute();
            }

            currentQuad = 1;
        }
    }
}
