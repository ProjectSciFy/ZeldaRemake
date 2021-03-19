using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Scripts;

/*This file is used for storage and will therefore contain otherwise frowned upon "magic numbers"*/
namespace CSE3902_Game_Sprint0.Classes.Level
{
    public class RoomTextureStorage
    {
        public ZeldaGame game;
        private Texture2D roomSpriteSheet;
        private float tileLayerDepth = .3f;
        private static int INTERIOR_WIDTH = 192;
        private static int INTERIOR_LENGTH = 112;
        private static int DOOR_SIZE = 32;

        public static Dictionary<int, Rectangle> INTERIOR_DIMENSIONS = new Dictionary<int, Rectangle>()
        {
            [1] = new Rectangle(1, 192, INTERIOR_WIDTH, INTERIOR_LENGTH), //
            [2] = new Rectangle(196, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [3] = new Rectangle(391, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [4] = new Rectangle(586, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [5] = new Rectangle(586, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [6] = new Rectangle(781, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [7] = new Rectangle(976, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [8] = new Rectangle(976, 882, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [9] = new Rectangle(1, 307, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [10] = new Rectangle(196, 307, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [11] = new Rectangle(781, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [12] = new Rectangle(391, 307, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [13] = new Rectangle(586, 307, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [14] = new Rectangle(781, 307, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [15] = new Rectangle(976, 307, INTERIOR_WIDTH, INTERIOR_LENGTH),//
           // [16] = new Rectangle(421, 1009, INTERIOR_WIDTH, INTERIOR_LENGTH),
            [16] = new Rectangle(1, 192, INTERIOR_WIDTH, INTERIOR_LENGTH),
            [17] = new Rectangle(1, 422, INTERIOR_WIDTH, INTERIOR_LENGTH),
            [18] = new Rectangle(196, 422, INTERIOR_WIDTH, INTERIOR_LENGTH),

        };
        public static Dictionary<int, Rectangle> DOOR_DIMENSIONS = new Dictionary<int, Rectangle>()
        {
            [0] = new Rectangle(815, 11, DOOR_SIZE, DOOR_SIZE), //
            [1] = new Rectangle(848, 11, DOOR_SIZE, DOOR_SIZE),//
            [2] = new Rectangle(881, 11, DOOR_SIZE, DOOR_SIZE),//
            [10] = new Rectangle(815, 44, DOOR_SIZE, DOOR_SIZE),//
            [11] = new Rectangle(848, 44, DOOR_SIZE, DOOR_SIZE),//
            [12] = new Rectangle(881, 44, DOOR_SIZE, DOOR_SIZE),//
            [20] = new Rectangle(815, 77, DOOR_SIZE, DOOR_SIZE),//
            [21] = new Rectangle(848, 77, DOOR_SIZE, DOOR_SIZE),//
            [22] = new Rectangle(881, 77, DOOR_SIZE, DOOR_SIZE),//
            [30] = new Rectangle(815, 110, DOOR_SIZE, DOOR_SIZE),//
            [31] = new Rectangle(848, 110, DOOR_SIZE, DOOR_SIZE),//
            [32] = new Rectangle(881, 110, DOOR_SIZE, DOOR_SIZE),//



        };

        public Texture2D tileSpriteSheet;

        public Texture2D itemSpriteSheet;
        

        public RoomTextureStorage(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonTileset", out roomSpriteSheet);
            game.spriteSheets.TryGetValue("DungeonTileset", out tileSpriteSheet);
            game.spriteSheets.TryGetValue("ItemsAndWeapons", out itemSpriteSheet);

        }




        public UniversalSprite getRoom(int roomNumber)
        {
            return new UniversalSprite(game, roomSpriteSheet, INTERIOR_DIMENSIONS[roomNumber], Color.White, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }
        public UniversalSprite getDoor(int doorValue)
        {
            return new UniversalSprite(game, roomSpriteSheet, DOOR_DIMENSIONS[doorValue], Color.White, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }
    }
}
