using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster
{
    public class EnemyWallmaster : IEnemy, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        public WallmasterStateMachine myState { get; set; }
        public WallmasterSpriteFactory enemySpriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        public int health { get; set; } = 3;
        private int hurtTimer { get; set; } = 0;
        public EnemyWallmaster(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.enemySpriteFactory = new WallmasterSpriteFactory(game);
            this.mySprite = this.enemySpriteFactory.WallmasterHiding();
            drawLocation = new Vector2(0, 0);
            myState = new WallmasterStateMachine(this);
            game.collisionManager.collisionEntities.Add(this, collisionRectangle);
            this.spriteScalar = game.util.spriteScalar;
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
            if (hurtTimer > 0)
            {
                hurtTimer--;
            }
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

            collisionRectangle.X = (int)drawLocation.X + 2 * HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + 2 * HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - 4 * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - 4 * HITBOX_OFFSET;

            if (myState.currentState != WallmasterStateMachine.CurrentState.dying)
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
