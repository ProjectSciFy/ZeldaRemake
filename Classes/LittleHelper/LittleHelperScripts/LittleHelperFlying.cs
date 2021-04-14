using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LittleHelper.LittleHelperScripts
{
    public class LittleHelperFlying : ICommand
    {
        private LittleHelper littleHelper;
        private LittleHelperSpriteFactory spriteFactory;
        private LittleHelperStateMachine littleHelperStateMachine;
        public LittleHelperFlying(LittleHelper littleHelper, LittleHelperSpriteFactory spriteFactory, LittleHelperStateMachine littleHelperStateMachine)
        {
            this.littleHelper = littleHelper;
            this.spriteFactory = spriteFactory;
            this.littleHelperStateMachine = littleHelperStateMachine;
        }

        public void Execute()
        {
            if (littleHelperStateMachine.currentState != LittleHelperStateMachine.CurrentState.flying)
            {
                littleHelper.spriteSize.X = 16;
                littleHelper.spriteSize.Y = 16;
                littleHelperStateMachine.currentState = LittleHelperStateMachine.CurrentState.flying;
                littleHelper.mySprite = spriteFactory.Flying();
            }
        }
    }
}
