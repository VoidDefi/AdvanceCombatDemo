using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.DemoContent
{
    public abstract class BaseTile
    {
        public int Type { get; private set; } = 0;

        public bool IsSolid { get; protected set; } = false;

        public void Init(int type)
        {
            if (Type > 0 && type > 0)
                Type = type;

            Setup();
        }

        public virtual void Setup()
        {

        }

        public virtual char GetChar() => ' ';

        public virtual Color GetColor() => Color.White;
    }
}
