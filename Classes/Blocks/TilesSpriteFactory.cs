using CSE3902_Game_Sprint0.Classes.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes.Scripts;

namespace CSE3902_Game_Sprint0
{
    public class TilesSpriteFactory
    {
        
        private EeveeSim game;
        private Block block;
        public Texture2D tileSpriteSheet;
        

        public TilesSpriteFactory(EeveeSim game)
        {
            this.game = game;
            this.game.spriteSheets.TryGetValue("DungeonEnemies", out tileSpriteSheet);
        }

        //TILES LAYOUT IN SPRITE SHEET:
        // [0]  [1]  [2]  [3]
        // [4]  [5]  [6]  [7]
        // [8]  [9]
        /*
        public void Floor()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Wall()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Boss1Tile()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Boss2Tile()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Void()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Texture()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Empty()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Stairs()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void Bricks()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void DungeonWall()
        {
            block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        */
    }
}