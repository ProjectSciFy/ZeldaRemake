using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class ProjectileSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private Texture2D bossSpriteSheet;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private float projectileLayerDepth { get; set; } = .5f;

        public ProjectileSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Bosses", out bossSpriteSheet);
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Bomb methods
        public void BombPlaced(Bomb bomb)
        {
            bomb.spriteSize.X = 16;
            bomb.spriteSize.Y = 16;
            bomb.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 203, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, projectileLayerDepth);
        }

        public void BombExploding(Bomb bomb)
        {
            bomb.spriteSize.X = 16;
            bomb.spriteSize.Y = 16;
            bomb.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10, projectileLayerDepth);
        }

        //Arrow methods
        public void ArrowUp(Arrow arrow)
        {
            arrow.spriteSize.X = 8;
            arrow.spriteSize.Y = 16;
            arrow.velocity.X = 0;
            arrow.velocity.Y = -3;
            arrow.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(1, 185, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, projectileLayerDepth);
        }

        public void ArrowDown(Arrow arrow)
        {
            arrow.spriteSize.X = 8;
            arrow.spriteSize.Y = 16;
            arrow.velocity.X = 0;
            arrow.velocity.Y = 3;
            arrow.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(1, 185, 8, 16), Color.White, SpriteEffects.FlipVertically, new Vector2(1, 1), 10, projectileLayerDepth);
        }

        public void ArrowLeft(Arrow arrow)
        {
            arrow.spriteSize.X = 16;
            arrow.spriteSize.Y = 16;
            arrow.velocity.X = -3;
            arrow.velocity.Y = 0;
            arrow.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(10, 185, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 1), 10, projectileLayerDepth);
        }

        public void ArrowRight(Arrow arrow)
        {
            arrow.spriteSize.X = 16;
            arrow.spriteSize.Y = 16;
            arrow.velocity.X = 3;
            arrow.velocity.Y = 0;
            arrow.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(10, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, projectileLayerDepth);
        }

        public void ArrowStrike(Arrow arrow)
        {
            arrow.spriteSize.X = 8;
            arrow.spriteSize.Y = 16;
            arrow.velocity.X = 0;
            arrow.velocity.Y = 0;
            arrow.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(53, 185, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, projectileLayerDepth);
        }
    }
}
