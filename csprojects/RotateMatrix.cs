public class RotateMatrix {
    public void Rotate(int[][] matrix) {
        int n = matrix.Length;
        int st = 0, ed = n-1;
        int row = 0, col = n-1;
        while(st < ed) {
            n = ed-st+1;
            //Cache last col
            int[] lastCol = new int[n];
            for(int i = st;i<=ed;i++){
                lastCol[i] = matrix[i][col];
            }
            //copy st row last col
            for(int i = st;i<=ed;i++){
                matrix[i][col] = matrix[row][i];
            }

            int[] lastrow = new int[n];
            //cache last row values
            int j = 0;
            for (int i = ed ; i >= 0 ; i--)
            {
                lastrow[j++] = matrix[ed][i];
            }
            //copy lastCol to lastRow in matrix
            for (int i = ed ; i >= 0 ; i--)
            {
                matrix[ed][i] = lastCol[i];
            }

            int[] firstCol = new int[n];
            //Cache firstCol values
            j=0;
            for (int i = ed ; i >= 0 ; i--)
            {
                firstCol[j++] = matrix[i][st];
            }
            //Copy lastRow data to firstCol matrix
            for (int i = ed ; i >= 0 ; i--)
            {
                matrix[i][st] = lastrow[i];
            }

            //Copy firstCol data to first row
            for (int i = st; i <= ed; i++){
                matrix[st][i] = firstCol[i];
            }

            st++;
            ed--;
            row = st;
            col = ed;
        }
    }
}