using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Controllers.BlockCommands
{
    public class IncrementBlock : ICommand
    {
        private TilesSpriteFactory blockFactory;
        public IncrementBlock(TilesSpriteFactory blockFactory)
        {
            this.blockFactory = blockFactory;
        }
        public void Execute()
        {
            if (this.blockFactory.currentBlock < 9)
            {
                this.blockFactory.currentBlock++;
            }
            else //last block in list, currentBlock == 9, cycle to first in list, index 0
            {
                this.blockFactory.currentBlock = 0;
            }
        }
    }
}
