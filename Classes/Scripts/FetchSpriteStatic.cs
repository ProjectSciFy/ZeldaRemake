using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Scripts
{
    class FetchSpriteStatic : ICommand
    {
        private ISprite sprite;

        //Sprite to be overwritten
        public FetchSpriteStatic(ISprite sprite, )
        {
            this.sprite = sprite;
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
