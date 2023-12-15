using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.TypeSystem
{
    public class Customer
    {
        // Initialize capacity field to a default value of 10:
        private int _capacity = 10;

        public Customer(int capacity) => _capacity = capacity;
    }

    //从 C# 12 开始，可以将主构造函数定义为类声明的一部分
    public class Container(int capacity)
    {
        private int _capacity = capacity;
    }

    //对某个属性使用 required 修饰符，并允许调用方使用对象初始值设定项来设置该属性的初始值
    public class Person
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
    }
    public class Employee { }
    public class Manager : Employee
    {
        // Employee fields, properties, methods and events are inherited
        // New Manager fields, properties, methods and events go here...
    }
    internal class ClassTest
    {
        static void Main(string[] args)
        {

            Customer object1 = new Customer(10);

            //var p1 = new Person(); // Error! Required properties not set
            var p2 = new Person() { FirstName = "Grace", LastName = "Hopper" };
        }
    }
}
