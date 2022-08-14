/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode node = head, iter = head;
        ListNode prevNodeLastList = null, newHead = null;
        int count = 0;
        while(node!=null){
            count++;
            node = node.next;
        }
        node = head;
        while(count >=k){
            var firstNode = node;
            ListNode prev = prevNodeLastList, next = null;
            for(int i=0;i<k;i++){
                next = node.next;
                node.next = prev;
                prev = node;
                node = next;
            }
            if(newHead == null) newHead = prev;//this case, no previous group
            else prevNodeLastList.next = prev;//previous group exist, so point last node of previous group to first node of this group
            firstNode.next = node;
            prevNodeLastList = firstNode;
            
            count -= k; 
            
        }
        return newHead;
    }
}