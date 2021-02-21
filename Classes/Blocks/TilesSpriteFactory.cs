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
        public int currentBlock = 0;

        public TilesSpriteFactory(Block block)
        {
            game = block.game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out tileSpriteSheet);
            this.block = block;
        }

        //TILES LAYOUT IN SPRITE SHEET:
        // [0]  [1]  [2]  [3]
        // [4]  [5]  [6]  [7]
        // [8]  [9]
        public void changeBlock(int newBlock)
        {
            this.currentBlock = newBlock;
            switch (newBlock)
            {
                case 0:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 1:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 2:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 3:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 4:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 5:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 6:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 7:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 8:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                case 9:
                    block.blockSprite = new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
                    break;
                default:
                    break;
            }
        }
    }
}