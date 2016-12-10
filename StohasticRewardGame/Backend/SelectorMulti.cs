using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    abstract class SelectorMulti : Selector
    {
        public double[,] Estimate { get; protected set; }
        public int[,] Selected { get; protected set; }

        public SelectorMulti(int numberActions1, int numberActions2) : base()
        {
            Estimate = new double[numberActions1, numberActions2];

            for (int i = 0; i < Estimate.GetLength(0); i++)
                for (int j = 0; j < Estimate.GetLength(1); j++)
                    Estimate[i, j] = 0.0;

            Selected = new int[numberActions1, numberActions2];

            for (int i = 0; i < Selected.GetLength(0); i++)
                for (int j = 0; j < Selected.GetLength(1); j++)
                    Selected[i, j] = 0;
        }

        public void updateReward(int action1, int action2, double reward)
        {
            Selected[action1, action2]++;
            Estimate[action1, action2] = Estimate[action1, action2] + 1.0 / Selected[action1, action2] * (reward - Estimate[action1, action2]);
        }
    }
}
