/*
 2. Add Two Numbers
   
   You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
   
   You may assume the two numbers do not contain any leading zero, except the number 0 itself.
   
   Example 1:
   
   
   Input: l1 = [2,4,3], l2 = [5,6,4]
   Output: [7,0,8]
   Explanation: 342 + 465 = 807.
   
   Example 2:
   
   Input: l1 = [0], l2 = [0]
   Output: [0]
   
   Example 3:
   
   Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
   Output: [8,9,9,9,0,0,0,1]
 */

using System.Diagnostics;

namespace Leetcode002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        // Definition for singly-linked list.
        public class ListNode 
        {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = null;
            ListNode tail = null;
            var carry = 0;

            while (l1 != null || l2 != null)
            {
                var n1 = l1 != null ? l1.val : 0;
                var n2 = l2 != null ? l2.val : 0;
                var sum = n1 + n2 + carry;

                if (head == null)
                {
                    head = tail = new ListNode(sum % 10);
                }
                else
                {
                    tail.next = new ListNode(sum % 10);
                    tail = tail.next;
                }

                carry = sum / 10;
                
                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }

            if (carry > 0)
            {
                tail.next = new ListNode(carry);
            }

            return head;
        }
    }
}