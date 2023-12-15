namespace CSharpBase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var student = new Student();
            student.Name = "yan";
            student.Id = 25;
            Console.WriteLine(student);
        }
    }

    //类
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Student()
        {

        }
        public Student(int id, string name) => (Id, Name) = (id, name);
        //等价于
        //public Student(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}

        //析构函数
        ~Student()
        {
        }
    }
}