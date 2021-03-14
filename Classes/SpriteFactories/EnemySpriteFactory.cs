using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Enemy.OldMan;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.Projectiles;
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
        private ZeldaGame game;
        private EnemyStalfos stalfos;
        private IEnemy enemy;
        private Texture2D bossSpriteSheet;
        private Texture2D enemySpriteSheet;
        private Texture2D linkSpriteSheet;
        private Texture2D NPCSpriteSheet;

        public EnemySpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Bosses", out bossSpriteSheet);
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
            game.spriteSheets.TryGetValue("NPC", out NPCSpriteSheet);
        }

        //Aquamentus methods
        public void SpawnAquamentus(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 16;
            aquamentus.spriteSize.Y = 16;
            aquamentus.velocity.X = 0;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30);
        }

        public void AquamentusMovingRight(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = 1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(49, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15);
        }

        public void AquamentusMovingLeft(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = -1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(49, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15);
        }

        public void AquamentusRoaringRight(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = 1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(1, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15);
        }

        public void AquamentusRoaringLeft(EnemyAquamentus aquamentus)
        {
            aquamentus.spriteSize.X = 24;
            aquamentus.spriteSize.Y = 32;
            aquamentus.velocity.X = -1;
            aquamentus.velocity.Y = 0;
            aquamentus.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(1, 11, 24, 32), Color.White, SpriteEffects.None, new Vector2(1, 2), 15);
        }

        //Blade trap methods
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
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(0, 0);
            goriya.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30);
        }
        public void GoriyaMovingUp(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(0, -1);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(322, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public void GoriyaMovingDown(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(0, 1);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public void GoriyaMovingRight(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(1, 0);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public void GoriyaMovingLeft(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(-1, 0);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 2), 10);
        }
        public void GoriyaIdleDown(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(0, 0);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public void GoriyaIdleUp(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(0, 0);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(322, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public void GoriyaIdleRight(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(0, 0);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }
        public void GoriyaIdleLeft(EnemyGoriya goriya)
        {
            goriya.SpriteSize = new Vector2(16, 16);
            goriya.Velocity = new Vector2(0, 0);
            goriya.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(254, 11, 16, 16), Color.White, SpriteEffects.FlipHorizontally, new Vector2(1, 2), 10);
        }

        //Keese methods
        public void SpawnKeese(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            keese.velocity.X = 0;
            keese.velocity.Y = 0;
            keese.mySprite = new UniversalSprite(game, linkSpriteSheet, new Rectangle(138, 185, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 30);
        }

        public void KeeseIdle(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            keese.velocity.X = 0;
            keese.velocity.Y = 0;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }

        public void KeeseFlyingNorth(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 0;
            //keese.velocity.Y = -2;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseFlyingNorthEast(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 2;
            //keese.velocity.Y = -2;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseFlyingEast(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 2;
            //keese.velocity.Y = 0;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseFlyingSouthEast(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 2;
            //keese.velocity.Y = 2;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseFlyingSouth(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 0;
            //keese.velocity.Y = 2;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseFlyingSouthWest(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = -2;
            //keese.velocity.Y = 2;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseFlyingWest(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = -2;
            //keese.velocity.Y = 0;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseFlyingNorthWest(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = -2;
            //keese.velocity.Y = -2;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
        }

        public void KeeseLandingNorth(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 0;
            //keese.velocity.Y = -1;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void KeeseLandingNorthEast(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 1;
            //keese.velocity.Y = -1;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void KeeseLandingEast(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 1;
            //keese.velocity.Y = 0;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void KeeseLandingSouthEast(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 1;
            //keese.velocity.Y = 1;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void KeeseLandingSouth(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = 0;
            //keese.velocity.Y = 1;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void KeeseLandingSouthWest(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = -1;
            //keese.velocity.Y = 1;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void KeeseLandingWest(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = -1;
            //keese.velocity.Y = 0;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void KeeseLandingNorthWest(EnemyKeese keese)
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            //keese.velocity.X = -1;
            //keese.velocity.Y = -1;
            keese.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(183, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        //OldMan methods :^]
        public void OldManIdle(EnemyOldMan oldMan)
        {
            oldMan.spriteSize.X = 16;
            oldMan.spriteSize.Y = 16;
            oldMan.velocity.X = 0;
            oldMan.velocity.Y = 0;
            oldMan.mySprite = new UniversalSprite(game, NPCSpriteSheet, new Rectangle(18, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }

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
            stalfos.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(383, 146, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10);
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


        //Wallmaster methods
        public void WallmasterIdle(EnemyWallmaster wallmaster)
        {
            wallmaster.spriteSize.X = 16;
            wallmaster.spriteSize.Y = 16;
            wallmaster.velocity.X = 0;
            wallmaster.velocity.Y = 0;
            wallmaster.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }
        public void WallmasterMovingUp(EnemyWallmaster wallmaster)
        {
            wallmaster.spriteSize.X = 16;
            wallmaster.spriteSize.Y = 16;
            wallmaster.velocity.X = 0;
            wallmaster.velocity.Y = -1;
            wallmaster.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void WallmasterMovingRight(EnemyWallmaster wallmaster)
        {
            wallmaster.spriteSize.X = 16;
            wallmaster.spriteSize.Y = 16;
            wallmaster.velocity.X = 1;
            wallmaster.velocity.Y = 0;
            wallmaster.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void WallmasterMovingDown(EnemyWallmaster wallmaster)
        {
            wallmaster.spriteSize.X = 16;
            wallmaster.spriteSize.Y = 16;
            wallmaster.velocity.X = 0;
            wallmaster.velocity.Y = 1;
            wallmaster.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        public void WallmasterMovingLeft(EnemyWallmaster wallmaster)
        {
            wallmaster.spriteSize.X = 16;
            wallmaster.spriteSize.Y = 16;
            wallmaster.velocity.X = -1;
            wallmaster.velocity.Y = 0;
            wallmaster.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(393, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 20);
        }

        // need to fix ItemSpriteFactory, Cant use from any other class except an item class. Needs to have game as parameter for constructor. Adding boomerang stuff here till then
        public void BoomerangDown(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = 0;
            boomerang.velocity.Y = 1;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void BoomerangUp(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = 0;
            boomerang.velocity.Y = -1;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void BoomerangRight(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = 1;
            boomerang.velocity.Y = 0;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void BoomerangLeft(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = -1;
            boomerang.velocity.Y = 0;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void BoomerangNE(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = 1;
            boomerang.velocity.Y = -1;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void BoomerangSE(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = 1;
            boomerang.velocity.Y = 1;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void BoomerangSW(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = -1;
            boomerang.velocity.Y = 1;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void BoomerangNW(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = -1;
            boomerang.velocity.Y = -1;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void LinkBoomerangAttack(LinkBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = boomerang.trajectory.X;
            boomerang.velocity.Y = boomerang.trajectory.Y;
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        public void GoriyaBoomerangAttack(GoriyaBoomerang boomerang)
        {
            boomerang.spriteSize.X = 16;
            boomerang.spriteSize.Y = 16;
            boomerang.velocity.X = boomerang.trajectory.X;
            boomerang.velocity.Y = boomerang.trajectory.Y;
            boomerang.MySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), 10);
        }
        //fireball
        public void FireballAttack(Fireball fireball)
        {
            fireball.spriteSize.X = 16;
            fireball.spriteSize.Y = 16;
            fireball.velocity.X = fireball.trajectory.X;
            fireball.velocity.Y = fireball.trajectory.Y;
            fireball.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(101, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 4), 5);
        }
    }
}
