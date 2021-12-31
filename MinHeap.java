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
}
