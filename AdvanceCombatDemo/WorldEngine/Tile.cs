using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.WorldEngine
{
    public struct Tile
    {
        public int type;

        public int contamination;

        public Tile()
        {
            type = 0;
            contamination = 0;
        }
    }
}
