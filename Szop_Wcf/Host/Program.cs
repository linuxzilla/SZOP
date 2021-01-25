using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Service;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(BookService)))
            {
                host.Open();
                Console.WriteLine("Host has started @" + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
