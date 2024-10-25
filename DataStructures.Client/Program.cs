using DataStructures.Library.Structures;

namespace DataStructures.Client
{
    internal class Program
    {
        static void Main()
        {
            QueueOnList<int> queue = new QueueOnList<int>([1,2,3,4,5,6,7,8,9]);
            Console.WriteLine(queue);
            queue.Enqueue(10);
            Console.WriteLine(queue);
            queue.Dequeue();
            Console.WriteLine(queue);
        }
    }
}
