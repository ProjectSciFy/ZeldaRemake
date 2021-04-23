using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*This file is a sprite-factory which will contain otherwise frowned upon "magic numbers".*/
namespace CSE3902_Game_Sprint0.Classes._21._2._13
{
    public class EnemySpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D bossSpriteSheet;
        private readonly Texture2D enemySpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private readonly Texture2D NPCSpriteSheet;
        private float linkLayerDepth { get; set; } = 0.2f;

        // fps limiters:
        private int enemyLimiter { get; set; } = 10;
        private int fireballLimiter { get; set; } = 5;

        public EnemySpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("Bosses", out bossSpriteSheet);
            game.spriteSheets.TryGetValue("DungeonEnemies", out enemySpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
            game.spriteSheets.TryGetValue("NPC", out NPCSpriteSheet);
        }

        public void GoriyaBoomerangAttack(GoriyaBoomerang boomerang)
        {
            boomerang.mySprite = new UniversalSprite(game, enemySpriteSheet, new Rectangle(290, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 3), enemyLimiter, linkLayerDepth);
        }
        //fireball
        public void FireballAttack(Fireball fireball)
        {
            fireball.spriteSize = new Vector2(16, 16);
            fireball.velocity = new Vector2(fireball.trajectory.X, fireball.trajectory.Y);
            fireball.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(101, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 4), fireballLimiter, linkLayerDepth);
        }
        public void KiBlastAttack(KiBlast kiBlast)
        {
            kiBlast.spriteSize = new Vector2(16, 16);
            kiBlast.velocity = new Vector2(kiBlast.trajectory.X, kiBlast.trajectory.Y);
            kiBlast.mySprite = new UniversalSprite(game, bossSpriteSheet, new Rectangle(125, 11, 8, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), fireballLimiter, linkLayerDepth);
        }
    }
}
