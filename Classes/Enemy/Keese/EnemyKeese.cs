using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese
{
    public class EnemyKeese : IEnemy, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        private KeeseStateMachine myState { get; set; }
        public KeeseSpriteFactory enemySpriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(16, 16);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        private static int HITBOX_SUBRACT { get; set; } = 2;
        public int health { get; set; } = 1;
        private int hurtTimer { get; set; } = 0;

        public EnemyKeese(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.spriteScalar = game.util.spriteScalar;
            this.enemySpriteFactory = new KeeseSpriteFactory(game);
            this.mySprite = this.enemySpriteFactory.KeeseIdle();
            drawLocation = spawnLocation;
            myState = new KeeseStateMachine(this);
            game.collisionManager.collisionEntities.Add(this, CollisionRectangle());
            health = health * game.util.difficultyMult;
        }
        public void TakeDamage(int damage)
        {
            if (hurtTimer <= 0)
            {
                hurtTimer = 30;
                this.health = this.health - damage;
                game.sounds["enemyHit"].CreateInstance().Play();
            }
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }

        public void Update()
        {
            myState.Update();
            mySprite.Update();

            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;

            if (drawLocation.X >= game.GraphicsDevice.Viewport.Bounds.Width && velocity.X > 0)
            {
                drawLocation.X = 0 - spriteSize.X;
            }
            else if (drawLocation.X + spriteSize.X <= 0 && velocity.X < 0)
            {
                drawLocation.X = game.GraphicsDevice.Viewport.Bounds.Width;
            }

            if (drawLocation.Y >= game.GraphicsDevice.Viewport.Bounds.Height && velocity.Y > 0)
            {
                drawLocation.Y = 0 - spriteSize.Y;
            }
            else if (drawLocation.Y + spriteSize.Y <= 0 && velocity.Y < 0)
            {
                drawLocation.Y = game.GraphicsDevice.Viewport.Bounds.Height;
            }

            collisionRectangle.X = (int)drawLocation.X + HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - HITBOX_SUBRACT * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - HITBOX_SUBRACT * HITBOX_OFFSET;
            if (health > 0)
            {
                game.collisionManager.collisionEntities[this] = collisionRectangle;
            }
        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
