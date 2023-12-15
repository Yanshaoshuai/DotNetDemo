using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.FunctionalTech
{
    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Person(string fname, string mname, string lname, string cityName, string stateName)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            City = cityName;
            State = stateName;
        }
        //多个重载的结构方法
        public void Deconstruct(out string fname, out string lname)
        {
            fname = FirstName;
            lname = LastName;
        }
        public void Deconstruct(out string fname, out string mname, out string lname)
        {
            fname = FirstName;
            mname = MiddleName;
            lname = LastName;
        }
        public void Deconstruct(out string fname, out string lname,
            out string city, out string state)
        {
            fname = FirstName;
            lname = LastName;
            city = City;
            state = State;
        }
    }

    internal class Discardeds
    {
        static void Main(string[] args)
        {
            var p = new Person("John", "Quincy", "Adams", "Boston", "MA");
            var (fName, _, city, _) = p;
            Console.WriteLine($"Hello {fName} of {city}");

            //switch模式匹配中使用弃元
            object?[] objects = [CultureInfo.CurrentCulture,
                CultureInfo.CurrentCulture.DateTimeFormat,
                CultureInfo.CurrentCulture.NumberFormat,
                new ArgumentException(),
                null];
            foreach (var obj in objects)
            {
                ProvidersFormatInfo(obj);
            }

            //在out参数中使用弃元作为占位符
            string[] dateStrings = ["05/01/2018 14:57:32.8",
                "2018-05-01 14:57:32.8",
                "2018-05-01T14:57:32.8375298-04:00",
                "5/01/2018",
                "5/01/2018 14:57:32.80 -07:00",
                "1 May 2018 2:57:32.8 PM",
                "16-05-2018 1:00:32 PM",
                "Fri, 15 May 2018 20:10:57 GMT"];
            foreach (var dateString in dateStrings)
            {
                if (DateTime.TryParse(dateString, out _))
                {
                    Console.WriteLine($"'{dateString}': valid");
                }
                else
                    Console.WriteLine($"'{dateString}': invalid");
            }

            //独立弃元
            //忽略返回值
            _ = args ?? throw new ArgumentNullException(paramName: nameof(args), message: "arg can't be null");
            //忽略异步操作返回值
            ExecuteAsyncMethods();
            Thread.Sleep(6000);
        }

        // _也是有效标识符 使用_作为变量又使用弃元会导致变量呗意外赋值
        private static void ShowValue(int _)
        {
            byte[] arr = [0, 0, 1, 2];
            _ = BitConverter.ToInt32(arr, 0);
            Console.WriteLine(_);
        }
        static async Task ExecuteAsyncMethods()
        {
            _ = Task.Run(() =>
            {
                var iterations = 0;
                for (int i = 0; i < int.MaxValue; i++)
                {
                    iterations++;
                }
                Console.WriteLine("Completed looping operation...");
                throw new InvalidOperationException();
            });
            await Task.Delay(5000);
            Console.WriteLine("Exiting after 5 second delay");
        }
        static void ProvidersFormatInfo(object? obj) =>
            Console.WriteLine(obj switch
            {
                IFormatProvider fmt => $"{fmt.GetType()} object",
                null => "A null object reference: Its use could result in a NullReferenceException",
                _ => "Some object type without format information"
            });

    }
}
