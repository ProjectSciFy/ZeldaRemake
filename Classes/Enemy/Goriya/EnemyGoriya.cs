using CSE3902_Game_Sprint0.Classes.Enemy.Goriya;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemyGoriya : IEnemy, ICollisionEntity
    {
        public ZeldaGame game { get; set; }
        public GoriyaStateMachine myState { get; set; }
        public GoriyaSpriteFactory spriteFactory { get; protected set; }
        public Vector2 drawLocation;
        public Vector2 velocity;
        public Vector2 spriteSize = new Vector2(16, 16);
        public GoriyaBoomerang boomerang { get; set; }
        public ISprite mySprite { get; set; }
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        private static int HITBOX_SUBTRACT{ get; set; } = 2;
        public int health { get; set; } = 2;
        private int hurtTimer { get; set; } = 0;
        private int timer { get; set; } = 0;
        public bool throwing { get; set; } = false;

        public EnemyGoriya(ZeldaGame game, Vector2 spawnLocation)
        {
            this.game = game;
            this.spriteFactory = new GoriyaSpriteFactory(game);
            this.mySprite = this.spriteFactory.GoriyaIdleDown();
            drawLocation = spawnLocation;
            myState = new GoriyaStateMachine(this);
            game.collisionManager.collisionEntities.Add(this, collisionRectangle);
            boomerang = new GoriyaBoomerang(game, this, myState);
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
            if (timer > 0) { timer--; }
            if (hurtTimer > 0) { hurtTimer--; }
            myState.Update();
            mySprite.Update();
            drawLocation = drawLocation + velocity;
            if (timer <= 0 && myState.currentState != GoriyaStateMachine.CurrentState.spawning)
            {
                timer = 300;
                boomerang = new GoriyaBoomerang(game, this, myState);
                game.projectileHandler.Add(boomerang);
                throwing = true;
                myState.moving = false;
            }
            if (health <= 0) { boomerang.collided = true; }
            collisionRectangle.X = (int)drawLocation.X + HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - HITBOX_SUBTRACT * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - HITBOX_SUBTRACT * HITBOX_OFFSET;
            if (myState.currentState != GoriyaStateMachine.CurrentState.dying)
            { game.collisionManager.collisionEntities[this] = collisionRectangle; }
        }
        public void Draw()
        { mySprite.Draw(drawLocation); }
    }
}
