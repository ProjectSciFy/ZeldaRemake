using CSE3902_Game_Sprint0.Classes.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes;

namespace CSE3902_Game_Sprint0
{
    public class TilesSpriteFactory
    {
        private EeveeSim game;
        private Block block;
        public Texture2D tileSpriteSheet;
        public int currentBlock;

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
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 1:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 2:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 3:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 4:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 5:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 6:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 7:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 8:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                case 9:
                    //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
                    block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
                    break;
                default:
                    break;
            }
        }
    }
}