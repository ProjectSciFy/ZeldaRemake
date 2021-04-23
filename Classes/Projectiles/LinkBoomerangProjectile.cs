using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class LinkBoomerangProjectile : IProjectile, ICollisionEntity
    {
        private ZeldaGame game { get; set; }
        public Classes.Link link { get; set; }
        public LinkStateMachine linkState { get; set; }

        public LinkSpriteFactory spriteFactory { get; set; }
        public ISprite mySprite { get; set; }
        public LinkBoomerangStateMachine myState { get; set; }
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 velocity { get; set; } = new Vector2(0, 0);
        public Vector2 spriteSize { get; set; } = new Vector2(0, 0);
        public bool newItem { get; set; }
        public Vector2 trajectory { get; set; } = new Vector2(0, 0);
        public Rectangle collisionRectangle = new Rectangle(0, 0, 0, 0);
        private float spriteScalar { get; set; }
        private static int HITBOX_OFFSET { get; set; } = 6;
        public bool collided { get; set; } = false;
        private int boomerangTimer { get; set; } = 30;
        private int soundTimer { get; set; } = 0;

        public LinkBoomerangProjectile(Link link, LinkStateMachine linkState)
        {
            this.link = link;
            this.game = link.game;
            this.linkState = linkState;
            this.spriteFactory = linkState.spriteFactory;
            this.drawLocation = link.drawLocation;
            this.spawnLocation = link.drawLocation;
            this.spriteScalar = link.game.util.spriteScalar;
            this.myState = new LinkBoomerangStateMachine(this);
        }
        public Rectangle CollisionRectangle()
        {
            return collisionRectangle;
        }
        public void Update()
        {
            if (soundTimer <= 0)
            {
                link.game.sounds["arrowBoomerang"].CreateInstance().Play();
                soundTimer = 10;
            }
            else
            {
                soundTimer--;
            }
            if (boomerangTimer > 0)
            {
                boomerangTimer--;
            }
            myState.Update();
            mySprite.Update();
            linkState.Update();

            //Update position of boomerang
            drawLocation = drawLocation + velocity;

            collisionRectangle.X = (int)drawLocation.X + 2 * HITBOX_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - 3 * HITBOX_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - 2 * HITBOX_OFFSET;

            game.collisionManager.collisionEntities[this] = collisionRectangle;

            if (collided && boomerangTimer <= 0)
            {
                game.projectileHandler.Remove(this);
                game.collisionManager.collisionEntities.Remove(this);
            }
            collided = false;
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }

    }
}
