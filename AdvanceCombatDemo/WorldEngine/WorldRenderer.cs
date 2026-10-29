using AdvanceCombatDemo.ContentLoaders;
using AdvanceCombatDemo.DemoContent;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace AdvanceCombatDemo.WorldEngine
{
    public static class WorldRenderer
    {
        public static void Render()
        {
            Point charSize = new(8, 19);

            World world = Main.World;

            if (world == null) return;

            Point screenSize = Main.ScreenSize;

            int width = screenSize.X / charSize.X;
            int height = screenSize.Y / charSize.Y;

            int offsetX = (int)((screenSize.X - width * charSize.X) / 2f);
            int offsetY = (int)((screenSize.Y - height * charSize.Y) / 2f);

            Point startPoint = Point.Zero;

            //RenderStopwatch = new Stopwatch();
            //RenderStopwatch.Start();

            Main.SpriteBatch.Begin();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Point Point = startPoint + new Point(i, j);

                    if (Point.X < 0 || Point.X > world.Size) continue;
                    if (Point.Y < 0 || Point.Y > world.Size) continue;

                    Vector2 drawPoint = new Vector2(i * charSize.X + offsetX, j * charSize.Y + offsetY);

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
        }
    }
}
