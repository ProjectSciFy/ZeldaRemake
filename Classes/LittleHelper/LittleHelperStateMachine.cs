using CSE3902_Game_Sprint0.Classes.LittleHelper.LittleHelperScripts;

namespace CSE3902_Game_Sprint0.Classes.LittleHelper
{
    public class LittleHelperStateMachine
    {
        public ZeldaGame game { get; set; }
        public LittleHelper littleHelper { get; set; }
        public LittleHelperSpriteFactory spriteFactory { get; set; }

        public bool interacting { get; set; } = false;
        public enum CurrentState { none, flying, interacting }
        public CurrentState currentState { get; set; } = CurrentState.none;
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
