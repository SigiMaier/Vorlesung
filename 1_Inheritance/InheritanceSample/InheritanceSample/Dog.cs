using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceSample
{
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Wuff!");
        }
    }
}
