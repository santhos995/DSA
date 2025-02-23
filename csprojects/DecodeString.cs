public class Decoder {
    public string DecodeString(string s) {
        Stack<Node> stk = new();
        
        string res = decode(s,0);
        
    }

    string decode(string s, int st){
        int i = st;
        if(s[i]-'0'<10){
            while(s[i]!='['){
                i++;
            }
            int num = Convert.ToInt32(s.Substring(st, i-st+1));

            i++;
            while()
        }
        else{

        }
    }



    public class Node{
        public int times;
        public string val;
    }
}