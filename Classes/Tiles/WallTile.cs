using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Tiles
{
    public class WallTile : ITile
    {
        private ZeldaGame game;
        private ISprite tileSprite;
        private TileSpriteFactory tileFactory;
        public Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        public Vector2 position;
        public WallTile(ZeldaGame game, TileSpriteFactory tileFactory, Vector2 location)
        {
            this.game = game;
            this.position = location;
            this.tileFactory = tileFactory;
            this.tileSprite = tileFactory.WallTile();
        }
        public void Update()
        {
        }

        public void Draw()
        {
            tileSprite.Draw(position);
        }
    }
}
