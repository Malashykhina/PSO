using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    class Martin_Gaddy : Function
    {
        private double _left = 0;
        private double _right = 10;
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
            solution = Math.Pow((x[0] - x[1]), 2) + Math.Pow(((x[0]+x[1]-10)/(double)3), 2);
            return solution;
        }
    }
}
