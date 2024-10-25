namespace DataStructures.Library.Nodes
{
    /// <summary>
    /// Single element of linked list
    /// </summary>
    /// <typeparam name="T">Represents the type of element</typeparam>
    /// <param name="value">Value of element</param>
    internal sealed class LinkedListElement<T>(T value)
    {
        public T Data { get; set; } = value;
        /// <summary>
        /// Link to next element of List
        /// </summary>
        public LinkedListElement<T>? Next { get; set; } = null;
    }
}
