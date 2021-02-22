using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    class Bomb : ISecondaryEntity
    {
        public EeveeSim game;
        public Link link = null;
        public LinkStateMachine linkState = null;
        public ItemSpriteFactory spriteFactory;
        public ISprite mySprite;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 spriteSize = new Vector2(0, 0);
        //public int BombTimer = 
        public enum Direction { right, up, left, down }; 
        public Direction direction = Direction.down;

        public Bomb(EeveeSim game, Link link, LinkStateMachine linkState)
        {
            this.game = game;
            this.link = link;
            drawLocation = link.drawLocation;
        }
        public void Update()
        {


        }

        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
