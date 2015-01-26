using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    abstract class Best
    {
        abstract public double[] BestVectorOutOfMatrix(double[][] A,double []g, int N, int m, Function fn);
        abstract public int BestVectorOutOfTwoV(double[] x1, double[] x2, int m, Function fn); 
    }
}
