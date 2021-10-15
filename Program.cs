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

            var result = SumTwoNumbers(new int[]{ 2, 7, 11, 15}, 9);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
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
