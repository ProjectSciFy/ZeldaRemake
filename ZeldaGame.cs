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


namespace CSE3902_Game_Sprint0
{

    public class ZeldaGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList = new List<IController>();
        public Dictionary<string, Texture2D> spriteSheets = new Dictionary<string, Texture2D>();
        //Sprite factories
        public EnemySpriteFactory enemySpriteFactory;
        public ProjectileSpriteFactory projectileSpriteFactory;
        public Classes.Link link;
        // test enemy draws
        public IEnemy stalfos;
        public IEnemy gel;
        public IEnemy keese;
        public IEnemy bladeTrap;
        public IEnemy goriya;
        public IEnemy aquamentus;
        public IEnemy wallmaster;
        public IEnemy oldMan;
        public enum Enemies { Stalfos, Gel, Keese, BladeTrap, Goriya, Aquamentus, Wallmaster, OldMan}
        public Enemies currentEnemy;
        public IEnemy drawnEnemy;
        public LinkStateMachine linkStateMachine;
        public BombStateMachine bombStateMachine;
        public Classes.Projectiles.Bomb bomb;
        public ProjectileHandler projectileHandler;

        public CollisionManager collisionManager;

        public int roomNumber;
        public List<Room> roomList;
        
        //PASS THIS TO ENTITIES FOR UPSCALING THEM UNIFORMLY
        public float spriteScalar = 3;


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

            //Setting up enemy spritefactory
            enemySpriteFactory = new EnemySpriteFactory(this);
            stalfos = new EnemyStalfos(this, new Vector2(400, 100));
            gel = new EnemyGel(this, new Vector2(400, 100));
            keese = new EnemyKeese(this, new Vector2(400, 100));
            bladeTrap = new BladeTrap(this, new Vector2(400, 100), new Vector2(100, 100), link);
            goriya = new EnemyGoriya(this, new Vector2(400, 100));
            aquamentus = new EnemyAquamentus(this, new Vector2(400, 100));
            wallmaster = new EnemyWallmaster(this, new Vector2(400, 100));
            oldMan = new EnemyOldMan(this, new Vector2(400, 100));
            currentEnemy = Enemies.Stalfos;
            drawnEnemy = new EnemyStalfos(this, new Vector2(400, 100));

            controllerList.Add(new CKeyboard(this));
            controllerList.Add(new CMouse(this));

            roomList = new List<Room>();
            for (int i = 1; i < 18; i++)
            {
                roomList.Add(new Room(this, i));
            }

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

            // TODO: Add your update logic here

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            base.Update(gameTime);

            link.Update();

            drawnEnemy.Update();

            projectileHandler.Update();

            collisionManager.Update();
            foreach (Room r in roomList)
            {
                if (r.getRoomNumber() == roomNumber)
                {
                    r.Update();
                }
            }
        }

        public void changeRoom()
        {
            if (roomNumber == 18)
            {
                roomNumber = 1;
            }
            else
            {
                roomNumber++;
            }

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            foreach (Room r in roomList)
            {
                if (r.getRoomNumber() == roomNumber)
                {
                    r.Draw();
                }
            }
            link.Draw();

            drawnEnemy.Draw();

            projectileHandler.Draw();



        }
    }
}
