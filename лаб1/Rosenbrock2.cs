using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class Rosenbrock2:Function
    {
        private double _left1 = -1.2;
        private double _right1 = 1.2;
        private double _left2 = -10;
        private double _right2 = 10;
        private int _num = 2;
        public override double left
        {
            get
            {
                return _left1;
            }
        }

        public override double right
        {
            get
            {
                return _right1;
            }
        }
        public double left2
        {
            get
            {
                return _left2;
            }
        }

        public double right2
        {
            get
            {
                return _right2;
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
            double solution = 100 * Math.Pow((x[0] * x[0] - x[1]), 2) + Math.Pow((1 - x[0]), 2);
            return solution;
        }
    }
}
