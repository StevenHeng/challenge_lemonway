using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLib.UnitTests
{
    [TestClass]
    public class FibonacciTests
    {
        private static readonly Fibonacci fibonacci = new Fibonacci();
        private static readonly Dictionary<int,decimal> sequences = new Dictionary<int, decimal>();

        [TestMethod]
        [ExpectedException(typeof(MyLibraryException))]
        public void ComputeSequence_NegativeNumber_ThrowsAnException()
        {
            fibonacci.ComputeSequences("-10");
        }

        [TestMethod]
        [ExpectedException(typeof(MyLibraryException))]
        public void ComputeSequence_EmptyOrWhiteSpaceString_ThrowsAnException()
        {
            fibonacci.ComputeSequences("  ");
        }

        [TestMethod]
        [ExpectedException(typeof(MyLibraryException))]
        public void ComputeSequence_NullString_ThrowsAnException()
        {
            fibonacci.ComputeSequences(null);
        }

        [TestMethod]
        [ExpectedException(typeof(MyLibraryException))]
        public void ComputeSequence_StringWithoutNumber_ThrowsAnException()
        {
            fibonacci.ComputeSequences("no number");
        }

        [TestMethod]
        public void FindNthValue_For1AsNumber_ReturnValueShouldBe1()
        {
            var result = fibonacci.FindNthValue(sequences, 1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindNthValue_For2AsNumber_ReturnValueShouldBe1()
        {
            var result = fibonacci.FindNthValue(sequences, 2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FindNthValue_For27AsNumber_ReturnValueShouldBe196418()
        {
            var result = fibonacci.FindNthValue(sequences, 27);
            Assert.AreEqual(196418, result);
        }
    }
}
