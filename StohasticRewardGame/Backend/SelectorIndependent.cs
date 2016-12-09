using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    abstract class SelectorIndependent : Selector
    {
        public GameAction[] action;

        public SelectorIndependent(int numberOfActions) : base()
        {
            action = new GameAction[numberOfActions];
        }

        public void updateReward(int action, double reward)
        {

        }
    }
}
