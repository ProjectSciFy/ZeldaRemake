using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Tiles
{
    public class PushableTile : ITile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        private ISprite tileSprite { get; set; }
        private TileSpriteFactory tileFactory { get; set; }
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; } = 7;
        private static int X_OFFSET { get; } = 6;
        public Vector2 drawLocation;
        public Vector2 spriteSize { get; set; } = new Vector2(16, 16);
        public bool pushed { get; set; }
        public PushableTile(ZeldaGame game, TileSpriteFactory tileFactory, Vector2 location)
        {
            this.game = game;
            this.drawLocation = location;
            this.tileFactory = tileFactory;
            this.tileSprite = tileFactory.PushableTile();
            this.spriteScalar = game.util.spriteScalar;
            this.pushed = false;
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }
        public void AddToCollision()
        {
            game.collisionManager.collisionEntities.Add(this, CollisionRectangle());
        }
        public void Update()
        {
            collisionRectangle.X = (int)drawLocation.X + HITBOX_OFFSET + X_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - 3 * HITBOX_OFFSET - X_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - 4 * HITBOX_OFFSET - 2;

            game.collisionManager.collisionEntities[this] = collisionRectangle;
        }

        public void Draw()
        {
            tileSprite.Draw(drawLocation);
        }
    }
}
