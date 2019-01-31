using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Program
    {
        public delegate void Writer(string message);

        static void Main(string[] args)
        {
            //Logger logger = new Logger();

            //Writer writer = new Writer(logger.WriteMessage);

            //writer("Success!");

            //Animal lion = new Animal();

            //lion.Name = "Mufasa";

            //string lionName = lion.Name;

            //Console.WriteLine(lionName);

            //lion.Name = "Simba";

            //lionName = lion.Name;

            //Console.WriteLine(lionName);
            //Library library2 = library;

            //library.Name = "Library 1";

            //Console.WriteLine(library.Name);

            //Console.WriteLine(library2.Name);


            //Library library = new Library();
            //library.AddBook("Clean Code: A Handbook of Agile Software Craftsmanship");
            //library.AddBook("Another Book");

            //Library library2 = new Library();

            //library2.AddBook("And a third Book?");
















            //Library library = new Library();

            //library.Name = "City Public Library";

            //library.NameChanged += OnNameChanged;
            //library.NameChanged += OnNameChanged;
            //library.NameChanged += OnNameChanged2;
            //library.NameChanged -= OnNameChanged;

            //library.Name = "University Library";



            Library library = new Library();
            library.Name = "City Public Library";
            library.NameChanged += OnNameChanged;
            library.Name = "University Library";
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine(
                "Name changed from {0} to {1} via NameChangedEvent from {2}",
                args.OldValue,
                args.NewValue,
                sender.ToString());
        }

        private static void OnNameChanged2(string oldValue, string newValue)
        {
            Console.WriteLine("****");
        }

        private static void OnNameChanged(string oldValue, string newValue)
        {
            Console.WriteLine("Name changed from {0} to {1}", oldValue, newValue);
        }
    }


    public abstract class AbstractClassSample
    {
        public string Title { get; set; }

        public virtual void Draw()
        {
            // ...
        }

        public abstract void Open();
    }


    public interface IWindow
    {
        string Title { get; set; }
        void Draw();
        void Open();
    }
}
