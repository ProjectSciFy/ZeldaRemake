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

namespace CSE3902_Game_Sprint0
{

    public class ZeldaGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public List<IController> controllerList = new List<IController>();

        public Dictionary<string, Texture2D> spriteSheets = new Dictionary<string, Texture2D>();
        public EnemySpriteFactory enemySpriteFactory;
        public ProjectileSpriteFactory projectileSpriteFactory;
        public HudSpriteFactory hudSpriteFactory;

        public LinkStateMachine linkStateMachine;
        public BombStateMachine bombStateMachine;

        public Classes.Link link;
        public Classes.Projectiles.Bomb bomb;

        public ProjectileHandler projectileHandler;
        public CollisionManager collisionManager;

        public List<Room> roomList;
        public Dictionary<int, int[]> neighbors;
        public Room currentRoom;
        public Room oldRoom;

        public IGameState currentMainGameState;
        public IGameState currentGameState;

        public GameUtility util;
        public ZeldaGame()
        {
            this.util = new GameUtility();
            _graphics = new GraphicsDeviceManager(this);
            //SIZE OF SCREEN 
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 896;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            //Setting up CollisionManager
            collisionManager = new CollisionManager();
            //Setting up projectileHandler
            projectileSpriteFactory = new ProjectileSpriteFactory(this);
            projectileHandler = new ProjectileHandler(this);
            /* LINK */
            //set StateMachine and Link to be used:
            link = new Classes.Link(this);
            linkStateMachine = new LinkStateMachine(link);
            //link is now created, maintains an instance of StateMachine to be passed around for commands:
            link.SetState(linkStateMachine);
            //Setting up playerHudSpriteFactory
            hudSpriteFactory = new HudSpriteFactory(this);
            //Setting up enemy spritefactory
            enemySpriteFactory = new EnemySpriteFactory(this);
            controllerList.Add(new CKeyboard(this));
            controllerList.Add(new CMouse(this));
            neighbors = Parser.ParseNeighborCSV();
            roomList = new List<Room>();
            //18 rooms
            for (int i = 1; i < 19; i++)
            {
                roomList.Add(Parser.ParseRoomCSV(this, i));
            }
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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Loading all of our textures into a texture dictionary
            spriteSheets.Add("Link", Content.Load<Texture2D>("NES - The Legend of Zelda - Link"));
            spriteSheets.Add("HUD", Content.Load<Texture2D>("NES - The Legend of Zelda - HUD & Pause Screen"));
            spriteSheets.Add("ItemsAndWeapons", Content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons"));
            spriteSheets.Add("NPC", Content.Load<Texture2D>("NES - The Legend of Zelda - NPCs"));
            spriteSheets.Add("DungeonEnemies", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies"));
            spriteSheets.Add("Bosses", Content.Load<Texture2D>("NES - The Legend of Zelda - Bosses"));
            spriteSheets.Add("DungeonBackgrounds", Content.Load<Texture2D>("Level 1 (Eagle)"));
            spriteSheets.Add("DungeonTileset", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset"));
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            currentGameState.UpdateCollisions();
            base.Update(gameTime);
            currentGameState.Update();
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
