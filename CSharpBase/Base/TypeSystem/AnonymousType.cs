using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.TypeSystem
{
    /// <summary>
    ///匿名类型提供了一种方便的方法，可用来将一组只读属性封装到单个对象中，而无需首先显式定义一个类型
    /// </summary>
    internal class AnonymousType
    {
        static void Main(string[] args)
        {
            //使用 new 运算符和对象初始值设定项创建匿名类型
            var v = new { Amount = 108, Message = "Hello" };

            // Rest the mouse pointer over v.Amount and v.Message in the following
            // statement to verify that their inferred types are int and string.
            Console.WriteLine(v.Amount + v.Message);

            //匿名类型通常用在查询表达式的 select 子句中，以便返回源序列中每个对象的属性子集
            List<Product> products = new List<Product>();
            products.Add(new Product { Color = "red", Price = 1 });
            products.Add(new Product { Color = "yello", Price = 2 });

            //严重性	代码	说明	项目	文件	行	禁止显示状态
            //错误 CS0266  无法将类型“System.Collections.Generic.IEnumerable << anonymous type: string Color, int Price>>”
            //隐式转换为“System.Collections.Generic.IEnumerable < CSharpBase.Base.Product >”
            //IEnumerable<Product> productQuery = from prod in products
            //                                    select new { prod.Color, prod.Price };
            var productQuery = from prod in products
                               select new { prod.Color, prod.Price };
            foreach (var p in productQuery)
            {
                Console.WriteLine("Color={0}, Price={1}", p.Color, p.Price);
            }

            //另一种类型（类、结构或另一个匿名类型）的对象定义字段
            var product = new Product();
            var bonus = new { note = "You won!" };
            var shipment = new { address = "Nowhere St.", product };
            var shipmentWithBonus = new { address = "Somewhere St.", product, bonus };
            Console.WriteLine(shipment.product.Color);


            //将隐式键入的本地变量与隐式键入的数组相结合创建匿名键入的元素的数组
            var anonArray = new[] { new { name = "apple", diam = 4 }, new { name = "grape", diam = 1 } };

            //匿名类型支持采用 with 表达式形式的非破坏性修改。 这使你能够创建匿名类型的新实例，其中一个或多个属性具有新值
            var apple = new { Item = "apples", Price = 1.35 };
            var onSale = apple with { Price = 0.79 };
            Console.WriteLine(apple);
            Console.WriteLine(onSale);


            //匿名类型确实会重写 ToString 方法，将用大括号括起来的每个属性的名称和 ToString 输出连接起来
            var a = new { Title = "Hello", Age = 24 };

            Console.WriteLine(a.ToString()); // "{ Title = Hello, Age = 24 }"
        }
    }

    class Product
    {
        public string Color { get; set; }
        public int Price { get; set; }
    }
}
