using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

/*This file is a sprite-factory which will contain otherwise frowned upon "magic numbers".*/
namespace CSE3902_Game_Sprint0.Classes.Enemy.OldMan
{
    public class OldManSpriteFactory 
    {
        private Texture2D NPCSpriteSheet;
        private ZeldaGame game;
        private float linkLayerDepth = 0.2f;
        public OldManSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("NPC", out NPCSpriteSheet);
        }
        public UniversalSprite OldManIdle()
        {
            return new UniversalSprite(game, NPCSpriteSheet, new Rectangle(18, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, linkLayerDepth);
        }
    }
}
