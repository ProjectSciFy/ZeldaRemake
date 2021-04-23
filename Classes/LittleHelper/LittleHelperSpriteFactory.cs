using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.LittleHelper
{
    public class LittleHelperSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private LittleHelper littleHelper { get; set; }
        private readonly Texture2D helperTexture;
        private float littleHelperLayerDepth { get; set; } = 1.0f;
        public LittleHelperSpriteFactory(LittleHelper littleHelper)
        {
            game = littleHelper.game;
            game.spriteSheets.TryGetValue("DungeonEnemies", out helperTexture);
            this.littleHelper = littleHelper;
        }
        public UniversalSprite Flying()
        {
            return new UniversalSprite(game, helperTexture, new Rectangle(183, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 10, littleHelperLayerDepth);
        }
        public UniversalSprite Interacting()
        {
            return new UniversalSprite(game, helperTexture, new Rectangle(183, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 2), 5, littleHelperLayerDepth);
        }
    }
}
