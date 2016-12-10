using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class Game
    {
        public GameAction[,] Action { get; protected set; }
        public Selector selector1 { get; protected set; }
        public Selector selector2 { get; protected set; }

        public Game(GameAction[,] action, Selector selector1, Selector selector2)
        {
            this.Action = action;
            this.selector1 = selector1;
            this.selector2 = selector2;            
        }

        public void NextStep()
        {
            int action1 = selector1.Select();
            int action2 = selector2.Select();

            double reward = Action[action1, action2].Reward();

            if (selector1 is SelectorIndependent)
                ((SelectorIndependent)selector1).updateReward(action1, reward);
            else
                ((SelectorMulti)selector1).updateReward(action1, action2, reward);

            if (selector2 is SelectorIndependent)
                ((SelectorIndependent)selector2).updateReward(action2, reward);
            else
                ((SelectorMulti)selector2).updateReward(action2, action1, reward);
        }
    }
}
