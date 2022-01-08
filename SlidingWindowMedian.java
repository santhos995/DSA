import java.util.*;

public class SlidingWindowMedian {
    int count = 0;
    MinHeap minHeap = new MinHeap();//all values greater than or equals to median will be stored here
    MaxHeap maxHeap = new MaxHeap();//all values less than or equals to median are stored here

    public double[] findSlidingWindowMedian(int[] nums, int k) throws Exception{

        try{
            double[] result = new double[nums.length - k + 1];
            // TODO: Write your code here
            int wEd = 0;

            for(int wSt =0;wSt<nums.length;wSt++){
                System.out.println(wSt);
                if(wSt < k){
                    insertNum(nums[wSt]);
                }
                else{
                    result[wEd] = findMedian();
                    removeNum(nums[wEd]);
                    insertNum(nums[wSt]);
                    wEd++;

                }
            }
            result[wEd] = findMedian();//this is to get median of last added number

            return result;
        } catch (Exception e) {
            System.out.println(e);
        }
        return new double[]{};
    }
    public void insertNum(int num) {
        System.out.println("insert called - " + num);
        if (count == 0) {
            maxHeap.add(num);
            count++;
            return;
        }

        if (!removeHappenedAtMaxHeap() && maxHeap.peek() > num) {
            maxHeap.add(num);
        } else {
            minHeap.add(num);
        }

        rebalanceHeap();

        count++;
    }

    private boolean removeHappenedAtMaxHeap() {//this condition will only happen when there is no element in maxheap
        return (minHeap.count()>0 && maxHeap.count()==0);
    }

    public double findMedian() {
        System.out.println(String.format("count - %s, min peek - %s, max peek - %s", count, minHeap.peek(), maxHeap.peek()));
        if (count % 2 == 0)
            return (double)(minHeap.peek() + maxHeap.peek()) / 2;
        return maxHeap.count() > minHeap.count() ? maxHeap.peek() : minHeap.peek();
    }

    private void removeNum(int num){
        if(maxHeap.peek()>=num)
            maxHeap.remove(num);
        else
            minHeap.remove(num);
        count--;
        rebalanceHeap();
    }
    private void rebalanceHeap() {
        if (Math.abs(maxHeap.count() - minHeap.count()) > 1) {//rebalance between heaps is needed
            if (maxHeap.count() > minHeap.count()) {//remove top value from maxHead and add it to minHeap
                minHeap.add(maxHeap.poll());
            } else {
                maxHeap.add(minHeap.poll());
            }
        }
    }
    public static void main(String[] args) {
        SlidingWindowMedian slidingWindowMedian = new SlidingWindowMedian();
        try{
            double[] result = slidingWindowMedian.findSlidingWindowMedian(new int[] { 1, 2, -1, 3, 5 }, 2);

            System.out.print("Sliding window medians are: ");
            for (double num : result)
                System.out.print(num + " ");
            System.out.println();

            /*
            slidingWindowMedian = new SlidingWindowMedian();

            result = slidingWindowMedian.findSlidingWindowMedian(new int[] { 1, 2, -1, 3, 5 }, 3);
            System.out.print("Sliding window medians are: ");
            for (double num : result)
                System.out.print(num + " ");

             */
        }
        catch(Exception e){
            System.out.println(e);
        }
    }

    class MinHeap {
        List<Integer> nums = new ArrayList<>();

        void MinHeap() {
            nums = new ArrayList<>();
        }

        void add(int val) {
            nums.add(val);
            heapifyUp(nums.size() - 1);//Heapify has to be done on its parent
        }

        int peek() {
            return nums.get(0);
        }

        int poll() {
            int num = nums.get(0);
            nums.set(0, nums.get(nums.size() - 1));
            nums.remove(nums.size() - 1);
            heapify(0);
            return num;
        }

        void heapify(int i) {
            if (i < 0) return;
            int k = i;
            int left = 2 * i;
            int right = left + 1;
            if (left < nums.size() && nums.get(left) < nums.get(k))
                k = left;
            if (right < nums.size() && nums.get(right) < nums.get(k))
                k = right;
            if (k != i) {
                swap(i, k);
                heapify(k);
            }
        }

        private void heapifyUp(int i) {
            int parent = i / 2;
            if (parent < 0) return;

            if (nums.get(parent) > nums.get(i)) {
                swap(i, parent);
                heapify(parent);//this is needed because the other child might break the heap property
                heapifyUp(parent);
            }
        }

        void swap(int i, int j) {
            int temp = nums.get(i);
            nums.set(i, nums.get(j));
            nums.set(j, temp);
        }

        public int count() {
            return nums.size();
        }
        public void remove(int val) {
            if(nums.size()==1 && nums.get(0) == val) {
                nums.remove(0);
                return;
            }
            int index = linearSearch(val);
            if(index == -1)
                return;

            swap(index, nums.size()-1);
            nums.remove(nums.size()-1);
            heapify(index);
        }

        private int linearSearch(int val) {
            for(int i=0;i<nums.size()-1;i++){
                if(nums.get(i) == val)
                    return i;
            }
            return -1;
        }
    }

    class MaxHeap {
        List<Integer> nums = new ArrayList<>();

        void MaxHeap() {
            nums = new ArrayList<>();
        }

        void add(int val) {
            nums.add(val);
            heapifyUp(nums.size() - 1);//Heapify has to be done on its parent
        }

        int peek() {
            return nums.get(0);
        }

        int poll() {
            int num = nums.get(0);
            nums.set(0, nums.get(nums.size() - 1));
            nums.remove(nums.size() - 1);
            heapify(0);
            return num;
        }

        void heapify(int i) {
            if (i < 0) return;
            int k = i;
            int left = 2 * i;
            int right = left + 1;
            if (left < nums.size() && nums.get(left) > nums.get(k))
                k = left;
            if (right < nums.size() && nums.get(right) > nums.get(k))
                k = right;
            if (k != i) {
                swap(i, k);
                heapify(k);
            }
        }

        private void heapifyUp(int i) {
            int parent = i / 2;
            if (parent < 0) return;

            if (nums.get(parent) < nums.get(i)) {
                swap(i, parent);
                heapify(parent);
                heapifyUp(parent);
            }
        }

        void swap(int i, int j) {
            int temp = nums.get(i);
            nums.set(i, nums.get(j));
            nums.set(j, temp);
        }

        public int count() {
            return nums.size();
        }
        public void remove(int val) {
            if(nums.size()==1 && nums.get(0) == val) {
                nums.remove(0);
                return;
            }
            int index = linearSearch(val);
            if(index == -1)
                return;

            swap(index, nums.size()-1);
            nums.remove(nums.size()-1);
            heapify(index);
        }

        private int linearSearch(int val) {
            for(int i=0;i<nums.size()-1;i++){
                if(nums.get(i) == val)
                    return i;
            }
            return -1;
        }
    }

}