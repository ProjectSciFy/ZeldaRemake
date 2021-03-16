using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class LinkOnTile
    {
        private Link link;
        private ITile tile;
        private Collision.Collision.Direction direction;

        public LinkOnTile(Link link, ITile tile, Collision.Collision.Direction direction)
        {
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
                    link.drawLocation.Y = link.drawLocation.Y + link.velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    link.drawLocation.X = link.drawLocation.X - link.velocity.X;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    link.drawLocation.X = link.drawLocation.X + link.velocity.X;
                }
            }
        }
    }
}
