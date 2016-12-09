using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class RandomValueNormal : RandomValue
    {
        public double Mean { get; protected set; }
        public double Deviation { get; protected set; }
        protected int rounds;
        protected static Random random = new Random();

        public RandomValueNormal(double mean, double deviation) : base()
        {
            this.Mean = mean;
            this.Deviation = deviation;
            rounds = 12;
        }

        public override double Generate()
        {
            double result = 0.0;

            for (int i = 0; i < rounds; i++)
                result += random.NextDouble();

            return Deviation * Math.Sqrt(12.0 / rounds) * (result - rounds / 2.0) + Mean;
        }
    }
}
