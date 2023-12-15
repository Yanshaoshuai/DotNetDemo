using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.mytest
{
    abstract class Animal
    {
        public virtual void sleep()
        {
            //must have method body
            Console.WriteLine("Animal Sleep");
        }
        public void run()
        {
            Console.WriteLine("Animal run");
        }
        //抽象方法 没有方法体 必须在abstract类里
        public abstract void eat();
    }
    class Dog : Animal
    {
        //重写虚方法
        public override void sleep()
        {
            //base.sleep();
            Console.WriteLine("Dog Sleep");
        }
        //隐藏父类方法
        new public void run()
        {
            //base.run();
            Console.WriteLine("Dog run");
        }

        public override void eat()
        {
            Console.WriteLine("Dog eat");
        }
    }

    internal class ObjectOriented
    {
        static void Main(string[] args)
        {
            Animal animal = new Dog();
            animal.sleep();//Dog Sleep
            animal.run();//Animal run
            ((Dog)animal).run();//Dog run
            animal.eat();
        }
    }
}
