namespace Coding_Problems
{
    public class SortingAlgo
    {
        public void QuickSort(int l, int r,ref int[] arr)
        {
            if(l < r)
            {
                int pivot = Partition(l, r, ref arr);
                QuickSort(l, pivot, ref arr);
                QuickSort(pivot+1, r, ref arr);
            }
        }

        public int Partition(int l, int r, ref int[] arr)
        {
            int i = l-1, pivot = arr[r];

            for(int j = l; j < r; j++)
            {
                if(arr[j]<pivot)
                {
                    i++;
                    Swap(arr[i], arr[j]);
                }
            }
            
            Swap(arr[i+1], arr[r]);

            return i+1;
        }

        public void Swap(int a, int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}