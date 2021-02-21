using CSE3902_Game_Sprint0.Classes.Blocks;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0
{
    public class TileStateMachine
    {
        private Block block;
        private TilesSpriteFactory spriteFactory;
        public Texture2D tileSpriteSheet;
        public enum BlockType { Floor, Wall, Boss1Tile, Boss2Tile, Void, Texture, Empty, Stairs, Bricks, DungeonWall };
        public BlockType currentBlock = BlockType.Wall;

        public TileStateMachine(Block block)
        {
            this.block = block;
            this.spriteFactory = this.block.spriteFactory;
        }

        public void Update()
        {
            switch (currentBlock)
            {
                case BlockType.Floor:
                    this.spriteFactory.Floor();
                    break;
                case BlockType.Wall:
                    this.spriteFactory.Wall();
                    break;
                case BlockType.Boss1Tile:
                    this.spriteFactory.Boss1Tile();
                    break;
                case BlockType.Boss2Tile:
                    this.spriteFactory.Boss2Tile();
                    break;
                case BlockType.Void:
                    this.spriteFactory.Void();
                    break;
                case BlockType.Texture:
                    this.spriteFactory.Texture();
                    break;
                case BlockType.Empty:
                    this.spriteFactory.Empty();
                    break;
                case BlockType.Stairs:
                    this.spriteFactory.Stairs();
                    break;
                case BlockType.Bricks:
                    this.spriteFactory.Bricks();
                    break;
                case BlockType.DungeonWall:
                    this.spriteFactory.DungeonWall();
                    break;
                default:
                    break;
            }
        }
    }
}
