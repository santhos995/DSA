//#LC100402
public class CountSubstringK {
    public int CountKConstraintSubstrings(string s, int k) {
        int[] ints = new int[2];
        int st = 0, ed;
        int count = 0;
        for (ed = 0; ed < s.Length; ed++)
        {
            int val = s[ed] - '0';
            ints[val]++;
            if (ints[0] <= k || ints[1] <= k)
            {
                int n = ed - st + 1;
                count += n;
                System.Console.WriteLine($"{st}:{ed}:{count}--{ints[0]}:{ints[1]}");
            }
            while (ints[0] > k && ints[1] > k)
            {

                ints[s[st] - '0']--;
                st++;
                if (ints[0] <= k || ints[1] <= k)
                {
                    int n = ed - st + 1;
                    count += n;
                    System.Console.WriteLine($"{st}:{ed}:{count}--{ints[0]}:{ints[1]}");
                }

            }
        }
        return count;
    }
}