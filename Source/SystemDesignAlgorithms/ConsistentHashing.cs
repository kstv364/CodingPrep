using System.Security.Cryptography;
using System.Text;

namespace Solutions.SystemDesignAlgorithms
{
    // Hash Function Interface
    public interface IHashFunction
    {
        int ComputeHash(string input);
    }

    // Default Hash Function using SHA256
    public class DefaultHashFunction : IHashFunction
    {
        public int ComputeHash(string input)
        {
            using var sha256 = SHA256.Create();
            byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToInt32(hash, 0) & 0x7FFFFFFF; // Ensure positive value
        }
    }

    // Consistent Hashing Class
    public class ConsistentHash<TNode>
    {
        private readonly SortedDictionary<int, TNode> _circle = new();
        private readonly IHashFunction _hashFunction;
        private readonly int _replicas;

        public ConsistentHash(IHashFunction hashFunction = null, int replicas = 100)
        {
            _hashFunction = hashFunction ?? new DefaultHashFunction();
            _replicas = replicas;
        }

        // Add a node to the hash ring
        public void AddNode(TNode node)
        {
            for (int i = 0; i < _replicas; i++)
            {
                string virtualNodeKey = $"{node}-{i}";
                int hash = _hashFunction.ComputeHash(virtualNodeKey);
                _circle[hash] = node;
            }
        }

        // Remove a node from the hash ring
        public void RemoveNode(TNode node)
        {
            for (int i = 0; i < _replicas; i++)
            {
                string virtualNodeKey = $"{node}-{i}";
                int hash = _hashFunction.ComputeHash(virtualNodeKey);
                _circle.Remove(hash);
            }
        }

        // Get the node for a given key
        public TNode GetNode(string key)
        {
            if (_circle.Count == 0)
            {
                throw new InvalidOperationException("No nodes available in the hash ring.");
            }

            int hash = _hashFunction.ComputeHash(key);
            foreach (var pair in _circle)
            {
                if (pair.Key >= hash)
                {
                    return pair.Value;
                }
            }

            // If not found, wrap around to the first node
            return _circle.Values.First();
        }

        // List all nodes in the hash ring (for debugging)
        public IEnumerable<TNode> GetAllNodes()
        {
            return _circle.Values.Distinct();
        }
    }

    // Example Usage
    class Program
    {
        static void Main(string[] args)
        {
            var consistentHash = new ConsistentHash<string>();

            consistentHash.AddNode("Node1");
            consistentHash.AddNode("Node2");
            consistentHash.AddNode("Node3");

            Console.WriteLine($"Key 'A' maps to: {consistentHash.GetNode("A")}");
            Console.WriteLine($"Key 'B' maps to: {consistentHash.GetNode("B")}");
            Console.WriteLine($"Key 'C' maps to: {consistentHash.GetNode("C")}");

            Console.WriteLine("\nRemoving Node2...\n");
            consistentHash.RemoveNode("Node2");

            Console.WriteLine($"Key 'A' maps to: {consistentHash.GetNode("A")}");
            Console.WriteLine($"Key 'B' maps to: {consistentHash.GetNode("B")}");
            Console.WriteLine($"Key 'C' maps to: {consistentHash.GetNode("C")}");
        }
    }
}
