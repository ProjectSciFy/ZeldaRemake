using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.BlockCommands
{
    public class DecrementBlock : ICommand
    {
        private TileStateMachine state;
        private TileStateMachine.BlockType currentBlock;
        
        public DecrementBlock(TileStateMachine state)
        {
            this.state = state;
            this.currentBlock = state.currentBlock; //Save current block of state machine to decrement.
        }
        public void Execute()
        {
            switch (this.currentBlock)
            {
                case TileStateMachine.BlockType.Floor:
                    state.currentBlock = TileStateMachine.BlockType.DungeonWall;
                    break;
                case TileStateMachine.BlockType.Wall:
                    state.currentBlock = TileStateMachine.BlockType.Floor;
                    break;
                case TileStateMachine.BlockType.Boss1Tile:
                    state.currentBlock = TileStateMachine.BlockType.Wall;
                    break;
                case TileStateMachine.BlockType.Boss2Tile:
                    state.currentBlock = TileStateMachine.BlockType.Boss1Tile;
                    break;
                case TileStateMachine.BlockType.Void:
                    state.currentBlock = TileStateMachine.BlockType.Boss2Tile;
                    break;
                case TileStateMachine.BlockType.Texture:
                    state.currentBlock = TileStateMachine.BlockType.Void;
                    break;
                case TileStateMachine.BlockType.Empty:
                    state.currentBlock = TileStateMachine.BlockType.Texture;
                    break;
                case TileStateMachine.BlockType.Stairs:
                    state.currentBlock = TileStateMachine.BlockType.Empty;
                    break;
                case TileStateMachine.BlockType.Bricks:
                    state.currentBlock = TileStateMachine.BlockType.Stairs;
                    break;
                case TileStateMachine.BlockType.DungeonWall:
                    state.currentBlock = TileStateMachine.BlockType.Bricks;
                    break;
                default:
                    break;
            }
        }
    }
}
