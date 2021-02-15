using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class LinkSpriteFactory
    {
        private EeveeSim game;
        private Link link;
        private Texture2D linkTexture;
        private Rectangle spriteIndex;

        public LinkSpriteFactory(Link link)
        {
            game = link.game;
            game.spriteSheets.TryGetValue("Link", out linkTexture);
            this.link = link;
        }
        

        public void IdleUp()
        {
            spriteIndex = new Rectangle(69, 11, 16, 16);
            link.LinkSprite = new StaticSprite(game, linkTexture, link.drawLocation, link.velocity = new Vector2(0, 0), spriteIndex, Color.White, SpriteEffects.None);
        }
        public void IdleDown()
        {
            spriteIndex = new Rectangle(1, 11, 16, 16);
            link.LinkSprite = new StaticSprite(game, linkTexture, link.drawLocation, link.velocity = new Vector2(0, 0), spriteIndex, Color.White, SpriteEffects.None);
        }
        public void IdleRight()
        {
            spriteIndex = new Rectangle(35, 11, 16, 16);
            link.LinkSprite = new StaticSprite(game, linkTexture, link.drawLocation, link.velocity = new Vector2(0, 0), spriteIndex, Color.White, SpriteEffects.None);
        }
        public void IdleLeft() //Not sure where we are drawing sprites but when drawn need to flip the IdleRight Sprite
        {
            spriteIndex = new Rectangle(35, 11, 16, 16);
            link.LinkSprite = new StaticSprite(game, linkTexture, link.drawLocation, link.velocity = new Vector2(0, 0), spriteIndex, Color.White, SpriteEffects.FlipHorizontally);
        }


        public void MovingUp()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void MovingDown()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void MovingRight()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void MovingLeft()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }


        public void SwordUp()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void SwordDown()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void SwordRight()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void SwordLeft()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }

        public void BoomerangUp()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void BoomerangDown()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void BoomerangRight()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void BoomerangLeft()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }

        public void ArrowUp()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite 
        }
        public void ArrowDown()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void ArrowRight()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
        public void ArrowLeft()
        {
            // set new spriteIndex
            // update link.LinkSprite = new AnimatedSprite
        }
    }
}
