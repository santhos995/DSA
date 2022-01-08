import java.security.KeyStore.Entry;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * KFrequentNumbers
 */
public class TopKFrequentNumbers {

    public static List<Integer> findTopKFrequentNumbers(int[] nums, int k) {
        List<Integer> topNumbers = new ArrayList<>(k);
        // TODO: Write your code here

        HashMap<Integer, Integer> map = new HashMap<>();
        for (Integer integer : nums) {
            if(map.containsKey(integer))
                map.put(integer, map.get(integer)+1);
            else    
                map.put(integer, 1);
        }

        PriorityQueue<Point> priorityQueue = new PriorityQueue<>(new MinPointComparator());

        for (Map.Entry<Integer,Integer> pt :
                map.entrySet()) {
            priorityQueue.add(new Point(pt.getKey(), pt.getValue()));
        }
        //ArrayList<Integer> topNumbers = new ArrayList<>(k);
        for (int i = 0; i < k; i++) {
            topNumbers.add(priorityQueue.poll().x);

        }

        return topNumbers;
      }
    
      public static void main(String[] args) {
        List<Integer> result = TopKFrequentNumbers.findTopKFrequentNumbers(new int[] { 1, 3, 5, 12, 11, 12, 11 }, 2);
        System.out.println("Here are the K frequent numbers: " + result);
    
        result = TopKFrequentNumbers.findTopKFrequentNumbers(new int[] { 5, 12, 11, 3, 11 }, 2);
        System.out.println("Here are the K frequent numbers: " + result);
      }
}