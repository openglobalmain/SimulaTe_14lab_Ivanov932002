using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.IM14
{
    public class Client
    {
        public int number;
        public Client(int num)
        {
            number = num;
        }
    }
    public class Clients
    {
        public List<Client> qu = new List<Client>();
        public int num = 0;
        public Client Create()
        {
            num++;
            Client c = new Client(num);
            qu.Add(c);
            return c;
        }
    }
}
