using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.started
{
    internal class MainLanguageBlock
    {
        //声明委托
        delegate double Function(double x);
        class Multiplier
        {
            double _factor;

            public Multiplier(double factor) => _factor = factor;

            public double Multiply(double x) => x * _factor;
        }

        class DelegateExample
        {
            internal static double[] Apply(double[] a, Function f)
            {
                var result = new double[a.Length];
                for (int i = 0; i < a.Length; i++) result[i] = f(a[i]);
                return result;
            }


        }


        #region async/await
        //将 async 修饰符添加到方法声明中，以声明这是异步方法。 await 运算符通知编译器异步等待结果完成。
        public async Task<int> RetrieveDocsHomePage()
        {
            var client = new HttpClient();
            byte[] content = await client.GetByteArrayAsync("https://learn.microsoft.com/");

            Console.WriteLine($"{nameof(RetrieveDocsHomePage)}: Finished downloading.");

            //return 语句中指定的类型与方法的 Task<T> 声明中的类型参数匹配
            return content.Length;
        }

        #endregion

        #region Attribute
        //定义Attribute
        public class HelpAttribute : Attribute
        {
            string _url;
            string _topic;

            public HelpAttribute(string url) => _url = url;

            public string Url => _url;

            public string Topic
            {
                get => _topic;
                set => _topic = value;
            }
        }
        //使用Attribute
        [Help("https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/features")]
        public class Widget
        {
            [Help("https://learn.microsoft.com/dotnet/csharp/tour-of-csharp/features",
            Topic = "Display")]
            public void Display(string text) { }
        }
        #endregion
        static void Main(string[] args)
        {

            #region 数组
            int[] a = new int[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i * i;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"a[{i}] = {a[i]}");
            }
            int[] a1 = new int[10];
            int[,] a2 = new int[10, 5];
            int[,,] a3 = new int[10, 5, 2];
            int[][] aa = new int[3][];
            aa[0] = new int[10];
            aa[1] = new int[5];
            aa[2] = new int[20];

            int[] b = new int[] { 1, 2, 3 };
            int[] c = { 1, 2, 3 };
            //foreach 语句使用 IEnumerable<T> 接口，因此适用于任何集合
            foreach (int item in a)
            {
                Console.WriteLine(item);
            }
            #endregion

            //字符串内插  C# 字符串内插使你能够通过定义表达式（其结果放置在格式字符串中）来设置字符串格式
            //Console.WriteLine($"The low and high temperature on {weatherData.Date:MM-dd-yyyy}");
            //Console.WriteLine($"    was {weatherData.LowTemp} and {weatherData.HighTemp}.");
            // Output (similar to):
            // The low and high temperature on 08-11-2020
            //     was 5 and 30.

            //模式匹配

            #region 委托和 Lambda 表达式

            double[] d = { 0.0, 0.5, 1.0 };
            double[] squares = DelegateExample.Apply(d, (x) => x * x);
            double[] sines = DelegateExample.Apply(d, Math.Sin);
            Multiplier m = new(2.0);
            double[] doubles = DelegateExample.Apply(d, m.Multiply);

            #endregion

            #region Resolve Attribute
            Type widgetType = typeof(Widget);

            object[] widgetClassAttributes = widgetType.GetCustomAttributes(typeof(HelpAttribute), false);

            if (widgetClassAttributes.Length > 0)
            {
                HelpAttribute attr = (HelpAttribute)widgetClassAttributes[0];
                Console.WriteLine($"Widget class help URL : {attr.Url} - Related topic : {attr.Topic}");
            }

            System.Reflection.MethodInfo displayMethod = widgetType.GetMethod(nameof(Widget.Display));

            object[] displayMethodAttributes = displayMethod.GetCustomAttributes(typeof(HelpAttribute), false);

            if (displayMethodAttributes.Length > 0)
            {
                HelpAttribute attr = (HelpAttribute)displayMethodAttributes[0];
                Console.WriteLine($"Display method help URL : {attr.Url} - Related topic : {attr.Topic}");
            }
            #endregion

        }
    }
}
