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
        //Sprite factories
        public EnemySpriteFactory enemySpriteFactory;
        public ProjectileSpriteFactory projectileSpriteFactory;
        //Player HUD:
        public HudSpriteFactory hudSpriteFactory;
        //Link:
        public Classes.Link link;
        public enum Enemies { Stalfos, Gel, Keese, BladeTrap, Goriya, Aquamentus, Wallmaster, OldMan}
        public LinkStateMachine linkStateMachine;
        public BombStateMachine bombStateMachine;
        public Classes.Projectiles.Bomb bomb;
        public ProjectileHandler projectileHandler;

        public CollisionManager collisionManager;

        public int roomNumber;
        public List<Room> roomList;
        public Dictionary<int, int[]> neighbors;
        
        //PASS THIS TO ENTITIES FOR UPSCALING THEM UNIFORMLY
        public float spriteScalar = 3;
        public Room currentRoom;

        //Seperate scalar for all HUD entities, still needs proper implementation:
        public float hudScalar = 1;
        //counter variables that are displayed in HUD graphically:
        public int numKeys;
        public int numBrups;
        public int numYrups;
        public int numLives;

        public IGameState currentMainGameState;
        public IGameState currentGameState;

        public bool keyPressedTempVariable = false;

        public ZeldaGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            //SIZE OF SCREEN 
            _graphics.PreferredBackBufferWidth = 1024;
            _graphics.PreferredBackBufferHeight = 768;
            //_graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            /* Weapons */
            //bomb = new Bomb(this, link, linkStateMachine);
            //bombStateMachine = new BombStateMachine(bomb);

            //Setting up playerHudSpriteFactory
            hudSpriteFactory = new HudSpriteFactory(this);
            //Initialize counter variables for HUD:
            numKeys = 0;
            numBrups = 0;
            numYrups = 0;
            numLives = 3;

            //Setting up enemy spritefactory
            enemySpriteFactory = new EnemySpriteFactory(this);

            controllerList.Add(new CKeyboard(this));
            controllerList.Add(new CMouse(this));

            neighbors = Parser.ParseNeighborCSV();

            roomList = new List<Room>();
            roomNumber = 2;

            for (int i = 1; i < 19; i++)
            {
                roomList.Add(Parser.ParseRoomCSV(this, i));
            }
            foreach (Room r in roomList)
            {
                if (r.getRoomNumber() == roomNumber)
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

            // TODO: use this.Content to load your game content here

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

            //if (Keyboard.GetState().IsKeyDown(Keys.D7) && !keyPressedTempVariable)
            //{
            //    if (roomNumber == 18)
            //    {
            //        changeRoom(0,0);
            //    }
            //    else
            //    {
            //        changeRoom(roomNumber + 1,0);
            //    }
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.D8) && !keyPressedTempVariable)
            //{
            //    if (roomNumber == 18)
            //    {
            //        changeRoom(0,0);
            //    }
            //    else
            //    {
            //        changeRoom(roomNumber + 1, 1);
            //    }
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.D9) && !keyPressedTempVariable)
            //{
            //    if (roomNumber == 18)
            //    {
            //        changeRoom(0,0);
            //    }
            //    else
            //    {
            //        changeRoom(roomNumber + 1, 2);
            //    }
            //}
            //else if (Keyboard.GetState().IsKeyDown(Keys.D0) && !keyPressedTempVariable)
            //{
            //    if (roomNumber == 18)
            //    {
            //        changeRoom(0,0);
            //    }
            //    else
            //    {
            //        changeRoom(roomNumber + 1, 3);
            //    }
            //}
            // TODO: Add your update logic here

            //sforeach (IController controller in controllerList)
            //{
            //   controller.Update();
            //}
            //
            currentGameState.UpdateCollisions();
            base.Update(gameTime);
            currentGameState.Update();
            //link.Update();

            //currentRoom.Update();

            //projectileHandler.Update();

            //collisionManager.Update();
        }

        public void changeRoom(int newRoom, Collision.Direction direction)
        {
            keyPressedTempVariable = true;
            Room oldRoom = currentRoom;
            collisionManager.ClearNotLink();
            roomNumber = newRoom;
            foreach (Room r in roomList)
            {
                if (r.getRoomNumber() == newRoom)
                {
                    currentRoom = r;
                }
            }
            //Wait for a quarter of a second before transition to next room
            //Fixes holding down mouse -> spamming through each room
            //Clear the collision set

            currentMainGameState = new MainState(this, currentRoom);
            //currentGameState = currentMainGameState;
            currentGameState = new TransitionState(this, oldRoom, currentRoom, direction);
            //7keyPressedTempVariable = false;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
            currentGameState.Draw();


            //currentRoom.Draw();

            //link.Draw();

            //projectileHandler.Draw();



        }
    }
}
