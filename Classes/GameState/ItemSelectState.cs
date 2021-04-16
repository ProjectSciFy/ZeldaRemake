using CSE3902_Game_Sprint0.Classes.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework.Input;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class ItemSelectState : IGameState
    {
        private ZeldaGame game { get; set; }
        public Room currentRoom { get; set; }
        private Texture2D inventorySpriteSheet;
        private ISprite top, mid;
        private Vector2 midPos;
        private Vector2 topPos;
        private float itemDepth { get; set; } = 0.4f;
        private int x, y;

        //player hud related variables:
        private playerHUD pHUD { get; set; }
        private HudSpriteFactory hudFactory { get; set; }
        private int keyCounter { get; set; }
        private int bluerupeeCounter { get; set; }
        private int yellowrupeeCounter { get; set; }
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
            //if (game.util.upSelectSpeed < 0)
            //{
            if (!game.util.finishTransition)
            {
                if (pHUD.hudPosition.Y <= 612)
                {
                    ItemScreenPositionalUpdate(game.util.selectSpeed);
                }
                else
                {
                    //freeze graphics:
                    game.util.selectSpeed = 0;
                }
            }
            //}
            else
            {
                game.util.selectSpeed = -6;

                if (pHUD.hudPosition.Y >= 25)
                {
                    ItemScreenPositionalUpdate(game.util.selectSpeed);
                }
                else
                {
                    //freeze graphics and go back to main game state:
                    game.util.selectSpeed = 0;
                    //set itemScreen flag to false so currentGameState goes back to mainGameState.
                    //game.itemScreen = false;
                }
            }

        }
        void IGameState.UpdateCollisions()
        {
            
        }

        void ItemScreenPositionalUpdate(int speed)
        {
            //hud update:
            pHUD.hudPosition.Y += speed;
            pHUD.YellowCounterPos.Y += speed;
            pHUD.BlueCounterPos.Y += speed;
            pHUD.KeyCounterPos.Y += speed;
            pHUD.digitKeyPos.Y += speed;
            pHUD.digitBrupPos.Y += speed;
            pHUD.digitYrupPos.Y += speed;
            pHUD.primWeapPos.Y += speed;
            pHUD.secWeapPos.Y += speed;
            pHUD.heartPos.Y += speed;
            //sprite for "Level 1" text is apart of hudPosition.Y, no need to update it manually.
            pHUD.minimapPos.Y += speed;
            //pHUD.linkIndicatorPos.Y += speed; (will be tedious because I was using portions of screen that window does not see to hide the link indicator between transitions.
            pHUD.levelPos.Y += speed;
            //item screen update:
            midPos.Y += speed;
            topPos.Y += speed;
        }
    }
}
