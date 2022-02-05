public class Solution {
    int[][] st;
    public int MaximumGood(int[][] statements) {
        int n=statements.Length;
        st = statements;
        for (int i = 0; i < n; i++)
        {
            int goodPersons =Math.Max(assume(i,true), assume(i,false));
        }
    }
    private int assume(int idx){
        int n=st.Length;

        int max=int.MinValue;
        for (int i = 0; i < n; i++)
        {
            if(idx==i)
                continue;

            if(st[idx][i]==1)
            {  
                max = Math.Max(max, 1+ assume(i));
            }
        }
    }
}