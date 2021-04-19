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
        public ZeldaGame game { get; set; }
        private static int INTERIOR_WIDTH { get; set; } = 192;
        private static int INTERIOR_LENGTH { get; set; } = 112;
        private static int DOOR_SIZE { get; set; } = 32;

        public static Dictionary<int, Rectangle> INTERIOR_DIMENSIONS = new Dictionary<int, Rectangle>()
        {
            [1] = new Rectangle(290, 918, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [2] = new Rectangle(547, 918, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [3] = new Rectangle(804, 918, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [4] = new Rectangle(547, 741, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [5] = new Rectangle(290, 564, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [6] = new Rectangle(547, 564, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [7] = new Rectangle(804, 564, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [8] = new Rectangle(33, 387, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [9] = new Rectangle(290, 387, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [10] = new Rectangle(547, 387, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [11] = new Rectangle(804, 387, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [12] = new Rectangle(1061, 387, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [13] = new Rectangle(547, 210, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [14] = new Rectangle(1061, 210, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            [15] = new Rectangle(1318, 210, INTERIOR_WIDTH, INTERIOR_LENGTH),//
            //[16] = new Rectangle(33, 32, INTERIOR_WIDTH, INTERIOR_LENGTH),
            [16] = new Rectangle(33, 32, INTERIOR_WIDTH, INTERIOR_LENGTH),
            //[16] = new Rectangle(290, 918, INTERIOR_WIDTH, INTERIOR_LENGTH),
            [17] = new Rectangle(290, 33, INTERIOR_WIDTH, INTERIOR_LENGTH),
            [18] = new Rectangle(547, 33, INTERIOR_WIDTH, INTERIOR_LENGTH),

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
            [-1] = new Rectangle(),
            [9] = new Rectangle(),
            [19] = new Rectangle(),
            [29] = new Rectangle(),
            [5] = new Rectangle(),


        };

        public Texture2D tileSpriteSheet;
        public Texture2D itemSpriteSheet;
        private Texture2D roomSpriteSheet;

        public RoomTextureStorage(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonBackgrounds", out roomSpriteSheet);
            game.spriteSheets.TryGetValue("DungeonTileset", out tileSpriteSheet);
            game.spriteSheets.TryGetValue("ItemsAndWeapons", out itemSpriteSheet);

        }

        public UniversalSprite getRoom(int roomNumber)
        {
            return new UniversalSprite(game, roomSpriteSheet, INTERIOR_DIMENSIONS[roomNumber], Color.White, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }
        public UniversalSprite getDoor(int doorValue)
        {
            return new UniversalSprite(game, tileSpriteSheet, DOOR_DIMENSIONS[doorValue], Color.White, SpriteEffects.None, new Vector2(1, 1), 10, 0.0f);
        }
    }
}
