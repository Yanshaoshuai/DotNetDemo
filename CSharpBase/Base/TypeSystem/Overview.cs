using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.TypeSystem
{
    internal class Overview
    {
        static void Main(string[] args)
        {
            float temperature;
            string name;
            char firstLetter = 'C';
            var limit = 3;
            int[] source = { 0, 1, 2, 3, 4, 5 };
            var query = from item in source
                        where item <= limit
                        select item;
            Console.WriteLine(query.GetType());
            //值类型 包括struct和enum
            //普通值类型不能具有 null 值。 不过，可以在类型后面追加 ?，创建可为空的值类型。
            byte num = byte.MaxValue;
            num = 0xA;
            int i = 5;
            char c = 'Z';
            //引用类型 包括类 record delegate 数组或interface
            int[] nums = { 1, 2, 3, 4, 5 };
            //数组隐式派生自 System.Array 类
            Console.WriteLine(nums.Length);

            //文本值类型
            string s = "The answer is " + 5.ToString();
            // Outputs: "The answer is 5"
            Console.WriteLine(s);

            Type type = 12345.GetType();
            // Outputs: "System.Int32"
            Console.WriteLine(type);

            //泛型 使用一个或多个类型参数声明的类型，用作实际类型（具体类型）的占位符 。
            //客户端代码在创建类型实例时提供具体类型。 这种类型称为泛型类型
            List<string> stringList = new List<string>();
            stringList.Add("String example");
            //stringList.Add(4);//error

            //隐式类型、匿名类型和可以为 null 的值类型

            //编译时类型和运行时类型
        }

        public struct Coords
        {
            public int x, y;
            public Coords(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public enum FileMode
        {
            CreateNew = 1,
            Create = 2,
            Open = 3,
            OpenOrCreate = 4,
            Truncate = 5,
            Append = 6,
        }
    }
}
