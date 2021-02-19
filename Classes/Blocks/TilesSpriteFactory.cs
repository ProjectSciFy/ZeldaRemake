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
        private Texture2D tileSpriteSheet;

        public TilesSpriteFactory(Block block)
        {
            game = block.game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out tileSpriteSheet);
            this.block = block;
        }

        //TILES LAYOUT IN SPRITE SHEET:
        // [1]  [2]  [3]  [4]
        // [5]  [6]  [7]  [8]
        // [9]  [10]
        public void Block1()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0,0,0,0), Color.White, SpriteEffects.None);
        }
        public void Block2()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block3()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block4()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block5()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block6()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block7()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block8()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block9()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
        public void Block10()
        {
            //CHANGE RECTANGLE TO SIZE AND LOCATION IN .png FILE
            block.blockSprite = new StaticSprite(game, tileSpriteSheet, block.drawLocation, block.velocity, new Rectangle(0, 0, 0, 0), Color.White, SpriteEffects.None);
        }
    }
}