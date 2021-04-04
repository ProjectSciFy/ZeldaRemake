using System;
using System.Collections.Generic;
using System.Text;

namespace CSE3902_Game_Sprint0.Classes.LinkContent.LinkScripts
{
    public class SecondaryWeaponSelect : ICommand
    {
        private LinkStateMachine state;
        private LinkStateMachine.Weapon weapon;
        public SecondaryWeaponSelect(LinkStateMachine state, LinkStateMachine.Weapon weapon)
        {
            this.state = state;
            this.weapon = weapon;
        }
        public void Execute() 
        {
            state.weaponSelected = weapon;
        }
    }
}
