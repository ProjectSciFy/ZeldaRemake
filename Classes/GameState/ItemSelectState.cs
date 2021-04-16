using CSE3902_Game_Sprint0.Classes.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class ItemSelectState : IGameState
    {
        private ZeldaGame game;
        public Room currentRoom;
        private Texture2D inventorySpriteSheet;
        private ISprite top, mid;
        private float itemDepth = 0.4f;
        private int x, y;
        private int counter;

        //player hud related variables:
        private playerHUD pHUD;
        private HudSpriteFactory hudFactory;
        private int maxLives = 16;
        private int keyCounter;
        private int bluerupeeCounter;
        private int yellowrupeeCounter;
        public ItemSelectState(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("HUD", out inventorySpriteSheet);
            top = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(1, 11, 259, 87), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            mid = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(164, 42, 259, 87), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            x = game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR / ParserUtility.GEN_ADJUST - ParserUtility.GEN_ADJUST;
            y = -186;
            counter = 1;

            //player HUD:
            this.keyCounter = game.util.numKeys;
            this.bluerupeeCounter = game.util.numBrups;
            this.yellowrupeeCounter = game.util.numYrups;
            this.hudFactory = game.hudSpriteFactory;
            pHUD = new playerHUD(game, hudFactory);
        }

        void IGameState.Draw()
        {
            //game.currentRoom.Draw();
            //game.link.Draw();
            //mid.Draw(new Vector2(x, y));
            //top.Draw(new Vector2(x, y - 87 * 3));
            //pHUD.Draw();
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
