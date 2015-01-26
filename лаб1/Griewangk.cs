using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class Griewangk : Function
    {
        private double _left = -512;
        private double _right = 512;
        private int _num = 10;
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
            double sum = 0;
            double dobutok = 1;
            for (int i = 0; i < 10; i++)
            {
                sum += x[i] * x[i] /(double)4000 ;
                dobutok = dobutok * Math.Cos(x[i] / (double)Math.Sqrt(i + 1));
            }
            solution = 1 / (double)(0.1 + sum -dobutok + 1);
            return solution;
        }
    }
}
