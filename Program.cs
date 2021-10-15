using System;

namespace Coding_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a linked using Class ListNode
            var node1 = new ListNode(1, node2);
            var node2 = new ListNode(2);

            SwapPairs(node1);
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
