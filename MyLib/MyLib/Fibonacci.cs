using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLib
{
    public class Fibonacci
    {
        public decimal FindNthValue(Dictionary<int, decimal> sequences, int n)
        {
            if (!sequences.ContainsKey(n))
            {
                if (n < 2) return n;
                else
                {
                    var result = FindNthValue(sequences, n - 1) + FindNthValue(sequences, n - 2);
                    sequences.Add(n, result);
                }
            }

            return sequences[n];
        }

        public decimal ComputeSequences(string input)
        {
            try
            {
                if (!input.All(Char.IsDigit) || String.IsNullOrWhiteSpace(input))
                    throw new MyLibraryException("Please enter a positive number.");

                Int32.TryParse(input, out int n);

                var sequences = new Dictionary<int, decimal>();
                var fibonacci = new Fibonacci();

                return FindNthValue(sequences, n);
            }
            catch (Exception ex)
            {
                throw new MyLibraryException(ex.Message);
            }
        }
    }
}