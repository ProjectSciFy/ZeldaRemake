﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Scripts
{
    class DrawSprite : ICommand
    {
        private EeveeSim game;
        private Texture2D texture;
        private ISprite sprite;
        private Vector2 drawLocation;
        private Vector2 velocity;
        private Rectangle spriteIndex;
        private Color color;
        private bool isAnimated;
        private Vector2 frameGrid;

        public DrawSprite(EeveeSim game, Texture2D texture, ISprite sprite, Vector2 drawLocation, Vector2 velocity, Rectangle spriteIndex, Color color, Vector2 frameGrid)
        {
            this.game = game;
            this.texture = texture;
            this.sprite = sprite;
            this.drawLocation = drawLocation;
            this.velocity = velocity;
            this.spriteIndex = spriteIndex;
            this.color = color;
            if ((int)(frameGrid.X * frameGrid.Y) > 1)
            {
                this.isAnimated = true;
                this.frameGrid = frameGrid;
            }
        }

        public void Execute()
        {
            if (isAnimated)
            {
                game.eeveeSprite = new AnimatedSprite(game, texture, drawLocation, velocity, spriteIndex, color, frameGrid);
            } 
            else
            {
                game.eeveeSprite = new StaticSprite(game, texture, drawLocation, velocity, spriteIndex, color);
            }
        }
    }
}