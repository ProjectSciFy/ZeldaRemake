using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus
{
    public class AquamentusSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private readonly Texture2D bossSpriteSheet;
        private readonly Texture2D linkSpriteSheet;
        private float enemyLayerDepth { get; set; } = 0.2f;
        private AquamentusHelper aquamentus { get; set; }

        public AquamentusSpriteFactory(ZeldaGame game)
        {
            this.aquamentus = new AquamentusHelper();
            this.game = game;
            game.spriteSheets.TryGetValue("Bosses", out bossSpriteSheet);
            game.spriteSheets.TryGetValue("Link", out linkSpriteSheet);
        }

        //Aquamentus methods
        public UniversalSprite SpawnAquamentus()
        {
            return new UniversalSprite(game, linkSpriteSheet, aquamentus.spawn, Color.White, SpriteEffects.None, aquamentus.spawnFrame, aquamentus.spawnLimiter, enemyLayerDepth);
        }

        public UniversalSprite AquamentusMovingRight()
        {
            return new UniversalSprite(game, bossSpriteSheet, aquamentus.moving, Color.White, SpriteEffects.None, aquamentus.movingFrame, aquamentus.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite AquamentusMovingLeft()
        {
            return new UniversalSprite(game, bossSpriteSheet, aquamentus.moving, Color.White, SpriteEffects.None, aquamentus.movingFrame, aquamentus.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite AquamentusRoaringRight()
        {
            return new UniversalSprite(game, bossSpriteSheet, aquamentus.roaring, Color.White, SpriteEffects.None, aquamentus.movingFrame, aquamentus.movementLimiter, enemyLayerDepth);
        }

        public UniversalSprite AquamentusRoaringLeft()
        {
            return new UniversalSprite(game, bossSpriteSheet, aquamentus.roaring, Color.White, SpriteEffects.None, aquamentus.movingFrame, aquamentus.movementLimiter, enemyLayerDepth);
        }
    }
}
