using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Redead
{
    public class EnemyRedead : IEnemy, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        public RedeadStateMachine myState { get; set; }
        public RedeadSpriteFactory enemySpriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(16, 16);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        public int health { get; set; } = 2;
        private int hurtTimer { get; set; } = 0;

        public EnemyRedead(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.spriteScalar = game.util.spriteScalar;
            this.enemySpriteFactory = new RedeadSpriteFactory(game);
            this.mySprite = this.enemySpriteFactory.RedeadIdle();
            drawLocation = spawnLocation;
            myState = new RedeadStateMachine(this);
            game.collisionManager.collisionEntities.Add(this, this.CollisionRectangle());
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
            if (hurtTimer > 0) { hurtTimer--; }
            myState.Update();
            mySprite.Update();
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;
            if (myState.idle)
            {
                collisionRectangle.X = (int)drawLocation.X - (int)(spriteSize.X * spriteScalar);
                collisionRectangle.Y = (int)drawLocation.Y - (int)(spriteSize.Y * spriteScalar);
                collisionRectangle.Width = ((int)(spriteSize.X * spriteScalar) - RedeadHelper.two * HITBOX_OFFSET) * RedeadHelper.three;
                collisionRectangle.Height = ((int)(spriteSize.Y * spriteScalar) - RedeadHelper.two * HITBOX_OFFSET) * RedeadHelper.three;
            }
            else
            {
                collisionRectangle.X = (int)drawLocation.X + HITBOX_OFFSET;
                collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
                collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - RedeadHelper.two * HITBOX_OFFSET;
                collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - RedeadHelper.two * HITBOX_OFFSET;
            }
            if (myState.currentState != RedeadStateMachine.CurrentState.dying) { game.collisionManager.collisionEntities[this] = collisionRectangle; }
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
