
public class HeapItr<T> 
{
    List<T> storage;
    IComparer<T> comparer;
    public HeapItr(IComparer<T> comparer)
    {
        storage = new List<T>();
        //comparer = new IComparer<T>((a,b)=>a-b);
        this.comparer = comparer;
    }

    public void Add(T item){
        //add to storage
        storage.Add(item);
        heapifyUp(storage.Count-1);
        
    }
    public T Peek(){
        return storage[0];
    }
    public T Poll(){
       System.Console.WriteLine($"heap count:{storage.Count}");
        T val = storage[0];
        storage[0] = storage[storage.Count-1];
        storage.RemoveAt(storage.Count-1);
        heapifyDown(0);
        return val;
    }
    void swap(int x, int y){
        (storage[x],storage[y]) = (storage[y], storage[x]);
    }
    public int Count(){return storage.Count;}
    void heapifyUp(int i) {
        if(i<=0) return;

        int parent = i/2;
        while(parent >= 0) {
            if(comparer.Compare(storage[parent],storage[i])>0){
                swap(i, parent);
                heapifyDown(parent);
                i = parent;
                parent /=2;
            }
            else{
                break;
            }
        }

        
    }
    void heapifyDown(int i) {
       if(i<0) return ;

       int left = i*2;
       int right = i*2+1;

       while(left<storage.Count){
        int k = i;
        if(comparer.Compare(storage[k],storage[left])>0){
            k = left;
        }
        if(right <storage.Count && comparer.Compare(storage[k],storage[right])>0){
            k = right;
        }
        if(k==i) break;

        swap(i,k);
        i = k;
        left = i*2;
        right = i*2+1;
       }
    }
}

