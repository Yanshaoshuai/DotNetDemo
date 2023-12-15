using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.FunctionalTech
{
    internal class PatternMatching
    {
        /// <summary>
        /// 测试变量是否与给定类型匹配
        /// 如果没有处理每个输入值，编译器会发出警告
        /// </summary>
        public static T MidPoint<T>(IEnumerable<T> sequence)
        {
            if (sequence is IList<T> list)
            {
                return list[list.Count / 2];
            }
            else if (sequence is null)
            {
                throw new ArgumentException(nameof(sequence), "Sequence can't be null");
            }
            else
            {
                int halfLength = sequence.Count() / 2 - 1;
                if (halfLength < 0) halfLength = 0;
                return sequence.Skip(halfLength).First();
            }
        }
        public class State { }
        public enum Operation
        {
            SystemTest,
            Start,
            Stop,
            Reset
        }
        State RunDiagnostics() { return new State(); }
        State StartSystem() { return new State(); }
        State StopSystem() { return new State(); }
        State ResetToReady() { return new State(); }

        //对枚举中声明的所有可能值进行数值测试
        public State PerformOperation(Operation command) =>
            command switch
            {
                Operation.SystemTest => RunDiagnostics(),
                Operation.Start => StartSystem(),
                Operation.Stop => StopSystem(),
                Operation.Reset => ResetToReady(),
                _ => throw new ArgumentException("Invalid enum value for command", nameof(command))
            };
        //匹配字符串
        public State PerformOperation(string command) =>
           command switch
           {
               "SystemTest" => RunDiagnostics(),
               "Start" => StartSystem(),
               "Stop" => StopSystem(),
               "Reset" => ResetToReady(),
               _ => throw new ArgumentException("Invalid string value for command", nameof(command)),
           };

        //从 C# 11 开始，还可以使用 Span<char> 或 ReadOnlySpan<char> 来测试常量字符串值
        public State PerformOperation(ReadOnlySpan<char> command) =>
           command switch
           {
               "SystemTest" => RunDiagnostics(),
               "Start" => StartSystem(),
               "Stop" => StopSystem(),
               "Reset" => ResetToReady(),
               _ => throw new ArgumentException("Invalid string value for command", nameof(command)),
           };

        //关系模式
        //使用关系模式测试如何将数值与常量进行比较
        string WaterState(int tempInFahrenheit) =>
            tempInFahrenheit switch
            {
                (> 32) and (< 212) => "liquid",
                < 32 => "solid",
                > 212 => "gas",
                32 => "solid/liquid transition",
                212 => "liquid / gas transition",
            };

        public record Order(int Items, decimal Cost);

        //位置模式
        //匹配记录
        public decimal CalculateDiscount(Order order) =>
            order switch
            {
                { Items: > 10, Cost: > 1000.00m } => 0.10m,
                { Items: > 5, Cost: > 500.00m } => 0.05m,
                { Cost: > 250.00m } => 0.02m,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var someObject => 0m,
            };
        public record class OrderWitDeconstruct(int Items, decimal Cost);

        //匹配定义了适当的结构方法的记录
        public decimal CalculateDiscountWitDeconstruct(OrderWitDeconstruct order) =>
            order switch
            {
                ( > 10, > 1000.00m) => 0.10m,
                ( > 5, > 50.00m) => 0.05m,
                { Cost: > 250.00m } => 0.02m,
                null => throw new ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
                var someObject => 0m,
            };


        static void Main(string[] args)
        {
            //null检查
            int? maybe = 12;
            //声明模式
            if (maybe is int number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {

                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }
            string? message = "This is not the null string";
            if (message is not null)
            {
                Console.WriteLine(message);
            }

            //列表模式
            decimal balance = 0m;
            foreach (string[] transaction in ReadRecords())
            {
                balance += transaction switch
                {
                    [_, "DEPOSIT", _, var amount] => decimal.Parse(amount),
                    [_, "WITHDRAWAL", .., var amount] => -decimal.Parse(amount),
                    [_, "INTEREST", var amount] => decimal.Parse(amount),
                    [_, "FEE", var fee] => -decimal.Parse(fee),
                    _ => throw new InvalidOperationException($"Record {string.Join(", ", transaction)} is not in the expected format!"),
                };
                Console.WriteLine($"Record: {string.Join(", ", transaction)}, New balance: {balance:C}");
            }
        }

        private static IEnumerable<string[]> ReadRecords()
        {
            return new List<string[]>() { new[] { "1", "DEPOSIT", "3", "1.11" } };
        }
    }
}
