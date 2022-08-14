
using System.Collections.Generic;

namespace Sol
{


    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    public class Solution
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return head;
            var node = head;
            var map = new Dictionary<Node, Node>();
            while (node != null)
            {
                var n = new Node(node.val);
                map.Add(node, n);
                node = node.next;
            }
            node = head;
            var newHead = map[node];
            while (node != null)
            {
                Node newNode = map[node];
                if (node.next != null)
                    newNode.next = map[node.next];
                if (node.random != null)
                    newNode.random = map[node.random];
                node = node.next;
            }
            return newHead;
        }

        public Node CopyRandomList_Optimised(Node head)
        {
            if (head == null)
                return head;
            /*Three passes needed
                First pass - create new node and add it to the next pointer of 
                    original node and mark its next node to original node's next pointer
                Second pass - remap random pointers
                Third pass - remove original Nodes
            */
            Node node = head;
            while (node != null)
            {
                var newNode = new Node(node.val);
                newNode.next = node.next;
                node.next = newNode;
                node = newNode.next;
            }

            node = head;
            while(node != null)
            {
                if(node.random!=null)
                {
                    node.next.random = node.random.next;
                }
                node = node.next.next;
            }

            node = head;
            Node newHead = node.next;
            Node newListNode = newHead;
            while (newListNode != null && newListNode.next != null)
            {
                node.next = newListNode.next;
                node = node.next;
                newListNode.next = newListNode.next.next;
                newListNode = newListNode.next;

            }
            node.next = null;
            return newHead;
        }
    }
}