
public class Heap<T> 
{
    List<T> storage;
    IComparer<T> comparer;
    public Heap(IComparer<T> comparer)
    {
        storage = new List<T>();
        //comparer = new IComparer<T>((a,b)=>a-b);
        this.comparer = comparer;
    }

    public void Add(T item){
        storage.Add(item);
        heapifyUp(storage.Count-1);
    }
    public T Poll(){
        System.Console.WriteLine($"heap count:{storage.Count}");
        T val = storage[0];
        storage[0] = storage[storage.Count-1];
        storage.RemoveAt(storage.Count-1);
        heapify(0);
        return val;
    }
    public int Count(){return storage.Count;}
    void heapifyUp(int i) {

        if(i<=0)
            return;
        int parent = i/2;

        if(comparer.Compare(storage[parent],storage[i])>0){//grt than 0 means val1 is grt than val2
            (storage[parent],storage[i]) = (storage[i],storage[parent]);
            heapify(parent);
            heapifyUp(parent);
        }

        
    }
    void heapify(int i) {
        if(i<0) return;
        int left = i*2;
        int right = i*2+1;
        int k = i;
        if(left<storage.Count && comparer.Compare(storage[i],storage[left])>0){
            k = left;
        }
        if(right<storage.Count && comparer.Compare(storage[k],storage[right])>0){
            k = right;
        }
        if(i!=k){
            (storage[k],storage[i]) = (storage[i],storage[k]);
            heapify(k);
        }
    }
}

