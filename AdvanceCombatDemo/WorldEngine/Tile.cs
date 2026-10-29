using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.WorldEngine
{
    public struct Tile
    {
        public short type;

        public short contamination;

        public Tile()
        {
            type = 0;
            contamination = 0;
        }
    }
}
