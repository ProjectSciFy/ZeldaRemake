using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Scripts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent
{
    public class FogOfWar : IEnemy
    {
        public ZeldaGame game { get; set; }
        private Vector2 drawLocation;
        private Vector2 spriteSize = new Vector2(1544, 352);
        private UniversalSprite mySprite;
        private FogOfWarSpriteFactory fogOfWarSpriteFactory;
        public float spriteScalar { get; set; }

        public FogOfWar(ZeldaGame game)
        {
            this.game = game;
            this.spriteScalar = game.util.spriteScalar;
            drawLocation.X = game.link.drawLocation.X + (game.link.spriteSize.X / 2) - (spriteSize.X / 2);
            drawLocation.Y = game.link.drawLocation.Y + (game.link.spriteSize.Y / 2) - (spriteSize.Y / 2);
            fogOfWarSpriteFactory = new FogOfWarSpriteFactory(this);
            mySprite = fogOfWarSpriteFactory.FogOfWar();
        }
        public void TakeDamage(int damage)
        {
            //Can't hurt this
        }
        public void Update()
        {
            drawLocation.X = game.link.drawLocation.X + (game.link.spriteSize.X * spriteScalar / 2) - (spriteSize.X * spriteScalar / 2);
            drawLocation.Y = game.link.drawLocation.Y + (game.link.spriteSize.Y * spriteScalar / 2) - (spriteSize.Y * spriteScalar / 2);
        }
        public void Draw()
        {
            mySprite.Draw(drawLocation);
        }
    }
}
