using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Items
{
    public class DropKey
    {
        private ZeldaGame game { get; set; }
        private Vector2 location { get; set; }
        private readonly int deathTimer;
        public DropKey(ZeldaGame game, Vector2 location, int deathTimer)
        {
            this.game = game;
            this.location = location;
            this.deathTimer = deathTimer;
        }
        public void Execute()
        {
            game.currentRoom.items.Add(new Key(game, new SpriteFactories.ItemSpriteFactory(game), location));
        }
    }
}
