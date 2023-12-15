using System.Reflection;

namespace CSharpBase.started
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }
    public class PointFactory(int numberOfPoints)//主构造函数
    {
        public IEnumerable<Point> CreatePoints()
        {
            Random generator = new Random();
            for (int i = 0; i < numberOfPoints; i++)
            {
                yield return new Point(generator.Next(), generator.Next());
            }
        }
    }

    /// <summary>
    /// 泛型类 类型
    /// </summary>
    /// <typeparam name="TFirst"></typeparam>
    /// <typeparam name="TSecond"></typeparam>
    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; }
        public TSecond Second { get; }
        public Pair(TFirst first, TSecond second) => (First, Second) = (first, second);
    }

    /// <summary>
    /// 继承
    /// </summary>
    public class Point3D : Point
    {
        public int Z { get; set; }
        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
    }

    /// <summary>
    /// 接口
    /// </summary>
    interface IControl
    {
        void Paint();
    }

    interface ITextBox : IControl
    {
        void SetText(string text);
    }

    interface IListBox : IControl
    {
        void SetItems(string[] items);
    }

    interface IComboBox : ITextBox, IListBox { }


    interface IDataBound
    {
        void Bind(Binder b);
    }


    /// <summary>
    /// 实现接口
    /// </summary>
    public class EditBox : IControl, IDataBound
    {
        public void Bind(Binder b)
        {
            throw new NotImplementedException();
        }

        public void Paint()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 枚举
    /// </summary>
    public enum SomeRootVegetable
    {
        HorseRadish,
        Radish,
        Turnip
    }

    [Flags]
    public enum Seasons
    {
        None = 0,
        Summer = 1,
        Autum = 2,
        Winter = 4,
        Spring = 8,
        All = Summer | Autum | Winter | Spring
    }

    internal class TypeTest
    {
        static void Main(string[] args)
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(1, 1);
            Console.WriteLine($"({p1.X},{p1.Y})");
            Console.WriteLine($"({p2.X},{p2.Y})");
            PointFactory pointFactory = new PointFactory(10);
            foreach (var point in pointFactory.CreatePoints())
            {
                Console.WriteLine($"({point.X},{point.Y})");
            }

            var pair = new Pair<int, string>(1, "two");
            int i = pair.First;
            string s = pair.Second;
            Console.WriteLine($"pair first={i},second={s}");


            //类型上转型
            Point a = new(10, 20);
            Point b = new Point3D(10, 20, 30);

            //接口上转型
            EditBox editBox = new();
            IControl control = editBox;
            IDataBound dataBound = editBox;


            //枚举
            Console.WriteLine(SomeRootVegetable.Turnip);
            Console.WriteLine(Seasons.Spring);
            Console.WriteLine(Seasons.All);

            //可为null
            int? optionalInt = default;
            Console.WriteLine(optionalInt);
            optionalInt = 5;
            Console.WriteLine(optionalInt);
            string? optionalText = default;
            Console.WriteLine(optionalText);
            optionalText = "Hello World";
            Console.WriteLine(optionalText);

            //元组
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}");
            Console.WriteLine(t2.GetType());
        }

    }

}
