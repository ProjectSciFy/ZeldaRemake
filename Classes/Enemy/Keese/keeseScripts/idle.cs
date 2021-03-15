using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese.keeseScripts
{
    public class idle : ICommand
    {
        private EnemyKeese keese;
        private KeeseSpriteFactory enemySpriteFactory;
        private KeeseStateMachine KeeseStateMachine;
        public idle(EnemyKeese keese, KeeseSpriteFactory enemySpriteFactory, KeeseStateMachine KeeseStateMachine)
        {
            this.keese = keese;
            this.enemySpriteFactory = enemySpriteFactory;
            this.KeeseStateMachine = KeeseStateMachine;
        }
        public void Execute()
        {
            if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.idle)
            {
                KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.idle;
                keese.mySprite = enemySpriteFactory.KeeseIdle();
            }
        }
    }
}