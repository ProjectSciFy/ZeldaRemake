using CSE3902_Game_Sprint0.Classes.Header;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Game_Sprint0.Classes.GameState
{
    public class ItemSelectState : IGameState
    {
        private ZeldaGame game { get; set; }
        public Room currentRoom { get; set; }
        private readonly Texture2D inventorySpriteSheet;


        private readonly ISprite top, mid;

        private float itemDepth { get; set; } = 0.4f;

        //player hud related variables:
        private playerHUD pHUD { get; set; }

        private HudSpriteFactory HudFactory { get; set; }

        private readonly ISprite holdingMap;
        private readonly ISprite holdingCompass;
        private ISprite secweaponHolding;
        private ISprite secweaponOne;
        private ISprite secweaponTwo;
        private ISprite secweaponThree;

        private ItemSelectStateStorage storage { get; set; }
        public ItemSelectState(ZeldaGame game)
        {
            this.storage = new ItemSelectStateStorage();
            this.game = game;
            game.spriteSheets.TryGetValue("HUD", out inventorySpriteSheet);
            HudFactory = game.hudSpriteFactory;
            top = new UniversalSprite(game, inventorySpriteSheet, storage.topRectangle, Color.White, SpriteEffects.None, new Vector2(1, 1), storage.fpsLimiter, itemDepth);
            mid = new UniversalSprite(game, inventorySpriteSheet, storage.midRectangle, Color.White, SpriteEffects.None, new Vector2(1, 1), storage.fpsLimiter, itemDepth);
            holdingMap = new UniversalSprite(game, inventorySpriteSheet, storage.mapRectangle, Color.White, SpriteEffects.None, new Vector2(1, 1), storage.fpsLimiter, itemDepth);
            holdingCompass = new UniversalSprite(game, inventorySpriteSheet, storage.compassRectangle, Color.White, SpriteEffects.None, new Vector2(1, 1), storage.fpsLimiter, itemDepth);
            pHUD = game.currentRoom.pHUD;
            secweaponHolding = HudFactory.blankBox();
            secweaponOne = HudFactory.blankBox();
            secweaponTwo = HudFactory.blankBox();
            secweaponThree = HudFactory.blankBox();
        }

        void IGameState.Draw()
        {
            game.currentRoom.Draw();
            game.link.Draw();
            pHUD.Draw();
            mid.Draw(game.util.midPos);
            top.Draw(game.util.topPos);
            if (game.util.hasMap) { holdingMap.Draw(new Vector2(game.util.midPos.X + storage.mapXAdjust, game.util.midPos.Y + storage.mapYAdjust)); }
            if (game.util.hasCompass) { holdingCompass.Draw(new Vector2(game.util.midPos.X + storage.compassXAdjust, game.util.midPos.Y + storage.compassYAdjust)); }
            secweaponHolding.Draw(new Vector2(game.util.topPos.X + storage.weaponHoldingXAdjust, game.util.topPos.Y + storage.weaponYAdjust));
            secweaponOne.Draw(new Vector2(game.util.topPos.X + storage.weapon1XAdjust, game.util.topPos.Y + storage.weaponYAdjust));
            secweaponTwo.Draw(new Vector2(game.util.topPos.X + storage.weapon2XAdjust, game.util.topPos.Y + storage.weaponYAdjust));
            secweaponThree.Draw(new Vector2(game.util.topPos.X + storage.weapon3XAdjust, game.util.topPos.Y + storage.weaponYAdjust));
        }

        void IGameState.Update()
        {
            pHUD = game.currentRoom.pHUD;
            pHUD.Update();
            game.util.inSelect = true;
            if (game.util.selectSpeed < 0)
            {
                if (pHUD.hudPosition.Y > storage.hudTopPos) { ItemScreenPositionalUpdate(game.util.selectSpeed); }
                else { game.currentGameState = game.currentMainGameState; game.util.inSelect = false; }
            }
            else { if (pHUD.hudPosition.Y < storage.hudBotPos) ItemScreenPositionalUpdate(game.util.selectSpeed); }
            game.controllerList[0].Update();
            game.controllerList[2].Update();
            secweaponHolding = HudFactory.secondaryWeaponHUD();
            switch (game.link.linkState.weaponSelected)
            {
                case LinkStateMachine.Weapon.bomb:
                    secweaponOne = HudFactory.blankBox();
                    secweaponTwo = HudFactory.staticBoomerang();
                    if (game.util.hasBow) { secweaponThree = HudFactory.staticBow(); }
                    else { secweaponThree = HudFactory.blankBox(); }
                    break;
                case LinkStateMachine.Weapon.boomerang:
                    secweaponOne = HudFactory.staticBomb();
                    secweaponTwo = HudFactory.blankBox();
                    if (game.util.hasBow) { secweaponThree = HudFactory.staticBow(); }
                    else { secweaponThree = HudFactory.blankBox(); }
                    break;
                case LinkStateMachine.Weapon.arrow:
                    secweaponOne = HudFactory.staticBomb();
                    secweaponTwo = HudFactory.staticBoomerang();
                    if (game.util.hasBow) { secweaponThree = HudFactory.blankBox(); }
                    break;
                default:
                    break;
            }
        }
        void IGameState.UpdateCollisions()
        {

        }
        void ItemScreenPositionalUpdate(int speed)
        {
            //hud update:
            pHUD.hudPosition.Y += speed;
            pHUD.YellowCounterPos.Y += speed;
            pHUD.BombCounterPos.Y += speed;
            pHUD.KeyCounterPos.Y += speed;
            pHUD.digitKeyPos.Y += speed;
            pHUD.digitBombPos.Y += speed;
            pHUD.digitYrupPos.Y += speed;
            pHUD.primWeapPos.Y += speed;
            pHUD.secWeapPos.Y += speed;
            pHUD.heartPos.Y += speed;
            //sprite for "Level 1" text is apart of hudPosition.Y, no need to update it manually.
            pHUD.minimapPos.Y += speed;
            pHUD.bossPos.Y += speed;
            pHUD.gameLevelPos.Y += speed;
            //pHUD.linkIndicatorPos.Y += speed;
            pHUD.xpPos.Y += speed;
            pHUD.linkLevelPos.Y += speed;
            //item screen update:
            game.util.midPos.Y += speed;
            game.util.topPos.Y += speed;
        }
    }
}
