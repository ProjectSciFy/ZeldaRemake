using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{
    public class EnemyAquamentus : IEnemy, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        private AquamentusStateMachine myState { get; set; }
        public AquamentusSpriteFactory enemySpriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        public int timer { get; set; } = 0;
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        public int health { get; set; } = 20;
        private int hurtTimer { get; set; } = 0;

        public EnemyAquamentus(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.enemySpriteFactory = new AquamentusSpriteFactory(game);
            this.mySprite = this.enemySpriteFactory.SpawnAquamentus();
            drawLocation = spawnLocation;
            myState = new AquamentusStateMachine(this);
            this.spriteScalar = game.util.spriteScalar;
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
            if (timer > 0) { timer--; }
            if (hurtTimer > 0) { hurtTimer--; }
            myState.Update();
            mySprite.Update();
            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;
            if (timer <= 0)
            {
                timer = 300;
                game.projectileHandler.Add(new Fireball(game, this, myState, new Vector2(-1, 0)));
                game.projectileHandler.Add(new Fireball(game, this, myState, new Vector2(-1, (float)0.15)));
                game.projectileHandler.Add(new Fireball(game, this, myState, new Vector2(-1, (float)-0.15)));
            }
            collisionRectangle.X = (int)drawLocation.X + AquamentusHelper.two * HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - AquamentusHelper.three * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - AquamentusHelper.two * HITBOX_OFFSET;
            if (myState.currentState != AquamentusStateMachine.CurrentState.dying)
            { game.collisionManager.collisionEntities[this] = collisionRectangle; }
        }
        public void Draw()
        { mySprite.Draw(drawLocation); }
    }
}
