using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.Header;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.Scripts;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class HudSpriteFactory
    {
        private ZeldaGame game;
        private float itemDepth = .4f;
        private Texture2D hudSpriteSheet;
        public HudSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("HUD", out hudSpriteSheet);
        }
        //this tempelate need life, map, level to be added
        public UniversalSprite baseHud()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(257, 10, 256, 56), Color.White, SpriteEffects.None, new Vector2(1,1), 10, itemDepth);
        }
    }
}
