using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.NewBlocks
{
    public class TileStateMachine
    {
        private EeveeSim game;
        private Tile tile;
        private TileSpriteFactory spriteFactory;

        /* //THIS IS FOR WHEN BLOCKS NEED TO INTERACT.
        public enum Direction { right, up, left, down };
        public Direction direction = Direction.down;
        public bool moving = false;
        */

        private int timer = 0;
        public enum TileType { Floor, Wall, Boss1Tile, Boss2Tile, Void, Texture, Empty, Stairs, Bricks, DungeonWall };
        public TileType currentState = TileType.Wall;

        public TileStateMachine(Tile tile)
        {
            this.game = tile.game;
            this.tile = tile;
            spriteFactory = new TileSpriteFactory(tile);
            spriteFactory.Wall();
        }

        public void Update()
        {
            switch (currentState)
            {
                case TileType.Floor:
                    spriteFactory.Floor();
                    break;
                case TileType.Wall:
                    spriteFactory.Wall();
                    break;
                case TileType.Boss1Tile:
                    spriteFactory.Boss1Tile();
                    break;
                case TileType.Boss2Tile:
                    spriteFactory.Boss2Tile();
                    break;
                case TileType.Void:
                    spriteFactory.Void();
                    break;
                case TileType.Texture:
                    spriteFactory.Texture();
                    break;
                case TileType.Empty:
                    spriteFactory.Empty();
                    break;
                case TileType.Stairs:
                    spriteFactory.Stairs();
                    break;
                case TileType.Bricks:
                    spriteFactory.Bricks();
                    break;
                case TileType.DungeonWall:
                    spriteFactory.DungeonWall();
                    break;
                default:
                    break;
            }
        }
    }
}
