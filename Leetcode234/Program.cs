/*
 234. Palindrome Linked List
   
   Given the head of a singly linked list, return true if it is a palindrome or false otherwise.
   
   
   
   Example 1:
   
   
   Input: head = [1,2,2,1]
   Output: true
   
   
   Example 2:
   
   
   Input: head = [1,2]
   Output: false
 */

using System.Collections;

namespace Leetcode234
{
    internal class Program
    {
        private ListNode frontPointer;
        
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

        public bool IsPalindrome(ListNode head) 
        {
            var values = new List<int>();

            var currentNode = head;
            
            while (currentNode != null)
            {
                values.Add(currentNode.val);
                currentNode = currentNode.next;
            }

            var front = 0;
            var end = values.Count - 1;

            while (front < end)
            {
                if (values[front] != values[end])
                {
                    return false;
                }

                front++;
                end--;
            }

            return true;
        }

        public bool IsPalindrome1(ListNode head) 
        {
            frontPointer = head;

            return RecursivelyCheck(head.next);
        }

        private bool RecursivelyCheck(ListNode currentNode)
        {
            if (currentNode != null)
            {
                if (!RecursivelyCheck(currentNode.next))
                {
                    return false;
                }

                if (frontPointer.val != currentNode.val)
                {
                    return false;
                }

                frontPointer = frontPointer.next;
            }
            return true;
        }

        public bool IsPalindrome2(ListNode head) 
        {
            var startNode = head;
            var firstHalfNode = EndofFirstHalf(head);
            var secondHalfStart = ReverseList(firstHalfNode.next);

            var p1 = head;
            var p2 = secondHalfStart;
            var result = true;

            while (result & p2 != null)
            {
                if (p1.val != p2.val)
                {
                    result = false;
                }

                p1 = p1.next;
                p2 = p2.next;
            }

            RecursivelyCheck(secondHalfStart);

            return result;
        }

        private ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode currentNode = head;

            while (currentNode != null)
            {
                var temp = currentNode.next;
                currentNode.next = prev;
                prev = currentNode;
                currentNode = temp;
            }

            return prev;
        }

        private ListNode EndofFirstHalf(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            return slow;
        }
    }
}