public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        PriorityQueue<Element,int> pq = new PriorityQueue<Element,int>();
        int n = nums1.Length, m = nums2.Length;
        int median = (n+m)/2;
        bool isOdd = (n+m)%2==1;
        int i=0;
        int? m1 = null;
        
        if(n>0)
            pq.Enqueue(new Element(nums1[0],0,0),nums1[0]);
        if(m>0)
            pq.Enqueue(new Element(nums2[0],1,0),nums2[0]);
        
        while(pq.Count>0){
            var ele = pq.Dequeue();
            i++;
            if(i==median || i==median+1){
                if(isOdd && i == median+1)
                    return ele.val;
                else{
                    Console.WriteLine($"in-{ele.val}");
                    if(m1==null)
                        m1 = ele.val;
                    else{
                        return (double)((int)m1 + ele.val)/2;
                    }
                }
            }
            Console.WriteLine($"{ele.val}--{ele.row}--{ele.col}");
            int colCount = (ele.row==0)?n:m;
            int[] items = (ele.row==0)?nums1:nums2;
            if(ele.col+1<colCount){
                pq.Enqueue(new Element(items[ele.col+1],ele.row,ele.col+1),items[ele.col+1]);
            }
        }
        
        return -1;
    }
    class Element{
        internal int val;
        internal int row;
        internal int col;
        internal Element(int v, int r, int c){
            val = v;
            row = r;
            col = c;
        }
    }
}