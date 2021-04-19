using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Controllers;
using CSE3902_Game_Sprint0.Classes.Enemy;
using CSE3902_Game_Sprint0.Classes.Enemy.Keese;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using CSE3902_Game_Sprint0.Classes.NewBlocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using CSE3902_Game_Sprint0.Classes.Items;
using CSE3902_Game_Sprint0.Classes.Enemy.Aquamentus;
using CSE3902_Game_Sprint0.Classes.Enemy.Wallmaster;
using CSE3902_Game_Sprint0.Classes.Enemy.OldMan;
using CSE3902_Game_Sprint0.Classes.Projectiles;
using CSE3902_Game_Sprint0.Classes.Collision;
using CSE3902_Game_Sprint0.Classes.Level;
using CSE3902_Game_Sprint0.Classes.GameState;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using CSE3902_Game_Sprint0.Classes.Controllers.CollisionCommands;
using CSE3902_Game_Sprint0.Classes.LittleHelper;

namespace CSE3902_Game_Sprint0
{

    public class ZeldaGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public List<IController> controllerList = new List<IController>();
        public GameUtility util { get; set; }
        public Dictionary<string, Texture2D> spriteSheets = new Dictionary<string, Texture2D>();
        public Song song { get; set; }
        public Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
        public EnemySpriteFactory enemySpriteFactory { get; set; }
        public ProjectileSpriteFactory projectileSpriteFactory { get; set; }
        public HudSpriteFactory hudSpriteFactory { get; set; }
        public LinkStateMachine linkStateMachine { get; set; }
        public BombStateMachine bombStateMachine { get; set; }
        public Classes.Link link { get; set; }
        public LittleHelper littleHelper { get; set; }
        public bool twoPlayer { get; set; } = false;
        public ProjectileHandler projectileHandler { get; set; }
        public CollisionManager collisionManager { get; set; }
        public List<Room> roomList { get; set; }
        public Dictionary<int, int[]> neighbors { get; set; }
        public Room currentRoom { get; set; }
        public Room oldRoom { get; set; }
        public IGameState currentMainGameState { get; set; }
        public IGameState currentGameState { get; set; }

        public ZeldaGame()
        {
            this.util = new GameUtility();
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            //SIZE OF SCREEN 
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 896;
            //DIRECTORY
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            collisionManager = new CollisionManager();
            projectileSpriteFactory = new ProjectileSpriteFactory(this);
            projectileHandler = new ProjectileHandler(this);
            link = new Classes.Link(this);
            linkStateMachine = new LinkStateMachine(link);
            link.SetState(linkStateMachine);
            hudSpriteFactory = new HudSpriteFactory(this);
            enemySpriteFactory = new EnemySpriteFactory(this);
            controllerList.Add(new CKeyboard(this));
            controllerList.Add(new CMouse(this));
            neighbors = Parser.ParseNeighborCSV();
            roomList = new List<Room>();
            /* 18 ROOMS */
            for (int i = 1; i < 19; i++)
            {
                roomList.Add(Parser.ParseRoomCSV(this, i));
            }
            /* SET CURRENT ROOM TO ROOM WITH CURRENT roomNumber */
            foreach (Room r in roomList)
            {
                if (r.getRoomNumber() == util.roomNumber)
                {
                    currentRoom = r;
                }
            }
            currentRoom.Initialize();
            currentMainGameState = new MainState(this, currentRoom);
            currentGameState = currentMainGameState;
            //BACKGROUND MUSIC
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheets.Add("Link", Content.Load<Texture2D>("NES - The Legend of Zelda - Link"));
            spriteSheets.Add("HUD", Content.Load<Texture2D>("NES - The Legend of Zelda - HUD & Pause Screen"));
            spriteSheets.Add("ItemsAndWeapons", Content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons"));
            spriteSheets.Add("NPC", Content.Load<Texture2D>("NES - The Legend of Zelda - NPCs"));
            spriteSheets.Add("DungeonEnemies", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies"));
            spriteSheets.Add("Bosses", Content.Load<Texture2D>("NES - The Legend of Zelda - Bosses"));
            spriteSheets.Add("DungeonBackgrounds", Content.Load<Texture2D>("Level 1 (Eagle)"));
            spriteSheets.Add("DungeonTileset", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset"));
            spriteSheets.Add("Fonts", Content.Load<Texture2D>("NES - The Legend of Zelda - Fonts"));
            spriteSheets.Add("GameOver", Content.Load<Texture2D>("game-over"));

            song = Content.Load<Song>("04 LabyrinthLooped");
            sounds.Add("arrowBoomerang", Content.Load<SoundEffect>("LOZ_Arrow_Boomerang"));
            sounds.Add("bombBlow", Content.Load<SoundEffect>("LOZ_Bomb_Blow"));
            sounds.Add("bombDrop", Content.Load<SoundEffect>("LOZ_Bomb_Drop"));
            sounds.Add("bossHit", Content.Load<SoundEffect>("LOZ_Boss_Hit"));
            sounds.Add("bossScream", Content.Load<SoundEffect>("LOZ_Boss_Scream1"));
            sounds.Add("doorUnlock", Content.Load<SoundEffect>("LOZ_Door_Unlock"));
            sounds.Add("enemyDie", Content.Load<SoundEffect>("LOZ_Enemy_Die"));
            sounds.Add("enemyHit", Content.Load<SoundEffect>("LOZ_Enemy_Hit"));
            sounds.Add("fanfare", Content.Load<SoundEffect>("LOZ_Fanfare"));
            sounds.Add("getHeart", Content.Load<SoundEffect>("LOZ_Get_Heart"));
            sounds.Add("getItem", Content.Load<SoundEffect>("LOZ_Get_Item"));
            sounds.Add("getRupee", Content.Load<SoundEffect>("LOZ_Get_Rupee"));
            sounds.Add("keyAppear", Content.Load<SoundEffect>("LOZ_Key_Appear"));
            sounds.Add("linkDie", Content.Load<SoundEffect>("LOZ_Link_Die"));
            sounds.Add("linkHurt", Content.Load<SoundEffect>("LOZ_Link_Hurt"));
            sounds.Add("lowHealth", Content.Load<SoundEffect>("LOZ_LowHealth"));
            sounds.Add("redeadIdle", Content.Load<SoundEffect>("OOT_ReDead_Moan"));
            sounds.Add("redeadScream", Content.Load<SoundEffect>("OOT_ReDead_Scream"));
            sounds.Add("refillLoop", Content.Load<SoundEffect>("LOZ_Refill_Loop"));
            sounds.Add("secret", Content.Load<SoundEffect>("LOZ_Secret"));
            sounds.Add("shield", Content.Load<SoundEffect>("LOZ_Shield"));
            sounds.Add("stairs", Content.Load<SoundEffect>("LOZ_Stairs"));
            sounds.Add("swordCombined", Content.Load<SoundEffect>("LOZ_Sword_Combined"));
            sounds.Add("swordShoot", Content.Load<SoundEffect>("LOZ_Sword_Shoot"));
            sounds.Add("swordSlash", Content.Load<SoundEffect>("LOZ_Sword_Slash"));
            sounds.Add("text", Content.Load<SoundEffect>("LOZ_Text"));
            sounds.Add("textSlow", Content.Load<SoundEffect>("LOZ_Text_Slow"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentGameState.UpdateCollisions();
            base.Update(gameTime);
            currentGameState.Update();
            if (util.numLives <= 0 && link.linkState.currentState != LinkStateMachine.CurrentState.dying)
            {
                MediaPlayer.Stop();
                currentGameState = new DeathState(this);
            }
            if (util.paused && !util.inSelect)
            {
                MediaPlayer.Pause();
                currentGameState = new PauseState(this);
            }
            else if (!util.paused && currentGameState.GetType() == typeof(PauseState))
            {
                MediaPlayer.Resume();
                currentGameState = currentMainGameState;
            }


            //link indicator:
            if (currentGameState.GetType() == typeof(MainState))
            {
                util.linkInd = true;
            }
            else
            {
                util.linkInd = false;
            }
        }
        public void changeRoom(int newRoom, Collision.Direction direction)
        {
            util.keyPressedTempVariable = true;
            oldRoom = currentRoom;
            collisionManager.ClearNotLink();
            projectileHandler.Clear();
            util.roomNumber = newRoom;
            foreach (Room r in roomList)
            {
                if (r.getRoomNumber() == newRoom)
                {
                    currentRoom = r;
                }
            }
            currentMainGameState = new MainState(this, currentRoom);
            currentGameState = new TransitionState(this, oldRoom, currentRoom, direction);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
            currentGameState.Draw();
        }
    }
}
