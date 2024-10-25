using System.Text;
using DataStructures.Library.Nodes;

namespace DataStructures.Library.Structures
{
    /// <summary>
    /// Custom implementation of Linked Listfor educational purposes
    /// </summary>
    /// <typeparam name="T">Represents the type of elements in list</typeparam>
    public class OneSidedLinkedList<T>
    {
        private LinkedListElement<T>? _head = null;
        private LinkedListElement<T>? _tail = null;
        public int Count { get; private set; } = 0;
        public bool IsEmpty { get => Count == 0; }
        /// <summary>
        /// Indexer for List
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns>Element at specified index</returns>
        public T this[int index]
        {
            get
            {
                LinkedListElement<T> temp = GetElementAt(index);
                return temp.Data;
            }
            set
            {
                LinkedListElement<T> temp = GetElementAt(index);
                temp.Data = value;
            }
        }
        /// <summary>
        /// Get element at specified index
        /// </summary>
        /// <param name="index">Required index of element</param>
        /// <returns>Element at specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Index was too small or too big</exception>
        /// <exception cref="ArgumentNullException">Can't explain... Only to remove the warning from the VS</exception>
        private LinkedListElement<T> GetElementAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            LinkedListElement<T>? temp = _head;
            for (int i = 0; i < index; i++, temp = temp?.Next) ;
            if (temp == null)
                throw new ArgumentNullException(nameof(index));
            return temp;
        }
        public OneSidedLinkedList() { }
        public OneSidedLinkedList(IEnumerable<T> values)
        {
            foreach (T value in values)
            {
                Add(value);
            }
        }
        /// <summary>
        /// Add new element to List
        /// </summary>
        /// <param name="element">Element to Add</param>
        /// <returns>Always true</returns>
        public bool Add(T element)
        {
            if (_head == null)
            {
                _head = new LinkedListElement<T>(element);
                _tail = _head;
            }
            else
            {
                //_tail can't be null here, but VS don't know about it ;D
                if (_tail != null)
                {
                    _tail.Next = new LinkedListElement<T>(element);
                    _tail = _tail.Next;
                }
            }
            Count++;
            return true;
        }
        /// <summary>
        /// Find element in list by it's value. Not sure how it works on custom types
        /// </summary>
        /// <param name="value">Value of element to find</param>
        /// <returns>Element with specified value</returns>
        public T? Find(T value)
        {
            if (_head == null)
                return default;
            LinkedListElement<T>? temp = _head;
            while (temp != null)
            {
                if (temp.Data?.Equals(value) ?? false)
                    return temp.Data;
                temp = temp.Next;
            }
            return default;
        }
        //TODO: add predicate to find elements
        /// <summary>
        /// Remove element in list by it's value. Not sure how it works on custom types
        /// </summary>
        /// <param name="element">Element to remove</param>
        /// <returns>True if element was succesfully removed, otherwise - false</returns>
        public bool Remove(T element)
        {
            if (_head == null)
                return false;
            if (_head.Data?.Equals(element) ?? false)
            {
                _head = _head.Next;
                Count--;
                return true;
            }
            LinkedListElement<T>? temp = _head;
            while (temp != null)
            {
                if (temp.Next != null)
                {
                    if (temp.Next.Data?.Equals(element) ?? false)
                    {
                        temp.Next = temp.Next.Next;
                        if (temp.Next == null)
                            _tail = temp;
                        Count--;
                        return true;
                    }
                }
                temp = temp.Next;
            }
            return false;
        }
        //TODO: add predicate to find elements
        /// <summary>
        /// Remove all elements.
        /// </summary>
        /// <param name="element"></param>
        public void RemoveAll(T element)
        {
            while (Remove(element)) ;
        }
        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }
        /// <summary>
        /// "Fancy" output for list
        /// </summary>
        /// <returns>String representation of list</returns>
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
