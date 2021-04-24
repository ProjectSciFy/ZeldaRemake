using CSE3902_Game_Sprint0.Classes.Enemy.Roshi;
using CSE3902_Game_Sprint0.Classes.Projectiles.KamehamehaUtility;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Kamehameha : IProjectile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        private EnemyRoshi roshi { get; set; }
        private RoshiStateMachine roshiState { get; set; }
        public RoshiSpriteFactory spriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        private Vector2 drawLocation;
        public Vector2 spriteSize { get; set; } = Vector2.Zero;
        public Rectangle collisionRectangle = Rectangle.Empty;
        private float spriteScalar { get; set; }
        public bool collided { get; set; } = false;
        private int timer = KamehamehaStorage.STARTING_TIMER;

        public Kamehameha(ZeldaGame game, EnemyRoshi roshi, RoshiStateMachine roshiState)
        {
            this.game = game;
            this.roshi = roshi;
            this.roshiState = roshiState;
            this.spriteFactory = roshi.spriteFactory;
            this.drawLocation = Vector2.Add(roshi.drawLocation, new Vector2(40 * 3, -24 * 3));
            this.spriteScalar = game.util.spriteScalar;
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }
        public void Update()
        {
            mySprite = spriteFactory.KamehamehaProjectile();
            mySprite.Update();
            if (timer <= 0)
            {
                spriteSize = KamehamehaStorage.SPRITE_SIZE_VECTOR;
                collisionRectangle.X = (int)drawLocation.X;
                collisionRectangle.Y = (int)drawLocation.Y + KamehamehaStorage.HITBOX_OFFSET;
                collisionRectangle.Width = (int)(spriteSize.X * spriteScalar);
                collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - KamehamehaStorage.DOUBLE_OFFSET;

                game.collisionManager.collisionEntities[this] = collisionRectangle;

                if (collided)
                {
                    game.projectileHandler.Remove(this);
                    game.collisionManager.collisionEntities.Remove(this);
                }
            }
            else
            {
                timer--;
            }
        }
        public void Draw()
        {
            if (timer <= 0)
            {
                mySprite.Draw(drawLocation);
            }
        }
    }
}
