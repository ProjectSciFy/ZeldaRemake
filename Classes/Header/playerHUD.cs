using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

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


        public float spriteScalar;
        public Vector2 drawLocation;

        private int X, Y;
        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory)
        {
            this.game = game;
            this.spriteScalar = game.hudScalar;
            this.HudFactory = hudFactory;
            this.hudSprite = HudFactory.baseHud();
            this.primWeapSprite = HudFactory.primaryWeaponHUD();
            this.secWeapSprite = HudFactory.secondaryWeaponHUD();
            this.levelSprite = HudFactory.levelHUD();
            this.heartSprite = HudFactory.livesHUD();
            this.xSprite = HudFactory.xHUD();
            this.digit = HudFactory.Digit(0);

            //position of top left corner of hud template is X,Y:
            X = 135;
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
        }

        public void Draw()
        {
            //THIS FILE NEEDS TO BE REFACTORED - I UNDERSTAND THAT IT IS WAY TOO LONG - THIS WAS JUST AN ATTEMPT

            //static displays:
            hudSprite.Draw(hudPosition);
            primWeapSprite.Draw(primWeapPos);
            secWeapSprite.Draw(secWeapPos);
            levelSprite.Draw(levelPos);

            //counter "x" before each number:
            xSprite.Draw(KeyCounterPos);
            xSprite.Draw(YellowCounterPos);
            xSprite.Draw(BlueCounterPos);

            //Lives Graphical Displays:

            //Hearts/Lives:
            if (game.numLives < 9)
            {
                for (int i = 0; i < game.numLives; i++)
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
                remainingHearts = game.numLives - 8;
                for (int i = 0; i < remainingHearts; i++)
                {
                    heartOffset = (i) * (24);
                    heartSprite.Draw(new Vector2(heartPos.X + heartOffset, heartPos.Y + 24));
                }
            }
            //Keys:
            if (game.numKeys > 9)
            {
                //ones place:
                keyOneDigit = game.numKeys % 10;
                keyTenDigit = (game.numKeys) - (keyOneDigit * 10);
                digitOffset = keyOneDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digit.Draw(digitKeyPos);
                //tens place:
                digitOffset = keyTenDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digitKeyPos.X += 24;
                digit.Draw(digitKeyPos);
            }
            else
            {
                //ones place:
                keyOneDigit = game.numKeys % 10;
                digitOffset = keyOneDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digit.Draw(digitKeyPos);
            }
            //---------------------------------------------------------
            //Blue Rupees:
            if (game.numBrups > 9)
            {
                //ones place:
                blueOneDigit = game.numBrups % 10;
                blueTenDigit = (game.numBrups) - (blueOneDigit * 10);
                digitOffset = blueOneDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digit.Draw(digitBrupPos);
                //tens place:
                digitOffset = blueTenDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digitBrupPos.X += 24;
                digit.Draw(digitBrupPos);
            }
            else
            {
                //ones place:
                blueOneDigit = game.numBrups % 10;
                digitOffset = blueOneDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digit.Draw(digitBrupPos);
            }
            //-----------------------------------------------------------
            //Yellow Rupees:
            if (game.numYrups > 9)
            {
                //ones place:
                yellowOneDigit = game.numYrups % 10;
                yellowTenDigit = (game.numYrups) - (yellowOneDigit * 10);
                digitOffset = yellowOneDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digit.Draw(digitYrupPos);
                //tens place:
                digitOffset = yellowTenDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digitYrupPos.X += 24;
                digit.Draw(digitYrupPos);
            }
            else
            {
                //ones place:
                yellowOneDigit = game.numYrups % 10;
                digitOffset = yellowOneDigit * 8;
                digit = HudFactory.Digit(digitOffset);
                digit.Draw(digitYrupPos);
            }
        }


    }
}
