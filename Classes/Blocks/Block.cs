using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Blocks
{
    public class Block : IBlock
    {
        public EeveeSim game;
        private TilesSpriteFactory spriteFactory;
        public Vector2 drawLocation;
        public ISprite blockSprite;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 blockSize = new Vector2(16, 16);
        

        public Block(EeveeSim game)
        {
            this.game = game;
            spriteFactory = game.tileSpriteFactory;
            drawLocation = new Vector2((game.GraphicsDevice.Viewport.Bounds.Width / 2) - (4 * blockSize.X), (game.GraphicsDevice.Viewport.Bounds.Height / 2));
        }

        public void update()
        {
            //empty for now -- no animation.
        }

        public void draw()
        {
            blockSprite.Draw(drawLocation);
        }

    }
}
