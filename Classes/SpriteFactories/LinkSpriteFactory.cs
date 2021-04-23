using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class LinkSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D linkTexture;
        private float linkLayerDepth { get; set; } = 1.0f;
        public LinkSpriteFactory(Link link)
        {
            game = link.game;
            game.spriteSheets.TryGetValue("Link", out linkTexture);
        }

        public UniversalSprite IdleUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }

        public UniversalSprite IdleDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
        public UniversalSprite IdleRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
        public UniversalSprite IdleLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1), 10, linkLayerDepth);
        }


        public UniversalSprite MovingUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(69, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }
        public UniversalSprite MovingDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }
        public UniversalSprite MovingRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, linkLayerDepth);
        }
        public UniversalSprite MovingLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(35, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 2), 10, linkLayerDepth);
        }

        public UniversalSprite RollUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(160, 206, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 4), 5, linkLayerDepth);
        }
        public UniversalSprite RollDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(342, 237, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5, linkLayerDepth);
        }
        public UniversalSprite RollLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(325, 237, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(4, 1), 5, linkLayerDepth);
        }
        public UniversalSprite RollRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(325, 237, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5, linkLayerDepth);
        }

        //item sprites:
        //Sword:
        public UniversalSprite SwordUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 83, 16, 28), Color.White, SpriteEffects.None, new Vector2(1, 4), 3, linkLayerDepth);
        }
        public UniversalSprite SwordDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(1, 47, 16, 27), Color.White, SpriteEffects.None, new Vector2(1, 4), 3, linkLayerDepth);
        }
        public UniversalSprite SwordRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(66, 47, 27, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 3, linkLayerDepth);
        }
        public UniversalSprite SwordLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(66, 47, 27, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(4, 1), 3, linkLayerDepth);
        }

        //Portal gun
        public UniversalSprite PortalUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(94, 75, 16, 28), Color.White, SpriteEffects.None, new Vector2(1, 4), 3, linkLayerDepth);
        }
        public UniversalSprite PortalDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(94, 47, 16, 27), Color.White, SpriteEffects.None, new Vector2(1, 4), 3, linkLayerDepth);
        }
        public UniversalSprite PortalRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(159, 47, 27, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 3, linkLayerDepth);
        }
        public UniversalSprite PortalLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(159, 47, 27, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(4, 1), 3, linkLayerDepth);
        }

        //Bomb:
        public UniversalSprite BombUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(342, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3, linkLayerDepth);
        }

        public UniversalSprite BombDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(325, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3, linkLayerDepth);
        }

        public UniversalSprite BombRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3, linkLayerDepth);
        }

        public UniversalSprite BombLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(5, 1), 3, linkLayerDepth);
        }

        //Boomerang
        public UniversalSprite BoomerangUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(342, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3, linkLayerDepth);
        }
        public UniversalSprite BoomerangDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(325, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3, linkLayerDepth);
        }
        public UniversalSprite BoomerangRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 3, linkLayerDepth);
        }
        public UniversalSprite BoomerangLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(5, 1), 3, linkLayerDepth);
        }

        public void LinkBoomerangAttack(LinkBoomerangProjectile boomerang)
        {
            boomerang.spriteSize = new Vector2(16, 16);
            boomerang.velocity = boomerang.trajectory;
            boomerang.mySprite = new UniversalSprite(game, linkTexture, new Rectangle(64, 189, 8, 8), Color.White, SpriteEffects.None, new Vector2(1, 3), 10, linkLayerDepth);
        }

        //Arrow
        public UniversalSprite ArrowUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(342, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 5, linkLayerDepth);
        }

        public UniversalSprite ArrowDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(325, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 5, linkLayerDepth);
        }

        public UniversalSprite ArrowRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.None, new Vector2(5, 1), 5, linkLayerDepth);
        }

        public UniversalSprite ArrowLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(308, 154, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(5, 1), 5, linkLayerDepth);
        }

        public UniversalSprite DamageUp()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(287, 202, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5, linkLayerDepth);
        }

        public UniversalSprite DamageDown()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(253, 202, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5, linkLayerDepth);
        }

        public UniversalSprite DamageRight()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(270, 202, 16, 16), Color.White, SpriteEffects.None, new Vector2(4, 1), 5, linkLayerDepth);
        }

        public UniversalSprite DamageLeft()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(270, 202, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(4, 1), 5, linkLayerDepth);
        }

        public UniversalSprite Dying()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(227, 270, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 4), 5, linkLayerDepth);
        }

        public UniversalSprite Death()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(227, 288, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 6), 30, linkLayerDepth);
        }

        public UniversalSprite PickUpNormal()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(213, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
        public UniversalSprite PickUpTriForce()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(230, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
        public UniversalSprite PickUpBow()
        {
            return new UniversalSprite(game, linkTexture, new Rectangle(230, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
    }
}
