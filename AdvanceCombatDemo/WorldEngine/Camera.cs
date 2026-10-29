using System;
using Microsoft.Xna.Framework;

namespace AdvanceCombatDemo.WorldEngine
{
    public static class Camera
    {
        public static Point Position { get; set; }

        private static Point center = new Point(0, 0);

        public static Point Center
        {
            get => center;

            set
            {
                center = value;

                int width = ViewTilesWidth;
                int height = ViewTilesHeight;

                Position = new Point(center.X - width / 2, center.Y - height / 2);
            }
        }

        public static Point ScreenSize => Main.ScreenSize;

        public static int ViewTilesWidth
        {
            get
            {
                int width = ScreenSize.X / WorldRenderer.CharSize.X;

                if (width % 2 == 0) width -= 1;
                if (width < 0) width = 0;

                return width;
            }
        }

        public static int ViewTilesHeight
        {
            get
            {
                int height = ScreenSize.Y / WorldRenderer.CharSize.Y;

                if (height % 2 == 0) height -= 1;
                if (height < 0) height = 0;

                return height;
            }
        }
    }
}
