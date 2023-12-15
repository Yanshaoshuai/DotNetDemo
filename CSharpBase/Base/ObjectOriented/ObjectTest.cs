using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.ObjectOriented
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        // Other properties, methods, events...
    }

    public struct PersonStruct
    {
        public string Name;
        public int Age;
        public PersonStruct(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    internal class ObjectTest
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Leopold", 6);
            Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

            // Declare new person, assign person1 to it.
            Person person2 = person1;

            // Change the name of person2, and person1 also changes.
            person2.Name = "Molly";
            person2.Age = 16;

            Console.WriteLine("person2 Name = {0} Age = {1}", person2.Name, person2.Age);
            Console.WriteLine("person1 Name = {0} Age = {1}", person1.Name, person1.Age);

            //Object.Equals 比较引用类型实例是否引用内存中的同一位置
            Console.WriteLine("person1.Equals(person2) is {0}", person1.Equals(person2));
            person2 = new Person("Leopold", 6);
            Console.WriteLine("person1.Equals(person2) is {0}", person1.Equals(person2));


            // Create  struct instance and initialize by using "new".
            // Memory is allocated on thread stack.
            PersonStruct p1 = new PersonStruct("Alex", 9);
            Console.WriteLine("p1 Name = {0} Age = {1}", p1.Name, p1.Age);
            // Create  new struct object. Note that  struct can be initialized
            // without using "new".
            PersonStruct p2 = p1;

            // Assign values to p2 members.
            p2.Name = "Spencer";
            p2.Age = 7;
            Console.WriteLine("p2 Name = {0} Age = {1}", p2.Name, p2.Age);

            // p1 values remain unchanged because p2 is  copy.
            Console.WriteLine("p1 Name = {0} Age = {1}", p1.Name, p1.Age);

            //ValueType.Equals 比较值类型实例字段是否具有相同的值
            Console.WriteLine("p1.Equals(p2) is {0}", p1.Equals(p2));
            p2 = new PersonStruct("Alex", 9);
            Console.WriteLine("p1.Equals(p2) is {0}", p1.Equals(p2));
            Console.WriteLine("p1.Equals(p2) is {0}", p1.Equals(p2));

        }
    }
}
