using CSE3902_Game_Sprint0.Classes.Header.HeaderUtility;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;

namespace CSE3902_Game_Sprint0.Classes.Header
{
    public class playerHUD
    {

        public HUDStorage storage { get; set; }
        public HUDHelper helper { get; set; }

        //static sprites:
        private ZeldaGame game { get; set; }
        private ISprite hudSprite { get; set; }
        private ISprite primWeapSprite { get; set; }
        private ISprite secWeapSprite { get; set; }
        private ISprite gameLevelSprite { get; set; }
        private int xpCount { get; set; }

        //counter sprites:
        private ISprite xSprite { get; set; }
        //background sprites:
        private ISprite top { get; set; }
        private ISprite bottom { get; set; }
        private ISprite right { get; set; }
        private ISprite left { get; set; }
        //digit positions:
        public Vector2 digitKeyPos;
        public Vector2 digitBombPos;
        public Vector2 digitYrupPos;
        public Vector2 YellowCounterPos;
        public Vector2 BombCounterPos;
        public Vector2 KeyCounterPos;

        private HudSpriteFactory HudFactory { get; set; }

        //general hud positions:
        public Vector2 hudPosition;
        public Vector2 primWeapPos;
        public Vector2 secWeapPos;
        public Vector2 gameLevelPos;
        public Vector2 heartPos;
        public Vector2 xpPos;
        public Vector2 linkLevelPos;
        public Vector2 minimapPos;
        public Vector2 linkIndicatorPos;
        public Vector2 bossPos;
        public float spriteScalar { get; set; }
        public Vector2 drawLocation;

        //top left corner coordinates of HUD:
        private readonly int X, Y;

        public playerHUD(ZeldaGame game, HudSpriteFactory hudFactory)
        {
            //general:
            this.game = game;
            storage = new HUDStorage(game);
            helper = new HUDHelper(game);
            spriteScalar = game.util.hudScalar;
            HudFactory = hudFactory;
            //---------------------------------------------------------------------------------------------------
            //sprite initialization:
            hudSprite = HudFactory.baseHud();
            primWeapSprite = HudFactory.primaryWeaponHUD();
            secWeapSprite = HudFactory.secondaryWeaponHUD();
            gameLevelSprite = HudFactory.levelHUD();
            xSprite = HudFactory.xHUD();
            top = HudFactory.top();
            bottom = HudFactory.bottom();
            right = HudFactory.right();
            left = HudFactory.left();
            //---------------------------------------------------------------------------------------------------
            //Position Initialization:
            X = storage.HUD_Main_X;
            Y = storage.HUD_Main_Y;
            hudPosition = new Vector2(X, Y);
            primWeapPos = storage.primaryWeaponPosition;
            secWeapPos = storage.secondaryWeaponPosition;
            gameLevelPos = storage.gameLevelPosition;
            heartPos = storage.heartPosition;
            digitKeyPos = storage.digitKeyPosition;
            KeyCounterPos = storage.keyCountPosition;
            digitBombPos = storage.digitBombPosition;
            BombCounterPos = storage.bombCountPosition;
            digitYrupPos = storage.digitYellowRuppeePosition;
            YellowCounterPos = storage.yellowruppeeCountPosition;
            xpPos = storage.xpPosition;
            linkLevelPos = storage.linkLevelPosition;
            minimapPos = storage.minimapPosition;
            bossPos = storage.bossPosition;
            linkIndicatorPos = storage.linkIndicatorPosition;
        }

        public void Update()
        {
            xpCount = game.util.numXP % game.util.XPPerLevel;
            secWeapSprite = HudFactory.secondaryWeaponHUD();
            helper.minimapCorrespondence();
        }

        public void Draw()
        {
            //background displays:
            top.Draw(storage.topPosition);
            bottom.Draw(storage.bottomPosition);
            right.Draw(storage.rightPosition);
            left.Draw(storage.leftPosition);
            //-----------------------------------------------------------------------------------------
            //static displays:
            hudSprite.Draw(hudPosition);
            primWeapSprite.Draw(primWeapPos);
            secWeapSprite.Draw(secWeapPos);
            xSprite.Draw(KeyCounterPos);
            xSprite.Draw(YellowCounterPos);
            xSprite.Draw(BombCounterPos);
            gameLevelSprite.Draw(gameLevelPos);
            //-------------------------------------------------------------------------------------
            //Lives Graphical Displays:
            helper.DisplayHeartSystem();
            helper.DisplayKeySystem();
            helper.DisplayBombSystem();
            helper.DisplayRupSystem();
            helper.DisplayMiniMap();
            helper.DisplayXPSystem(xpCount);
            //-------------------------------------------------------------------------------
        }
    }
}
