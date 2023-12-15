using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.TypeSystem
{
    interface IEquatable<T>
    {
        public bool Equals(T obj);
        public static int i;
    }

    public class Car : IEquatable<Car>
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Year { get; set; }

        // Implementation of IEquatable<T> interface
        public bool Equals(Car? car)
        {
            return (Make, Model, Year) ==
                (car?.Make, car?.Model, car?.Year);
        }
    }
    internal class InterfaceTest
    {
    }
}
