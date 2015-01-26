using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class Branin : Function
    {
        private double _left = -5;
        private double _right = 13;//было 10, но одна и точек не в диап
        private int _num = 2;
        private double a= 1;
        private double b = 5.1*49/(double)(4*22*22);
        private double c = 5 * 7 / (double)22;
        private double d = 6;
        private double e = 10;
        private double f = 7 / (double)(8 * 22); 
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
            solution = a * Math.Pow((x[1] - b * x[0] * x[0] + c * x[0] - d), 2) + e * (1 - f) * Math.Cos(x[0]) + e;
            return solution;
        }
    }
}
