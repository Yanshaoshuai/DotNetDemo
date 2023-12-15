using ExtensionMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSharpBase.ProgramGuide.ClassStructRecord.MethodTest
{

    /// <summary>
    /// 扩展方法必须在非泛型静态类中定义
    /// </summary>
    static class ExtensionMethod
    {

        static void Main(string[] args)
        {
            int[] ints = [10, 45, 15, 39, 21, 26];
            //OrderBy是System.Linq.Enumerable的方法
            //但其是静态方法且第一个参数是IEnumerable类型所以可作为ints的扩展方法
            Console.WriteLine(ints is IEnumerable);
            var result = ints.OrderBy(x => x);
            foreach (var i in result)
            {
                Console.WriteLine(i + " ");
            }

            Console.WriteLine(ints.IntsLength());

            string s = "Hello Extension Methods";
            Console.WriteLine(s.WordCount());
        }

        static int IntsLength(this int[] ints)
        {
            return ints.Length;
        }
    }



}

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
