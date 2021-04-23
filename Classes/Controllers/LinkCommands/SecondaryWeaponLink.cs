namespace CSE3902_Game_Sprint0.Classes.Controllers.LinkCommands
{
    public class SecondaryWeaponLink : ICommand
    {
        private LinkStateMachine linkState { get; set; }
        private LinkStateMachine.Weapon weaponSelected { get; set; }

        public SecondaryWeaponLink(LinkStateMachine linkState)
        {
            this.linkState = linkState;
        }
        public void Execute()
        {
            this.weaponSelected = linkState.weaponSelected;
            // need to update link's state so that corresponding animation is drawn.
            switch (weaponSelected)
            {
                case LinkStateMachine.Weapon.bomb:
                    linkState.useBomb = true;
                    break;

                case LinkStateMachine.Weapon.arrow:
                    linkState.useArrow = true;
                    break;

                case LinkStateMachine.Weapon.boomerang:
                    linkState.useBoomerang = true;
                    break;
            }
        }
    }
}
