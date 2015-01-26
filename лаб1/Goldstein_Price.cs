using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class Goldstein_Price:Function
    {
        private double _left = -2;
        private double _right = 2;
        private int _num = 2;
        public override double left
        {
            get
            {
                return _left;
            }
        }

        public override double right
        {
            get
            {
                return _right;
            }
        }
        public override int num
        {
            get
            {
                return _num;
            }
        }
        public override double Solve(double[] x)
        {
            double solution;
            solution = 1 + Math.Pow((x[0] + x[1] + 1), 2) * (19 - 14 * x[0] + 3 * x[0] * x[0]-14*x[1]+6*x[0]*x[1]+3*x[1]*x[1]);
            solution = solution * (30 + Math.Pow((2*x[0] -3* x[1]), 2) * (18 - 32 * x[0] + 12 * x[0] * x[0] + 48 * x[1] - 36 * x[0] * x[1] + 27 * x[1] * x[1]));
            return solution;
        }
    }
}
