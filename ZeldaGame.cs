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

namespace CSE3902_Game_Sprint0
{

    public class ZeldaGame : Game
    {
        //GENERAL STUFF
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //CONTROLLERS
        public List<IController> controllerList = new List<IController>();
        //UTILITY STORAGE
        public GameUtility util;
        //SPRITE SHEETS
        public Dictionary<string, Texture2D> spriteSheets = new Dictionary<string, Texture2D>();
        //SOUNDS
        public Song song;
        public Dictionary<string, SoundEffect> sounds = new Dictionary<string, SoundEffect>();
        //SPRITE FACTORIES
        public EnemySpriteFactory enemySpriteFactory;
        public ProjectileSpriteFactory projectileSpriteFactory;
        public HudSpriteFactory hudSpriteFactory;
        //STATE MACHINES
        public LinkStateMachine linkStateMachine;
        public BombStateMachine bombStateMachine;
        //LINK
        public Classes.Link link;
        //COLLISIONS
        public ProjectileHandler projectileHandler;
        public CollisionManager collisionManager;
        //ROOMS
        public List<Room> roomList;
        public Dictionary<int, int[]> neighbors;
        public Room currentRoom;
        public Room oldRoom;
        //GAME STATES
        public IGameState currentMainGameState;
        public IGameState currentGameState;

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
            //COLLISIONS
            collisionManager = new CollisionManager();
            //PROJECTILES
            projectileSpriteFactory = new ProjectileSpriteFactory(this);
            projectileHandler = new ProjectileHandler(this);
            //LINK
            link = new Classes.Link(this);
            linkStateMachine = new LinkStateMachine(link);
            link.SetState(linkStateMachine);
            //HUD
            hudSpriteFactory = new HudSpriteFactory(this);
            //ENEMIES
            enemySpriteFactory = new EnemySpriteFactory(this);
            //CONTROLLERS
            controllerList.Add(new CKeyboard(this));
            controllerList.Add(new CMouse(this));
            //ROOMS
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
            //GAME STATE
            currentMainGameState = new MainState(this, currentRoom);
            currentGameState = currentMainGameState;
            //BACKGROUND MUSIC
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //SPRITE SHEETS
            spriteSheets.Add("Link", Content.Load<Texture2D>("NES - The Legend of Zelda - Link"));
            spriteSheets.Add("HUD", Content.Load<Texture2D>("NES - The Legend of Zelda - HUD & Pause Screen"));
            spriteSheets.Add("ItemsAndWeapons", Content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons"));
            spriteSheets.Add("NPC", Content.Load<Texture2D>("NES - The Legend of Zelda - NPCs"));
            spriteSheets.Add("DungeonEnemies", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies"));
            spriteSheets.Add("Bosses", Content.Load<Texture2D>("NES - The Legend of Zelda - Bosses"));
            spriteSheets.Add("DungeonBackgrounds", Content.Load<Texture2D>("Level 1 (Eagle)"));
            spriteSheets.Add("DungeonTileset", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset"));
            //SOUNDS
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

            //COLLISIONS
            currentGameState.UpdateCollisions();
            //GENERAL
            base.Update(gameTime);
            //GAME STATE
            currentGameState.Update();
            if (util.numLives <= 0 && link.linkState.currentState != LinkStateMachine.CurrentState.dying)
            {
                MediaPlayer.Stop();
                currentGameState = new DeathState(this);
            }
        }

        /*
         * Change room smooothly from room number util.roomNumber to room number newRoom
         */
        public void changeRoom(int newRoom, Collision.Direction direction)
        {
            util.keyPressedTempVariable = true;
            oldRoom = currentRoom;
            //CLEAR COLLISIONS
            collisionManager.ClearNotLink();
            projectileHandler.Clear();
            util.roomNumber = newRoom;
            //FIND NEW ROOM
            foreach (Room r in roomList)
            {
                if (r.getRoomNumber() == newRoom)
                {
                    currentRoom = r;
                }
            }
            //TRANSITION STATE
            currentMainGameState = new MainState(this, currentRoom);
            currentGameState = new TransitionState(this, oldRoom, currentRoom, direction);
        }

        protected override void Draw(GameTime gameTime)
        {
            //BLACK BACKGROUND
            GraphicsDevice.Clear(Color.Black);
            //GENERAL
            base.Draw(gameTime);
            //GAME STATE
            currentGameState.Draw();
        }
    }
}
