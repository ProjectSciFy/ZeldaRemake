using System;

namespace CSE3902_Game_Sprint0
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new ZeldaGame())
                game.Run();
        }
    }
}
