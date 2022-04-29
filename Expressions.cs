using System;
namespace Problems
{
    public class Expressions
    {
        public Expressions()
        {
        }

        public string MinimizeResult(string expression)
        {
            int index = expression.IndexOf('+');
            int n = expression.Length;
            int min = int.MaxValue;
            string exp = expression;
            for (int i = 0; i < index; i++)
            {
                for (int j = index+1; j < n; j++)
                {
                    int l = Convert.ToInt32(expression.Substring(i, index - i));
                    int r = Convert.ToInt32(expression.Substring(index+1,  j-index ));

                    int l1 = 1;
                    int r1 = 1;
                    if(i>0)
                    {
                        l1 = Convert.ToInt32(expression.Substring(0, i ));
                    }
                    if (j < n - 1)
                    {
                        r1 = Convert.ToInt32(expression.Substring(j+1, n - j-1));
                    }
                    Console.WriteLine($"i-{i},j-{j},l-{l},r-{r},l1-{l1},r1-{r1}");
                    int val = l1 * (l + r) * r1;
                    if (val < min)
                    {
                        exp = $"({l}+{r})";

                        if (i>0)
                            exp = l1 + exp;
                        if (j < n - 1)
                            exp = exp + r1;
                    }
                }
            }
            return exp;
        }
    }
}
