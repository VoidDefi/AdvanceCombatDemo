using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.ContentLoaders
{
    public static class Content
    {
        public static TileLoader TileLoader { get; private set; }

        public static void Load()
        {
            TileLoader = new();
            TileLoader.Load();
        }
    }
}
