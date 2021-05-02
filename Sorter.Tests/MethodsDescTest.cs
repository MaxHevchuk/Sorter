using NUnit.Framework;

namespace Sorter.Tests
{
    public class MethodsDescTest
    {
        private readonly MethodsDesc _methodsDesc = new();
        private int[] _input = {5, 1, 3, 6, 2, 4};
        private readonly int[] _expected = {6, 5, 4, 3, 2, 1};

        [Test]
        public void BubbleSortTest()
        {
            _methodsDesc.BubbleSort(ref _input, out _, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }

        [Test]
        public void CocktailSortTest()
        {
            _methodsDesc.CocktailSort(ref _input, out _, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }

        [Test]
        public void InsertionTest()
        {
            _methodsDesc.InsertionSort(ref _input, out _, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }

        [Test]
        public void MergeSortTest()
        {
            _methodsDesc.MergeSort(ref _input, out _, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }

        [Test]
        public void SelectionSortTest()
        {
            _methodsDesc.SelectionSort(ref _input, out _, out _);
            Assert.AreEqual(_expected, _input);
            _input = new[] {5, 1, 3, 6, 2, 4};
        }
    }
}