using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Bomb : IProjectile, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        public ProjectileSpriteFactory projectileSpriteFactory { get; set; }
        public ProjectileHandler projectileHandler { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 spriteSize;
        private BombStateMachine myState { get; set; }
        public bool exploding { get; set; } = false;
        private int explosionTimer { get; set; } = 6;
        private bool explosionMirror { get; set; } = false;
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public float spriteScalar { get; set; }

        public Bomb(ZeldaGame game, Vector2 drawLocation, ProjectileHandler projectileHandler)
        {
            this.game = game;
            this.spriteScalar = game.util.spriteScalar;
            this.projectileSpriteFactory = game.projectileSpriteFactory;
            this.drawLocation = drawLocation;
            this.projectileHandler = projectileHandler;
            myState = new BombStateMachine(this);
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();

        }

        public void Draw()
        {
            if (!exploding)
            {
                mySprite.Draw(drawLocation);
            }
            else
            {
                if (explosionMirror)
                {
                    mySprite.Draw(new Vector2(drawLocation.X - 8 * spriteScalar, drawLocation.Y - 16 * spriteScalar));
                    mySprite.Draw(new Vector2(drawLocation.X + 16 * spriteScalar, drawLocation.Y));
                    mySprite.Draw(drawLocation);
                    mySprite.Draw(new Vector2(drawLocation.X + 8 * spriteScalar, drawLocation.Y + 16 * spriteScalar));
                }
                else
                {
                    mySprite.Draw(new Vector2(drawLocation.X + 8 * spriteScalar, drawLocation.Y - 16 * spriteScalar));
                    mySprite.Draw(new Vector2(drawLocation.X - 16 * spriteScalar, drawLocation.Y));
                    mySprite.Draw(drawLocation);
                    mySprite.Draw(new Vector2(drawLocation.X - 8 * spriteScalar, drawLocation.Y + 16 * spriteScalar));
                }

                if (explosionTimer <= 0)
                {
                    explosionMirror = !explosionMirror;
                    explosionTimer = 6;
                }
                else
                {
                    explosionTimer--;
                }
            }
        }
    }
}
