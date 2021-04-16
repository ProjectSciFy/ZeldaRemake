using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class ParserUtility
    {
        public static int GAME_FRAME_ADJUST { get; set; } = 128;

        public static int WINDOW_X_ADJUST { get; set; } = 176;
        public static int WINDOW_Y_ADJUST { get; set; } = 256;
        public static int SCALE_FACTOR { get; set; } = 3;
        public static int GEN_ADJUST { get; set; } = 2;
        public static int SPRITE_SIZE { get; set; } = 16;
        private static int BLOCK_ADJUST { get; set; } = 6;
        private static int LARGE_ADJUST { get; set; } = 12;
        private static int CONTAINER_ADJUST { get; set; } = 4;
        private static int MID_ADJUST { get; set; } = 129;

        private ZeldaGame game;
        public ParserUtility(ZeldaGame game)
        {
            this.game = game;
        }

        public Vector2 GetBlockSecondaryItemPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST;
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }

        public Vector2 GetPushablePosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE;
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }

        public Vector2 GetHeartPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + LARGE_ADJUST;
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + LARGE_ADJUST;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }

        public Vector2 GetHeartContainerPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + CONTAINER_ADJUST;
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }

        public Vector2 GetCommonItemPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + LARGE_ADJUST;
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }

        public Vector2 GetBombPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + LARGE_ADJUST;
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + GEN_ADJUST;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }

        public Vector2 GetEnemyPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE;
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }

        public Vector2 GetTriforceOldPosition(int windowWidth, int windowHeightFloor)
        {
            return new Vector2((windowWidth / GEN_ADJUST) - SPRITE_SIZE, windowHeightFloor + MID_ADJUST * GEN_ADJUST);
        }

        public Vector2 GetTopStairPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST + (SCALE_FACTOR * SPRITE_SIZE / GEN_ADJUST);
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST - (SCALE_FACTOR * SPRITE_SIZE);
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }
        public Vector2 GetLeftStairPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST - (SCALE_FACTOR * SPRITE_SIZE);
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }
        public Vector2 GetRightStairPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST + (SCALE_FACTOR * SPRITE_SIZE);
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST;
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }
        public Vector2 GetBotStairPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            float xDiff = SCALE_FACTOR * x * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST + (SCALE_FACTOR * SPRITE_SIZE / GEN_ADJUST);
            float yDiff = SCALE_FACTOR * y * SPRITE_SIZE + SCALE_FACTOR * SPRITE_SIZE + BLOCK_ADJUST + (SCALE_FACTOR * SPRITE_SIZE);
            return new Vector2(windowWidthFloor + xDiff, windowHeightFloor + yDiff);
        }
    }
}
