using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    abstract class GameAction
    {
        /// <summary>
        /// Number of times this action is chosen
        /// </summary>
        public int SelectedNumber { get; protected set; }

        public double Estimate { get; protected set; }

        public GameAction()
        {
            Reset();
        }

        public void Reset()
        {
            SelectedNumber = 0;
            Estimate = 0.0;
        }

        public double Select()
        {
            SelectedNumber++;
            double reward = Reward();
            Estimate = Estimate + 1.0 / SelectedNumber * (reward - Estimate);
            return reward;
        }

        protected abstract double Reward();
    }
}
