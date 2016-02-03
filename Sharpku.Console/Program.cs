using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpku.Console
{
    class Program
    {
        private static void Main(string[] args)
        {
            var sharpku = new Sharpku.Generator();
            System.Console.WriteLine(sharpku.GenerateHaiku());

            System.Console.ReadKey();
        }
    }
}
