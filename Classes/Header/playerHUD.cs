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
        private ISprite primWeapSprite;
        private ISprite secWeapSprite;
        private ISprite levelSprite;
        private ISprite heartSprite;

        private HudSpriteFactory HudFactory;
        public Vector2 hudPosition;
        public Vector2 primWeapPos;
        public Vector2 secWeapPos;
        public Vector2 levelPos;
        public Vector2 heartPos;
        private int heartOffset;


        public float spriteScalar;
        public Vector2 drawLocation;

        private int X, Y;
        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory)
        {
            //position of top left corner of hud template is X,Y:
            X = 0;
            Y = 0;
            this.hudPosition = new Vector2(X, Y);
            //elements of the Hud will be positioned in reference to X and Y so when Hud is moved, only X and Y need to change:
            this.primWeapPos = new Vector2((X + 456), (Y + 72));
            this.secWeapPos = new Vector2((X + 384),(Y + 72));
            this.levelPos = new Vector2((X + 47), (Y + 24));
            this.heartPos = new Vector2((X + 528), (Y + 96));
            


            this.game = game;
            this.spriteScalar = game.hudScalar;
            this.HudFactory = hudFactory;
            this.hudSprite = HudFactory.baseHud();
            this.primWeapSprite = HudFactory.primaryWeaponHUD();
            this.secWeapSprite = HudFactory.secondaryWeaponHUD();
            this.levelSprite = HudFactory.levelHUD();
            this.heartSprite = HudFactory.livesHUD();
        }

        public void Update()
        { 
            // this is where the counters for the HUD will be accessed, and graphical output delegated based on counter values.

        }

        public void Draw()
        {
            //static displays:
            hudSprite.Draw(hudPosition);
            primWeapSprite.Draw(primWeapPos);
            secWeapSprite.Draw(secWeapPos);
            levelSprite.Draw(levelPos);

            //Lives Graphical Displays:
            for (int i = 0; i < game.numLives; i++)
            {
                    heartOffset = (i) * (24);
                    heartSprite.Draw(new Vector2(heartPos.X + heartOffset,heartPos.Y));
            }
        }


    }
}
