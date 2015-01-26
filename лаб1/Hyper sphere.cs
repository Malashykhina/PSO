using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class Hyper_sphere : Function
    {
        private double _left = -5.12;
        private double _right = 5.12;
        private int _num = 6;
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
            for (int i = 0; i < this.num; i++ )
                solution += x[i] * x[i];
            return solution;
        }
    }
}
