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
        public Vector2 velocity = new Vector2(0, 0);
        public Vector2 spriteSize = new Vector2(0, 0);
        public Vector2 trajectory;
        private LinkStateMachine linkState;
        public LinkSpriteFactory spriteFactory;
        public enum Direction { right, up, left, down }; // NE = North East
        public Direction direction = Direction.down;
        public bool newItem = true;

        public Arrow(EeveeSim game, Link link, LinkStateMachine linkState, Vector2 trajectory)
        {
            this.game = game;
            this.link = link;
            this.linkState = link.linkState;
            //this.spriteFactory = game.itemSpriteFactory;
            this.drawLocation = link.drawLocation;
            this.spawnLocation = link.drawLocation;
            this.trajectory = trajectory;
            //spriteFactory.Arrow();
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

        /*
        public void Update()
        {
            if (newItem)
            {
                newItem = false;
                spriteFactory.FireballAttack(this);
            }
            aquamentusState.Update();

            drawLocation.X = drawLocation.X + velocity.X;
            drawLocation.Y = drawLocation.Y + velocity.Y;
        }
        */
    }
}
