﻿using CSE3902_Game_Sprint0.Classes.Scripts;
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

        private float itemDepth { get; set; } = 0.4f;

        //player hud related variables:
        private playerHUD pHUD { get; set; }

        private HudSpriteFactory HudFactory { get; set; }

        private ISprite holdingMap;
        private ISprite holdingCompass;
        private ISprite secweaponHolding;
        private ISprite secweaponOne;
        private ISprite secweaponTwo;

        public ItemSelectState(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("HUD", out inventorySpriteSheet);
            HudFactory = game.hudSpriteFactory;

            top = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(1, 11, 260, 100), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            mid = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(258, 111, 260, 99), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            holdingMap=new UniversalSprite(game,inventorySpriteSheet, new Rectangle(601, 156, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            holdingCompass = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(613, 157, 13, 14), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);

            if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.bomb)
            {
                //bomb
                secweaponHolding = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(604, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
                //arrow
                secweaponOne = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(633, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
                //boomerang
                secweaponTwo = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(584, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            }
            else if (game.link.linkState.weaponSelected == LinkStateMachine.Weapon.arrow)
            {
                //arrow
                secweaponHolding = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(633, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
                //bomb
                secweaponOne = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(604, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
                //boomerang
                secweaponTwo = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(584, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            }
            else
            {
                //boomerang
                secweaponHolding = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(584, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
                //bomb
                secweaponOne = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(604, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
                //arrow
                secweaponTwo = new UniversalSprite(game, inventorySpriteSheet, new Rectangle(633, 137, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, itemDepth);
            }
                 

            //164 42 259 87
            pHUD = game.currentRoom.pHUD; 

        }

        void IGameState.Draw()
        {
            game.currentRoom.Draw();
            game.link.Draw();
            pHUD.Draw();
            mid.Draw(game.util.midPos);
            top.Draw(game.util.topPos);
            if (game.util.hasMap)
            {
               holdingMap.Draw(new Vector2(game.util.midPos.X + 142,game.util.midPos.Y+ 70));
            }
            if (game.util.hasCompass)
            {
                holdingCompass.Draw(new Vector2(game.util.midPos.X + 136, game.util.midPos.Y + 190));
            }

            secweaponHolding.Draw(new Vector2(game.util.topPos.X + 201, game.util.topPos.Y + 144));
            secweaponOne.Draw(new Vector2(game.util.topPos.X + 390, game.util.topPos.Y + 144));
            secweaponTwo.Draw(new Vector2(game.util.topPos.X + 460, game.util.topPos.Y + 144));
        }

        void IGameState.Update()
        {
            game.util.inSelect = true;
            pHUD = game.currentRoom.pHUD;
            if (game.util.selectSpeed < 0)
            {
                if (pHUD.hudPosition.Y > 25)
                {
                    ItemScreenPositionalUpdate(game.util.selectSpeed);
                }
                else
                {
                    game.currentGameState = game.currentMainGameState;
                    game.util.inSelect = false;
                }
            }
            else
            {
                if (pHUD.hudPosition.Y < 612)
                {
                    ItemScreenPositionalUpdate(game.util.selectSpeed);
                }
                else
                {
                    //dont move
                }
            }
            foreach (IController controller in game.controllerList)
            {
                controller.Update();
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
            pHUD.BombCounterPos.Y += speed;
            pHUD.KeyCounterPos.Y += speed;
            pHUD.digitKeyPos.Y += speed;
            pHUD.digitBombPos.Y += speed;
            pHUD.digitYrupPos.Y += speed;
            pHUD.primWeapPos.Y += speed;
            pHUD.secWeapPos.Y += speed;
            pHUD.heartPos.Y += speed;
            //sprite for "Level 1" text is apart of hudPosition.Y, no need to update it manually.
            pHUD.minimapPos.Y += speed;
            pHUD.bossPos.Y += speed;
            pHUD.gameLevelPos.Y += speed;
            pHUD.linkIndicatorPos.Y += speed;
            pHUD.xpPos.Y += speed;
            //pHUD.linkLevelPos.Y += speed;
            //item screen update:
            game.util.midPos.Y += speed;
            game.util.topPos.Y += speed;
        }
    }
}
