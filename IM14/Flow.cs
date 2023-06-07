using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.IM14
{
    public class Flow
    {
        Random rnd = new Random();
        double m;
        public Flow() { }
        public Flow(double l) { this.m = l; }
        public double GetTime(double l = -1)
        {
            if (l == -1) l = m;
            double a = rnd.NextDouble();
            return -Math.Log(a) / l;
        }
    }
}
