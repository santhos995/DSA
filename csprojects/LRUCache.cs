public class LRUCache {

    Dictionary<int, dll> cache;
    dll lastNode;
    dll dummyHead;
    int capacity;
    public LRUCache(int capacity) {
        this.capacity = capacity;
        cache=new();
        dummyHead = new dll(-1,-1);
    }
    
    public int Get(int key) {
        Console.WriteLine($"Get : {key}");
        if(!cache.ContainsKey(key))
            return -1;
        
        BringNodeToFront(cache[key]);
        return cache[key].val;
    }
    
    public void Put(int key, int value) {
        Console.WriteLine($"PUT : {key}-{value}");
        if(cache.Count==0){
            dll node = new dll(key,value);
            node.prev = dummyHead;
            dummyHead.next = node;
            lastNode = node;
            cache.Add(key,node);
            return;
        }
        if(!cache.ContainsKey(key)){
            if(cache.Count==capacity){
                int key1 = EvictLastNode();
                cache.Remove(key1);
                Console.WriteLine($"Evicts : {key1}");
            }
            dll node = AddNodeToFront(key, value);
            cache.Add(key, node);
        }else{
            UpdateValue(key, value);
            BringNodeToFront(cache[key]);
        }

    }
    void UpdateValue(int key, int val){
        cache[key].val = val;
    }

    void BringNodeToFront(dll node){
        Console.WriteLine($"Bring {node.val}:{lastNode.val}");
        if(node==lastNode){
            lastNode = lastNode.prev;
            lastNode.next = null;
        }else{
        //First break this node from linkedlist chain
        node.prev.next = node.next;
        node.next.prev = node.prev;
        }

        //add to fronnt
        dll firstNode = dummyHead.next;
        dummyHead.next = node;
        node.prev = dummyHead;
        node.next = firstNode;
        firstNode.prev = node;
    }
    int EvictLastNode(){
        int key = lastNode.key;
        dll temp = lastNode.prev;
        temp.next = null;
        lastNode = temp;
        return key;
    }

    dll AddNodeToFront(int key, int val){
        dll node = new dll(key, val, dummyHead, dummyHead.next);
        dummyHead.next.prev = node;
        dummyHead.next = node;
        return node;
    }

    public class dll{//doubly linked list
        public int val;
        public int key;
        public dll prev;
        public dll next;
        public dll(int key, int val, dll prev=null,dll next=null){
            this.val = val;
            this.prev = prev;
            this.next = next;
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */