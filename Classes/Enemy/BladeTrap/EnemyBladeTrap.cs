using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemyBladeTrap : IEnemy, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        private BladeTrapStateMachine myState { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 range;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(16, 16);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        private static int HITBOX_SUBTRACT { get; set; } = 2;

        public EnemyBladeTrap(ZeldaGame game, Vector2 spawnLocation, Vector2 range, Link link)
        {
            this.game = game;
            this.spawnLocation = spawnLocation;
            this.range = range;
            drawLocation = spawnLocation;
            myState = new BladeTrapStateMachine(this, link);
            this.spriteScalar = game.util.spriteScalar;
            game.collisionManager.collisionEntities.Add(this, CollisionRectangle());
        }
        public void TakeDamage(int damage)
        {
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Spawn()
        {

        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;
            collisionRectangle.X = (int)drawLocation.X + HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)spriteSize.X - HITBOX_SUBTRACT * HITBOX_OFFSET;
            collisionRectangle.Height = (int)spriteSize.Y - HITBOX_SUBTRACT * HITBOX_OFFSET;
            game.collisionManager.collisionEntities[this] = collisionRectangle;
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
