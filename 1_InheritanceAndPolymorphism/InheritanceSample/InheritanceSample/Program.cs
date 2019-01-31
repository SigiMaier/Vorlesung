using System.Collections.Generic;

namespace InheritanceSample
{
    public static class Program
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>()
            {
                new Dog()
                { Name = "Pluto" },
                new Cat()
                { Name = "Felix" }
            };

            foreach (var animal in animals)
            {
                System.Console.WriteLine(animal.Name + " make sound!");
                animal.MakeSound();
                System.Console.WriteLine("\n");
            }
        }
    }
}
