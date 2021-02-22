using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.NewBlocks
{
    public class Tile : ITile
    {
        public EeveeSim game;
        private TileStateMachine tileState;
        public ISprite tileSprite;
        public Vector2 drawLocation;
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(16, 16);

        public Tile(EeveeSim game)
        {
            this.game = game;
            //Arbitrary location
            drawLocation = new Vector2(300, 100);
        }

        public void SetState(TileStateMachine empty)
        {
            tileState = empty;
        }

        public void Update()
        {
            tileSprite.Update();
            tileState.Update();
        }

        public void Draw()
        {
            tileSprite.Draw(drawLocation);
        }
    }
}
