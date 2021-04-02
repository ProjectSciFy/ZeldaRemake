using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.Header
{
    public class playerHUD
    {
        private ZeldaGame game;
        private ISprite hudSprite;
        private HudSpriteFactory HudFactory;
        public Vector2 position;
        public float spriteScalar;
        public Vector2 drawLocation;
        private int keyCounter;
        private int bluerupeeCounter;
        private int yellowrupeeCounter;
        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory)
        {
            this.game = game;
            this.spriteScalar = game.hudScalar;
            this.position = new Vector2(0, 0);
            this.HudFactory = hudFactory;
            this.hudSprite = HudFactory.baseHud();
        }

        public void Update()
        { 
            // this is where the counters for the HUD will be accessed, and graphical output delegated based on counter values.

        }

        public void Draw()
        {
            hudSprite.Draw(position);
            
        }


    }
}
