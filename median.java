package com.company;

import java.util.*;

class Main {
    static int count = 0;
    static MinHeap minHeap = new MinHeap();//all values greater than or equals to median will be stored here
    static MaxHeap maxHeap = new MaxHeap();//all values less than or equals to median are stored here

    public void insertNum(int num) {
        if (count == 0) {
            maxHeap.add(num);
            count++;
            return;
        }

        if (maxHeap.peek() > num) {
            maxHeap.add(num);
        } else {
            minHeap.add(num);
        }

        rebalanceHeap();

        count++;
    }

    public double findMedian() {
        System.out.println(String.format("count - %s, min peek - %s, max peek - %s", count, minHeap.peek(), maxHeap.peek()));
        if (count % 2 == 0)
            return (double)(minHeap.peek() + maxHeap.peek()) / 2;
        return maxHeap.count() > minHeap.count() ? maxHeap.peek() : minHeap.peek();
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
        Main medianOfAStream = new Main();
        medianOfAStream.insertNum(3);
        medianOfAStream.insertNum(1);
        System.out.println("The median is: " + medianOfAStream.findMedian());
        medianOfAStream.insertNum(5);
        System.out.println("The median is: " + medianOfAStream.findMedian());
        medianOfAStream.insertNum(4);
        System.out.println("The median is: " + medianOfAStream.findMedian());
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
}