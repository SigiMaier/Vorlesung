using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRY_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Michael ist Arzt, wohnt in Rosenheim ud ist 34 Jahre alt");
            Console.WriteLine("Sandra ist Anwältin, wohnt in Hamburg ud ist 39 Jahre alt");
            Console.WriteLine("Stefan ist Elektriker, wohnt in Berlin ud ist 22 Jahre alt");
            Console.WriteLine("Maria ist Bankkauffrau, wohnt in München ud ist 19 Jahre alt");






            WritePersonDataToScreen("Michael", "Arzt", "Rosenheim", 34);
            WritePersonDataToScreen("Sandra", "Anwältin", "Hamburg", 39);
            WritePersonDataToScreen("Stefan", "Elektriker", "Berlin", 22);
            WritePersonDataToScreen("Maria", "Bankkauffrau", "München", 19);
        }

        public static void WritePersonDataToScreen(string name, string job, string placeOfResidence, int age)
        {
            Console.WriteLine("{0} ist {1}, lebt in {2} und ist {3} Jahre alt",
                name, job, placeOfResidence, age);
        }
    }
}
