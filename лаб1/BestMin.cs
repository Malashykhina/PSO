using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class BestMin : Best
    {
        public override double[] BestVectorOutOfMatrix(double[][] A,double []g, int N, int m, Function fn) 
        {
            double gBest = fn.Solve(A[0]);
            for (int j = 0; j < m; j++)
                    {
                        g[j] = A[0][j];
                    }
            double gt;
            for (int i = 0; i < N; i++)//выбрать лучшее решение g
            {
                gt = fn.Solve(A[i]);
                if (gt < gBest)
                {
                    gBest = gt;
                    for (int j = 0; j < m; j++)
                    {
                        g[j] = A[i][j];
                    }
                }
            }
            return g;
        }
        public override int BestVectorOutOfTwoV(double[] x1, double[] x2, int m, Function fn)
        {
            if (fn.Solve(x1) < fn.Solve(x2))
                return 1;
            else return 2;
        }
    }
}
