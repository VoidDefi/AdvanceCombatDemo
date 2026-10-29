using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.DemoContent.Tiles
{
    internal class Wall : BaseTile
    {
        public override void Setup()
        {
            IsSolid = true;
        }

        public override char GetChar() => '█';

        public override Color GetColor() => Color.White;
    }
}
