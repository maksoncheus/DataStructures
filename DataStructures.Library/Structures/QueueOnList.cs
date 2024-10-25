using DataStructures.Library.Nodes;
using System.Text;

namespace DataStructures.Library.Structures
{
    /// <summary>
    /// Custom implementation of Queue based on LinkedList for educational purposes
    /// </summary>
    /// <typeparam name="T">Represents the type of elements in queue</typeparam>
    public class QueueOnList<T>
    {
        private OneSidedLinkedListElement<T>? _head = null;
        private OneSidedLinkedListElement<T>? _tail = null;
        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }
        public QueueOnList() { }
        public QueueOnList(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Enqueue(value);
            }
        }
        /// <summary>
        /// Add new element to Queue
        /// </summary>
        /// <param name="element">Element to add</param>
        public void Enqueue(T element)
        {
            if (_head == null)
            {
                _head = new OneSidedLinkedListElement<T>(element);
                _tail = _head;
            }
            else
            {
                //_tail can't be null here, but VS don't know about it ;D
                if (_tail != null)
                {
                    _tail.Next = new OneSidedLinkedListElement<T>(element);
                    _tail = _tail.Next;
                }
            }
            Count++;
        }
        /// <summary>
        /// Get first element of queue. Thed, remove it from structure
        /// </summary>
        /// <returns>First element of queue</returns>
        public T? Dequeue()
        {
            if (_head == null)
                return default;
            OneSidedLinkedListElement<T>? temp = _head;
            _head = _head.Next;
            return temp.Data;
        }
        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }
        /// <summary>
        /// "Fancy" output for queue
        /// </summary>
        /// <returns>String representation of queue</returns>
        public override string ToString()
        {
            OneSidedLinkedListElement<T>? temp = _head;
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
