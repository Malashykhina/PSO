using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class FDeJong:Function
    {
        private double _left = -2.048;
        private double _right = 2.048;
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
            double solution=0;
            solution = 3905.93 - 100 * Math.Pow((x[0] * x[0] - x[1]), 2) - Math.Pow((1 - x[0]), 2);
            return solution;
        }
    }
}
