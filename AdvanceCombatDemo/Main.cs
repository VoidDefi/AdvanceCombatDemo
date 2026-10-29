using AdvanceCombatDemo.WorldEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AdvanceCombatDemo
{
    public class Main : Game
    {
        public static GraphicsDeviceManager Graphics { get; private set; }

        public static SpriteBatch SpriteBatch { get; private set; }

        public static int ScreenWidth => 1602;

        public static int ScreenHeight => 912;

        public static float Width => Graphics.PreferredBackBufferWidth;

        public static float Height => Graphics.PreferredBackBufferHeight;

        public static SpriteFont Font { get; private set; }

        public static World World { get; private set; }

        public Main()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.Title = $"Advance Combat System Demo";

            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.PreferredBackBufferWidth = ScreenWidth;
            Graphics.PreferredBackBufferHeight = ScreenHeight;
            Graphics.ApplyChanges();

            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            World = new World(500);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            Font = Content.Load<SpriteFont>("Fonts/font");
        }

        protected override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
