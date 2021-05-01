using NUnit.Framework;

namespace Sorter.Tests
{
    public class MethodsAscTest
    {
        private readonly MethodsAsc _methodsAsc = new();
        private int[] _input = {5, 1, 3, 6, 2, 4};
        private readonly int[] _expected = {1, 2, 3, 4, 5, 6};

        [Test]
        public void BubbleSortTest()
        {
            _methodsAsc.BubbleSort(ref _input, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }
        [Test]
        public void CocktailSortTest()
        {
            _methodsAsc.CocktailSort(ref _input, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }
        [Test]
        public void InsertionTest()
        {
            _methodsAsc.InsertionSort(ref _input, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }
        [Test]
        public void MergeSortTest()
        {
            _methodsAsc.MergeSort(ref _input, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }
        [Test]
        public void SelectionSortTest()
        {
            _methodsAsc.SelectionSort(ref _input, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }
    }
}