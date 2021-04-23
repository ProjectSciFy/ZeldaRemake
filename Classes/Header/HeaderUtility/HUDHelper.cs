using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header.HeaderUtility;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Header.HeaderUtility
{
    public class HUDHelper
    {
        public HUDStorage storage { get; set; }
        public HudSpriteFactory HudFactory { get; set; }
        private ZeldaGame game;

        private int heartOffset;
        private ISprite heartSprite { get; set; }
        private ISprite minimap { get; set; }
        private ISprite linkIndicator { get; set; }
        private ISprite boss { get; set; }

        private ISprite linkLevelDigit { get; set; }

        private int digitOffset;
        private int linkLevelOffset;
        private int xpOffset;
        private int xpCount;
        private ISprite xpSprite { get; set; }
        private ISprite digit { get; set; }
        private int keyOneDigit { get; set; }
        private int keyTenDigit { get; set; }
        private int bombOneDigit { get; set; }
        private int bombTenDigit { get; set; }
        private int yellowOneDigit { get; set; }
        private int yellowTenDigit { get; set; }
        public HUDHelper(ZeldaGame game)
        {
            this.game = game;
            storage = new HUDStorage(game);
            HudFactory = game.hudSpriteFactory;

            heartSprite = HudFactory.livesHUD();
            digit = HudFactory.Digit(storage.zero);
            minimap = HudFactory.mapHUD();
            linkIndicator = HudFactory.linkOnMap();
            boss = HudFactory.compassBoss();

            linkLevelOffset = game.util.linkXPlevel;
            linkLevelDigit = HudFactory.Digit(linkLevelOffset);

            xpSprite = HudFactory.xpSegment();
        }
        public void minimapCorrespondence()
        {
            switch (game.util.roomNumber)
            {
                case 1:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomOne;
                    break;
                case 2:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomTwo;
                    break;
                case 3:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomThree;
                    break;
                case 4:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomFour;
                    break;
                case 5:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomFive;
                    break;
                case 6:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomSix;
                    break;
                case 7:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomSeven;
                    break;
                case 8:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomEight;
                    break;
                case 9:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomNine;
                    break;
                case 10:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomTen;
                    break;
                case 11:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomEleven;
                    break;
                case 12:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomTwelve;
                    break;
                case 13:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomThirteen;
                    break;
                case 14:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomFourteen;
                    break;
                case 15:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomFifteen;
                    break;
                case 17:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomSeventeen;
                    break;
                case 18:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomEighteen;
                    break;
                case 19:
                    game.currentRoom.pHUD.linkIndicatorPos = storage.RoomNineteen;
                    break;
            }
        }
        public void DisplayHeartSystem()
        {
            //Hearts/Lives:
            if (game.util.numLives > game.util.MAX_LIVES)
            {
                game.util.numLives = game.util.MAX_LIVES;
            }
            if (game.util.numLives <= game.util.HALF_MAX_LIVES)
            {
                for (int i = 0; i < game.util.numLives; i++)
                {
                    heartOffset = i * storage.heartBuffer;
                    heartSprite.Draw(new Vector2(game.currentRoom.pHUD.heartPos.X + heartOffset, game.currentRoom.pHUD.heartPos.Y));
                }
            }
            else
            {
                //1st row:
                for (int i = 0; i < game.util.HALF_MAX_LIVES; i++)
                {
                    heartOffset = i * storage.heartBuffer;
                    heartSprite.Draw(new Vector2(game.currentRoom.pHUD.heartPos.X + heartOffset, game.currentRoom.pHUD.heartPos.Y));
                }
                //2nd row:
                storage.remainingHearts = game.util.numLives - game.util.HALF_MAX_LIVES;
                for (int i = 0; i < storage.remainingHearts; i++)
                {
                    heartOffset = i * storage.heartBuffer;
                    heartSprite.Draw(new Vector2(game.currentRoom.pHUD.heartPos.X + heartOffset, game.currentRoom.pHUD.heartPos.Y + storage.heartBuffer));
                }
            }
        }
        public void DisplayKeySystem()
        {
            if (game.util.numKeys > game.util.MAX_KEYS)
            {
                game.util.numKeys = game.util.MAX_KEYS;
            }
            //digits:
            keyOneDigit = game.util.numKeys % storage.ten;
            keyTenDigit = (game.util.numKeys - keyOneDigit) / storage.ten;
            //tens place:
            digitOffset = keyTenDigit * storage.digitBuffer;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(game.currentRoom.pHUD.digitKeyPos);
            //ones place:
            digitOffset = keyOneDigit * storage.digitBuffer;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(new Vector2(game.currentRoom.pHUD.digitKeyPos.X + storage.secondDigitBuffer, game.currentRoom.pHUD.digitKeyPos.Y));
        }
        public void DisplayRupSystem()
        {
            if (game.util.numYrups > game.util.MAX_RUPS)
            {
                game.util.numYrups = game.util.MAX_RUPS;
            }
            //digits:
            yellowOneDigit = game.util.numYrups % storage.ten;
            yellowTenDigit = (game.util.numYrups - yellowOneDigit) / storage.ten;
            //tens place:
            digitOffset = yellowTenDigit * storage.digitBuffer;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(game.currentRoom.pHUD.digitYrupPos);
            //ones place:
            digitOffset = yellowOneDigit * storage.digitBuffer;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(new Vector2(game.currentRoom.pHUD.digitYrupPos.X + storage.secondDigitBuffer, game.currentRoom.pHUD.digitYrupPos.Y));
        }
        public void DisplayBombSystem()
        {
            if (game.util.numBombs > game.util.MAX_BOMBS)
            {
                game.util.numBombs = game.util.MAX_BOMBS;
            }
            //digits:
            bombOneDigit = game.util.numBombs % storage.ten;
            bombTenDigit = (game.util.numBombs - bombOneDigit) / storage.ten;
            //tens place:
            digitOffset = bombTenDigit * storage.digitBuffer;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(game.currentRoom.pHUD.digitBombPos);
            //ones place:
            digitOffset = bombOneDigit * storage.digitBuffer;
            digit = HudFactory.Digit(digitOffset);
            digit.Draw(new Vector2(game.currentRoom.pHUD.digitBombPos.X + storage.secondDigitBuffer, game.currentRoom.pHUD.digitBombPos.Y));
        }
        public void DisplayMiniMap()
        {
            //mini-map & link indicator & compass & boss indicator
            if (game.util.hasMap)
            {
                minimap.Draw(game.currentRoom.pHUD.minimapPos);
            }
            linkIndicator.Draw(game.currentRoom.pHUD.linkIndicatorPos);
            //---------------------------------------------------------
            //compass showing location of aquamentus:
            if (game.util.hasCompass)
            {
                boss.Draw(game.currentRoom.pHUD.bossPos);
            }
        }
        public void DisplayXPSystem(int xpC)
        {
            xpCount = xpC;
            //xp & level graphics
            linkLevelOffset = game.util.linkXPlevel * storage.digitBuffer;
            linkLevelDigit = HudFactory.Digit(linkLevelOffset);
            linkLevelDigit.Draw(game.currentRoom.pHUD.linkLevelPos);
            //xp loop:
            for (int i = 0; i < xpCount; i++)
            {
                xpOffset = i * storage.xpBuffer;
                xpSprite.Draw(new Vector2(game.currentRoom.pHUD.xpPos.X, game.currentRoom.pHUD.xpPos.Y - xpOffset));
            }
        }
    }
}
