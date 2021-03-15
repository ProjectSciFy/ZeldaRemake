using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Keese.keeseScripts
{
    public class spawning: ICommand
    {
        private EnemyKeese keese;
        private KeeseSpriteFactory enemySpriteFactory;
        private KeeseStateMachine KeeseStateMachine;
        public spawning(EnemyKeese keese, KeeseSpriteFactory enemySpriteFactory, KeeseStateMachine KeeseStateMachine)
        {
            this.keese = keese;
            this.enemySpriteFactory = enemySpriteFactory;
            this.KeeseStateMachine = KeeseStateMachine;
        }
        public void Execute()
        {
            keese.spriteSize.X = 16;
            keese.spriteSize.Y = 16;
            keese.velocity.X = 16;
            keese.velocity.Y = 16;
            if (KeeseStateMachine.currentState != KeeseStateMachine.CurrentState.spawning)
            {
                KeeseStateMachine.currentState = KeeseStateMachine.CurrentState.spawning;
                keese.mySprite = enemySpriteFactory.SpawnKeese();
            }

        }

    }

}