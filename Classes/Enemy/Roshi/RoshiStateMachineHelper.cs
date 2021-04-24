using CSE3902_Game_Sprint0.Classes.Enemy.Roshi.RoshiScripts;

namespace CSE3902_Game_Sprint0.Classes.Enemy.Roshi
{
    public class RoshiStateMachineHelper
    {
        public EnemyRoshi roshi;
        public RoshiStateMachine roshiState;
        public RoshiSpriteFactory spriteFactory;
        public ZeldaGame game;
        public RoshiStateMachineHelper(EnemyRoshi roshi, RoshiStateMachine roshiState)
        {
            this.game = roshi.game;
            this.roshi = roshi;
            this.roshiState = roshiState;
            spriteFactory = new RoshiSpriteFactory(game);
        }
        public void Spawning() { new RoshiSpawning(roshi, spriteFactory, roshiState).Execute(); }
        public void Dying() { new RoshiDying(roshi, spriteFactory, roshiState).Execute(); }
        public void Damaged() { new RoshiDamaged(roshi, spriteFactory, roshiState).Execute(); }
        public void Moving() { new RoshiMoving(roshi, spriteFactory, roshiState).Execute(); }
        public void KiBlast() { new RoshiKiBlast(roshi, spriteFactory, roshiState).Execute(); }
        public void Kamehameha() { new RoshiKamehameha(roshi, spriteFactory, roshiState).Execute(); }
        public void Lift()
        {
            roshi.drawLocation = roshi.spawnLocation;
            new RoshiLift(roshi, spriteFactory, roshiState).Execute();
        }
        public void Charge() { new RoshiCharge(roshi, spriteFactory, roshiState).Execute(); }
        public void Throw() { new RoshiThrow(roshi, spriteFactory, roshiState).Execute(); }
        public void Hold() { new RoshiHold(roshi, spriteFactory, roshiState).Execute(); }
        public void Explode() { new RoshiExplosion(roshi, spriteFactory, roshiState).Execute(); }
        public void Enrage()
        {
            if (roshiState.enrageTimer == RoshiStateMachineStorage.LIFT_TIMER)
            {
                Lift();
                roshiState.enrageTimer--;
            }
            else if (roshiState.enrageTimer == RoshiStateMachineStorage.CHARGE_TIMER)
            {
                Charge();
                roshiState.enrageTimer--;
            }
            else if (roshiState.enrageTimer == RoshiStateMachineStorage.THROW_TIMER)
            {
                Throw();
                roshiState.enrageTimer--;
            }
            else if (roshiState.enrageTimer == RoshiStateMachineStorage.HOLD_TIMER)
            {
                Hold();
                roshiState.enrageTimer--;
            }
            else if (roshiState.enrageTimer == RoshiStateMachineStorage.EXPLODE_TIMER)
            {
                Explode();
                roshiState.enrageTimer--;
            }
            else if (roshiState.enrageTimer == 0) { game.util.numLives = 0; }
            else { roshiState.enrageTimer--; }
        }
    }
}
