using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.ObjectOriented
{
    public class Shape
    {
        // A few example members
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }
    public class Circle : Shape
    {
        public override void Draw()
        {
            // Code to draw a circle...
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            Console.WriteLine("Drawing a rectangle");
            base.Draw();
        }
    }
    public class Triangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a triangle...
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }

    public class BaseClass
    {
        public void DoWork() { WorkField++; }
        public int WorkField;
        public int WorkProperty
        {
            get { return 0; }
        }
    }

    public class DerivedClass : BaseClass
    {
        //使用 new 关键字隐藏基类成员
        public new void DoWork() { WorkField++; }
        public new int WorkField;
        public new int WorkProperty
        {
            get { return 0; }
        }
    }

    /// <summary>
    /// 阻止派生类重写
    /// </summary>
    public class A
    {
        public virtual void DoWork() { Console.WriteLine("A DoWork"); }
    }
    public class B : A
    {
        public override void DoWork() { Console.WriteLine("B DoWork"); }
    }

    public class C : B
    {
        //将重写声明为 sealed 来停止虚拟继承
        //方法 DoWork 对从 C 派生的任何类都不再是虚拟方法。 即使它们转换为类型 B 或类型 A，它对于 C 的实例仍然是虚拟的。
        public sealed override void DoWork() { Console.WriteLine("C DoWork"); }
    }

    public class D : C
    {
        public new void DoWork()
        {
            Console.WriteLine("D DoWork");
            //已替换或重写某个方法或属性的派生类仍然可以使用 base 关键字访问基类的该方法或属性
            //base.DoWork();
        }
    }
    internal class Polymorphism
    {
        static void Main(string[] args)
        {
            // Polymorphism at work #1: a Rectangle, Triangle and Circle
            // can all be used wherever a Shape is expected. No cast is
            // required because an implicit conversion exists from a derived
            // class to its base class.
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            // Polymorphism at work #2: the virtual method Draw is
            // invoked on each of the derived classes, not the base class.
            foreach (Shape shape in shapes)
            {
                shape.Draw();
            }
            /* Output:
                Drawing a rectangle
                Performing base class drawing tasks
                Drawing a triangle
                Performing base class drawing tasks
                Drawing a circle
                Performing base class drawing tasks
            */

            DerivedClass derived = new DerivedClass();
            derived.DoWork();  // Calls the new method.

            BaseClass baseClass = derived;
            baseClass.DoWork();  // Calls the old method.

            D d = new D();
            d.DoWork();//D DoWork
            //使用类型为 C、B 或 A 的变量访问 D 的实例，对 DoWork 的调用将遵循虚拟继承的规则，即把这些调用传送到类 C 的 DoWork 实现
            A a = d;
            a.DoWork();//C DoWork
        }
    }
}
