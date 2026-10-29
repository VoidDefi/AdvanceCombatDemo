using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.ContentLoaders
{
    public class Content
    {
        public TileLoader TileLoader { get; private set; }

        public void Load()
        {
            TileLoader = new();
            TileLoader.Load();
        }
    }
}
