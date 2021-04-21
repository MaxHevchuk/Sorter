using System;

namespace Sorter
{
    public interface IMethods
    {
        int BubbleSort<T>(ref T[] array, out long time) where T : IComparable<T>;
        int CocktailSort<T>(ref T[] array, out long time) where T : IComparable<T>;
        int InsertionSort<T>(ref T[] array, out long time) where T : IComparable<T>;
        int MergeSort<T>(ref T[] array, out long time) where T : IComparable<T>;
        int MergeSort<T>(ref T[] array, T[] temp, int left, int right) where T : IComparable<T>;
        int Merge<T>(ref T[] array, T[] temp, int left, int mid, int right) where T : IComparable<T>;
        int SelectionSort<T>(ref T[] array, out long time) where T : IComparable<T>;
    }
}