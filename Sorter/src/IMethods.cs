using System;

namespace Sorter
{
    public interface IMethods
    {
        void BubbleSort<T>(ref T[] array, out long time, out int permutations) where T : IComparable<T>;
        void CocktailSort<T>(ref T[] array, out long time, out int permutations) where T : IComparable<T>;
        void InsertionSort<T>(ref T[] array, out long time, out int permutations) where T : IComparable<T>;
        void MergeSort<T>(ref T[] array, out long time, out int permutations) where T : IComparable<T>;
        int MergeSort<T>(ref T[] array, T[] temp, int left, int right) where T : IComparable<T>;
        int Merge<T>(ref T[] array, T[] temp, int left, int mid, int right) where T : IComparable<T>;
        void SelectionSort<T>(ref T[] array, out long time, out int permutations) where T : IComparable<T>;
    }
}