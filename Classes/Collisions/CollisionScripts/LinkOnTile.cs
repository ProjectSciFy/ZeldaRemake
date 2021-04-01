using CSE3902_Game_Sprint0.Classes.GameState;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class LinkOnTile : ICommand
    {
        private Link link;
        private ITile tile;
        private Collision.Collision.Direction direction;
        private ZeldaGame game;
        private TransitionState transition;
        public LinkOnTile(Link link, ITile tile, Collision.Collision.Direction direction)
        {
            this.game = link.game;
            this.link = link;
            this.tile = tile;
            this.direction = direction;
        }
        public void Execute()
        {
            if (tile is BlockTile || tile is WallTile)
            {
                if (direction == Collision.Collision.Direction.down)
                {
                    link.drawLocation.Y = link.drawLocation.Y - link.velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.up)
                {
                    link.drawLocation.Y = link.drawLocation.Y - link.velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                }
                else if (direction == Collision.Collision.Direction.left)
                {
                    link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                }
            }
            if (tile is StairsTile)
            {
                if (direction == Collision.Collision.Direction.down)
                {
                    game.changeRoom(game.neighbors[game.roomNumber][3], direction);
                }
                else if (direction == Collision.Collision.Direction.up)
                {
                    game.changeRoom(game.neighbors[game.roomNumber][0], direction);
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    game.changeRoom(game.neighbors[game.roomNumber][2], direction);
                }
                else if (direction == Collision.Collision.Direction.left)
                {
                    game.changeRoom(game.neighbors[game.roomNumber][1], direction);
                }
            }
        }
    }
}
