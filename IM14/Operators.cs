using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.IM14
{
    public class Operator
    {
        double mu = 1.5;
        public Client cust = null;
        public int number;
        public Operator(int i)
        {
            number = i;
        }
        public double time(Random rnd)
        {
            if (cust != null)
            {
                double a = rnd.NextDouble();
                return -Math.Log(a) / mu;
            }
            else return 999999;
        }
        public void End()
        {
            cust = null;
        }
    }
    public class Operators
    {
        List<Operator> Opers = new List<Operator>();
        int N;
        Flow f = new Flow();
        double l;
        Clients custs= new Clients();
        Queue q = new Queue();
        public Operators(int N, double l)
        {
            this.N = N;
            this.l = l;
            for (int i = 0; i < N; i++)
                Opers.Add(new Operator(i));
        }
        public int NumOfBusies()
        {
            int busy = 0;
            for (int i = 0; i < N; i++)
                if (Opers[i].cust != null) busy++;
            return busy;
        }
        public double GetTime(double t1, Random rnd)
        {
            double T;
            double time;
            int busy = 0;
            for (int i = 0; i < N; i++)
                if (Opers[i].cust != null) busy++;
            if (busy > 0) time=f.GetTime(l * busy); else time = 99999;
            if (t1 < time)
            {
                Client c = custs.Create();
                if (busy < N) { Opers[Findfree()].cust = c; busy++; }
                else q.AddCustomer(c);
                T = t1;
            }
            else 
            {
                int i = 0;
                double t = 999;
                foreach (Operator oper in Opers)
                {
                    if (oper.cust != null)
                    {
                        double t2 = oper.time(rnd);
                        if (t2 < t) {
                            i = oper.number; t = t2;
                        }
                    }
                }
                 
                Opers[i].cust = q.delete();
                T = time;
            }
            return T;

        }
        public int Findfree()
        {
            int i = 0;
            for (i = 0; i < N; i++)
                if (Opers[i].cust == null)
                {
                    break;
                }
            return i;
        }
        public Queue InfQ()
        {
            return q;
        }
        public List<Operator> InfB()
        {
            List<Operator> ops = new List<Operator>();
            for (int i = 0; i < N; i++)
                ops.Add(Opers[i]);
            return ops;
        }
        public string InfC()
        {
            return Convert.ToString(custs.num);
        }
    }
}
