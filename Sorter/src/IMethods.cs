namespace Sorter
{
    public interface IMethods
    {
        int BubbleSort(ref int[] array);
        int CocktailSort(ref int[] array);
        int InsertionSort(ref int[] array);
        int MergeSort(ref int[] array);
        int MergeSort(ref int[] array, int[] temp, int left, int right);
        int Merge(ref int[] array, int[] temp, int left, int mid, int right);
        int SelectionSort(ref int[] array);
    }
}