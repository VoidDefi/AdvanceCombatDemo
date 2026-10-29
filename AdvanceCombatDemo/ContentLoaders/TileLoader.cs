using AdvanceCombatDemo.DemoContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.ContentLoaders
{
    public class TileLoader : Loader
    {
        public BaseTile[] Tiles { get; private set; }

        private Dictionary<Type, int> TilesAndTypes { get; set; }

        public override void Load()
        {
            Tiles = LoadContent<BaseTile>().ToArray();

            for (int i = 0; i < Tiles.Length; i++)
            {
                BaseTile tile = Tiles[i];

                tile.Init(i + 1);

                TilesAndTypes.Add(tile.GetType(), tile.Type);
            }
        }

        public BaseTile GetBaseTile(int type)
        {
            if (type < 0 || type >= Tiles.Length)
                return null;

            return Tiles[type];
        }

        public int GetType<T>() where T : BaseTile
        {
            if (TilesAndTypes.TryGetValue(typeof(T), out int type))
                return type;

            return 0;
        }
    }
}
