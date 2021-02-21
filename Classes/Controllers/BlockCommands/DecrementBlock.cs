using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.BlockCommands
{
    public class DecrementBlock : ICommand
    {
        private TilesSpriteFactory blockFactory;
        public DecrementBlock(TilesSpriteFactory blockFactory)
        {
            this.blockFactory = blockFactory;
        }
        public void Execute()
        {
            if (this.blockFactory.currentBlock > 0)
            {
                this.blockFactory.changeBlock(this.blockFactory.currentBlock - 1); 
            }
            else //first block in list, currentBlock == 0, cycle to last in list, index 9
            {
                this.blockFactory.changeBlock(9);
            }
        }
    }
}
