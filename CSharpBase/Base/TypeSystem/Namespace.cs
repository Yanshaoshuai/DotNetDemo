using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//global 命名空间是“根”命名空间：global::System 始终引用 .NET System 命名空间
using System;

namespace CSharpBase.Base.TypeSystem
{
    internal class Namespace
    {
        static void Main(string[] args)
        {
            //System 是一个命名空间，Console 是该命名空间中的一个类。
            Console.WriteLine("Hello World!");
            //可使用 using 关键字，这样就不必使用完整的名称
            Console.WriteLine("Hello World!");
        }
    }
}


//声明自己的命名空间可以帮助控制类和方法名称的范围
namespace SampleNamespace
{
    class SampleClass
    {
        public void SampleMethod()
        {
            Console.WriteLine(
                "SampleMethod inside SampleNamespace");
        }
    }
}

//从 C# 10 开始，可以为该文件中定义的所有类型声明一个命名空间
//namespace SampleNamespace;

//class AnotherSampleClass
//{
//    public void AnotherSampleMethod()
//    {
//        System.Console.WriteLine(
//            "SampleMethod inside SampleNamespace");
//    }
//}