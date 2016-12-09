using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    abstract class Selector
    {
        public Selector()
        {
        }

        public abstract int Select();
    }
}
