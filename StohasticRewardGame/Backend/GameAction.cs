using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    abstract class GameAction
    {
        public GameAction()
        {
        }

        public abstract double Reward();
    }
}
