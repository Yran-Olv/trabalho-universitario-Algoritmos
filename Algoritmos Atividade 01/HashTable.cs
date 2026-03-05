using System;

namespace HashTableRefatorada
{
	/// <summary>
	/// Tabela hash refatorada: Separate Chaining (encadeamento separado).
	/// Cada bucket é uma lista encadeada (HashNode). Colisões não quebram busca/remoção.
	/// Função hash: soma dos códigos ASCII da chave % tamanho (preservada do enunciado).
	/// </summary>
	public sealed class HashTable
	{
		private readonly HashNode?[] _buckets;

		public HashTable(int size)
		{
			if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
			_buckets = new HashNode?[size];
		}

		public int Size => _buckets.Length;

		public int Hash(string key)
		{
			if (key is null) throw new ArgumentNullException(nameof(key));

			int sum = 0;
			foreach (var ch in key)
				sum += ch;

			return sum % _buckets.Length;
		}

		public void Insert(string key)
		{
			if (string.IsNullOrWhiteSpace(key)) return;

			int index = Hash(key);

			if (Contains(key)) return;

			_buckets[index] = new HashNode(key, _buckets[index]);
		}

		public bool Contains(string key)
		{
			if (string.IsNullOrWhiteSpace(key)) return false;

			int index = Hash(key);
			var current = _buckets[index];

			while (current != null)
			{
				if (string.Equals(current.Key, key, StringComparison.Ordinal))
					return true;

				current = current.Next;
			}

			return false;
		}

		public bool Remove(string key)
		{
			if (string.IsNullOrWhiteSpace(key)) return false;

			int index = Hash(key);

			HashNode? current = _buckets[index];
			HashNode? previous = null;

			while (current != null)
			{
				if (string.Equals(current.Key, key, StringComparison.Ordinal))
				{
					if (previous == null)
						_buckets[index] = current.Next;
					else
						previous.Next = current.Next;

					return true;
				}

				previous = current;
				current = current.Next;
			}

			return false;
		}

		public void Dump()
		{
			for (int i = 0; i < _buckets.Length; i++)
			{
				Console.Write($"[{i}] => ");

				var current = _buckets[i];
				if (current == null)
				{
					Console.WriteLine("(vazio)");
					continue;
				}

				while (current != null)
				{
					Console.Write(current.Key);
					current = current.Next;
					if (current != null) Console.Write(" -> ");
				}

				Console.WriteLine();
			}
		}
	}
}