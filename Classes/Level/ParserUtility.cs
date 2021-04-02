using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class ParserUtility
    {
        private ZeldaGame game;
        public ParserUtility(ZeldaGame game)
        {
            this.game = game;
        }

        public Vector2 GetBlockSecondaryItemPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            return new Vector2(windowWidthFloor + 3 * x * 16 + 48 + 6, windowHeightFloor + 3 * y * 16 + 48 + 6);
        }

        public Vector2 GetHeartPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            return new Vector2(windowWidthFloor + 3 * x * 16 + 48 + 12, windowHeightFloor + 3 * y * 16 + 48 + 12);
        }

        public Vector2 GetHeartContainerPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            return new Vector2(windowWidthFloor + 3 * x * 16 + 48 + 4, windowHeightFloor + 3 * y * 16 + 48 + 6);
        }

        public Vector2 GetCommonItemPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            return new Vector2(windowWidthFloor + 3 * x * 16 + 48 + 12, windowHeightFloor + 3 * y * 16 + 48);
        }

        public Vector2 GetBombPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            return new Vector2(windowWidthFloor + 3 * x * 16 + 48 + 12, windowHeightFloor + 3 * y * 16 + 48 + 2);
        }

        public Vector2 GetEnemyPosition(int windowWidthFloor, int windowHeightFloor, float x, float y)
        {
            return new Vector2(windowWidthFloor + 3 * x * 16 + 48, windowHeightFloor + 3 * y * 16 + 48);
        }

        public Vector2 GetTriforceOldPosition(int windowWidth, int windowHeightFloor)
        {
            return new Vector2((windowWidth / 2) - 16, windowHeightFloor + 129 * 2);
        }
    }
}
