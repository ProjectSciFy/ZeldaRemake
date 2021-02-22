using CSE3902_Game_Sprint0.Classes.NewBlocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.TileCommands
{
    public class PreviousTile : ICommand
    {
        private TileStateMachine tileStateMachine;
        private TileStateMachine.TileType currentTile;

        public PreviousTile(TileStateMachine tileStateMachine)
        {
            this.tileStateMachine = tileStateMachine;
            this.currentTile = tileStateMachine.currentState;
        }

        public void Execute()
        {
            switch (this.currentTile)
            {
                case TileStateMachine.TileType.Floor:
                    tileStateMachine.currentState = TileStateMachine.TileType.DungeonWall;
                    break;
                case TileStateMachine.TileType.Wall:
                    tileStateMachine.currentState = TileStateMachine.TileType.Floor;
                    break;
                case TileStateMachine.TileType.Boss1Tile:
                    tileStateMachine.currentState = TileStateMachine.TileType.Wall;
                    break;
                case TileStateMachine.TileType.Boss2Tile:
                    tileStateMachine.currentState = TileStateMachine.TileType.Boss1Tile;
                    break;
                case TileStateMachine.TileType.Void:
                    tileStateMachine.currentState = TileStateMachine.TileType.Boss2Tile;
                    break;
                case TileStateMachine.TileType.Texture:
                    tileStateMachine.currentState = TileStateMachine.TileType.Void;
                    break;
                case TileStateMachine.TileType.Empty:
                    tileStateMachine.currentState = TileStateMachine.TileType.Texture;
                    break;
                case TileStateMachine.TileType.Stairs:
                    tileStateMachine.currentState = TileStateMachine.TileType.Empty;
                    break;
                case TileStateMachine.TileType.Bricks:
                    tileStateMachine.currentState = TileStateMachine.TileType.Stairs;
                    break;
                case TileStateMachine.TileType.DungeonWall:
                    tileStateMachine.currentState = TileStateMachine.TileType.Bricks;
                    break;
                default:
                    break;
            }
        }
    }
}
