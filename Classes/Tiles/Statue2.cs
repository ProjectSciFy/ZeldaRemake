using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Tiles
{
    public class Statue2 : ITile
    {
        private SpriteBatch batch;
        private Texture2D spriteSheet;
        private Rectangle statue2Tile = TileSpriteFactory.Statue2Tile;
        public Vector2 position;
        public Statue2(EeveeSim game, Vector2 location)
        {
            game.spriteSheets.TryGetValue("DungeonTileset", out this.spriteSheet);
            this.batch = new SpriteBatch(game.GraphicsDevice);
            this.position = location;
        }
        public void Update()
        {
        }

        public void Draw()
        {
            batch.Draw(spriteSheet, position, statue2Tile, Color.White);
        }
    }
}
