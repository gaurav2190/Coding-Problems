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
                    // here i is to create a subarray with elements less than pivot incrementally.
                    i++;
                    Swap(arr[i], arr[j]);
                }
            }
            
            // swapping pivot with the appropriate element.
            Swap(arr[i+1], arr[r]);

            return i+1;
        }

        public void Swap(int a, int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public string QuickSorting(string input)
        {
            var stringArray = input.ToCharArray();
            QuickSortString(0, stringArray.Length-1, ref stringArray);
            var result = new string(stringArray);

            return result;
        }

        public void QuickSortString(int l, int r,ref char[] input)
        {
            if(l < r)
            {
                var pivotIndex = this.PartitionString(l, r, ref input);
                QuickSortString(l, pivotIndex-1, ref input);
                QuickSortString(pivotIndex, r, ref input);
            }            
        }

        public int PartitionString(int l, int r, ref char[] s)
        {
            int i = l-1;
            var pivot = (int)s[r];

            for(int j = l; j<r; j++)
            {
                if((int)s[j] <= pivot)
                {
                    i++;
                    this.SwapChar(i, j, ref s);
                }
            }
            this.SwapChar(i+1, r, ref s);

            return i+1;
        }

        public void SwapChar(int i, int j, ref char[] s)
        {
            var temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }
    }
}