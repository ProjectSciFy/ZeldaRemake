using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Projectiles.LinkBoomerangProjectileUtility;
using CSE3902_Game_Sprint0.Classes.Scripts;
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
        public Vector2 velocity { get; set; } = Vector2.Zero;
        public Vector2 spriteSize { get; set; } = Vector2.Zero;
        public bool newItem { get; set; }
        public Vector2 trajectory { get; set; } = Vector2.Zero;
        public Rectangle collisionRectangle = Rectangle.Empty;
        private float spriteScalar { get; set; }
        public bool collided { get; set; } = false;
        private int boomerangTimer { get; set; } = LinkBoomerangProjectileStorage.BOOMERANG_TIMER_STARTING_VALUE;
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
                soundTimer = LinkBoomerangProjectileStorage.SOUND_TIMER_VALUE;
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

            collisionRectangle.X = (int)drawLocation.X + LinkBoomerangProjectileStorage.DOUBLE_OFFSET;
            collisionRectangle.Y = (int)drawLocation.Y + LinkBoomerangProjectileStorage.HITBOX_OFFSET;
            collisionRectangle.Width = (int)(spriteSize.X * spriteScalar) - LinkBoomerangProjectileStorage.TRIPLE_OFFSET;
            collisionRectangle.Height = (int)(spriteSize.Y * spriteScalar) - LinkBoomerangProjectileStorage.DOUBLE_OFFSET;

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
