using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.LittleHelper.LittleHelperScripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LittleHelper
{
    public class LittleHelperStateMachine
    {
        public ZeldaGame game;
        public LittleHelper littleHelper;
        public LittleHelperSpriteFactory spriteFactory;

        public bool interacting = false;
        public enum CurrentState { none, flying, interacting}
        public CurrentState currentState = CurrentState.none;
        public LittleHelperStateMachine(LittleHelper littleHelper)
        {
            game = littleHelper.game;
            this.littleHelper = littleHelper;
            spriteFactory = new LittleHelperSpriteFactory(littleHelper);
        }

        public void Flying()
        {
            new LittleHelperFlying(littleHelper, spriteFactory, this).Execute();
        }

        public void Interacting()
        {
            interacting = false;
            new LittleHelperInteracting(littleHelper, spriteFactory, this).Execute();
        }

        public void Update()
        {
            if (interacting)
            {
                Interacting();
            }
            else
            {
                Flying();
            }
        }
    }
}
