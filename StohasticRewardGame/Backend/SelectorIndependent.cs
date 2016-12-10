using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    abstract class SelectorIndependent : Selector
    {    
        public double[] Estimate { get; protected set; }
        public int[] Selected { get; protected set; }

        public SelectorIndependent(int numberOfActions) : base()
        {
            Estimate = new double[numberOfActions];
            for (int i = 0; i < Estimate.Length; i++)
                Estimate[i] = 0.0;

            Selected = new int[numberOfActions];
            for (int i = 0; i < Selected.Length; i++)
                Selected[i] = 0;
        }

        public void updateReward(int action, double reward)
        {
            Selected[action]++;
            Estimate[action] = Estimate[action] + 1.0 / Selected[action] * (reward - Estimate[action]);
        }
    }
}
