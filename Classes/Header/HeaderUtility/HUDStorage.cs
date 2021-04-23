using CSE3902_Game_Sprint0.Classes.Level;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Header.HeaderUtility
{
    public class HUDStorage
    {
        private ZeldaGame game;
        public int HUD_Main_X;
        public int HUD_Main_Y;
        public Vector2 primaryWeaponPosition;
        public Vector2 secondaryWeaponPosition;
        public Vector2 gameLevelPosition;
        public Vector2 heartPosition;
        public int remainingHearts;
        public int heartBuffer;
        public Vector2 digitKeyPosition;
        public Vector2 keyCountPosition;
        public Vector2 digitBombPosition;
        public Vector2 bombCountPosition;
        public Vector2 digitYellowRuppeePosition;
        public Vector2 yellowruppeeCountPosition;
        public int digitBuffer;
        public int secondDigitBuffer;
        public int ten;
        public int zero;
        public Vector2 xpPosition;
        public int xpBuffer;
        public Vector2 linkLevelPosition;
        public Vector2 minimapPosition;
        public Vector2 bossPosition;
        public Vector2 linkIndicatorPosition;
        public Vector2 RoomOne;
        public Vector2 RoomTwo;
        public Vector2 RoomThree;
        public Vector2 RoomFour;
        public Vector2 RoomFive;
        public Vector2 RoomSix;
        public Vector2 RoomSeven;
        public Vector2 RoomEight;
        public Vector2 RoomNine;
        public Vector2 RoomTen;
        public Vector2 RoomEleven;
        public Vector2 RoomTwelve;
        public Vector2 RoomThirteen;
        public Vector2 RoomFourteen;
        public Vector2 RoomFifteen;
        public Vector2 RoomSixteen;
        public Vector2 RoomSeventeen;
        public Vector2 RoomEighteen;
        public Vector2 RoomNineteen;
        public Vector2 topPosition;
        public Vector2 bottomPosition;
        public Vector2 rightPosition;
        public Vector2 leftPosition;
        public float windowWidthFloor;
        public float windowHeightFloor;
        public HUDStorage(ZeldaGame game)
        {
            this.game = game;
            HUD_Main_X = (game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST - ParserUtility.GEN_ADJUST;
            HUD_Main_Y = 25;
            windowWidthFloor = (game.GraphicsDevice.Viewport.Width / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_Y_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST;
            windowHeightFloor = ((game.GraphicsDevice.Viewport.Height / ParserUtility.SCALE_FACTOR - ParserUtility.WINDOW_X_ADJUST / ParserUtility.SCALE_FACTOR) / ParserUtility.GEN_ADJUST) + ParserUtility.GAME_FRAME_ADJUST - ParserUtility.GEN_ADJUST;
            topPosition = new Vector2(HUD_Main_X, 0);
            bottomPosition = new Vector2(HUD_Main_X, windowHeightFloor + 530);
            rightPosition = new Vector2(windowWidthFloor + 768, windowHeightFloor);
            leftPosition = new Vector2(0, windowHeightFloor);
            primaryWeaponPosition = new Vector2(HUD_Main_X + 456, HUD_Main_Y + 72);
            secondaryWeaponPosition = new Vector2((HUD_Main_X + 384), (HUD_Main_Y + 72));
            gameLevelPosition = new Vector2((HUD_Main_X + 47), (HUD_Main_Y + 24));
            heartPosition = new Vector2((HUD_Main_X + 516), (HUD_Main_Y + 96));
            digitKeyPosition = new Vector2((HUD_Main_X + 312), (HUD_Main_Y + 96));
            keyCountPosition = new Vector2((HUD_Main_X + 288), (HUD_Main_Y + 96));
            digitBombPosition = new Vector2((HUD_Main_X + 312), (HUD_Main_Y + 120));
            bombCountPosition = new Vector2((HUD_Main_X + 288), (HUD_Main_Y + 120));
            digitYellowRuppeePosition = new Vector2((HUD_Main_X + 312), (HUD_Main_Y + 48));
            yellowruppeeCountPosition = new Vector2((HUD_Main_X + 288), (HUD_Main_Y + 48));
            xpPosition = new Vector2(HUD_Main_X + (729), HUD_Main_Y + 121);
            linkLevelPosition = new Vector2(HUD_Main_X + (232 * 3), HUD_Main_Y + 15);
            minimapPosition = new Vector2((HUD_Main_X + 60), (HUD_Main_Y + 60));
            bossPosition = new Vector2(minimapPosition.X + 105, minimapPosition.Y + 12);
            linkIndicatorPosition = new Vector2(-30, -15);
            RoomOne = new Vector2(minimapPosition.X + 33, minimapPosition.Y + 60);
            RoomTwo = new Vector2(minimapPosition.X + 57, minimapPosition.Y + 60);
            RoomThree = new Vector2(minimapPosition.X + 81, minimapPosition.Y + 60);
            RoomFour = new Vector2(minimapPosition.X + 57, minimapPosition.Y + 48);
            RoomFive = new Vector2(minimapPosition.X + 33, minimapPosition.Y + 36);
            RoomSix = new Vector2(minimapPosition.X + 57, minimapPosition.Y + 36);
            RoomSeven = new Vector2(minimapPosition.X + 81, minimapPosition.Y + 36);
            RoomEight = new Vector2(minimapPosition.X + 9, minimapPosition.Y + 24);
            RoomNine = new Vector2(minimapPosition.X + 33, minimapPosition.Y + 24);
            RoomTen = new Vector2(minimapPosition.X + 57, minimapPosition.Y + 24);
            RoomEleven = new Vector2(minimapPosition.X + 81, minimapPosition.Y + 24);
            RoomTwelve = new Vector2(minimapPosition.X + 105, minimapPosition.Y + 24);
            RoomThirteen = new Vector2(minimapPosition.X + 57, minimapPosition.Y + 12);
            RoomFourteen = new Vector2(minimapPosition.X + 105, minimapPosition.Y + 12);
            RoomFifteen = new Vector2(minimapPosition.X + 129, minimapPosition.Y + 12);
            RoomSeventeen = new Vector2(minimapPosition.X + 33, minimapPosition.Y);
            RoomEighteen = new Vector2(minimapPosition.X + 57, minimapPosition.Y);
            RoomNineteen = new Vector2(minimapPosition.X + 81, minimapPosition.Y);
            heartBuffer = 24;
            remainingHearts = game.util.numLives - game.util.HALF_MAX_LIVES;
            digitBuffer = 9;
            xpBuffer = 12;
            secondDigitBuffer = 24;
            ten = 10;
            zero = 0;
        }

    }
}
