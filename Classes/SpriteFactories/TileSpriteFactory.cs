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
        private Tile tile;
        private Texture2D tileSpriteSheet;

        public TileSpriteFactory(Tile tile)
        {
            this.game = tile.game;
            game.spriteSheets.TryGetValue("DungeonTileset", out tileSpriteSheet);
            this.tile = tile;
        }

        //TILES LAYOUT IN SPRITE SHEET:
        // [0]  [1]  [2]  [3]
        // [4]  [5]  [6]  [7]
        // [8]  [9]

        public void Floor()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Wall()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Boss1Tile()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Boss2Tile()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Void()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Texture()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Empty()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Stairs()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Bricks()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void DungeonWall()
        {
            tile.tileSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
    }
}
