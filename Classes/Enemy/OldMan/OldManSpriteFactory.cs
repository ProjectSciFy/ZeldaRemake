using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Enemy.OldMan
{
    public class OldManSpriteFactory
    {
        private readonly Texture2D NPCSpriteSheet;
        private ZeldaGame game { get; set; }
        private int idlelimiter = 10;
        private Rectangle idle = new Rectangle(18, 11, 16, 16);
        private float linkLayerDepth { get; set; } = 0.2f;
        public OldManSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("NPC", out NPCSpriteSheet);
        }
        public UniversalSprite OldManIdle()
        {
            return new UniversalSprite(game, NPCSpriteSheet, idle, Color.White, SpriteEffects.None, new Vector2(1, 1), idlelimiter, linkLayerDepth);
        }
    }
}
