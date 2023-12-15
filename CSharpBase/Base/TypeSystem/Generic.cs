using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBase.Base.TypeSystem
{

    // type parameter T in angle brackets
    public class GenericList<T>
    {
        public void Add(T item) { }
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node? next;
            public Node? Next
            {
                get { return next; }
                set { next = value; }
            }

            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node? head;

        // constructor
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type:
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    internal class Generic
    {
        static void Main(string[] args)
        {
            GenericList<int> list1 = new GenericList<int>();
            list1.Add(1);
            GenericList<string> list2 = new GenericList<string>();
            list2.Add("a");

            GenericList<ICloneable> list3 = new GenericList<ICloneable>();
            list3.Add("b");

            GenericList<int> list = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }
            foreach (int i in list)
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}
