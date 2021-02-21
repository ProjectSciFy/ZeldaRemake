using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Blocks
{
    public class Block : IBlock
    {
        public EeveeSim game;
        public TileStateMachine tileState;
        public TilesSpriteFactory spriteFactory;
        public Vector2 drawLocation;
        public ISprite blockSprite;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 blockSize = new Vector2(16, 16);
        

        public Block(EeveeSim game, Vector2 location)
        {
            this.game = game;
            this.spriteFactory = game.tileSpriteFactory;
            drawLocation = location;
            tileState = new TileStateMachine(this);
        }

        public void update()
        {
            tileState.Update();
            blockSprite.Update();
        }

        public void draw()
        {
            blockSprite.Draw(drawLocation);
        }

    }
}
