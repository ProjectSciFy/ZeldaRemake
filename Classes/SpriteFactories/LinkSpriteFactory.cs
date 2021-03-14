using CSE3902_Game_Sprint0.Classes.Projectiles;
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
        private ZeldaGame game;
        private Link link;
        private Texture2D linkTexture;

        public LinkSpriteFactory(Link link)
        {
            game = link.game;
            game.spriteSheets.TryGetValue("Link", out linkTexture);
            this.link = link;
        }

        public UniversalSprite IdleUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }

        public UniversalSprite IdleDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite IdleRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite IdleLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1), 10);
        }


        public UniversalSprite MovingUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public UniversalSprite MovingDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public UniversalSprite MovingRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public UniversalSprite MovingLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 2), 10);
        }

        //item sprites:
        //Sword:
        public UniversalSprite SwordUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 83, 16, 28), Color.White, SpriteEffects.None, new Vector2(1,4), 15);
        }
        public UniversalSprite SwordDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 47, 16, 27), Color.White, SpriteEffects.None, new Vector2(1, 4), 15);
        }
        public UniversalSprite SwordRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(66, 47, 27, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 15);
        }
        public UniversalSprite SwordLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(66, 47, 27, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(4, 1), 15);
        }

        //Bomb:
        public UniversalSprite BombUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(342, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3);
        }

        public UniversalSprite BombDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(325, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3);
        }

        public UniversalSprite BombRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3);
        }

        public UniversalSprite BombLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(5, 1), 3);
        }

        //Boomerang: TO DO - change sprite index for boomerang animation
        public UniversalSprite BoomerangUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(342, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3);
        }
        public UniversalSprite BoomerangDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(325, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3);
        }
        public UniversalSprite BoomerangRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3);
        }
        public UniversalSprite BoomerangLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(5, 1), 3);
        }

        //Arrow
        public void ArrowUp()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(342, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 5);
        }

        public void ArrowDown()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(325, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 5);
        }

        public void ArrowRight()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 5);
        }

        public void ArrowLeft()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(5, 1), 5);
        }

        public void DamageUp()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 4;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(287, 202, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5);
        }

        public void DamageDown()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = -4;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(253, 202, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5);
        }

        public void DamageRight()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = -4;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(270, 202, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5);
        }

        public void DamageLeft()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 4;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(270, 202, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(4, 1), 5);
        }
        public void PickUpNormal()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(213, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void PickUpTriForce()
        {
            link.spriteSize.X = 16;
            link.spriteSize.Y = 16;
            link.velocity.X = 0;
            link.velocity.Y = 0;
            link.linkSprite = new UniversalSprite(game, linkTexture, new Rectangle(230, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
    }
}
