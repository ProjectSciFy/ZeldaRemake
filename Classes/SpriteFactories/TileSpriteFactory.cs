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

        public TileSpriteFactory(ZeldaGame game)
        {
            this.game = game;
            game.spriteSheets.TryGetValue("DungeonTileset", out tileSpriteSheet);
        }

        public UniversalSprite WallTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite Statue1Tile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite Statue2Tile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 11, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite SandTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite StairsTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1035, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite VoidTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite EmptyTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1018, 28, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        /*
        public UniversalSprite BrickTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(984, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        public UniversalSprite LadderTile()
        {
            return new UniversalSprite(game, tileSpriteSheet, new Rectangle(1001, 45, 16, 16), Color.White, SpriteEffects.None, new Vector2(1, 1), 10);
        }
        */
    }
}
