using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    // sealed verhindert, dass andere Klassen von dieser Klasse erben.
    public sealed class Singleton
    {

        static Singleton()
        {
        }

        private Singleton()
        {
        }

        public static Singleton Instance { get; } = new Singleton();
    }
}
