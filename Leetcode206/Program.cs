/*
 206. Reverse Linked List
   
   Given the head of a singly linked list, reverse the list, and return the reversed list.
   
   
   Example 1:
   
   Input: head = [1,2,3,4,5]
   Output: [5,4,3,2,1]
   
   Example 2:
   
   Input: head = [1,2]
   Output: [2,1]
   
   Example 3:
   
   Input: head = []
   Output: []
   
   
   Constraints:
   
   The number of nodes in the list is the range [0, 5000].
   -5000 <= Node.val <= 5000
   
   
   Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
 */
namespace Leetcode206
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode ReverseList(ListNode head) 
        {
            ListNode current = head;
            ListNode prev = null;

            while (current.next != null )
            {
                var temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }

            return prev;
        }

        public ListNode ReverseList1(ListNode head) 
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode newHead = ReverseList1(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }

    }
}