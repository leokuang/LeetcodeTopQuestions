﻿/*
 * 19. Remove Nth Node From End of List
   Given the head of a linked list, remove the nth node from the end of the list and return its head.
   
   Example 1:
   
   Input: head = [1,2,3,4,5], n = 2
   Output: [1,2,3,5]
   
   Example 2:
   
   Input: head = [1], n = 1
   Output: []
   
   Example 3:
   
   Input: head = [1,2], n = 1
   Output: [1]
   
   
   Constraints:
   
   The number of nodes in the list is sz.
   1 <= sz <= 30
   0 <= Node.val <= 100
   1 <= n <= sz
   
   
   Follow up: Could you do this in one pass?
 */
namespace Leetcode019
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        //Definition for singly-linked list.
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var fast = head;
            var slow = dummy;

            for (var i = 0; i < n; i++)
            {
                fast = fast.next;
            }

            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;
            var result = dummy.next;
            
            return result;
        }
    }
}