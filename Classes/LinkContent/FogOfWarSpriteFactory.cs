using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent
{
    public class FogOfWarSpriteFactory
    {
        private ZeldaGame game { get; set; }
        private Texture2D fogOfWarTexture;
        private float fogOfWarLayerDepth { get; set; } = 0.0f;
        public FogOfWarSpriteFactory(FogOfWar fogOfWar)
        {
            game = fogOfWar.game;
            game.spriteSheets.TryGetValue("FogOfWar", out fogOfWarTexture);
        }

        public UniversalSprite FogOfWar()
        {
            return new UniversalSprite(game, fogOfWarTexture, new Rectangle(0, 0, 1544, 352), Color.White, SpriteEffects.None, new Vector2(1, 1), 10, fogOfWarLayerDepth);
        }
    }
}
