using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StohasticRewardGame.Backend
{
    class SelectorBestMulti : SelectorMulti
    {
        public SelectorBestMulti(int numberAction1, int numberAction2) : base(numberAction1, numberAction2)
        {
        }

        public override int Select()
        {
            int iMax = 0, jMax = 0;

            for (int i = 0; i < Estimate.GetLength(0); i++)
                for (int j = 0; j < Estimate.GetLength(1); j++)
                    if (Estimate[i, j] > Estimate[iMax, jMax])
                    {
                        iMax = i;
                        jMax = j;
                    }

            return iMax;
        }
    }
}
