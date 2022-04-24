using System;
using System.Collections.Generic;

namespace Coding_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a linked using Class ListNode
            /* var node2 = new ListNode(2);
            var node1 = new ListNode(1, node2);

            SwapPairs(node1); */

            /*var result = SumTwoNumbers(new int[]{ 2, 7, 11, 15}, 9);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }*/

            //var input = new int[]{ 2, 7, 11, 15};
            //Console.WriteLine();
            //var list1 = new List<int> { 1, 3, 2, 4};

            //var result = ReverseArray(list1);            
            //Console.WriteLine(SingleNumber([2, 2, 1]))


            // Prority Queue Problems section.

            //#problem:347 => Top K frequent elements
            
            /*var pQueue = new PriorityQueue<Number>();

            var input = new int[] {6,0,1,4,9,7,-3,1,-4,-8,4,-7,-3,3,2,-3,9,5,-4,0};
            var valuePair = new Dictionary<int, int>();

            foreach(var i in input)
            {
                if(valuePair.ContainsKey(i))
                {
                    valuePair[i]++;
                }
                else
                {
                    valuePair.Add(i, 1);
                }
            }

            foreach(var item in valuePair)
            {
                pQueue.Insert(new Number(item.Key, item.Value));
            }          

            int k = 6;
            
            while(k > 0)
            {
                var item = pQueue.DeQueue();
                Console.WriteLine(item.NumberValue);                
                k--;
            }*/

            // problem 215
            /*var input = new int[] {3,2,3,1,2,4,5,5,6};
            int k = 4;

            var priorityQueue = new PriorityQueue<Number>();

            foreach(var i in input)
            {
                priorityQueue.Insert(new Number(i, i));
            }

            int j = int.MinValue;
            while(k > 0)
            {
                j = priorityQueue.DeQueue().NumberValue;
                k--;
            }*/

            //problem 506.
            /*var score = new int[]{10,3,8,9,4};
            var priorityQueue = new PriorityQueue<Number>();

            for(int i = 0; i< score.Length; i++)
            {
                priorityQueue.Insert(new Number(i, score[i]));
            }

            var output = new string[score.Length];
            var j = 0;
            while(j < score.Length)
            {
                var number = priorityQueue.DeQueue();
                var num = number.NumberValue;
                Console.WriteLine(number.Priority);
                switch(j)
                {
                    case 0:
                    output[num] = "Gold Medal";
                    break;
                    case 1:
                    output[num] = "Silver Medal";
                    break;
                    case 2:
                    output[num] = "Bronze Medal";
                    break;
                    default:
                    output[num] = (j+1).ToString();
                    break;
                }
                
                j++;
            }*/

            // problem: 2099
            var nums = new int[] {50, -75};
            var output = new int[2];
            var temp = new int[nums.Length];

            var priorityQueue = new PriorityQueue<Number>();

            for(int i = 0; i< nums.Length; i++)
            {
                priorityQueue.Insert(new Number(i, nums[i]));
            }

            for(int l = 0; l < temp.Length; l++)
            {
                temp[l] = int.MinValue;
            }
            int k = 2;

            var j = 0;
            while(k > 0)
            {
                var number1 = priorityQueue.DeQueue();
                temp[number1.NumberValue] = number1.Priority;
                k--;
            }            
            
            foreach(var y in temp)
            {
                if(y != int.MinValue)
                {
                    output[j++] = y;
                }
            }

            foreach(var x in output)
            {
                Console.WriteLine(x);
            }

            // problem: 373...pending
            /*var num1 = new int[] {1, 1, 2};
            var num2 = new int[] {1, 2, 3};
            var minPriorityQueue = new MinPriorityQueue<NumberPair>();
            int k = 10;

            for(int i=0; i < num1.Length && i < k ; i++)
            {
                var pair = num1[i] +","+num2[0];
                minPriorityQueue.Insert(new NumberPair(pair, num1[i]+num2[0]));
            }

            var resultList = new List<IList<int>>();
            
            while(k > 0 && minPriorityQueue.GetCount() > 0)
            {
                var pairResult = minPriorityQueue.DeQueue().Pair;
                var pairArray = pairResult.Split(',');
                var n1 = Convert.ToInt32(pairArray[0]);
                resultList.Add(new List<int>{ Convert.ToInt32(pairArray[0]), Convert.ToInt32(pairArray[1])});                
                var j = 0;
                if(j < num2.Length)
                {
                    minPriorityQueue.Insert(new NumberPair(n1+","+num2[j+1], n1+num2[j+1]));
                    //j++;
                }
                k--;
            }*/
        }

        public static List<int> ReverseArray(List<int> arr)
        {
            int n = arr.Count;
            int n1= n/2;

            for(int i = 0; i <= n1; i++)
            {
                var j = n - 1 - i;

                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            //string.Compare("","", StringComparison.CurrentCultureIgnoreCase)!=0
            return arr;
        }
        
        static decimal Divide(int p, int q)
        {
            var res = (decimal)0;
            
            try
            {
                res = (decimal)p/q;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("ddivide not possible.");
            }

            return res;
        }

        /// <summary>
        /// Swaps a pair of adjacent nodes in a linked list.
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode SwapPairs(ListNode head) {
        if (head == null || head.next == null)
            {
                return head;
            }

            var temp = head;
            ListNode prevNode = null;
            head = head.next;

            while (temp!= null && temp.next != null)
            {
                var tempNext = temp.next;
                var temp1 = tempNext.next;

                 tempNext.next = temp;
                 temp.next = temp1;

                 if (prevNode != null)
                 {
                     prevNode.next = tempNext;
                 }

                 prevNode = temp;
                 temp = temp.next;
            }

            return head;
        }

        /// <summary>
        /// Function to return pair of indexes of numbers that add to give target.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] SumTwoNumbers(int[] nums, int target)
        {
            var targetValuePair = new Dictionary<int,int>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                if(targetValuePair.ContainsKey(nums[i]))
                {
                    return new int[]{ targetValuePair[nums[i]], i };
                }
                else if(!targetValuePair.ContainsKey(target-nums[i]))
                {
                    targetValuePair.Add(target-nums[i], i);
                }
            }

            return null;
        }

        public int SingleNumber(int[] nums) {
            var listToStore = new List<int>();

            foreach(var num in nums)
            {
                if(listToStore.Contains(num))
                {
                    listToStore.Remove(num);
                }
                else
                {
                    listToStore.Add(num);
                }
            }

            return listToStore[0];
        }
    }

     
    public class ListNode 
    {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
    }
}
