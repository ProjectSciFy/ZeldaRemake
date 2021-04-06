using CSE3902_Game_Sprint0.Classes.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Level;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class ItemSelectState : IGameState
    {
        //private ZeldaGame game;
        //private Texture2D inventorySpriteSheet;
        //private ISprite top, mid, hud;
        //private float itemDepth = 0.4f;
        //private int x, y;
        //private int counter;
        public ItemSelectState(ZeldaGame game)
        {
            //this.game = game;
            //game.spriteSheets.TryGetValue("HUD", out inventorySpriteSheet);
            //top = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(1, 11, 259, 87), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            //mid = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(164, 42, 259, 87), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            //x = game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR / ParserUtility.GEN_ADJUST - ParserUtility.GEN_ADJUST;
            //y = -186;
            //counter = 1;
        }

        void IGameState.Draw()
        {
            //game.currentRoom.Draw();
            //game.link.Draw();
            //mid.Draw(new Vector2(x, y));
            //top.Draw(new Vector2(x, y - 87 * 3));
        }

        void IGameState.Update()
        {
            //if (!game.util.finishSelecting)
            //{
            //    if (y == -186 && counter > 1)
            //    {
            //        game.util.finishSelecting = true; 
            //        counter = 1;
            //    }
            //    if (counter < 186)
            //    {
            //        y += game.util.selectSpeed;
            //        counter++;
            //    }
            //    else if (counter > 186)
            //    {
            //        y -= game.util.selectSpeed;
            //        counter++;
            //    }
            //}
        }
        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
