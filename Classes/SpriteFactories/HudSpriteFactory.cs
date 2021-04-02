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
        //this is just the base template sprite. HUD still needs life, map, level, counters to be implemented and updated in real time.
        public UniversalSprite baseHud()
        {
            return new UniversalSprite(game, hudSpriteSheet, new Rectangle(258, 11, 255, 55), Color.White, SpriteEffects.None, new Vector2(1,1), 10, itemDepth);
        }

        //public UniversalSprite mapHUD()
        //{
        //}

        //public UniversalSprite keysHUD()
        //{
        //}

        //public UniversalSprite bluerupeesHUD()
        //{
        //}

        //public UniversalSprite yellowrupeesHUD()
        //{
        //}

        //public UniversalSprite livesHUD()
        //{
        //}

        //public UniversalSprite levelHUD()
        //{
        //}

        //public UniversalSprite primaryToolHUD()
        //{
        //}

        //public UniversalSprite secondaryToolHUD()
        //{
        //}
    }
}
