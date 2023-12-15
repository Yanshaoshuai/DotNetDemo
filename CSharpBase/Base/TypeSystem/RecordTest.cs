using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.TypeSystem
{
    public record PersonRecord(string FirstName, string LastName);
    public record Person2(string FirstName, string LastName, string[] PhoneNumbers);
    public record Person3(string FirstName, string LastName)
    {
        public required string[] PhoneNumbers { get; init; }
    }

    public record class A { }
    public record struct B { }
    internal class RecordTest
    {
        static void Main(string[] args)
        {
            PersonRecord person = new("Nancy", "Davolio");
            Console.WriteLine(person); // output: Person { FirstName = Nancy, LastName = Davolio }

            //下面的示例演示了记录中的值相等性
            var phoneNumbers = new string[2];
            Person2 person1 = new("Nancy", "Davolio", phoneNumbers);
            Person2 person2 = new("Nancy", "Davolio", phoneNumbers);
            Console.WriteLine(person1 == person2); // output: True

            person1.PhoneNumbers[0] = "555-1234";
            Console.WriteLine(person1 == person2); // output: True

            Console.WriteLine(ReferenceEquals(person1, person2)); // output: False

            //使用 with 表达式来复制不可变对象和更改其中的一个属性
            Person3 person11 = new("Nancy", "Davolio") { PhoneNumbers = new string[1] };
            Console.WriteLine(person11);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }

            Person3 person22 = person11 with { FirstName = "John" };
            Console.WriteLine(person22);
            // output: Person { FirstName = John, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person1 == person2); // output: False

            person22 = person11 with { PhoneNumbers = new string[1] };
            Console.WriteLine(person22);
            // output: Person { FirstName = Nancy, LastName = Davolio, PhoneNumbers = System.String[] }
            Console.WriteLine(person11 == person22); // output: False

            person22 = person11 with { };
            Console.WriteLine(person11 == person22); // output: True

            //record struct 和 record struct都具有值相等性
            A a = new A();
            A a1 = new A();
            Console.WriteLine(a == a1);
            B b = new B();
            B b1 = new B();
            Console.WriteLine(b == b1);
        }
    }
}
