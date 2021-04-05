using CSE3902_Game_Sprint0.Classes.Level;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
   public class MainState : IGameState
    {
        public ZeldaGame game;
        public Room currentRoom;
        public MainState(ZeldaGame game, Room room)
        {
            this.game = game;
            this.currentRoom = room;
            this.game.util.linkInd = true;
        }

        public void Draw()
        {
            game.GraphicsDevice.Clear(Color.Black);

            currentRoom.Draw();

            game.link.Draw();

            game.projectileHandler.Draw();
        }
        public void UpdateCollisions()
        {
            foreach (IController controller in game.controllerList)
            {
                controller.Update();
            }
        }
        public void Update()
        {
            game.util.linkInd = true;

            game.link.Update();

            currentRoom.Update();

            game.projectileHandler.Update();

            game.collisionManager.Update();

        }
    }
}
