using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Sever s = new Sever();
            s.man(new User());
            Console.WriteLine("Press key to end...");
            Console.ReadKey();
        }
    }
}
