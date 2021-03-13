using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class TileSpriteFactory
    {
        private EeveeSim game;
        private Texture2D tileSpriteSheet;

        public static Rectangle WallTile = new Rectangle(1001, 11, 16, 16);
        public static Rectangle Statue1Tile = new Rectangle(1018, 11, 16, 16);
        public static Rectangle Statue2Tile = new Rectangle(1035, 11, 16, 16);
        public static Rectangle SandTile = new Rectangle(1001, 28, 16, 16);
        public static Rectangle StairsTile = new Rectangle(1035, 28, 16, 16);
        public static Rectangle VoidTile = new Rectangle(984, 28, 16, 16);
        public static Rectangle EmptyTile = new Rectangle(1018, 28, 16, 16);

        public TileSpriteFactory(EeveeSim game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonTileset", out tileSpriteSheet);
        }
        /*
        public void Bricks()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void DungeonWall()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        */
    }
}
