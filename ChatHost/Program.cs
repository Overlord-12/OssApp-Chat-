using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(OssApp_Chat_.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Почалось");
                Console.ReadLine();
            }
        }
    }
}
