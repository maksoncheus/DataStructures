using DataStructures.Library.Structures;

namespace DataStructures.Client
{
    internal class Program
    {
        static void Main()
        {
            StackOnList<int> stack = new([1,2,3,4,5,6,7,8]);
            Console.WriteLine(stack);
            stack.Push(9);
            Console.WriteLine(stack);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack);
        }
    }
}
