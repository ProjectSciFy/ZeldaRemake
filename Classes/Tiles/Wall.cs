using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using Microsoft.Xna.Framework.Graphics;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.Tiles
{
    public class Wall : ITile
    {
        private SpriteBatch batch;
        private Texture2D spriteSheet;
        private Rectangle wallTile = TileSpriteFactory.WallTile;
        public Vector2 position;
        public Wall(EeveeSim game, Vector2 location)
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
            batch.Draw(spriteSheet, position, wallTile, Color.White);
        }
    }
}
