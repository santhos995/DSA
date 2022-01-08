import java.util.*;

public class PriorityQueue<T> {
        List<T> nums = new ArrayList<>();
        Comparator<T> comparator;

        public PriorityQueue(Comparator<T> comparator) {
            this.comparator = comparator;
            nums = new ArrayList<>();
        }

        void add(T val) {
            nums.add(val);
            heapifyUp(nums.size() - 1);//Heapify has to be done on its parent
        }

        T peek() {
            return nums.get(0);
        }

        T poll() {
            T num = nums.get(0);
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
            if (left < nums.size() && comparator.compare(nums.get(left),nums.get(k))>0)
                k = left;
            if (right < nums.size() && comparator.compare(nums.get(right), nums.get(k))>0)
                k = right;
            if (k != i) {
                swap(i, k);
                heapify(k);
            }
        }

        private void heapifyUp(int i) {
            int parent = i / 2;
            if (parent < 0) return;

            if (comparator.compare(nums.get(parent), nums.get(i))<0) {
                swap(i, parent);
                heapify(parent);//this is needed because the other child might break the heap property
                heapifyUp(parent);
            }
        }

        void swap(int i, int j) {
            Collections.swap(nums,i,j);
        }

        public int count() {
            return nums.size();
        }
}