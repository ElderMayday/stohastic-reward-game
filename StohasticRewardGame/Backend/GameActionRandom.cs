using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class GameActionRandom : GameAction
    {
        protected RandomValue random;

        public GameActionRandom(RandomValue random) : base()
        {
            this.random = random;
        }

        protected override double Reward()
        {
            return random.Generate();
        }
    }
}
