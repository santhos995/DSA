import java.util.Comparator;

public class MinPointComparator implements Comparator<Point> {


    @Override
    public int compare(Point o1, Point o2) {
        return  ((o2.x * o2.x) + (o2.y * o2.y)) - ((o1.x * o1.x) + (o1.y * o1.y));
    }
}
