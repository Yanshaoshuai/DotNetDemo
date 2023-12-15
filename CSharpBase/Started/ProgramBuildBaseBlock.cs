using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.started
{
    internal class ProgramBuildBaseBlock
    {

        #region 字段
        //访问不受限制
        public string field1;
        //访问仅限于此类
        private string field2;
        //访问仅限于此类或派生自此类的类
        protected string field3;
        //仅可由当前程序集（.exe 或 .dll)访问
        internal string field4;
        //仅可由此类、从此类中派生的类，或者同一程序集中的类访问
        protected internal string field5;
        //仅可由此类或同一程序集中从此类中派生的类访问
        private protected string field6;

        //静态字段属于类永远只有一个静态字段副本 实例字段(非static字段)属于类实例每个类实例均包含相应类的所有实例字段的单独副本
        //readonly 修饰符声明只读字段 只能在字段声明期间或在同一个类的构造函数中赋值
        public static readonly int field7 = 0;
        #endregion

        #region 方法

        //方法签名包含方法名称、类型参数数量及其参数的数量、修饰符和类型。 方法签名不包含返回类型

        //当方法主体是单个表达式时，可使用紧凑表达式格式定义方法
        public override string ToString() => "This is an object";
        #endregion

        #region 参数
        //有四类参数：值参数、引用参数、输出参数和参数数组

        //值参数 修改值形参不会影响为其传递的实参
        static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        //引用参数 引用参数指出的存储位置与自变量相同
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        //输出参数  输出参数与引用参数类似，不同之处在于，不要求调用方提供自变量的显式赋值
        static void Divide(int x, int y, out int quotient, out int remainder)
        {
            quotient = x / y;
            remainder = x % y;
        }

        //参数数组 允许向方法传递数量不定的自变量 参数数组只能是方法的最后一个参数，且参数数组的类型必须是一维数组类型
        public static void Write(string fmt, params object[] args) { }
        public static void WriteLine(string fmt, params object[] args) { }
        #endregion

        #region 方法主体
        /// <summary>
        /// 指定了在调用方法时执行的语句
        /// </summary>
        public static void WriteSquares()
        {
            //局部变量  C# 要求必须先明确赋值局部变量，然后才能获取其值
            int i = 0;
            int j;
            while (i < 10)
            {
                j = i * i;
                Console.WriteLine($"{i} x {i} = {j}");
                i++;
            }
            //return 语句将控制权返回给调用方
            //return;
        }
        #endregion

        #region 静态和实例方法
        class Entity
        {
            static int s_nextSerialNo;
            int _serialNo;

            public Entity()
            {
                _serialNo = s_nextSerialNo++;
            }
            // 实例方法对特定的实例起作用，并能够访问静态和实例成员
            public int GetSerialNo()
            {
                return _serialNo;
            }
            // 静态方法不对特定的实例起作用，只能直接访问静态成员
            public static int GetNextSerialNo()
            {
                return s_nextSerialNo;
            }

            public static void SetNextSerialNo(int value)
            {
                s_nextSerialNo = value;
            }
        }
        #endregion

        #region 虚方法、重写方法和抽象方法
        public abstract class Expression
        {
            // 虚方法是在基类中声明和实现的方法
            // 抽象方法是在基类中声明的方法，必须在所有派生类中重写 不在基类中定义实现
            // 抽象方法是没有实现代码的虚方法
            // 抽象方法使用 abstract 修饰符进行声明，仅可在抽象类中使用。 必须在所有非抽象派生类中重写抽象方法。
            public abstract double Evaluate(Dictionary<string, object> vars);
        }

        public class Constant : Expression
        {
            double _value;

            public Constant(double value)
            {
                _value = value;
            }
            //重写方法是在派生类中实现的方法，可修改基类实现的行为
            public override double Evaluate(Dictionary<string, object> vars)
            {
                return _value;
            }
        }

        public class VariableReference : Expression
        {
            string _name;

            public VariableReference(string name)
            {
                _name = name;
            }

            public override double Evaluate(Dictionary<string, object> vars)
            {
                object value = vars[_name] ?? throw new Exception($"Unknown variable: {_name}");
                return Convert.ToDouble(value);
            }
        }

        public class Operation : Expression
        {
            Expression _left;
            char _op;
            Expression _right;

            public Operation(Expression left, char op, Expression right)
            {
                _left = left;
                _op = op;
                _right = right;
            }

            public override double Evaluate(Dictionary<string, object> vars)
            {
                double x = _left.Evaluate(vars);
                double y = _right.Evaluate(vars);
                switch (_op)
                {
                    case '+': return x + y;
                    case '-': return x - y;
                    case '*': return x * y;
                    case '/': return x / y;

                    default: throw new Exception("Unknown operator");
                }
            }
        }
        #endregion
        #region 构造函数、属性、索引器、事件、运算符和终结器
        public class MyList<T>
        {
            const int DefaultCapacity = 4;

            T[] _items;
            int _count;
            //构造函数
            public MyList(int capacity = DefaultCapacity)
            {
                _items = new T[capacity];
            }

            public int Count => _count;

            public int Capacity
            {
                get => _items.Length;
                set
                {
                    if (value < _count) value = _count;
                    if (value != _items.Length)
                    {
                        T[] newItems = new T[value];
                        Array.Copy(_items, 0, newItems, 0, _count);
                        _items = newItems;
                    }
                }
            }
            //索引器  可被重载 只要其参数的数量或类型不同即可
            public T this[int index]
            {
                get => _items[index];
                set
                {
                    if (!object.Equals(_items[index], value))
                    {
                        _items[index] = value;
                        OnChanged();
                    }
                }
            }

            public void Add(T item)
            {
                if (_count == Capacity) Capacity = _count * 2;
                _items[_count] = item;
                _count++;
                //触发事件
                OnChanged();
            }

            protected virtual void OnChanged() =>
                Changed?.Invoke(this, EventArgs.Empty);

            public override bool Equals(object other) =>
                Equals(this, other as MyList<T>);

            static bool Equals(MyList<T> a, MyList<T> b)
            {
                if (Object.ReferenceEquals(a, null)) return Object.ReferenceEquals(b, null);
                if (Object.ReferenceEquals(b, null) || a._count != b._count)
                    return false;
                for (int i = 0; i < a._count; i++)
                {
                    if (!object.Equals(a._items[i], b._items[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            //事件 类型必须是委托类型
            public event EventHandler Changed;


            //可以定义三种类型的运算符：一元运算符、二元运算符和转换运算符。 所有运算符都必须声明为 public 和 static。
            //运算符 == 
            public static bool operator ==(MyList<T> a, MyList<T> b) =>
                Equals(a, b);
            //运算符 !=
            public static bool operator !=(MyList<T> a, MyList<T> b) =>
                !Equals(a, b);
        }
        #endregion
        #region 方法重载
        //同一类中可以有多个同名的方法，只要这些方法具有唯一签名即可
        class OverloadingExample
        {
            static void F() => Console.WriteLine("F()");
            static void F(object x) => Console.WriteLine("F(object)");
            static void F(int x) => Console.WriteLine("F(int)");
            static void F(double x) => Console.WriteLine("F(double)");
            static void F<T>(T x) => Console.WriteLine($"F<T>(T), T is {typeof(T)}");
            static void F(double x, double y) => Console.WriteLine("F(double, double)");

            public static void UsageExample()
            {
                F();            // Invokes F()
                F(1);           // Invokes F(int)
                F(1.0);         // Invokes F(double)
                F("abc");       // Invokes F<T>(T), T is System.String
                F((double)1);   // Invokes F(double)
                F((object)1);   // Invokes F(object)
                F<int>(1);      // Invokes F<T>(T), T is System.Int32
                F(1, 1);        // Invokes F(double, double)
            }
        }
        static int s_changeCount;
        static void ListChanged(object sender, EventArgs e)
        {
            s_changeCount++;
        }
        #endregion
        static void Main(string[] args)
        {
            int i = 1, j = 2;
            Swap(i, j);
            Console.WriteLine($"{i} {j}");
            Swap(ref i, ref j);
            Console.WriteLine($"{i} {j}"); // "2 1"

            Divide(10, 3, out int quo, out int rem);
            Console.WriteLine($"{quo} {rem}");	// "3 1"

            int x = 3, y = 4, z = 5;
            Console.WriteLine("x={0} y={1} z={2}", x, y, z);
            string s = "x={0} y={1} z={2}";
            object[] arr = new object[3];
            arr[0] = x;
            arr[1] = y;
            arr[2] = z;
            Console.WriteLine(s, arr);

            Entity.SetNextSerialNo(1000);
            Entity e1 = new();
            Entity e2 = new();
            Console.WriteLine(e1.GetSerialNo());          // Outputs "1000"
            Console.WriteLine(e2.GetSerialNo());          // Outputs "1001"
            //Console.WriteLine(e2.GetNextSerialNo());          // error
            Console.WriteLine(Entity.GetNextSerialNo());  // Outputs "1002"


            Expression expression1 = new Operation(new VariableReference("x"),
            '+',
            new Constant(3));

            Expression expression2 = new Operation(new VariableReference("x"),
                '*',
                    new Operation(new VariableReference("y"),
                    '+',
                    new Constant(2)
                    )
            );
            Dictionary<string, object> vars = new();
            vars["x"] = 3;
            vars["y"] = 5;
            Console.WriteLine(expression2.Evaluate(vars)); // "21"
            vars["x"] = 1.5;
            vars["y"] = 9;
            Console.WriteLine(expression2.Evaluate(vars)); // "16.5"

            //使用 += 和 -= 运算符分别可以附加和删除事件处理程序
            var names = new MyList<string>();
            names.Changed += new EventHandler(ListChanged);
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            Console.WriteLine(s_changeCount); // "3"


            MyList<int> a = new();
            a.Add(1);
            a.Add(2);
            MyList<int> b = new();
            b.Add(1);
            b.Add(2);
            Console.WriteLine(a == b);  // Outputs "True"
            b.Add(3);
            Console.WriteLine(a == b);  // Outputs "False"
        }
    }
}
