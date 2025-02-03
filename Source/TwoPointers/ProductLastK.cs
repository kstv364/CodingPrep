//Design an algorithm that accepts a stream of integers and retrieves the product of the last k integers of the stream.

//Implement the ProductOfNumbers class:

//ProductOfNumbers() Initializes the object with an empty stream.
//void add(int num) Appends the integer num to the stream.
//int getProduct(int k) Returns the product of the last k numbers in the current list.You can assume that always the current list has at least k numbers.
//The test cases are generated so that, at any time, the product of any contiguous sequence of numbers will fit into a single 32-bit integer without overflowing.

namespace Solutions.TwoPointers
{
    public class ProductOfNumbers
    {
        private List<int> _stream = new List<int>();
        public ProductOfNumbers()
        {
        }

        public void Add(int num)
        {
            
            if (num == 0)
            {
                _stream.Clear();
                return;
            }
            int n = _stream.Count;
            if (n == 0)
            {
                _stream.Add(num);
            }
            else
            {
                _stream.Add(num * _stream[n - 1]);
            }
        }

        public int GetProduct(int k)
        {
           if(_stream.Count < k )
            {
                return 0;
            }
            if(_stream.Count == k)
            {
                return _stream[k - 1];
            }
            return _stream[_stream.Count - 1] / _stream[_stream.Count - k - 1];
        }
    }

}
