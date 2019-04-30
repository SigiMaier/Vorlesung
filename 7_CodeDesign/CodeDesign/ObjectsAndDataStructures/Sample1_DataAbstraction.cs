using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsAndDataStructures
{
    public class Point
    {
        public double x;
        public double y;
    }

    public interface IPoint
    {
        double GetX();
        double GetY();
        void SetCartesian(double x, double y);
        double GetR();
        double GetTheta();
        void SetPolar(double r, double theta);
    }


    // The great thing about the second sample is that there is no way someone can thell whether the implementation is in
    // rectangular or polar coordinates. But the interface unmistakably represents a data structure.
    // The methods enforce an access policy. It is possible to read the coordinates independently, but they have to be set together
    // as one operation.
    
    // The first implementation is clearly implemented in rectangular coordinates and it forces to manipulate the coordinates
    // independently. This exposes implementation

    // Hiding implementation is not just a matter of putting a layer of functions between variables. Hiding implementation is about
    // abstractions. Classes should expose abstract interfaces to allow its users to manipulate the essence of the data, without
    // having to know its implementation
}
