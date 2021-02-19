using CSE3902_Game_Sprint0.Classes.Scripts;
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
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
        }
        public void IdleDown()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
        }
        public void IdleRight()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
        }
        public void IdleLeft() //Not sure where we are drawing sprites but when drawn need to flip the IdleRight Sprite
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }


        public void MovingUp()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = -2;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2));
        }
        public void MovingDown()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 2;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2));
        }
        public void MovingRight()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 2;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2));
        }
        public void MovingLeft()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = -2;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 2));
        }

        //item sprites:
        public void SwordUp()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1,1));
        }
        public void SwordDown()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
        }
        public void SwordRight()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1));
        }
        public void SwordLeft()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }


        public void BoomerangUp()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }
        public void BoomerangDown()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }
        public void BoomerangRight()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }
        public void BoomerangLeft()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }


        public void ArrowUp()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }
        public void ArrowDown()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }
        public void ArrowRight()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }
        public void ArrowLeft()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1));
        }
    }
}
