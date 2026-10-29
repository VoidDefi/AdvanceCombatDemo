using AdvanceCombatDemo.ContentLoaders;
using AdvanceCombatDemo.DemoContent;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace AdvanceCombatDemo.WorldEngine
{
    public static class WorldRenderer
    {
        public static Point CharSize => new(8, 19);

        internal static Stopwatch RenderStopwatch;

        public static void Draw()
        {
            World world = Main.World;

            if (world == null) return;

            Point screenSize = Main.ScreenSize;

            int width = Camera.ViewTilesWidth;
            int height = Camera.ViewTilesHeight;

            int offsetX = (int)((screenSize.X - width * CharSize.X) / 2f);
            int offsetY = (int)((screenSize.Y - height * CharSize.Y) / 2f);

            Point startPoint = Camera.Position;

            RenderStopwatch = new Stopwatch();
            RenderStopwatch.Start();

            Main.SpriteBatch.Begin();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Point Point = startPoint + new Point(i, j);

                    if (Point.X < 0 || Point.X > world.Size) continue;
                    if (Point.Y < 0 || Point.Y > world.Size) continue;

                    Vector2 drawPoint = new Vector2(i * CharSize.X + offsetX, j * CharSize.Y + offsetY);

                    Tile tile = world.Tiles[Point.X, Point.Y];

                    if (tile.type > 0)
                    {
                        BaseTile baseTile = Content.TileLoader.GetBaseTile(tile.type);

                        char symbol = baseTile.GetChar();
                        Color color = baseTile.GetColor();
                        
                        Main.SpriteBatch.DrawString(Main.Font, symbol.ToString(), drawPoint, color);
                    }
                }
            }

            Main.SpriteBatch.End();

            RenderStopwatch.Stop();
        }
    }
}
