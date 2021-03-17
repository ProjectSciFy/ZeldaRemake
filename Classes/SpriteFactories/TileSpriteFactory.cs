using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.SpriteFactories
{
    public class TileSpriteFactory
    {
        private ZeldaGame game;
        private Texture2D tileSpriteSheet;
        private float tileLayerDepth = .3f;
        public TileSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonTileset", out tileSpriteSheet);
        }

        public UniversalSprite BlockTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1055, 12, 12, 12), Color.Transparent, SpriteEffects.None, new Vector2(1, 1), 10, tileLayerDepth);
        }
        public UniversalSprite StairsTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 28, 16, 16), Color.Transparent, SpriteEffects.None, new Vector2(1, 1), 10, tileLayerDepth);
        }
        public UniversalSprite WallTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1055, 12, 12, 12), Color.Transparent, SpriteEffects.None, new Vector2(1, 1), 10, tileLayerDepth);
        }
    }
}
