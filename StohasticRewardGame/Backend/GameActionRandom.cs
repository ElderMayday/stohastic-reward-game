using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class GameActionRandom : GameAction
    {
        protected RandomValue randomValue;

        public GameActionRandom(RandomValue randomValue) : base()
        {
            this.randomValue = randomValue;
        }

        public override double Reward()
        {
            return randomValue.Generate();
        }
    }
}
