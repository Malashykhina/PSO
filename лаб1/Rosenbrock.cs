using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class Rosenbrock : Function
    {
        private double _left = -1.2;
        private double _right = 1.2;
        private int _num = 4;
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
            double solution=0;
            for (int i = 0; i < 3; i++ )
                solution += 100 * Math.Pow((x[i] * x[i] - x[i + 1]), 2)+  Math.Pow((1 - x[i]), 2);
            return solution;
        }
    }
}
