using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class SelectorBoltzmannMulti : SelectorMulti
    {
        protected double tau;
        protected const double e = 2.71828;
        protected static Random random = new Random();

        public SelectorBoltzmannMulti(int numberAction1, int numberAction2, double tau) : base(numberAction1, numberAction2)
        {
            this.tau = tau;
        }

        public override int Select()
        {
            double[] estimateRow = new double[Estimate.GetLength(0)];

            // calculate row Q-value

            for (int i = 0; i < Estimate.GetLength(0); i++)
            {
                double max = Estimate[i, 0];

                for (int j = 1; j < Estimate.GetLength(1); j++)
                    if (max < Estimate[i, j])
                        max = Estimate[i, j];

                estimateRow[i] = max;
            }

            // calculate exponentiated values

            List<double> exp = new List<double>();

            foreach (var estimate in estimateRow)
                exp.Add(Math.Pow(SelectorBoltzmannMulti.e, estimate / tau));

            double sum = exp.Sum();

            // calculate probabilities

            List<double> probability = new List<double>();

            double current = 0.0;

            for (int i = 0; i < exp.Count; i++)
            {
                current += exp[i];
                probability.Add(current / sum);
            }

            // find action index

            double r = random.NextDouble();

            for (int i = 0; i < probability.Count - 1; i++)
                if (r <= probability[i])
                    return i;

            return probability.Count - 1;
        }
    }
}
