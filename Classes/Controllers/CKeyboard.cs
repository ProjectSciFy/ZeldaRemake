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
            //Change commands in future--

            //Up and W -- change direction (switch case/state machine?) and movement
            // direction added as new parameter being sent to DrawSprite:
            keyBinds.Add(Keys.Up, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2)), new Vector2(0, 0), new Rectangle(21, 0, 21, 24), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.W, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (22 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(0, 0), new Rectangle(75, 70, 22, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //Left and A
            keyBinds.Add(Keys.Left, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.A, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //Down and S
            keyBinds.Add(Keys.Down, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.S, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //Right and D
            keyBinds.Add(Keys.Right, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.D, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //Z and N -- attack and animation
            keyBinds.Add(Keys.Z, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.N, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //E -- test damage taken animation
            keyBinds.Add(Keys.E, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));

            //1, 2, 3, 4 -- change between items animation
            keyBinds.Add(Keys.D1, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.D2, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));
            keyBinds.Add(Keys.D3, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.D4, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //T and Y -- test block animation
            keyBinds.Add(Keys.T, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.Y, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //U and I -- cycle through items
            keyBinds.Add(Keys.U, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.I, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //O and P -- test other characters/NPCs animation (cycles through sprites)
            keyBinds.Add(Keys.O, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (24 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (25 / 2)), new Vector2(0, 2), new Rectangle(0, 112, 24, 25), Color.White, SpriteEffects.None, new Vector2(1, 1)));
            keyBinds.Add(Keys.P, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));

            //Q -- quit game
            keyBinds.Add(Keys.Q, new ShutDownGame(game));
            //R -- reset game to initial state
            keyBinds.Add(Keys.R, new DrawSprite(game, game.eeveeTexture, game.eeveeSprite, game.eeveeLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (25 / 2), (game.GraphicsDevice.Viewport.Bounds.Height / 2) - (21 / 2)), new Vector2(2, 0), new Rectangle(75, 48, 25, 21), Color.White, SpriteEffects.None, new Vector2(1, 3)));
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
