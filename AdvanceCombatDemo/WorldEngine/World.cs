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
        }

        public void Update()
        {

        }
    }
}
