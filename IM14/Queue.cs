using System.Collections.Generic;
using System.Linq;

namespace IM.IM14
{
    public class Queue
    {
        public List<Client> qu = new List<Client>();
        public int N = 0;
        public void AddCustomer(Client cust)
        {
            qu.Add(cust);
            N++;
        }
        public Client delete()
        {
            Client c = null;
            if (N > 0)
            {
                c = qu[0];
                qu.Remove(c);
                N -= 1;
            }
            return c;
        }
        public int Count()
        {
            return qu.Count();
        }
    }
}
