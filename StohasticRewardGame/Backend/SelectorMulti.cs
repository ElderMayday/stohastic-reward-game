using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class SelectorMulti
    {
        public GameAction[,] action;

        public SelectorMulti(int numberOfActions1, int numberOfActions2) : base()
        {
            action = new GameAction[numberOfActions1, numberOfActions2];
        }

        public void updateReward(int action1, int reward2, double reward)
        {

        }
    }
}
