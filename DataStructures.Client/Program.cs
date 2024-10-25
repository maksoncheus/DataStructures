using DataStructures.Library.Structures;

namespace DataStructures.Client
{
    internal class Program
    {
        static void Main()
        {
            TwoSidedLinkedList<int> list = new([1,2,3,4,5]);
            Console.WriteLine(list);
            list.Add(6);
            Console.WriteLine(list);
            list.Remove(list.Find(x => x == 6));
            list.Remove(list.Find(x => x == 1));
            list.Remove(list.Find(x => x == 3));
            Console.WriteLine(list);
        }
    }
}
