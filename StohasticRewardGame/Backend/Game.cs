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
        public Selector Selector1 { get; protected set; }
        public Selector Selector2 { get; protected set; }
        public double TotalReward { get; protected set; }

        public Game(GameAction[,] action, Selector selector1, Selector selector2)
        {
            this.Action = action;
            this.Selector1 = selector1;
            this.Selector2 = selector2;            
        }

        public void NextStep()
        {
            int action1 = Selector1.Select();
            int action2 = Selector2.Select();

            double reward = Action[action1, action2].Reward();
            TotalReward += reward;

            if (Selector1 is SelectorIndependent)
                ((SelectorIndependent)Selector1).updateReward(action1, reward);
            else
                ((SelectorMulti)Selector1).updateReward(action1, action2, reward);

            if (Selector2 is SelectorIndependent)
                ((SelectorIndependent)Selector2).updateReward(action2, reward);
            else
                ((SelectorMulti)Selector2).updateReward(action2, action1, reward);
        }
    }
}
