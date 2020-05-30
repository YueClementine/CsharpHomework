using System;

namespace _20200309
{
    class Program
    {
        public class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Data { get; set; }

            public Node(T t)
            {
                Next = null;
                Data = t;
            }
        }
        public class GenericList<T>
        {
            private Node<T> head;
            private Node<T> tail;

            public GenericList()
            {
                tail = head = null;
            }

            public Node<T> Head
            {
                get => head;
            }
            public void ForEach(Action<T> action)
            {
              
                Node<T> current = head;
                action(current.Data);
                while(current!=tail)
                {
                    current = current.Next;
                    action(current.Data);
                }
            }
            public void Add(T t)
            {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else
                {
                    tail.Next = n;
                    tail = n;
                }
            }
        }

        static void Main(string[] args)
        {
            GenericList<int> genericList = new GenericList<int>();
            for(int x = 0; x < 10; x++)
            {
                genericList.Add(x);
            }
            genericList.ForEach(x => Console.WriteLine(x));
            int sum = 0;
            genericList.ForEach(x => sum += x);
            Console.WriteLine(sum);
            int max = 0;
            genericList.ForEach(x => max = x >max ? x : max);
            Console.WriteLine(max);
            int min = 0;
            genericList.ForEach(x => min = x < min ? x : min);
            Console.WriteLine(min);

        }
    }
}
