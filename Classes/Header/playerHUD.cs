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
        private ZeldaGame game;
        private ISprite hudSprite;
        private ISprite primWeapSprite;
        private ISprite secWeapSprite;
        private ISprite levelSprite;

        //heart sprite:
        private ISprite heartSprite;

        //counter sprites:
        private ISprite xSprite;
        private ISprite digit;
        private int digitOffset;

        //background sprites:
        private ISprite top;
        private ISprite bottom;
        private ISprite right;
        private ISprite left;

        //mini-map sprites:
        private ISprite minimap;
        private ISprite linkIndicator;
        private ISprite boss;

        //digit sprites for counters:
        private int keyOneDigit;
        private int keyTenDigit;
        private int blueOneDigit;
        private int blueTenDigit;
        private int yellowOneDigit;
        private int yellowTenDigit;
        //digit positions:
        public Vector2 digitKeyPos;
        public Vector2 digitBrupPos;
        public Vector2 digitYrupPos;
        public Vector2 YellowCounterPos;
        public Vector2 BlueCounterPos;
        public Vector2 KeyCounterPos;

        private HudSpriteFactory HudFactory;

        //general hud positions:
        public Vector2 hudPosition;
        public Vector2 primWeapPos;
        public Vector2 secWeapPos;
        public Vector2 levelPos;
        public Vector2 heartPos;
        public Vector2 minimapPos;
        public Vector2 linkIndicatorPos;
        public Vector2 bossPos;

        private int heartOffset;
        private int remainingHearts;

        public float spriteScalar;
        public Vector2 drawLocation;

        //top left corner coordinates of HUD:
        private int X, Y;

        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory)
        {
            //general:
            this.game = game;
            this.spriteScalar = game.util.hudScalar;
            this.HudFactory = hudFactory;
            this.hudSprite = HudFactory.baseHud();
            this.primWeapSprite = HudFactory.primaryWeaponHUD();
            this.secWeapSprite = HudFactory.secondaryWeaponHUD();
            this.levelSprite = HudFactory.levelHUD();
            this.heartSprite = HudFactory.livesHUD();

            //counters:
            this.xSprite = HudFactory.xHUD();
            this.digit = HudFactory.Digit(0);

            //background:
            this.top = HudFactory.top();
            this.bottom = HudFactory.bottom();
            this.right = HudFactory.right();
            this.left = HudFactory.left();

            //mini-map:
            this.minimap = HudFactory.mapHUD();
            this.linkIndicator = HudFactory.linkOnMap();
            this.boss = HudFactory.compassBoss();

            //position of top left corner of hud template is X,Y:
            X = (game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST - ParserUtility.GEN_ADJUST;
            Y = 25;
            this.hudPosition = new Vector2(X, Y);

            //elements of the Hud will be positioned in reference to hudPosition.X and hudPosition.Y so when Hud is moved, only X and Y need to change:
            this.primWeapPos = new Vector2((hudPosition.X + 456), (hudPosition.Y + 72));
            this.secWeapPos = new Vector2((hudPosition.X + 384),(hudPosition.Y + 72));
            this.levelPos = new Vector2((hudPosition.X + 47), (hudPosition.Y + 24));
            this.heartPos = new Vector2((hudPosition.X + 528), (hudPosition.Y + 96));
            //counter related positions:
            this.digitKeyPos = new Vector2((hudPosition.X + 312), (hudPosition.Y + 96));
            this.KeyCounterPos = new Vector2((hudPosition.X + 288), (hudPosition.Y + 96));
            this.digitBrupPos = new Vector2((hudPosition.X + 312), (hudPosition.Y + 120));
            this.BlueCounterPos = new Vector2((hudPosition.X + 288), (hudPosition.Y + 120));
            this.digitYrupPos = new Vector2((hudPosition.X + 312), (hudPosition.Y + 48));
            this.YellowCounterPos = new Vector2((hudPosition.X + 288), (hudPosition.Y + 48));
            //mini-map positions:
            this.minimapPos = new Vector2((hudPosition.X + 60), (hudPosition.Y + 60));
            this.bossPos = new Vector2(minimapPos.X + 105, minimapPos.Y + 12);
            //makes it so the link indicator does not show on screen until mainstate is achieved:
            this.linkIndicatorPos = new Vector2((-30), (-15));
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
                case 16:
                    linkIndicatorPos.X = minimapPos.X + 57;
                    linkIndicatorPos.Y = minimapPos.Y;
                    break;
                case 17:
                    linkIndicatorPos.X = minimapPos.X + 33;
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
            levelSprite.Draw(levelPos);
            xSprite.Draw(KeyCounterPos);
            xSprite.Draw(YellowCounterPos);
            xSprite.Draw(BlueCounterPos);

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
            //Blue Rupees:
            if (game.util.numBrups > 99)
            {
                game.util.numBrups = 99;
            }
            //digits:
            blueOneDigit = game.util.numBrups % 10;
            blueTenDigit = (game.util.numBrups - blueOneDigit) / 10;
            //tens place:
            digitOffset = blueTenDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(digitBrupPos);
            //ones place:
            digitOffset = blueOneDigit * 9;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(new Vector2(digitBrupPos.X + 24, digitBrupPos.Y));

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
            if (this.game.util.hasMap)
            {
                minimap.Draw(minimapPos);
                if (this.game.util.linkInd)
                {
                    linkIndicator.Draw(linkIndicatorPos);
                }
            }
            else
            {
                if (this.game.util.linkInd)
                {
                    linkIndicator.Draw(linkIndicatorPos);
                }
            }
            //---------------------------------------------------------
            //compass showing location of aquamentus:
            if (this.game.util.hasCompass)
            {
                boss.Draw(bossPos);
            }
            //---------------------------------------------------------
        }

        public void SlideUp()
        {
            //draw HUD
            this.Draw();
            //update hudPosition.Y
            this.hudPosition.Y -= game.util.selectSpeed;
        }

        public void SlideDown()
        {
            //draw HUD
            this.Draw();
            //update hudPosition.Y
            this.hudPosition.Y += game.util.selectSpeed;
        }
    }
}
