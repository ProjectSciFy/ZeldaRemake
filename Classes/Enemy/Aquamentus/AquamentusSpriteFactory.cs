using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.OldMan;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.Scripts;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{
    public class AquamentusSpriteFactory
    {
        private ZeldaGame game;
        private Texture2D bossSpriteSheet;
        private Texture2D linkSpriteSheet;
        private float enemyLayerDepth = 0.2f;

        public AquamentusSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Bosses", out bossSpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Aquamentus methods
        public void SpawnAquamentus(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 16;
            aquamentus.spriteSize.Y = 16;
            aquamentus.velocity.X = 0;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30, enemyLayerDepth);
        }

        public void AquamentusMovingRight(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = 1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(49, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }

        public void AquamentusMovingLeft(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = -1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(49, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }

        public void AquamentusRoaringRight(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = 1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(1, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }

        public void AquamentusRoaringLeft(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = -1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(1, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15, enemyLayerDepth);
        }
    }
}
