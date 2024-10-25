using DataStructures.Library.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Library.Structures
{
    /// <summary>
    /// Custom implementation of Linked List for educational purposes
    /// </summary>
    /// <typeparam name="T">Represents the type of elements in list</typeparam>
    public class TwoSidedLinkedList<T>
    {
        private TwoSidedLinkedListElement<T>? _head = null;
        private TwoSidedLinkedListElement<T>? _tail = null;
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
                TwoSidedLinkedListElement<T> temp = GetElementAt(index);
                return temp.Data;
            }
            set
            {
                TwoSidedLinkedListElement<T> temp = GetElementAt(index);
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
        private TwoSidedLinkedListElement<T> GetElementAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            TwoSidedLinkedListElement<T>? temp = _head;
            for (int i = 0; i < index; i++, temp = temp?.Next) ;
            if (temp == null)
                throw new ArgumentNullException(nameof(index));
            return temp;
        }
        public TwoSidedLinkedList() { }
        public TwoSidedLinkedList(IEnumerable<T> values)
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
        public void Add(T element)
        {
            if (_head == null)
            {
                _head = new TwoSidedLinkedListElement<T>(element);
                _tail = _head;
            }
            else
            {
                //_tail can't be null here, but VS don't know about it ;D
                if (_tail != null)
                {
                    _tail.Next = new TwoSidedLinkedListElement<T>(element)
                    {
                        Previous = _tail
                    };
                    _tail = _tail.Next;
                }
            }
            Count++;
        }
        /// <summary>
        /// Find element by given expression in list.
        /// </summary>
        /// <param name="expression">Predicate to find element</param>
        /// <returns>An element  satisfying the expression</returns>
        public T? Find(Predicate<T> expression)
        {
            if (_head == null)
                return default;
            TwoSidedLinkedListElement<T>? temp = _head;
            while (temp != null)
            {
                if (expression(temp.Data))
                    return temp.Data;
                temp = temp.Next;
            }
            return default;
        }
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
                if(_head.Next != null)
                    _head.Next.Previous = null;
                _head = _head.Next;
                Count--;
                return true;
            }
            TwoSidedLinkedListElement<T>? temp = _head;
            while (temp != null)
            {
                if (temp.Next != null)
                {
                    if (temp.Next.Data?.Equals(element) ?? false)
                    {
                        if(temp.Next.Next != null)
                            temp.Next.Next.Previous = temp;
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
        public void RemoveAll(Predicate<T> expression)
        {
            T? temp = Find(expression);
            while (!EqualityComparer<T>.Default.Equals(temp, default))
            {
                if (temp != null)
                    Remove(temp);
                temp = Find(expression);
            }
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
            TwoSidedLinkedListElement<T>? temp = _head;
            if (temp == null)
                return "Пустой список";
            StringBuilder sb = new();
            while (temp != null)
            {
                sb.Append((temp?.Data?.ToString() ?? "null") + " <--> ");
                temp = temp?.Next;
            }
            sb.Append("null");
            return sb.ToString();
        }
    }
}
