using CSE3902_Game_Sprint0.Classes;
using CSE3902_Game_Sprint0.Classes._21._2._13;
using CSE3902_Game_Sprint0.Classes.Controllers;
using CSE3902_Game_Sprint0.Classes.Scripts;
using CSE3902_Game_Sprint0.Classes.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        public EnemySpriteFactory enemySpriteFactory;
        public TilesSpriteFactory tileSpriteFactory;
        public Link link;
        public StateMachine linkStateMachine;
 
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

            //set StateMachine and Link to be used:
            link = new Link(this);
            linkStateMachine = new StateMachine(link);

            //link is now created, maintains an instance of StateMachine to be passed around for commands:
            link.SetState(linkStateMachine);

            controllerList.Add(new CKeyboard(this));
            controllerList.Add(new CMouse(this));
            enemySpriteFactory = new EnemySpriteFactory(this);
            //tileSpriteFactory = new TilesSpriteFactory(this); //think the constructor needs changed but I'll let Gal check since he did it.
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
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            eeveeSprite.Draw(new Vector2(0, 0));
            link.Draw();

            _spriteBatch.Begin();
            _spriteBatch.DrawString(credits, creditsText, new Vector2(20, (this.GraphicsDevice.Viewport.Height / 4) * 3), Color.Black);
            _spriteBatch.End();
        }
    }
}
