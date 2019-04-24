using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting
{
    public class Sample2_VerticalDensityBad
    {
        /**
         * The class name of the class
         */
        private string className;

        /**
         * The properties of the class
         */
        private List<int> properties = new List<int>();

        public void AddProperty(int property)
        {
            this.properties.Add(property);
        }
    }

    // Lines of code that are tightly related should appear vertically dense.
    // The useless comments in above example break the close association of the two instance variables.






        // This version is much easier to read. It can be seen at once, that this is a class with two variables and one method,
        // without having to move the head or eyes much. 
    public class Sample2_VerticalDensity
    {
        private string className;
        private List<int> properties = new List<int>();

        public void AddProperty(int property)
        {
            this.properties.Add(property);
        }
    }

}
