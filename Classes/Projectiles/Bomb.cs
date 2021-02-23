using System;
using System.Collections.Generic;
using System.Text;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.Projectiles
{
    public class Bomb : ISecondaryEntity
    {
        public EeveeSim game;
        public Link link = null;
        public LinkStateMachine linkState = null;
        public ItemSpriteFactory spriteFactory;
        private Texture2D bombTexture;
        public ISprite bombSprite;
        public Vector2 drawLocation;
        public Vector2 spawnLocation;
        public Vector2 spriteSize = new Vector2(16, 16);
        private Bomb bomb;
        private BombStateMachine myState;

        public Bomb(EeveeSim game, Link link, LinkStateMachine linkState)
        {
            this.game = game;
            this.link = link;
            drawLocation = link.drawLocation;
            spriteFactory.SpawnBomb(bomb); // bomb texture
        }
        public void Update()
        {
            myState.Update();
            bombSprite.Update();
        }

        public void Draw()
        {
            bombSprite.Draw(drawLocation);
        }
    }
}
