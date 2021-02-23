using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Arrow : ISecondaryEntity
    {
        private EeveeSim game;
        private Link link;
        private Texture2D arrowTexture;
        public ISprite arrowSprite;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        private LinkStateMachine linkState;
        public ItemSpriteFactory spriteFactory;
        public enum Direction { right, up, left, down }; // NE = North East
        public Direction direction = Direction.down;


        public Arrow(EeveeSim game, Link link)
        {
            this.game = game;
            this.link = link;
            this.linkState = link.linkState;
            this.drawLocation = link.drawLocation;
            spriteFactory.Arrow();
        }

        public void Update()
        {
            linkState.Update();
            arrowSprite.Update();
        }

        public void Draw()
        {
            arrowSprite.Draw(drawLocation);
        }
    }
}
