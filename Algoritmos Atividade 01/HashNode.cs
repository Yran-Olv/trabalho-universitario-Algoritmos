namespace HashTableRefatorada
{
	/// <summary>Nó da lista encadeada em cada bucket (Separate Chaining).</summary>
	public sealed class HashNode
	{
		public string Key { get; }
		public HashNode? Next { get; set; }

		public HashNode(string key, HashNode? next = null)
		{
			Key = key;
			Next = next;
		}
	}
}