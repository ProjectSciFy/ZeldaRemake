﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;

namespace CSE3902_Game_Sprint0.Classes.Header
{
    class playerHUD
    {
        private ZeldaGame game;
        private ISprite hudSprite;
        private HudSpriteFactory HudFactory;
        public Vector2 position;
        public float spriteScalar;
        public Vector2 drawLocation;
        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory, Vector2 location)
        {
            this.game = game;
            this.spriteScalar = game.spriteScalar;
            this.position = location;
            this.HudFactory = hudFactory;
            this.hudSprite = HudFactory.HUD();
        }

        public void Update()
        {
           // this is where the counters in the HUD will need to be updated, this class will need access to # of keys, # of yellow rupees, # of blue rupees.
        }

        public void Draw()
        {
            hudSprite.Draw(position);
        }


    }
}
