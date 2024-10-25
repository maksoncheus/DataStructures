using DataStructures.Library.Nodes;
using System.Text;
namespace DataStructures.Library.Structures
{
    /// <summary>
    /// Custom implementation of Stack based on linked list implementation for educational purposes
    /// </summary>
    /// <typeparam name="T">Represents the type of elements in stack</typeparam>
    public class StackOnList<T>
    {
        private LinkedListElement<T>? _head = null;
        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }

        public StackOnList() { }
        public StackOnList(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Push(value);
            }
        }
        /// <summary>
        /// Push new element to beginning of the Stack
        /// </summary>
        /// <param name="element">Element to push</param>
        public void Push(T element)
        {
            if (_head == null)
            {
                _head = new LinkedListElement<T>(element);
            }
            else
            {
                LinkedListElement<T> temp = new(element)
                {
                    Next = _head
                };
                _head = temp;
            }
            Count++;
        }
        /// <summary>
        /// Get top element of Stack and remove it from structure
        /// </summary>
        /// <returns>Top element of Stack</returns>
        public T? Pop()
        {
            if (_head == null)
                return default;
            LinkedListElement<T>? temp = _head;
            _head = _head.Next;
            return temp.Data;
        }
        /// <summary>
        /// Get top element of Stack
        /// </summary>
        /// <returns>Top element of Stack</returns>
        public T? Peek()
        {
            if (_head == null)
                return default;
            return _head.Data;
        }
        public void Clear()
        {
            _head = null;
            Count = 0;
        }
        /// <summary>
        /// "Fancy" output for stack
        /// </summary>
        /// <returns>String representation of stack</returns>
        public override string ToString()
        {
            LinkedListElement<T>? temp = _head;
            if (temp == null)
                return "Пустой список";
            StringBuilder sb = new();
            while (temp != null)
            {
                sb.Append((temp?.Data?.ToString() ?? "null") + " --> ");
                temp = temp?.Next;
            }
            sb.Append("null");
            return sb.ToString();
        }
    }
}
