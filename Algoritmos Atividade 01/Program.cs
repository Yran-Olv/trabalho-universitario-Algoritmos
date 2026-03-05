// Program.cs

using System;

namespace HashTableRefatorada
{
	internal static class Program
	{
		static void Main()
		{
			Console.WriteLine("=== Hash Table Demo (Refatorada - Separate Chaining) ===\n");

			var table = new HashTable(size: 7);

			// FEED (dados iniciais) - pequeno de propósito para gerar colisões
			var seed = new[]
			{
				"RANDY", "ERIC", "STAN", "ANA", "JULIA", "RICARDO",
				"RAY", "EDU", "RAFA", "NAT", "ELISA", "JUJU"
			};

			Console.WriteLine("Inserindo seed...\n");
			foreach (var name in seed)
			{
				Console.WriteLine($"Insert({name})");
				table.Insert(name);
			}

			Console.WriteLine("\nEstado interno após seed:");
			table.Dump();

			// Demonstrações: comportamento correto com Separate Chaining
			Console.WriteLine("\n=== Demonstrações (comportamento correto com encadeamento separado) ===");

			// 1) Busca funciona corretamente mesmo com colisões e após remoções
			DemoContains(table, "ERIC");
			DemoContains(table, "RANDY");
			DemoContains(table, "STAN");
			DemoContains(table, "INEXISTENTE");

			// 2) Remoção correta: não quebra o caminho de busca (cada bucket é uma lista independente)
			Console.WriteLine("\nRemovendo ERIC (não quebra buscas de outros itens no mesmo bucket)...");
			table.Remove("ERIC");

			Console.WriteLine("\nEstado interno após Remove(ERIC):");
			table.Dump();

			DemoContains(table, "ERIC");  // false
			DemoContains(table, "RANDY"); // true
			DemoContains(table, "STAN");  // true

			// 3) Inserção: duplicata ignorada
			Console.WriteLine("\nInserindo novamente RANDY (duplicata deve ser ignorada)...");
			table.Insert("RANDY");

			Console.WriteLine("\nEstado interno após Insert(RANDY) novamente:");
			table.Dump();

			Console.WriteLine("\n=== Fim do demo ===");
			Console.WriteLine("\nREFATORAÇÃO REALIZADA:");
			Console.WriteLine("- HashTable com Separate Chaining (array de buckets com lista encadeada).");
			Console.WriteLine("- Insert/Contains/Remove corretos, com função hash ASCII%size preservada.");
			Console.WriteLine("- Colisões não quebram busca/remoção; tabela funciona sob carga.\n");

			Console.WriteLine("Pressione ENTER para sair.");
			Console.ReadLine();
		}

		private static void DemoContains(HashTable table, string key)
		{
			var result = table.Contains(key);
			Console.WriteLine($"Contains({key}) => {result}");
		}
	}
}
