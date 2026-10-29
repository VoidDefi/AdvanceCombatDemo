using AdvanceCombatDemo.ContentLoaders;
using AdvanceCombatDemo.DemoContent.Tiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.WorldEngine
{
    public class World
    {
        public Tile[,] Tiles { get; private set; }

        public int Size { get; private set; } 

        public World(int size) 
        { 
            Size = size;
            Tiles = new Tile[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Tiles[i, j] = new Tile();
                    Tiles[i, j].type = Content.TileLoader.GetType<Floor>();
                }
            }
        }

        public void Update()
        {

        }
    }
}
