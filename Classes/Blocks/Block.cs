using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Blocks
{
    public class Block : IBlock
    {
        public EeveeSim game;
        private List<Block> blocks = new List<Block>();
        private int currentBlockIndex = 0;
        private TilesSpriteFactory spriteFactory;
        public Vector2 drawLocation;
        public ISprite blockSprite;
        public Vector2 blockSize = new Vector2(5, 5);
        public Vector2 velocity = new Vector2(0, 0);

        public Block(EeveeSim game, Vector2 drawHere)
        {
            this.game = game;
            spriteFactory = game.tileSpriteFactory;
            drawLocation = drawHere;
        }

        public void setCurrentBlockIndex(int newBlockIndex)
        {
            this.currentBlockIndex = newBlockIndex;
        }

        public int getCurrentBlockIndex()
        {
            return currentBlockIndex;
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
