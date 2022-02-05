public static void Print2DArray<T>(T[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + "\t");
            }
            Console.WriteLine();
        }
    }
     public static T[,] GetNew2DArray<T>(int x, int y, T initialValue)
    {
        T[,] nums = new T[x, y];
        for (int i = 0; i < x * y; i++) nums[i % x, i / x] = initialValue;
        return nums;
    }