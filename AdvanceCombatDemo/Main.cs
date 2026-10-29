using AdvanceCombatDemo.InputLogic;
using AdvanceCombatDemo.WorldEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static Point ScreenSize => new Point((int)Width, (int)Height);

        public static SpriteFont Font { get; private set; }

        public static World World { get; private set; }

        public static int FPS { get; private set; }

        private static int frameCount;

        private static TimeSpan elapsedTime;

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
            ContentLoaders.Content.Load();
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
            elapsedTime += gameTime.ElapsedGameTime;
            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                FPS = frameCount;
                frameCount = 0;
            }

            Input.Update(this);

            World.Update();
            Camera.Center = Point.Zero;

            base.Update(gameTime);
        }

        private List<long> ticksHistory = new List<long>();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            frameCount++;

            WorldRenderer.Draw();

            SpriteBatch.Begin();

            long milliseconds = WorldRenderer.RenderStopwatch.ElapsedMilliseconds;
            long currentTicks = WorldRenderer.RenderStopwatch.ElapsedTicks;

            ticksHistory.Add(currentTicks);

            if (ticksHistory.Count > 30)
                ticksHistory.RemoveAt(0);

            long ticks = (long)ticksHistory.Average();

            string fps = $"FPS: {FPS} | Render Time: {milliseconds}ms, {ticks}ticks";
            Vector2 fpsPosition = new Vector2(5, ScreenHeight - 18);

            SpriteBatch.DrawString(Font, new string('█', fps.Length), fpsPosition, Color.Black);
            SpriteBatch.DrawString(Font, fps, fpsPosition, Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
