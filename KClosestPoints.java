import java.util.ArrayList;
import java.util.List;

public class KClosestPoints {

    public static void main(String[] args) {

        Point[] points = new Point[]{
                new Point(1, 3),
                new Point(3, 4),
                new Point(2, -1),
                new Point(0,0),
                new Point(5,1)
        };
        List<Point> result = KClosestPoints.findClosestPoints(points, 4);
        System.out.print("Here are the k points closest the origin: ");
        for (Point p : result)
            System.out.print("[" + p.x + " , " + p.y + "] ");

    }

    private static List<Point> findClosestPoints(Point[] points, int k) {
        PriorityQueue<Point> priorityQueue = new PriorityQueue<>(new MinPointComparator());

        for (Point pt :
                points) {
            priorityQueue.add(pt);
        }
        ArrayList<Point> res = new ArrayList<>(k);
        for (int i = 0; i < k; i++) {
            res.add(priorityQueue.poll());

        }
        return res;
    }
}
