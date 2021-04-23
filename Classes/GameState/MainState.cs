using CSE3902_Game_Sprint0.Classes.Level;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class MainState : IGameState
    {
        public ZeldaGame game { get; set; }
        public Room currentRoom { get; set; }
        public MainState(ZeldaGame game, Room room)
        {
            this.game = game;
            this.currentRoom = room;
        }

        public void Draw()
        {
            game.GraphicsDevice.Clear(Color.Black);

            currentRoom.Draw();

            game.link.Draw();
            if (game.twoPlayer)
            {
                game.littleHelper.Draw();
            }

            game.projectileHandler.Draw();
        }
        public void UpdateCollisions()
        {
            game.controllerList[0].Update();
            game.controllerList[1].Update();
        }
        public void Update()
        {
            game.link.Update();
            if (game.twoPlayer)
            {
                game.littleHelper.Update();
            }

            currentRoom.Update();

            game.projectileHandler.Update();

            game.collisionManager.Update();

        }
    }
}
