using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemySpriteFactory
    {
        private EeveeSim game;
        private EnemyStalfos stalfos;
        private IEnemy enemy;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;

        public EnemySpriteFactory(EeveeSim game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Blade trap methods

        //Gel methods
        public void SpawnGel(EnemyGel gel)
        {
            gel.spriteSize.X = 16;
            gel.spriteSize.Y = 16;
            gel.velocity.X = 0;
            gel.velocity.Y = 0;
            gel.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30);
        }

        public void GelMovingUp(EnemyGel gel)
        {
            gel.spriteSize.X = 8;
            gel.spriteSize.Y = 16;
            gel.velocity.X = 0;
            gel.velocity.Y = -2;
            gel.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2);
        }

        public void GelMovingDown(EnemyGel gel)
        {
            gel.spriteSize.X = 8;
            gel.spriteSize.Y = 16;
            gel.velocity.X = 0;
            gel.velocity.Y = 2;
            gel.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2);
        }

        public void GelIdle(EnemyGel gel)
        {
            gel.spriteSize.X = 8;
            gel.spriteSize.Y = 16;
            gel.velocity.X = 0;
            gel.velocity.Y = 0;
            gel.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2);
        }

        public void GelMovingLeft(EnemyGel gel)
        {
            gel.spriteSize.X = 8;
            gel.spriteSize.Y = 16;
            gel.velocity.X = -2;
            gel.velocity.Y = 0;
            gel.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2);
        }

        public void GelMovingRight(EnemyGel gel)
        {
            gel.spriteSize.X = 8;
            gel.spriteSize.Y = 16;
            gel.velocity.X = 2;
            gel.velocity.Y = 0;
            gel.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(1, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 2);
        }

        //Goriya methods
        public void SpawnGoriya(EnemyGoriya goriya)
        {
            goriya.spriteSize.X = 16;
            goriya.spriteSize.Y = 16;
            goriya.velocity.X = 0;
            goriya.velocity.Y = 0;
            goriya.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30);
        }
        public void GoriyaMovingUp(EnemyGoriya goriya)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = -1;
            stalfos.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(22, 146, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 4), 1);
        }

        //Keese methods

        //Stalfos methods
        public void SpawnStalfos(EnemyStalfos stalfos)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = 0;
            stalfos.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30);
        }

        public void StalfosMovingUp(EnemyStalfos stalfos)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = -1;
            stalfos.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(383, 146, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 1);
        }

        public void StalfosMovingDown(EnemyStalfos stalfos)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = 1;
            stalfos.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(383, 146, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void StalfosMovingLeft(EnemyStalfos stalfos)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = -1;
            stalfos.velocity.Y = 0;
            stalfos.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(383, 146, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void StalfosMovingRight(EnemyStalfos stalfos)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 1;
            stalfos.velocity.Y = 0;
            stalfos.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(383, 146, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void StalfosIdle(EnemyStalfos stalfos)
        {
            stalfos.spriteSize.X = 16;
            stalfos.spriteSize.Y = 16;
            stalfos.velocity.X = 0;
            stalfos.velocity.Y = 0;
            stalfos.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(383, 146, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void BladeTrapIdle(BladeTrap bladetrap)
        {
            bladetrap.spriteSize.X = 16;
            bladetrap.spriteSize.Y = 16;
            bladetrap.velocity.X = 0;
            bladetrap.velocity.Y = 0;
            bladetrap.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void BladeTrapUp(BladeTrap bladetrap)
        {
            bladetrap.spriteSize.X = 16;
            bladetrap.spriteSize.Y = 16;
            bladetrap.velocity.X = 0;
            bladetrap.velocity.Y = -1;
            bladetrap.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }

        public void BladeTrapDown(BladeTrap bladetrap)
        {
            bladetrap.spriteSize.X = 16;
            bladetrap.spriteSize.Y = 16;
            bladetrap.velocity.X = 0;
            bladetrap.velocity.Y = 1;
            bladetrap.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void BladeTrapRight(BladeTrap bladetrap)
        {
            bladetrap.spriteSize.X = 16;
            bladetrap.spriteSize.Y = 16;
            bladetrap.velocity.X = 1;
            bladetrap.velocity.Y = 0;
            bladetrap.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public void BladeTrapLeft(BladeTrap bladetrap)
        {
            bladetrap.spriteSize.X = 16;
            bladetrap.spriteSize.Y = 16;
            bladetrap.velocity.X = -1;
            bladetrap.velocity.Y = 0;
            bladetrap.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(164, 59, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }

        //Wallmaster methods

    }
}
