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
        private ISprite halfheartSprite;
        private ISprite emptyheartSprite;

        //counter sprites:
        private ISprite xSprite;
        private ISprite digit;
        private int digitOffset;

        //background
        private ISprite top;
        private ISprite bottom;
        private ISprite right;
        private ISprite left;

        private int keyOneDigit;
        private int keyTenDigit;
        private int blueOneDigit;
        private int blueTenDigit;
        private int yellowOneDigit;
        private int yellowTenDigit;
        public Vector2 digitKeyPos;
        public Vector2 digitBrupPos;
        public Vector2 digitYrupPos;


        private HudSpriteFactory HudFactory;
        public Vector2 hudPosition;
        public Vector2 primWeapPos;
        public Vector2 secWeapPos;
        public Vector2 levelPos;
        public Vector2 heartPos;

        public Vector2 YellowCounterPos;
        public Vector2 BlueCounterPos;
        public Vector2 KeyCounterPos;
        private int heartOffset;
        private int remainingHearts;

        private bool hasMap;

        public float spriteScalar;
        public Vector2 drawLocation;

        private int X, Y;
        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory)
        {
            this.game = game;
            this.spriteScalar = game.util.hudScalar;
            this.HudFactory = hudFactory;
            this.hudSprite = HudFactory.baseHud();
            this.primWeapSprite = HudFactory.primaryWeaponHUD();
            this.secWeapSprite = HudFactory.secondaryWeaponHUD();
            this.levelSprite = HudFactory.levelHUD();
            this.heartSprite = HudFactory.livesHUD();
            this.xSprite = HudFactory.xHUD();
            this.digit = HudFactory.Digit(0);
            this.top = HudFactory.top();
            this.bottom = HudFactory.bottom();
            this.right = HudFactory.right();
            this.left = HudFactory.left();

            this.hasMap = game.util.hasMap;

            //position of top left corner of hud template is X,Y:
            X = (game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST - ParserUtility.GEN_ADJUST;
            Y = 25;
            this.hudPosition = new Vector2(X, Y);
            //elements of the Hud will be positioned in reference to X and Y so when Hud is moved, only X and Y need to change:
            this.primWeapPos = new Vector2((X + 456), (Y + 72));
            this.secWeapPos = new Vector2((X + 384),(Y + 72));
            this.levelPos = new Vector2((X + 47), (Y + 24));
            this.heartPos = new Vector2((X + 528), (Y + 96));

            //keys:
            this.digitKeyPos = new Vector2((X + 312), (Y + 96));
            this.KeyCounterPos = new Vector2((X + 288), (Y + 96));
            //Blue rupees:
            this.digitBrupPos = new Vector2((X+312), (Y+120));
            this.BlueCounterPos = new Vector2((X + 288), (Y + 120));
            //Yellow rupees:
            this.digitYrupPos = new Vector2((X+312), (Y+48));
            this.YellowCounterPos = new Vector2((X + 288), (Y + 48));
        }

        public void Update()
        {
            //this is where a keystate can be accessed to either show/not show the HUD or other functionalities.
            secWeapSprite = HudFactory.secondaryWeaponHUD();
        }

        public void Draw()
        {
            float windowWidthFloor = (game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            float windowHeightFloor = ((game.GraphicsDevice.Viewport.Height / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST - ParserUtility.GEN_ADJUST;

            //THIS FILE NEEDS TO BE REFACTORED - I UNDERSTAND THAT IT IS WAY TOO LONG - THIS WAS JUST AN ATTEMPT
            //static displays:
            top.Draw(new Vector2(X, 0));
            bottom.Draw(new Vector2(X, windowHeightFloor + 530));
            right.Draw(new Vector2(windowWidthFloor + 768, windowHeightFloor));
            left.Draw(new Vector2(0, windowHeightFloor));
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

            //Map:
            if (hasMap)
            {
                //display map
                //display where link is on map
            }
            else
            {
                //dont display map
            }
        }


    }
}
