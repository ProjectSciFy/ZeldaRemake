using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Classes.Level;

namespace CSE3902_Game_Sprint0.Classes.Header
{
    public class playerHUD
    {
        //static sprites:
        private ZeldaGame game { get; set; }
        private ISprite hudSprite { get; set; }
        private ISprite primWeapSprite { get; set; }
        private ISprite secWeapSprite { get; set; }
        private ISprite gameLevelSprite { get; set; }

        //heart sprite:
        private ISprite heartSprite { get; set; }

        //XP sprites:
        private ISprite xpSprite { get; set; }
        private ISprite xpBarSprite { get; set; }
        private ISprite linkLevelSprite { get; set; }

        //counter sprites:
        private ISprite xSprite { get; set; }
        private ISprite digit { get; set; }
        private int digitOffset { get; set; }

        //background sprites:
        private ISprite top { get; set; }
        private ISprite bottom { get; set; }
        private ISprite right { get; set; }
        private ISprite left { get; set; }

        //mini-map sprites:
        private ISprite minimap { get; set; }
        private ISprite linkIndicator { get; set; }
        private ISprite boss { get; set; }

        //digit sprites for counters:
        private int keyOneDigit { get; set; }
        private int keyTenDigit { get; set; }
        private int bombOneDigit { get; set; }
        private int bombTenDigit { get; set; }
        private int yellowOneDigit { get; set; }
        private int yellowTenDigit { get; set; }
        //digit positions:
        public Vector2 digitKeyPos;
        public Vector2 digitBombPos;
        public Vector2 digitYrupPos;
        public Vector2 YellowCounterPos;
        public Vector2 BombCounterPos;
        public Vector2 KeyCounterPos; 

        private HudSpriteFactory HudFactory { get; set; }

        //general hud positions:
        public Vector2 hudPosition;
        public Vector2 primWeapPos;
        public Vector2 secWeapPos;
        public Vector2 gameLevelPos;
        public Vector2 heartPos;

        public Vector2 xpPos;
        public Vector2 xpBarPos;
        public Vector2 linkLevelPos;

        public Vector2 minimapPos;
        public Vector2 linkIndicatorPos;
        public Vector2 bossPos;

        private int heartOffset { get; set; }
        private int remainingHearts { get; set; }

        private int xpOffset { get; set; }

        public float spriteScalar { get; set; }
        public Vector2 drawLocation;

        //top left corner coordinates of HUD:
        private int X, Y;

        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory)
        {
            //general:
            this.game = game;
            spriteScalar = game.util.hudScalar;
            HudFactory = hudFactory;
            hudSprite = HudFactory.baseHud();
            primWeapSprite = HudFactory.primaryWeaponHUD();
            secWeapSprite = HudFactory.secondaryWeaponHUD();
            gameLevelSprite = HudFactory.levelHUD();
            heartSprite = HudFactory.livesHUD();
            //xp & leveling:
            //xpSprite = HudFactory.xpSegment();
            //xpBarSprite = HudFactory.xpBarOutline();
            //linkLevelSprite = HudFactory.linkLevel();

            //counters:
            xSprite = HudFactory.xHUD();
            digit = HudFactory.Digit(0);

            //background:
            top = HudFactory.top();
            bottom = HudFactory.bottom();
            right = HudFactory.right();
            left = HudFactory.left();

            //mini-map:
            minimap = HudFactory.mapHUD();
            linkIndicator = HudFactory.linkOnMap();
            boss = HudFactory.compassBoss();

            //position of top left corner of hud template is X,Y:
            X = (game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST - ParserUtility.GEN_ADJUST;
            Y = 25;
            hudPosition = new Vector2(X, Y);

            //elements of the Hud will be positioned in reference to hudPosition.X and hudPosition.Y so when Hud is moved, only X and Y need to change:
            primWeapPos = new Vector2((hudPosition.X + 456), (hudPosition.Y + 72));
            secWeapPos = new Vector2((hudPosition.X + 384),(hudPosition.Y + 72));
            gameLevelPos = new Vector2((hudPosition.X + 47), (hudPosition.Y + 24));
            heartPos = new Vector2((hudPosition.X + 528), (hudPosition.Y + 96));
            //counter related positions:
            digitKeyPos = new Vector2((hudPosition.X + 312), (hudPosition.Y + 96));
            KeyCounterPos = new Vector2((hudPosition.X + 288), (hudPosition.Y + 96));
            digitBombPos = new Vector2((hudPosition.X + 312), (hudPosition.Y + 120));
            BombCounterPos = new Vector2((hudPosition.X + 288), (hudPosition.Y + 120));
            digitYrupPos = new Vector2((hudPosition.X + 312), (hudPosition.Y + 48));
            YellowCounterPos = new Vector2((hudPosition.X + 288), (hudPosition.Y + 48));
            //xp & leveling:
            


            //mini-map positions:
            minimapPos = new Vector2((hudPosition.X + 60), (hudPosition.Y + 60));
            bossPos = new Vector2(minimapPos.X + 105, minimapPos.Y + 12);
            //makes it so the link indicator does not show on screen until mainstate is achieved:
            linkIndicatorPos = new Vector2(-30, -15);
        }

        public void Update()
        {
            //responds to currently selected secondary weapon:
            secWeapSprite = HudFactory.secondaryWeaponHUD();

            //link on map correspondence:
            switch (game.util.roomNumber)
            {
                case 1:
                    linkIndicatorPos.X = minimapPos.X + 33; 
                    linkIndicatorPos.Y = minimapPos.Y + 60;
                    break;
                case 2:
                    linkIndicatorPos.X = minimapPos.X + 57;
                    linkIndicatorPos.Y = minimapPos.Y + 60;
                    break;
                case 3:
                    linkIndicatorPos.X = minimapPos.X + 81;
                    linkIndicatorPos.Y = minimapPos.Y + 60;
                    break;
                case 4:
                    linkIndicatorPos.X = minimapPos.X + 57;
                    linkIndicatorPos.Y = minimapPos.Y + 48;
                    break;
                case 5:
                    linkIndicatorPos.X = minimapPos.X + 33;
                    linkIndicatorPos.Y = minimapPos.Y + 36;
                    break;
                case 6:
                    linkIndicatorPos.X = minimapPos.X + 57;
                    linkIndicatorPos.Y = minimapPos.Y + 36;
                    break;
                case 7:
                    linkIndicatorPos.X = minimapPos.X + 81;
                    linkIndicatorPos.Y = minimapPos.Y + 36;
                    break;
                case 8:
                    linkIndicatorPos.X = minimapPos.X + 9;
                    linkIndicatorPos.Y = minimapPos.Y + 24;
                    break;
                case 9:
                    linkIndicatorPos.X = minimapPos.X + 33;
                    linkIndicatorPos.Y = minimapPos.Y + 24;
                    break;
                case 10:
                    linkIndicatorPos.X = minimapPos.X + 57;
                    linkIndicatorPos.Y = minimapPos.Y + 24;
                    break;
                case 11:
                    linkIndicatorPos.X = minimapPos.X + 81;
                    linkIndicatorPos.Y = minimapPos.Y + 24;
                    break;
                case 12:
                    linkIndicatorPos.X = minimapPos.X + 105;
                    linkIndicatorPos.Y = minimapPos.Y + 24;
                    break;
                case 13:
                    linkIndicatorPos.X = minimapPos.X + 57;
                    linkIndicatorPos.Y = minimapPos.Y + 12;
                    break;
                case 14:
                    //aquamentus "boss" room:
                    linkIndicatorPos.X = minimapPos.X + 105;
                    linkIndicatorPos.Y = minimapPos.Y + 12;
                    break;
                case 15:
                    linkIndicatorPos.X = minimapPos.X + 129;
                    linkIndicatorPos.Y = minimapPos.Y + 12;
                    break;
                case 17:
                    linkIndicatorPos.X = minimapPos.X + 33;
                    linkIndicatorPos.Y = minimapPos.Y;
                    break;
                case 18:
                    linkIndicatorPos.X = minimapPos.X + 57;
                    linkIndicatorPos.Y = minimapPos.Y;
                    break;
            }
        }

        public void Draw()
        {
            float windowWidthFloor = (game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            float windowHeightFloor = ((game.GraphicsDevice.Viewport.Height / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST - ParserUtility.GEN_ADJUST;

            //background displays:
            top.Draw(new Vector2(hudPosition.X, 0));
            bottom.Draw(new Vector2(hudPosition.X, windowHeightFloor + 530));
            right.Draw(new Vector2(windowWidthFloor + 768, windowHeightFloor));
            left.Draw(new Vector2(0, windowHeightFloor));

            //static displays:
            hudSprite.Draw(hudPosition);
            primWeapSprite.Draw(primWeapPos);
            secWeapSprite.Draw(secWeapPos);
            xSprite.Draw(KeyCounterPos);
            xSprite.Draw(YellowCounterPos);
            xSprite.Draw(BombCounterPos);
            gameLevelSprite.Draw(gameLevelPos);

            //Lives Graphical Displays:

            //Hearts/Lives:
            if (game.util.numLives > 16)
            {
                game.util.numLives = 16;
            }
            if (game.util.numLives < 9)
            {
                for (int i = 0; i < game.util.numLives; i++)
                {
                    heartOffset = (i) * (24);
                    heartSprite.Draw(new Vector2(heartPos.X + heartOffset, heartPos.Y));
                }
            }
            else
            {
                //1st row:
                for (int i = 0; i < 8; i++)
                {
                    heartOffset = (i) * (24);
                    heartSprite.Draw(new Vector2(heartPos.X + heartOffset, heartPos.Y));
                }
                //2nd row:
                remainingHearts = game.util.numLives - 8;
                for (int i = 0; i < remainingHearts; i++)
                {
                    heartOffset = (i) * (24);
                    heartSprite.Draw(new Vector2(heartPos.X + heartOffset, heartPos.Y + 24));
                }
            }
            //-----------------------------------------------------------
            //Keys:
            if (game.util.numKeys > 99)
            {
                game.util.numKeys = 99;
            }
            //digits:
            keyOneDigit = game.util.numKeys % 10;
            keyTenDigit = (game.util.numKeys - keyOneDigit) / 10;
            //tens place:
            digitOffset = keyTenDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(digitKeyPos);
            //ones place:
            digitOffset = keyOneDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(new Vector2(digitKeyPos.X + 24, digitKeyPos.Y));

            //---------------------------------------------------------
            //Bombs:
            if (game.util.numBombs > 99)
            {
                game.util.numBombs = 99;
            }
            //digits:
            bombOneDigit = game.util.numBombs % 10;
            bombTenDigit = (game.util.numBombs - bombOneDigit) / 10;
            //tens place:
            digitOffset = bombTenDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(digitBombPos);
            //ones place:
            digitOffset = bombOneDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(new Vector2(digitBombPos.X + 24, digitBombPos.Y));

            //-----------------------------------------------------------
            //Yellow Rupees:
            if (game.util.numYrups > 99)
            {
                game.util.numYrups = 99;
            }
            //digits:
            yellowOneDigit = game.util.numYrups % 10;
            yellowTenDigit = (game.util.numYrups - yellowOneDigit) / 10;
            //tens place:
            digitOffset = yellowTenDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(digitYrupPos);
            //ones place:
            digitOffset = yellowOneDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(new Vector2(digitYrupPos.X + 24, digitYrupPos.Y));
            //----------------------------------------------------------
            //mini-map & link indicator
            if (game.util.hasMap)
            {
                minimap.Draw(minimapPos);
            }
            linkIndicator.Draw(linkIndicatorPos);
            //---------------------------------------------------------
            //compass showing location of aquamentus:
            if (game.util.hasCompass)
            {
                boss.Draw(bossPos);
            }
            //--------------------------------------------------------------------------------
            //xp & level graphics
            //Hearts/Lives:

            //linkLevel.Draw(linkLevelPos);

            //if (game.util.numXP < 10)
            //{
            //    for (int i = 0; i < game.util.numXP; i++)
            //    {
            //        xpOffset = (i) * (24);
            //        xpSprite.Draw(new Vector2(xpPos.X + xpOffset, xpPos.Y));
            //    }
            //}
            //-------------------------------------------------------------------------------
        }
    }
}
