using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Collisions.CollisionScripts
{
    public class ItemOnTile : ICommand
    {
        private IItem item { get; set; }
        private ITile tile { get; set; }
        private Collision.Collision.Direction direction { get; set; }

        public ItemOnTile(IItem item, ITile tile, Collision.Collision.Direction direction)
        {
            this.item = item;
            this.tile = tile;
            this.direction = direction;
        }
        public void Execute()
        {
            if (tile is WallTile || tile is GateKeeperTile)
            {
                ((Fairy)item).velocity = Vector2.Negate(((Fairy)item).velocity);
            }
        }
    }
}
