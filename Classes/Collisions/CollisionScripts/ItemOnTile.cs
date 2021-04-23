using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Tiles;

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
            if (item is Fairy && (tile is WallTile || tile is GateKeeperTile))
            {
                if (direction == Collision.Collision.Direction.down)
                {
                    ((Fairy)item).position.Y = ((Fairy)item).position.Y - ((Fairy)item).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.up)
                {
                    ((Fairy)item).position.Y = ((Fairy)item).position.Y - ((Fairy)item).velocity.Y;
                }
                else if (direction == Collision.Collision.Direction.right)
                {
                    ((Fairy)item).position.X = ((Fairy)item).position.X - ((Fairy)item).velocity.X;
                }
                else if (direction == Collision.Collision.Direction.left)
                {
                    ((Fairy)item).position.X = ((Fairy)item).position.X - ((Fairy)item).velocity.X;
                }
                //((Fairy)item).velocity = Vector2.Negate(((Fairy)item).velocity);
            }
        }
    }
}
