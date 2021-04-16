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
        private Vector2 midPos;
        private Vector2 topPos;
        private float itemDepth = 0.4f;
        private int x, y;

        //player hud related variables:
        private playerHUD pHUD;
        private HudSpriteFactory hudFactory;
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
            midPos = new Vector2(x, y);
            topPos = new Vector2(x, y - 87 * 3);

            //player HUD:
            this.keyCounter = game.util.numKeys;
            this.bluerupeeCounter = game.util.numBrups;
            this.yellowrupeeCounter = game.util.numYrups;
            this.hudFactory = game.hudSpriteFactory;
            pHUD = new playerHUD(game, hudFactory);
        }

        void IGameState.Draw()
        {
            game.currentRoom.Draw();
            game.link.Draw();
            mid.Draw(midPos);
            top.Draw(topPos);
            pHUD.Draw();
        }

        void IGameState.Update()
        {
            if (game.util.itemSelectSpeed < 0)
            {
                if (pHUD.hudPosition.Y == 25)
                {
                    game.util.selectSpeed = 6;
                } 
                else
                {
                    pHUD.hudPosition.Y += game.util.itemSelectSpeed;
                    midPos.Y += game.util.itemSelectSpeed;
                    topPos.Y += game.util.itemSelectSpeed;
                }
            }
            else
            {
                if (pHUD.hudPosition.Y >= 612)
                {
                    game.util.selectSpeed = -6;
                }
                else
                {
                    pHUD.hudPosition.Y += game.util.itemSelectSpeed;
                    midPos.Y += game.util.itemSelectSpeed;
                    topPos.Y += game.util.itemSelectSpeed;
                }
            }

        }
        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
