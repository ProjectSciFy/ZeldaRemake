using CSE3902_Game_Sprint0.Classes.GameState;
using CSE3902_Game_Sprint0.Classes.Level;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.GameCommands.ResetUtility
{
    public class ResetRooms : ICommand
    {
        private readonly ZeldaGame game;
        public ResetRooms(ZeldaGame game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.collisionManager.ClearNotLink();
            game.projectileHandler.Clear();
            game.roomList = new List<Room>();
            game.util.roomNumber = 2;
            for (int i = 1; i < 20; i++)
            {
                game.roomList.Add(Parser.ParseRoomCSV(game, i));
            }
            game.currentRoom = game.roomList[1];

            game.currentRoom.Initialize();
            game.currentMainGameState = new MainState(game, game.currentRoom);
            game.currentGameState = game.currentMainGameState;
        }
    }
}
