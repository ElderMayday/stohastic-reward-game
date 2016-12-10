using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class SelectorBoltzmannIndependent : SelectorIndependent
    {
        protected double tau;
        protected const double e = 2.71828;
        protected static Random random = new Random();

        public SelectorBoltzmannIndependent(int numberOfActions, double tau) : base(numberOfActions)
        {
            this.tau = tau;
        }

        public override int Select()
        {
            // calculate exponentiated values

            List<double> exp = new List<double>();

            foreach (var estimate in Estimate)
                exp.Add(Math.Pow(SelectorBoltzmannIndependent.e, estimate / tau));

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
