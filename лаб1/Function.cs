using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace лаб1
{
    abstract class Function
    {
        public abstract double left { get; }
        public abstract double right { get; }
        public abstract int num { get; }
        abstract public double Solve(double [] x);        
    }
}
