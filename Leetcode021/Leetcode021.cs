/*
21. Merge Two Sorted Lists
 
You are given the heads of two sorted linked lists list1 and list2.
   
   Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.
   
   Return the head of the merged linked list.
 
 
 */

namespace Leetcode021
{
    public class Leetcode021
    {
        public static void Main(string[] args)
        {
            //var result = MergeTwoLists()
        }

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

        public static ListNode MergeTwoLists1(ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                return list2;
            } else if (list2 == null)
            {
                return list1;
            } else if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists1(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists1(list1, list2.next);
                return list2;
            }
        }

        public static ListNode MergeTwoLists2(ListNode list1, ListNode list2)
        {
            ListNode preHead = new ListNode(-1);
            ListNode prev = preHead;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    prev.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    prev.next = list2;
                    list2 = list2.next;
                }

                prev = prev.next;
            }

            prev.next = list1 == null ? list2 : list1;
            
            return preHead.next;
        }
    }
}