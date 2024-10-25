namespace DataStructures.Library.Nodes
{
    internal sealed class TwoSidedLinkedListElement<T>(T value)
    {
        public T Data { get; set; } = value;
        /// <summary>
        /// Link to next element of List
        /// </summary>
        public TwoSidedLinkedListElement<T>? Next { get; set; } = null;
        public TwoSidedLinkedListElement<T>? Previous { get; set; } = null;
    }
}
