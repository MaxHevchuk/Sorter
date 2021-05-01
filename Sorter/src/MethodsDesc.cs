using System;
using System.Diagnostics;

namespace Sorter
{
    /// <summary>
    /// Provides the ability to sort an array of data in different methods in descending order.
    /// </summary>
    public class MethodsDesc : IMethods
    {
        /// <summary>
        /// Swaps two variables values.
        /// </summary>
        /// <param name="a">The first variable.</param>
        /// <param name="b">The second variable.</param>
        private static void Swap<T>(ref T a, ref T b) where T : IComparable<T>
        {
            var temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Sorts the data array using the bubble method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="time">The time it takes to sort the array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int BubbleSort<T>(ref T[] array, out long time) where T : IComparable<T>
        {
            var arrayLenght = array.Length;
            var permutations = 0;
            var swapped = false;

            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < arrayLenght - 1; i++)
            {
                for (var j = 0; j < arrayLenght - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) >= 0) continue;

                    Swap(ref array[j], ref array[j + 1]);
                    permutations++;
                    swapped = true;
                }

                // IF no two elements were swapped by inner loop, then break
                if (!swapped) break;
            }

            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;

            return permutations;
        }

        /// <summary>
        /// Sorts the data array using the cocktail method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="time">The time it takes to sort the array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int CocktailSort<T>(ref T[] array, out long time) where T : IComparable<T>
        {
            var arrayLenght = array.Length;
            var permutations = 0;
            var swapped = false;

            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < arrayLenght / 2; i++)
            {
                // from left to right
                for (var j = i; j < arrayLenght - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) >= 0) continue;

                    Swap(ref array[j], ref array[j + 1]);
                    permutations++;
                    swapped = true;
                }

                // from right to left
                for (var j = arrayLenght - 2 - i; j > i; j--)
                {
                    if (array[j - 1].CompareTo(array[j]) >= 0) continue;

                    Swap(ref array[j - 1], ref array[j]);
                    permutations++;
                    swapped = true;
                }

                // IF no two elements were swapped by inner loop, then break
                if (!swapped) break;
            }

            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;

            return permutations;
        }

        /// <summary>
        /// Sorts the data array using the insertion method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="time">The time it takes to sort the array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int InsertionSort<T>(ref T[] array, out long time) where T : IComparable<T>
        {
            var permutations = 0;

            var stopwatch = Stopwatch.StartNew();
            for (var i = 1; i < array.Length; i++)
            {
                var value = array[i];
                var j = i - 1;
                while (j >= 0 && array[j].CompareTo(value) < 0)
                {
                    Swap(ref array[j + 1], ref array[j]);
                    permutations++;
                    j--;
                }

                array[j + 1] = value;
            }

            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;

            return permutations;
        }

        /// <summary>
        /// Sorts the data array using the merge method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="time">The time it takes to sort the array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int MergeSort<T>(ref T[] array, out long time) where T : IComparable<T>
        {
            var temp = new T[array.Length];

            var stopwatch = Stopwatch.StartNew();
            var permutation = MergeSort(ref array, temp, 0, array.Length - 1);
            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;
            return permutation;
        }

        ///<summary>
        /// An auxiliary recursive method that sort the input array and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="temp">Auxiliary temporary array.</param>
        /// <param name="left">The first index of the temporary array.</param>
        /// <param name="right">The last index of the temporary array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int MergeSort<T>(ref T[] array, T[] temp, int left, int right) where T : IComparable<T>
        {
            var permutations = 0;
            if (right <= left) return permutations;

            var mid = (right + left) / 2;

            /* Inversion count will be the sum of inversions in left-part, right-part and number of inversions
                 in merging */
            permutations += MergeSort(ref array, temp, left, mid);
            permutations += MergeSort(ref array, temp, mid + 1, right);

            // Merge the two parts
            permutations += Merge(ref array, temp, left, mid + 1, right);

            return permutations;
        }

        /// <summary>
        /// Merges two sorted arrays and returns inversion count in the arrays.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="temp">Auxiliary temporary array.</param>
        /// <param name="left">The first index of the temporary array.</param>
        /// <param name="mid">The middle index of the temporary arrray.</param>
        /// <param name="right">The last index of the temporary array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int Merge<T>(ref T[] array, T[] temp, int left, int mid, int right) where T : IComparable<T>
        {
            {
                var permutations = 0;
                var i = left; // i is index for left subarray
                var j = mid; // j is index for right subarray
                var k = left; // k is index for resultant merged subarray

                while (i <= mid - 1 && j <= right)
                {
                    if (array[i].CompareTo(array[j]) >= 0)
                    {
                        temp[k++] = array[i++];
                    }
                    else
                    {
                        temp[k++] = array[j++];
                        permutations += mid - i;
                    }
                }

                // Copy the remaining elements of left subarray (if there are any) to temp
                while (i <= mid - 1)
                    temp[k++] = array[i++];

                // Copy the remaining elements of right subarray (if there are any) to temp
                while (j <= right)
                    temp[k++] = array[j++];

                // Copy back the merged elements to original array
                for (i = left; i <= right; i++)
                    array[i] = temp[i];
                return permutations;
            }
        }

        /// <summary>
        /// Sorts the data array using the selection method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Data array.</param>
        /// <param name="time">The time it takes to sort the array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int SelectionSort<T>(ref T[] array, out long time) where T : IComparable<T>
        {
            var arrayLength = array.Length;
            var permutations = 0;

            var stopwatch = Stopwatch.StartNew();
            for (var i = 0; i < arrayLength - 1; i++)
            {
                // Find the minimum element in unsorted array
                var minIndex = i;
                for (var j = i + 1; j < arrayLength; j++)
                    if (array[j].CompareTo(array[minIndex]) > 0)
                        minIndex = j;

                Swap(ref array[minIndex], ref array[i]);
                permutations++;
            }

            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;

            return permutations;
        }
    }
}