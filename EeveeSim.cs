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

namespace CSE3902_Game_Sprint0
{

    // Gal tell me if you can see this comment.
    public class EeveeSim : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<IController> controllerList = new List<IController>();
        public Texture2D eeveeTexture;
        public ISprite eeveeSprite;
        public Vector2 eeveeLocation;
        public Vector2 eevelocity = new Vector2(0, 0);
        private SpriteFont credits;
        private string creditsText = "Credits:\nProgram made by: Mark Maher (maher.159)\nSprites from: https://www.spriters-resource.com/ds_dsi/pokemonmysterydungeonexplorersofsky/sheet/131043/";
        public Dictionary<string, Texture2D> spriteSheets = new Dictionary<string, Texture2D>();
        //Sprite factories
        public EnemySpriteFactory enemySpriteFactory;
        public ItemSpriteFactory itemSpriteFactory;
        public ProjectileSpriteFactory projectileSpriteFactory;
        public Link link;
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
        public TileStateMachine tileStateMachine;
        public ItemStateMachine itemStateMachine;
        public Tile tile;
        public Item item;
        public BombStateMachine bombStateMachine;
        public Bomb bomb;
        public ProjectileHandler projectileHandler;

        public EeveeSim()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
            //Setting up projectileHandler
            projectileSpriteFactory = new ProjectileSpriteFactory(this);
            projectileHandler = new ProjectileHandler(this);

            /* LINK */
            //set StateMachine and Link to be used:
            link = new Link(this);
            linkStateMachine = new LinkStateMachine(link);

            //link is now created, maintains an instance of StateMachine to be passed around for commands:
            link.SetState(linkStateMachine);

            /* TILE */
            //Setting up block state machine
            tile = new Tile(this);
            tileStateMachine = new TileStateMachine(tile);

            //tile is created, maintains an instance of its StateMachine to be passed for commands:
            tile.SetState(tileStateMachine);

            /* ITEM */
            //Setting up item state machine
            item = new Item(this);
            itemStateMachine = new ItemStateMachine(item);

            //item is created, maintains an instance of its StateMachine to be passed for commands:
            item.SetState(itemStateMachine);

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

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Loading all of our textures into a texture dictionary
            spriteSheets.Add("Eevee", Content.Load<Texture2D>("DS DSi - Pokemon Mystery Dungeon Explorers of Sky - Eevee.AFTER"));
            spriteSheets.Add("Link", Content.Load<Texture2D>("NES - The Legend of Zelda - Link"));
            spriteSheets.Add("HUD", Content.Load<Texture2D>("NES - The Legend of Zelda - HUD & Pause Screen"));
            spriteSheets.Add("ItemsAndWeapons", Content.Load<Texture2D>("NES - The Legend of Zelda - Items & Weapons"));
            spriteSheets.Add("NPC", Content.Load<Texture2D>("NES - The Legend of Zelda - NPCs"));
            spriteSheets.Add("DungeonEnemies", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies"));
            spriteSheets.Add("Bosses", Content.Load<Texture2D>("NES - The Legend of Zelda - Bosses"));
            spriteSheets.Add("DungeonBackgrounds", Content.Load<Texture2D>("Level 1 (Eagle)"));
            spriteSheets.Add("DungeonTileset", Content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Tileset"));

            eeveeTexture = Content.Load<Texture2D>("DS DSi - Pokemon Mystery Dungeon Explorers of Sky - Eevee.AFTER");
            eeveeLocation = new Vector2((GraphicsDevice.Viewport.Bounds.Width / 2) - (21 / 2), (GraphicsDevice.Viewport.Bounds.Height / 2) - (24 / 2));
            eeveeSprite = new StaticSprite(this, eeveeTexture, eeveeLocation, eevelocity, new Rectangle(21, 0, 21, 24), Color.White, SpriteEffects.None);
            credits = Content.Load<SpriteFont>("Credits");
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
            eeveeSprite.Update();

            link.Update();

            tile.Update();

            item.Update();

            drawnEnemy.Update();

            projectileHandler.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            eeveeSprite.Draw(new Vector2(0, 0));

            link.Draw();

            tile.Draw();

            item.Draw();

            drawnEnemy.Draw();

            projectileHandler.Draw();

            _spriteBatch.Begin();
            _spriteBatch.DrawString(credits, creditsText, new Vector2(20, (this.GraphicsDevice.Viewport.Height / 4) * 3), Color.Black);
            _spriteBatch.End();
        }
    }
}
