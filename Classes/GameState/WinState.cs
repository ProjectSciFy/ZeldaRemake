using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class WinState : IGameState
    {
        private ZeldaGame game { get; set; }
        private Triforce triforce;
        private Vector2 position;

        public WinState(ZeldaGame game)
        {
            this.game = game;
            position.X = game.link.drawLocation.X + (3 * game.link.spriteScalar);
            position.Y = game.link.drawLocation.Y - (10 * game.link.spriteScalar);
            triforce = new Triforce(this.game, new ItemSpriteFactory(this.game), position);
        }

        void IGameState.Draw()
        {
            game.link.Draw();
            triforce.Draw();
        }

        void IGameState.Update()
        {
            game.controllerList[0].Update();
            game.controllerList[1].Update();
            if (game.link.linkState.grabItem == true && game.link.linkState.isTriforce == true)
            {
                game.link.Update();
                MediaPlayer.Stop();
            }
        }

        void IGameState.UpdateCollisions()
        {
            
        }
    }
}
