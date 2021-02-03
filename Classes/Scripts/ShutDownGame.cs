using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes
{
    public class ShutDownGame : ICommand
    {
        //TheGame var to close
        private EeveeSim closeThis;

        //Constructor
        public ShutDownGame(EeveeSim ongoingGame)
        {
            closeThis = ongoingGame;
        }

        //Quit the provided game
        public void Execute()
        {
            closeThis.Exit();
        }
    }
}
