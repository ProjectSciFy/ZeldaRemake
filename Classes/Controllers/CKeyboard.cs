using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0
{
    public class CKeyboard : IController
    {
        Dictionary<Keys, ICommand> keyBinds = new Dictionary<Keys, ICommand>();

        public CKeyboard(EeveeSim game)
        {
            keyBinds.Add(Keys.D0, new ShutDownGame(game));
            keyBinds.Add(Keys.D1, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2)), new Vector2(0, 0), new Rectangle(21, 0, 21, 24), Color.White, new Vector2 (1, 1)));
            keyBinds.Add(Keys.D2, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (22 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(0, 0), new Rectangle(75, 70, 22, 21), Color.White, new Vector2(1, 3)));
            keyBinds.Add(Keys.D3, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, new Vector2(1, 1)));
            keyBinds.Add(Keys.D4, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, new Vector2(1, 3)));
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();

            Keys[] pressedKeys = keyState.GetPressedKeys();

            for (int i = 0; i < pressedKeys.Length; i++)
            {
                if (keyBinds.ContainsKey(pressedKeys[i]))
                {
                    keyBinds[pressedKeys[i]].Execute();
                }
            }
        }
    }
}
